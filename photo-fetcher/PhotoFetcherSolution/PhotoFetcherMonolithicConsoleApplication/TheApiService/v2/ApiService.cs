using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.Json;
using Dapper;

namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2;

internal class ApiService
{
    internal async Task ExecuteAsync()
    {
        HttpClient httpClient = new HttpClient();
        List<Domain.Models.Photo> photos = new();

        try
        {
            string elapsedTime = "";
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (int id = 1000; id <= 5000; id++)
            {
                using HttpResponseMessage response = await httpClient.GetAsync($"{Configuration.PhotosApi.Url}/{id}");

                var responseCode = (int)response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                string result = "";

                if (response.IsSuccessStatusCode)
                {
                    result = $"SUCCESS!\nHttpCode: {responseCode}\nResponse Body:{responseBody}";

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var photo = JsonSerializer.Deserialize<Domain.Models.Photo>(responseBody, options) ?? new Domain.Models.Photo();

                    photos.Add(photo);

                    Console.WriteLine($"Record:: Id: {photo.Id}, Title: {photo.Title}, Album Id: {photo.AlbumId}, Url: {photo.Url}, Thumbnail Url: {photo.ThumbnailUrl}\n");

                    string sql = "";

                    try
                    {
                        var saveRec = Data.PhotoDbMapper.MapFromPhoto(photo, DateTime.UtcNow, responseBody);

                        using (var dbConn = new SqlConnection(Configuration.ConnectionStrings.LabWorXDb))
                        {
                            dbConn.Open();

                            await dbConn.ExecuteAsync(Data.PhotoDbSqlStatements.Insert, saveRec);

                            dbConn.Close();
                        }

                        Console.WriteLine($"SAVED! PhotoId: {saveRec.PhotoId}, Title: {saveRec.Title}, Url: {saveRec.Url}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to write to the Db.\nException: {ex.Message}\nSQL: {sql}");
                    }
                }
                else
                {
                    result = $"FAILED!\nHttpCode: {responseCode}\nResponse Body:{responseBody}";
                }

                TimeSpan ts = stopWatch.Elapsed;
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                Console.WriteLine(result + $"\nElapsed Time: {elapsedTime}");
                Console.WriteLine("\n====================\n");

                if (id % 20 == 0)
                {
                    await Task.Delay(3000);
                }
            }

            stopWatch.Stop();

            Console.WriteLine($"Total: {photos.Count},  Completed in: {elapsedTime}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unknow Exception: {ex.Message}");
        }
    }
}