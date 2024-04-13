namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Domain.Entities;

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