namespace WebApp.Models;
using MongoDB.Bson;

public class UserRegisterRepository
{
    IMongoDBConnection connection;
    public UserRegisterRepository(IMongoDBConnection mongoDBConnection)
    {
        this.connection = mongoDBConnection;
    }
    public Task Register(UserRegister obj)
    {
        var user = new UserRegister
        {
            Id = ObjectId.GenerateNewId(),
            Email = obj.Email,
            Password = obj.Password,

        };
    }
}