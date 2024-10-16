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
        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<UserAccount>("user_account");

        // Tạo bộ lọc để khớp với email và mật khẩu
        var filter = Builders<UserAccount>.Filter.Eq(x => x.Email, email);

        // Truy vấn để lấy người dùng phù hợp
        var userAccount = collection.Find(filter).FirstOrDefault();

        // Nếu tìm thấy người dùng, trả về thông tin người dùng
        return userAccount;
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
            DateOfBirth = new DateTime(), // DateTime? or default if nullable
            Gender = false, // Default false as it's a boolean
            IsActive = false, // Default false for activation
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

}