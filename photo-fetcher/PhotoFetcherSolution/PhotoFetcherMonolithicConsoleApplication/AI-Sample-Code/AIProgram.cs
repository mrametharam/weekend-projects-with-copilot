using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.Json;
using Dapper;

namespace PhotoFetcherMonolithicConsoleApplication.AI_Sample_Code
{
    internal class AIProgram
    {
        static async Task Main()
        {
            var httpClient = new HttpClient();
            var photos = new List<Photo>();

            try
            {
                var stopwatch = Stopwatch.StartNew();

                for (int id = 1; id <= 5000; id++)
                {
                    var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/photos/{id}");
                    var responseCode = (int)response.StatusCode;
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var photo = JsonSerializer.Deserialize<Photo>(responseBody, options) ?? new Photo();
                        photos.Add(photo);

                        // Save to database
                        // await SavePhotoToDb(photo, responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"FAILED! HttpCode: {responseCode}\nResponse Body: {responseBody}");
                    }

                    Console.WriteLine($"Elapsed Time: {stopwatch.Elapsed}");
                    Console.WriteLine("====================");

                    if (id % 20 == 0)
                    {
                        await Task.Delay(3000);
                    }
                }

                Console.WriteLine($"Total: {photos.Count}, Completed in: {stopwatch.Elapsed}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
            }
        }

        static async Task SavePhotoToDb(PhotoDb photo, string payload)
        {
            try
            {
                if (photo == null)
                {
                    throw new ArgumentNullException(nameof(photo));
                }

                var connectionString = "YourConnectionStringHere"; // Load from config
                using var dbConn = new SqlConnection(connectionString);
                await dbConn.OpenAsync();

                var photoRepository = new PhotoRepository(dbConn);
                await photoRepository.SaveAsync(photo, payload);

                Console.WriteLine($"SAVED! PhotoId: {photo.PhotoId}, Title: {photo.Title}, Url: {photo.Url}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Failed to write to the Db.\nException: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown Exception: {ex.Message}");
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

    public class PhotoRepository
    {
        private readonly SqlConnection _dbConnection;

        public PhotoRepository(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task SaveAsync(PhotoDb photo, string payload)
        {
            var sql = PhotoSqlStatements.InsertPhoto;
            await _dbConnection.ExecuteAsync(sql, new
            {
                photo.PhotoId,
                photo.AlbumId,
                photo.Title,
                photo.Url,
                photo.ThumbnailUrl,
                DownloadedUTC = DateTime.UtcNow,
                PayLoad = payload
            });
        }
    }

    public static class PhotoSqlStatements
    {
        public const string InsertPhoto = @"
        INSERT INTO [photo-fetcher].[Photos] 
        ([PhotoId], [AlbumId], [Title], [URL], [ThumbnailURL], [DownloadedUTC], [PayLoad])
        VALUES (@PhotoId, @AlbumId, @Title, @URL, @ThumbnailURL, @DownloadedUTC, @PayLoad)";
    }
}