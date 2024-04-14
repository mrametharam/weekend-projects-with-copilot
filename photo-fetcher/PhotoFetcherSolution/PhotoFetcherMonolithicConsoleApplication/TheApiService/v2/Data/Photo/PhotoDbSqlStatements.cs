namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Data.Photo;

internal class PhotoDbSqlStatements
{
    internal static string Insert =>
        """
        Insert into [photo-fetcher].[Photos] 
            ([PhotoId], [AlbumId], [Title], [URL], [ThumbnailURL], [DownloadedUTC], [PayLoad])
            values
            (@PhotoId, @AlbumId, @Title, @URL, @ThumbnailURL, @DownloadedUTC, @PayLoad)
        """;
}
