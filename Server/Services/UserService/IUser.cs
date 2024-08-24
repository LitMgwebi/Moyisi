using Server.Models;

namespace Server.Services.UserService
{
    public interface IUser
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserById(string id);
        public Task<string> Create(User user, string password);
    }
}
