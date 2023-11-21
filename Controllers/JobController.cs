using ApiJobs.Models;
using ApiJobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiJobs.Controllers;



[Route("/api/[controller]")]
public class JobController :  ControllerBase
{

    IJobService jobService;

    public JobController(IJobService service)
    {
        jobService = service;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(jobService.Get());
    }


    [HttpPost]
    public IActionResult Post([FromBody] Job job)
    {
        jobService.Save(job);
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Job job)
    {
        jobService.Update(id, job);
        return Ok();
    }



    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        jobService.Delete(id);
        return Ok();
    }




}