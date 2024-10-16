using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApp.Models;


public class EducationDetailRepository
{
    IMongoDBConnection connection;
    public EducationDetailRepository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }
    public async Task Add(ObjectId id, EducationDetail educationDetail)
    {
        // Find the user by their ID
        var filter = Builders<UserAccount>.Filter.Eq(u => u.Id, id);

        // Add the new EducationDetail to the existing user's list of EducationDetails
        var update = Builders<UserAccount>.Update.Push(u => u.EducationDetails, educationDetail);

        // Update the user document in the collection
        var collection = connection.GetCollection<UserAccount>("user_account");
        var result = await collection.UpdateOneAsync(filter, update);

        if (result.ModifiedCount == 0)
        {
            // Handle the case where no documents were updated
            throw new Exception("User not found or update failed.");
        }
    }
    public async Task XoaExperienceTheoJobTitleAsync(string jobTitle)
    {
        var filter = Builders<ExperienceDetail>.Filter.Eq("job_title", jobTitle);
        var result = await _experienceCollection.DeleteOneAsync(filter);
    }
}