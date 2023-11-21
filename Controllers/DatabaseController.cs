using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly IDatabaseService dbService;
        private readonly JobsContext dbContext;

        public DatabaseController(IDatabaseService dbService, JobsContext dbContext)
        {
            this.dbService = dbService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            try
            {
                // Aplicar migraciones pendientes
                dbContext.Database.Migrate();

                return StatusCode(201, new { Message = "La base de datos ha sido creada exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error al intentar crear la base de datos: {ex.Message}" });
            }
        }
    }
}
