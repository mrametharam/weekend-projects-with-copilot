using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.Json;
using Dapper;

namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v1;

internal class ApiService
{
    internal async Task ExecuteAsync()
    {
        HttpClient httpClient = new HttpClient();
        List<Photo> photos = new List<Photo>();

        try
        {
            string elapsedTime = "";
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (int id = 1; id <= 5000; id++)
            {
                using HttpResponseMessage response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/photos/{id}");

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

                    var photo = JsonSerializer.Deserialize<Photo>(responseBody, options) ?? new Photo();

                    photos.Add(photo);

                    Console.WriteLine($"Record:: Id: {photo.Id}, Title: {photo.Title}, Album Id: {photo.AlbumId}, Url: {photo.Url}, Thumbnail Url: {photo.ThumbnailUrl}\n");

                    string sql = "";

                    try
                    {
                        var saveRec = new PhotoDb
                        {
                            PhotoId = photo.Id,
                            AlbumId = photo.AlbumId,
                            Title = photo.Title,
                            Url = photo.Url,
                            ThumbnailUrl = photo.ThumbnailUrl,
                            DownloadedUTC = DateTime.UtcNow,
                            PayLoad = responseBody
                        };

                        string connectionString = "Data Source=127.0.0.1;Initial Catalog=LabWorX;User ID=sa;Password=@dm1n123#;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                        connectionString = "Data Source=127.0.0.1;Initial Catalog=LabWorX;User ID=sa;Password=@dm1n123#;Connect Timeout=60;Encrypt=False";

                        using (var dbConn = new SqlConnection(connectionString))
                        {
                            dbConn.Open();

                            sql = """
                    Insert into [photo-fetcher].[Photos] 
                        ([PhotoId], [AlbumId], [Title], [URL], [ThumbnailURL], [DownloadedUTC], [PayLoad])
                        values
                        (@PhotoId, @AlbumId, @Title, @URL, @ThumbnailURL, @DownloadedUTC, @PayLoad)
                    """;

                            await dbConn.ExecuteAsync(sql, saveRec);

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

public class Photo
{
    public int Id { get; set; }
    public int AlbumId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
}

public class PhotoDb
{
    public Guid Id { get; set; }
    public int PhotoId { get; set; }
    public int AlbumId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public DateTime DownloadedUTC { get; set; }
    public string PayLoad { get; set; } = string.Empty;
}