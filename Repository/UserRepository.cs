using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Entities;
using UserManagement.Repository.Interfaces;

namespace UserManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<User> CreateUser(User user)
        {
             _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var result = await _context.User.Where(user => user.Email == id).FirstOrDefaultAsync();

            _context.User.Remove(result); 
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUser(string id)
        {
            return await _context.User.Where(user => user.Email == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {

            var result = await _context.User.ToListAsync();                

            return result;
        }

        public async Task<User> UpdateUser(User user)
        {
            var updateResult = _context
                                       .User
                                       .Where(u => u.Email == user.Email)
                                       .First();

            updateResult.Email = user.Email;
            updateResult.FirstName  = user.FirstName;
            updateResult.LastName = user.LastName;         
            
            _context.Update(updateResult);

            await _context.SaveChangesAsync();

            return updateResult;
        }
    }
}
