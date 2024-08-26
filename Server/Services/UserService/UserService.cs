using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
            try
            {
                IEnumerable<User> users = await _userCollection.Find(x => x.isActive == true).ToListAsync();
                return users;
            } catch (Exception ex)
            {
                throw new Exception("Cannot find users.");
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                User user = await _userCollection.Find(c => c.Email == email).FirstOrDefaultAsync();

                return user;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserById(string id)
        {
            try
            {
                User user = await _userCollection.Find(c => c.Id == id).FirstOrDefaultAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Create(User user)
        {
            try
            {
                user.GenerateId();
                await _userCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(User user)
        {
            try
            {
                await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(User user)
        {
            try
            {
                user.isActive = false;
                await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
