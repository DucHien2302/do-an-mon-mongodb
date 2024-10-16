using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApp.Models;

public class JobPosrREpository
{
    IMongoDBConnection connection;
    public JobPosrREpository(IMongoDBConnection connection)
    {
        this.connection = connection;
    }
    public IEnumerable<JobPost> GetAllJobPost(IEnumerable<JobPostActivity> jobPostActivities)
    {
        // Lấy danh sách các job_post_id từ JobPostActivity
        var jobPostActivityIds = jobPostActivities.Select(a => a.JobPostId).ToList();

        // Lấy tất cả các JobPost mà _id không nằm trong danh sách job_post_id
        var collection = connection.GetCollection<JobPost>("job_post");

        // Truy vấn MongoDB với điều kiện _id không nằm trong jobPostActivityIds
        var filter = Builders<JobPost>.Filter.Nin(job => job.Id, jobPostActivityIds);
        var listJobPost = collection.Find(filter).ToList();

        return listJobPost;
    }

    public JobPost GetJobPostById(ObjectId id)
    {
        var collection = connection.GetCollection<JobPost>("job_post");
        var jobPost = collection.Find(p => p.Id == id).FirstOrDefault();
        return jobPost;
    }

    public bool AddJobPostActivity(JobPostActivity jobPostActivity)
    {
        try
        {
            var collection = connection.GetCollection<JobPostActivity>("job_post_activity");
            collection.InsertOne(jobPostActivity);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<JobPostActivity> GetJobPostActivitiesByUser(ObjectId userId)
    {
        var collection = connection.GetCollection<JobPostActivity>("job_post_activity");
        return collection.Find(activity => activity.UserAccountId == userId).ToList();
    }

    public IEnumerable<JobPost> GetJobPostsInActivities(IEnumerable<JobPostActivity> jobPostActivities)
    {
        // Lấy danh sách các job_post_id từ JobPostActivity
        var jobPostActivityIds = jobPostActivities.Select(a => a.JobPostId).ToList();

        // Lấy collection từ MongoDB
        var collection = connection.GetCollection<JobPost>("job_post");

        // Sử dụng $in để tìm các JobPost mà Id nằm trong danh sách job_post_id
        var filter = Builders<JobPost>.Filter.In(job => job.Id, jobPostActivityIds);
        var jobPostsInActivities = collection.Find(filter).ToList();

        return jobPostsInActivities;
    }
}