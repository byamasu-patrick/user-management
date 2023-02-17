using UserManagement.Entities;

namespace UserManagement.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
        Task<User> CreateUser(User product);
        Task<User> UpdateUser(User product);
        Task<bool> DeleteUser(string id);
    }
}
