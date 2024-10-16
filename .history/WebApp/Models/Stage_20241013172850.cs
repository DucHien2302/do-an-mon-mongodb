using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models;

public class Stage
{
    [BsonElement("stage_name")]
    public string StageName { get; set; }

    [BsonElement("stage_status")]
    public string StageStatus { get; set; }

    [BsonElement("date_started")]
    public DateTime DateStarted { get; set; }

    [BsonElement("date_completed")]
    public DateTime? DateCompleted { get; set; }

    [BsonElement("feedback")]
    public string Feedback { get; set; }
}