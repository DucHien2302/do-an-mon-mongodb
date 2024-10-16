using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebApp.Models;

namespace WebApp.Controllers;

public class JobPostController : Controller
{
    JobPosrREpository jobPosrREpository;

    public JobPostController(IMongoDBConnection connection)
    {
        jobPosrREpository = new JobPosrREpository(connection);
    }
    public IActionResult Index()
    {
        ObjectId userId = ObjectId.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        IEnumerable<JobPostActivity> jobPostActivities = jobPosrREpository.GetJobPostActivitiesByUser(userId);

        IEnumerable<JobPost> jobPosts = jobPosrREpository.GetAllJobPost(jobPostActivities);
        return View(jobPosts);
    }

    public IActionResult Detail(ObjectId id)
    {

        ObjectId userId = ObjectId.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        IEnumerable<JobPostActivity> jobPostActivities = jobPosrREpository.GetJobPostActivitiesByUser(userId);
        IEnumerable<JobPost> jobPosts = jobPosrREpository.GetJobPostsInActivities(jobPostActivities);
        ViewBag.IsApplied = false;
        foreach (var item in jobPosts)
        {
            if (item.Id == id)
            {
                ViewBag.IsApplied = true;
            }
        }

        JobPost jobPost = jobPosrREpository.GetJobPostById(id);
        return View(jobPost);
    }

    public IActionResult Apply(ObjectId id)
    {
        ObjectId userId = ObjectId.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        ObjectId postId = id;
        DateTime applyDate = DateTime.Now;
        bool isAccepted = false;

        JobPostActivity jobPostActivity = new JobPostActivity();
        jobPostActivity.UserAccountId = userId;
        jobPostActivity.JobPostId = postId;
        jobPostActivity.ApplyDate = applyDate;
        jobPostActivity.IsAccepted = isAccepted;

        jobPosrREpository.AddJobPostActivity(jobPostActivity);

        return Redirect("/jobpost/index");
    }

    public IActionResult MyJob()
    {
        ObjectId userId = ObjectId.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        IEnumerable<JobPostActivity> jobPostActivities = jobPosrREpository.GetJobPostActivitiesByUser(userId);
        IEnumerable<JobPost> jobPosts = jobPosrREpository.GetJobPostsInActivities(jobPostActivities);
        return View(jobPosts);
    }
    public IActionResult MyJob()
    {
        ObjectId userId = ObjectId.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        IEnumerable<JobPostActivity> jobPostActivities = jobPosrREpository.GetJobPostActivitiesByUser(userId);
        IEnumerable<JobPost> jobPosts = jobPosrREpository.GetJobPostsInActivities(jobPostActivities);
        ViewBag.JobPostActivity = jobPostActivities;
        return View(jobPosts);
    }

}