namespace _01_FirstAPSNETApp;

public class MyRepository : IRepository
{
    private readonly ILogger<MyRepository> _logger;
    
    public MyRepository(ILogger<MyRepository> logger)
    {
        _logger = logger;
        
        logger.LogInformation("NEW MyRepository");
    }
    
    public string GetById(string id)
    {
        return "ID: " + id;
    }
}