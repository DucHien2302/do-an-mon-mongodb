using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class SeekerProfile
{
    [BsonElement("first_name")]
    public string FirstName { get; set; }

    [BsonElement("last_name")]
    public string LastName { get; set; }

    [BsonElement("current_salary")]
    public decimal CurrentSalary { get; set; }

    [BsonElement("currency")]
    public string Currency { get; set; }

    [BsonElement("is_annually_monthly")]
    public int IsAnnuallyMonthly { get; set; }

    [BsonElement("email_contact")]
    public string EmailContact { get; set; }

    [BsonElement("file_cv")]
    public string FileCv { get; set; }
}