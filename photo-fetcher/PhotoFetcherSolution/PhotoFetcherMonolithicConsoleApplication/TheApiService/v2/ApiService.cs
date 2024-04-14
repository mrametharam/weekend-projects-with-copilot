using PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Data.Photo;
using PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Core;
using System.Diagnostics;
using System.Text.Json;

namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2;

internal class ApiService
{
    HttpClient _httpClient = new HttpClient();
    List<Domain.Models.Photo> _photos = new();

    internal async Task ExecuteAsync()
    {
        // TODO: Update the exception handlers to be more specific.
        // TODO: Build a logger class that performs the console.Writeline and the stopwatch tasks.
        // TODO: Look at how the chain of responsibility pattern can be used to perform the API call, validation of the data, then the Saving to the DB.

        string elapsedTime = "";
        var stopWatch = new Stopwatch();

        stopWatch.Start();

        for (int id = 2500; id <= 2520; id++)
        {
            await FetchData(id);

            if (id % 20 == 0)
            {
                await Task.Delay(3000);
            }
        }

        foreach (var photo in _photos)
        {
            var saveRec = PhotoDbMapper.MapFromPhoto(photo, DateTime.UtcNow, "");

            var photoRepo = new PhotosRepository();
            await photoRepo.Insert(saveRec);

            Console.WriteLine($"Saved photo: {saveRec.PhotoId} / {_photos.Count}");
        }

        TimeSpan ts = stopWatch.Elapsed;
        elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

        Console.WriteLine($"Elapsed Time: {elapsedTime}");
        Console.WriteLine("\n====================\n");

        stopWatch.Stop();

        Console.WriteLine($"Total: {_photos.Count},  Completed in: {elapsedTime}");
    }

    private async Task FetchData(int id)
    {
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"{Configuration.PhotosApi.Url}/{id}");

            var responseCode = (int)response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{responseCode}: {responseBody}");   // TODO: Move this into a logging class.

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var photo = JsonSerializer.Deserialize<Domain.Models.Photo>(responseBody, options) ?? new Domain.Models.Photo();

                _photos.Add(photo);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unknow Exception: {ex.Message}");
        }
    }
}