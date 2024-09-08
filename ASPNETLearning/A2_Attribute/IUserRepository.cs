namespace _02_Attribute;

public interface IUserRepository
{
    void Add(string user);
    IEnumerable<string> Users { get; }
}