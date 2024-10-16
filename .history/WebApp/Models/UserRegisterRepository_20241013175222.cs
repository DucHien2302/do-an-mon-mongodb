namespace WebApp.Models;
using MongoDB.Bson;

public class UserRegisterRepository
{
    IMongoDBConnection connection;
    public UserRegisterRepository(IMongoDBConnection mongoDBConnection)
    {
        this.connection = mongoDBConnection;
    }
    public void Register(UserRegister obj)
    {
        var user = new UserRegister
        {
            Id = ObjectId.GenerateNewId(),
            Email = obj.Email,
            Password = obj.Password,
            ContactNumber = obj.ContactNumber,
            UserTypeId = obj.UserTypeId
        };
        try
        {
            var collection = connection.GetCollection<UserRegister>("user_account");
            collection.InsertOne(user);
            return;
        }
        catch (Exception e)
        {
            e.StackTrace;
        }
    }
}