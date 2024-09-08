namespace _01_FirstAPSNETApp;

public interface IUserRepository
{
    void Add(string user);
    IEnumerable<string> Users { get; }
}