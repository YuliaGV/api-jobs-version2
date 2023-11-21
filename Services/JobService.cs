using ApiJobs.Models;
namespace ApiJobs.Services;

public class JobService : IJobService
{

    JobsContext context;

    public JobService(JobsContext dbcontext)
    {
           context = dbcontext;
    }


    public IEnumerable<Job> Get()
    {
        return context.Jobs;
    }


    public async Task Save(Job job)
    {
        context.Add(job);
        await context.SaveChangesAsync();
    }


    public async Task Update(Guid id, Job job)
    {
        var currentJob= context.Jobs.Find(id);

        if(currentJob != null){
            currentJob.CategoryId = job.CategoryId;
            currentJob.Title = job.Title;
            currentJob.Location = job.Location;
            currentJob.JobType = job.JobType;
            currentJob.Description = job.Description;
            currentJob.IsActive = job.IsActive;
            await context.SaveChangesAsync();
        }

    }


    public async Task Delete(Guid id)
    {
        var currentJob = context.Jobs.Find(id);

        if(currentJob != null){
            context.Jobs.Remove(currentJob);
            await context.SaveChangesAsync();
        }

    }


}


public interface IJobService
{

    IEnumerable<Job> Get();
    Task Save(Job job);
    Task Update(Guid id, Job job);
    Task Delete(Guid id);

}