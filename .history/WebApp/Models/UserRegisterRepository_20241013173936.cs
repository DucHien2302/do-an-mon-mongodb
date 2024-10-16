namespace WebApp.Models;
using MongoDB.Bson;

public class UserRegisterRepository
{
    IMongoDBConnection connection;
    public UserRegisterRepository(IMongoDBConnection mongoDBConnection)
    {
        this.connection = mongoDBConnection;
    }
    public int Register(UserRegister obj)
    {
        var collection = connection.GetCollection<UserRegister>("user_account");
    }
}