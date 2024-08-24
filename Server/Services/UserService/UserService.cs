using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Server.Models;

namespace Server.Services.UserService
{
    public class UserService: IUser
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<MongoDBSettings> userServiceOptions)
        {
            MongoClient client = new MongoClient(userServiceOptions.Value.ConnectionUri);
            IMongoDatabase database = client.GetDatabase(userServiceOptions.Value.DatabaseName);
            _userCollection = database.GetCollection<User>("User");
        }

        public async Task<IEnumerable<User>> GetAll()
        {

        }

        public async Task<User> GetUserByEmail(string email)
        {

        }

        public async Task<User> GetUserById(string id)
        {

        }

        public async Task<string> Create(User user, string password)
        {

        }
    }
}
