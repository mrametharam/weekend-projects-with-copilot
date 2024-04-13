namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2;

public class Configuration
{
    public class ConnectionStrings
    {
        public static string LabWorXDb
            => "Data Source=127.0.0.1;Initial Catalog=LabWorX;User ID=sa;Password=@dm1n123#;Connect Timeout=60;Encrypt=False";
    }

    public class PhotosApi
    {
        public static string BaseUrl
            => "https://jsonplaceholder.typicode.com";

        public static string Url
            => $"{BaseUrl}/photos";
    }
}
