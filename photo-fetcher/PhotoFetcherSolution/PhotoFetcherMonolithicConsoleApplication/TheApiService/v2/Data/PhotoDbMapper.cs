namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Data;

internal class PhotoDbMapper
{
    internal static Domain.Entities.PhotoDb MapFromPhoto(Domain.Models.Photo photo, DateTime downloadedUtc, string payload)
    {
        Domain.Entities.PhotoDb retVal = new Domain.Entities.PhotoDb
        {
            AlbumId = photo.AlbumId,
            DownloadedUTC = downloadedUtc,
            PayLoad = payload,
            PhotoId = photo.Id,
            ThumbnailUrl = photo.ThumbnailUrl,
            Title = photo.Title,
            Url = photo.Url
        };

        return retVal;
    }
}
