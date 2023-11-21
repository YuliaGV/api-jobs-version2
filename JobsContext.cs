using ApiJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJobs;

public class JobsContext: DbContext
{
    public DbSet<Category> Categories {get;set;}
    public DbSet<Job> Jobs {get;set;}

    public JobsContext(DbContextOptions<JobsContext> options) : base(options){ }

    protected override void  OnModelCreating(ModelBuilder modelBuilder)
    {


        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(
            new Category(){
                CategoryId = Guid.Parse("434bb0cc-afba-40f3-a872-980b562d7280"),
                Name = "Healthcare",
                Description = "From nursing and medical practitioners to administrative roles, discover diverse positions that contribute to the well-being of individuals and communities"
            }
        );
        categoriesInit.Add(
            new Category(){
                CategoryId = Guid.Parse("434bb0cc-afba-40f3-a872-980b562d7279"),
                Name = "Education",
                Description = "From teaching roles to administrative positions, find your place in shaping the future. Explore diverse jobs that contribute to educational excellence and student success"
            }
        );


        modelBuilder.Entity<Category>(categ =>
        {
            categ.ToTable("Category");
            categ.HasKey(p => p.CategoryId);
            categ.Property(p => p.Name).IsRequired().HasMaxLength(150);
            categ.Property(p => p.Description).IsRequired(false);

            categ.HasData(categoriesInit);
    
        });


         List<Job> jobsInit = new List<Job>();
         jobsInit.Add(
            new Job(){
                JobId = Guid.Parse("434bb0cc-afba-40f3-a872-980b562d7290"),
                Title = "Registered Nurse",
                CategoryId = Guid.Parse("434bb0cc-afba-40f3-a872-980b562d7280"),
                Location = "Miami, FL",
                PostingDate = DateTime.Now,
                JobType = JobTypeList.FullTime,
                Description = "Nurse for the intensive care area in a large hospital in Miami. At least 3 years of experience"

                
            }
        );
        jobsInit.Add(
            new Job(){
                JobId = Guid.Parse("434bb0cc-afba-40f3-a872-980b562d7291"),
                Title = "Math Teacher",
                CategoryId = Guid.Parse("434bb0cc-afba-40f3-a872-980b562d7279"),
                Location = "Orlando, FL",
                PostingDate = DateTime.Now,
                JobType = JobTypeList.FullTime,
                Description = "Math Teacher for High School. At least 2 years of experience"

                
            }
        );


        modelBuilder.Entity<Job>(job =>
        {
            job.ToTable("Job");
            job.HasKey(p => p.JobId);   
            job.HasOne(p => p.Category).WithMany(p => p.Jobs).HasForeignKey(p => p.CategoryId);

            job.Property(p => p.Title).IsRequired().HasMaxLength(200);
            job.Property(p => p.Location);
            job.Property(p => p.PostingDate).HasDefaultValue(DateTime.Now);
            job.Property(p => p.JobType);
            job.Property(p => p.Description);
            job.Property(p => p.IsActive).HasDefaultValue(true);

            job.Ignore(p=>p.Summary);

            job.HasData(jobsInit);

        });


    }
    
}