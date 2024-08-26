using Server.Models;

namespace Server.Services.UserService
{
    public interface IUser
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserById(string id);
        public Task Create(User user);
        public Task Edit(User user);
        public Task Delete(User user);
    }
}
