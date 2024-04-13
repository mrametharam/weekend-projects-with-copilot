using System.Data.SqlClient;

namespace PhotoFetcherMonolithicConsoleApplication.SampleRepository;

// IRepository.cs
public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

// ConcreteRepository.cs
public class ConcreteRepository<T> : IRepository<T> where T : class, new()
{
    private readonly string _connectionString;

    public ConcreteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public T GetById(int id)
    {
        // Implementation for fetching an entity by ID using ADO.NET
        // This is a simplified example and assumes the existence of a method to map data reader to entity
        T entity = new T();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM TableName WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    entity = MapReaderToEntity(reader);
                }
            }
        }
        return entity;
    }

    public IEnumerable<T> GetAll()
    {
        // Implementation for fetching all entities using ADO.NET
        var entities = new List<T>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM TableName", connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    entities.Add(MapReaderToEntity(reader));
                }
            }
        }
        return entities;
    }

    public void Add(T entity)
    {
        // Implementation for adding a new entity using ADO.NET
    }

    public void Update(T entity)
    {
        // Implementation for updating an existing entity using ADO.NET
    }

    public void Delete(T entity)
    {
        // Implementation for deleting an entity using ADO.NET
    }

    private T MapReaderToEntity(SqlDataReader reader)
    {
        // Implementation for mapping a data reader to an entity
        // This method should be implemented to map the columns of the data reader to the properties of the entity
        throw new NotImplementedException();
    }
}