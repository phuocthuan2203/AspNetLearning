namespace _01_FirstAPSNETApp;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<string> _users = [];
    
    public void Add(string user)
    {
        _users.Add(user);
    }

    public IEnumerable<string> Users => _users;
}