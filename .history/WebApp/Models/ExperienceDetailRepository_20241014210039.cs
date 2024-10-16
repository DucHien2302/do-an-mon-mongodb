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
    public async Task AddExperienceDetail(ObjectId userId, ExperienceDetail experienceDetail)
    {
        // Tìm người dùng theo ID của họ
        var filter = Builders<UserAccount>.Filter.Eq(u => u.Id, userId);

        // Sử dụng thao tác Push để thêm ExperienceDetail mới vào danh sách ExperienceDetails của người dùng
        var update = Builders<UserAccount>.Update.Push(u => u.ExperienceDetails, experienceDetail);

        var collection = connection.GetCollection<UserAccount>("user_account");
        // Cập nhật tài liệu người dùng trong bộ sưu tập
        var result = await _usersCollection.UpdateOneAsync(filter, update);

        if (result.ModifiedCount == 0)
        {
            // Xử lý trường hợp không tìm thấy tài liệu hoặc cập nhật thất bại
            throw new Exception("Không tìm thấy người dùng hoặc cập nhật thất bại.");
        }
    }
}