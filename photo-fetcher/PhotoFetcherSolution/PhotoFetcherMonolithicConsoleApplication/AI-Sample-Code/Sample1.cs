using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PhotoFetcherMonolithicConsoleApplication.AI_Sample_Code;

// Model with Data Annotations for validation
public class DataModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Range(0, 100)]
    public int Value { get; set; }
}

// IRepository interface
public interface IRepository<T> where T : class
{
    void Save(T entity);
    // Other repository methods...
}

// ConcreteRepository implementation
public class ConcreteRepository : IRepository<DataModel>
{
    // Assuming _context is an instance of your DbContext or similar data access context
    //private readonly DbContext _context;

    //public ConcreteRepository(DbContext context)
    //{
    //    _context = context;
    //}

    public void Save(DataModel entity)
    {
        // Add validation logic here if needed
        //_context.Add(entity);
        //_context.SaveChanges();
    }

    // Other repository methods...
}

// Service to make the API call and process data
public class ApiService
{
    private readonly IRepository<DataModel> _repository;
    private readonly HttpClient _httpClient;

    public ApiService(IRepository<DataModel> repository, HttpClient httpClient)
    {
        _repository = repository;
        _httpClient = httpClient;
    }

    public async Task GetDataAndSaveAsync(string requestUri)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            DataModel data = JsonConvert.DeserializeObject<DataModel>(json)!;

            // Perform validation
            var results = new List<ValidationResult>();
            var context = new ValidationContext(data);
            if (!Validator.TryValidateObject(data, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return;
            }

            // Save to repository if validation passes
            _repository.Save(data);
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }
}