using MongoDB.Bson;

namespace WebApp.Models;


public class EducationDetailRepository
{
    IMongoDBConnection connection;
    public EducationDetailRepository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }
    public async Task AddEducationDetail(ObjectId id, EducationDetail educationDetail)
    {
        // Find the user by their ID
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);

        // Add the new EducationDetail to the existing user's list of EducationDetails
        var update = Builders<User>.Update.Push(u => u.EducationDetails, educationDetail);

        // Update the user document in the collection
        var result = await _usersCollection.UpdateOneAsync(filter, update);

        if (result.ModifiedCount == 0)
        {
            // Handle the case where no documents were updated
            throw new Exception("User not found or update failed.");
        }
    }