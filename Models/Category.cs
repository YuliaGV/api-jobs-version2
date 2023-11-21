
using System.Text.Json.Serialization;

namespace ApiJobs.Models;

public class Category
{


    //[Key]
    public Guid CategoryId { get; set;}
    //[Required]
   // [MaxLength(150)]
    public string Name { get; set;}
    public string Description { get; set;}

    [JsonIgnore]
    public virtual ICollection<Job> Jobs { get; set;}



}

