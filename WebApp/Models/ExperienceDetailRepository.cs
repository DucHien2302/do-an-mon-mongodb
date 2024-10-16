using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApp.Models;

public class ExperienceDetailRepository
{
    IMongoDBConnection connection;
    public ExperienceDetailRepository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }
    public async Task Add(ObjectId userId, ExperienceDetail experienceDetail)
    {
        var filter = Builders<UserAccount>.Filter.Eq(u => u.Id, userId);
        var update = Builders<UserAccount>.Update.Push(u => u.ExperienceDetails, experienceDetail);

        var collection = connection.GetCollection<UserAccount>("user_account");
        var result = await collection.UpdateOneAsync(filter, update);

        if (result.ModifiedCount == 0)
        {
            throw new Exception("Không tìm thấy người dùng hoặc cập nhật thất bại.");
        }
    }
}