namespace ApiJobs.Models ;


public class Job 
{
    //[Key]
    public Guid JobId { get; set; }
  
    //[ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    //[Required]
    //[MaxLength(200)]
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime PostingDate { get; set; }
    public JobTypeList JobType { get; set; }
    public string Description { get; set; }

    public virtual Category Category { get; set; }

    public bool IsActive { get; set; }

    //[NotMapped]
    public string Summary { get; set; }


}



public enum JobTypeList
{
    FullTime,
    PartTime,
    Contract,
    Freelance,
    Internship,
    Temporary
}