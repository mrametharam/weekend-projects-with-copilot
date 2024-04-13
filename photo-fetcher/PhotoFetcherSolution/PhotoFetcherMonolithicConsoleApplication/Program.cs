using System.Text.Json;
using System.Text.Json.Serialization;

HttpClient httpClient = new HttpClient();

try
{
    for (int id = 0; id < 10; id++)
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

            var photo = JsonSerializer.Deserialize<Photo>(responseBody, options) ;

            Console.WriteLine($"Record:: Id: {photo.Id}, Title: {photo.Title}, Album Id: {photo.AlbumId}, Url: {photo.Url}, Thumbnail Url: {photo.ThumbnailUrl}\n");
        }
        else
        {
            result = $"FAILED!\nHttpCode: {responseCode}\nResponse Body:{responseBody}";
        }

        Console.WriteLine(result);
        Console.WriteLine("\n====================\n");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Unknow Exception: {ex.Message}");
}

public class Photo
{
    public int Id { get; set; }
    public int AlbumId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
}