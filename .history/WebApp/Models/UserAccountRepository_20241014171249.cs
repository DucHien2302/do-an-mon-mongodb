using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApp.Models;

public class UserAccountRepository
{
    IMongoDBConnection connection;
    public UserAccountRepository(IMongoDBConnection connection) => this.connection = connection;
    public UserAccount GetUserAccount(UserLogin obj)
    {
        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<UserAccount>("user_account");

        // Tạo bộ lọc để khớp với email và mật khẩu
        var filter = Builders<UserAccount>.Filter.Eq(x => x.Email, obj.Email) &
                     Builders<UserAccount>.Filter.Eq(x => x.Password, Helper.HashPassword(obj.Password));

        // Truy vấn để lấy người dùng phù hợp
        var userAccount = collection.Find(filter).FirstOrDefault();

        // Nếu tìm thấy người dùng, trả về thông tin người dùng
        return userAccount;
    }
    public UserAccount GetUserAccount(string email)
    {
        var collection = connection.GetCollection<UserAccount>("user_account");
        var filter = Builders<UserAccount>.Filter.Eq(x => x.Email, email);
        var userAccount = collection.Find(filter).FirstOrDefault();
        return userAccount;
    }
    public async Task<UserAccount> GetUserAccount(ObjectId id)
    {
        var collection = connection.GetCollection<UserAccount>("user_account");
        var filter = Builders<UserAccount>.Filter.Eq(u => u.Id, id);
        var user = await collection.Find(filter).FirstOrDefaultAsync();
        return user;
    }

    public void Register(UserRegister obj)
    {
        var user = new UserAccount // Change to UserAccount to include new fields
        {
            Id = ObjectId.GenerateNewId(),
            Email = obj.Email,
            Password = Helper.HashPassword(obj.Password),
            ContactNumber = obj.ContactNumber,
            UserTypeId = obj.UserTypeId,

            // Newly added fields with null values
            DateOfBirth = DateTime.Now, // DateTime? or default if nullable
            Gender = true, // Default false as it's a boolean
            IsActive = true, // Default false for activation
            UserImage = null, // Assuming it's a string, set to null
            RegistrationDate = DateTime.Now, // Set current date as the registration date
            SeekerProfile = null, // Assuming it's an object, set to null
            EducationDetails = null, // List can be set to null or new List<EducationDetail>()
            ExperienceDetails = null // List can be set to null or new List<ExperienceDetail>()
        };

        try
        {
            var collection = connection.GetCollection<UserAccount>("user_account"); // Updated to UserAccount
            collection.InsertOne(user);
            return;
        }
        catch (Exception ex) // Optionally catch and log the exception
        {
            // Log or handle error
        }
    }
    public async Task<bool> UpdateUserAccountAsync(ObjectId id, UserAccount updatedUserAccount)
    {
        // Lấy bản ghi hiện có trong cơ sở dữ liệu
        var collection = connection.GetCollection<UserAccount>("user_account");
        var existingUserAccount = await collection.Find(u => u.Id == id).FirstOrDefaultAsync();

        if (existingUserAccount == null)
        {
            // Không tìm thấy người dùng
            return false;
        }

        // Chỉ cập nhật các trường có trong form
        var update = Builders<UserAccount>.Update
            .Set(u => u.Email, string.IsNullOrEmpty(updatedUserAccount.Email) ? existingUserAccount.Email : updatedUserAccount.Email)
            .Set(u => u.Password, string.IsNullOrEmpty(updatedUserAccount.Password) ? existingUserAccount.Password : Helper.HashPassword(updatedUserAccount.Password))
            .Set(u => u.ContactNumber, string.IsNullOrEmpty(updatedUserAccount.ContactNumber) ? existingUserAccount.ContactNumber : updatedUserAccount.ContactNumber)
            .Set(u => u.UserImage, string.IsNullOrEmpty(updatedUserAccount.UserImage) ? existingUserAccount.UserImage : updatedUserAccount.UserImage)
            .Set(u => u.DateOfBirth, updatedUserAccount.DateOfBirth != default(DateTime) ? updatedUserAccount.DateOfBirth : existingUserAccount.DateOfBirth)
            .Set(u => u.Gender, updatedUserAccount.Gender)
            .Set(u => u.IsActive, updatedUserAccount.IsActive)
            .Set(u => u.SeekerProfile, updatedUserAccount.SeekerProfile ?? existingUserAccount.SeekerProfile)
            .Set(u => u.EducationDetails, updatedUserAccount.EducationDetails ?? existingUserAccount.EducationDetails)
            .Set(u => u.ExperienceDetails, updatedUserAccount.ExperienceDetails ?? existingUserAccount.ExperienceDetails);

        // Thực hiện cập nhật trong MongoDB
        var result = await collection.UpdateOneAsync(
            Builders<UserAccount>.Filter.Eq(u => u.Id, id),
            update
        );

        return result.ModifiedCount > 0;
    }

}