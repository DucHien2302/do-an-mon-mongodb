namespace WebApp.Models;
using MongoDB.Bson;

public class UserRegisterRepository
{
    IMongoDBConnection connection;
    public UserRegisterRepository(IMongoDBConnection mongoDBConnection)
    {

    }
}