namespace DataManagementAPI.Interfaces.IRepos;

public interface IUserRepo
{
    List<User> GetAllUsers();
    User? GetUserById(int userId);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
