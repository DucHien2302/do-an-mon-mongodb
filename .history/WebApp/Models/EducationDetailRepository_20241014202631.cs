using MongoDB.Bson;

namespace WebApp.Models;


public class EducationDetailRepository
{
    IMongoDBConnection connection;
    public EducationDetailRepository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }
    public void Add(ObjectId id, EducationDetail obj)
    {

    }
}