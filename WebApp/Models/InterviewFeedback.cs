using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class InterviewFeedback
{
    [BsonElement("interviewer_name")]
    public string InterviewerName { get; set; }

    [BsonElement("comments")]
    public string Comments { get; set; }

    [BsonElement("rating")]
    public int Rating { get; set; }
}