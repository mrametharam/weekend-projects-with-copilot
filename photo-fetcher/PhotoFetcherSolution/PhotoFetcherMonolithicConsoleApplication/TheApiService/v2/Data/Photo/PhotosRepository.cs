using PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Core;
using System.Data.SqlClient;
using Dapper;

namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Data.Photo;

internal class PhotosRepository
{
    internal async Task Insert(Domain.Entities.PhotoDb saveRecord)
    {
        using (var dbConn = new SqlConnection(Configuration.ConnectionStrings.LabWorXDb))
        {
            dbConn.Open();

            await dbConn.ExecuteAsync(PhotoDbSqlStatements.Insert, saveRecord);

            dbConn.Close();
        }
    }
}

