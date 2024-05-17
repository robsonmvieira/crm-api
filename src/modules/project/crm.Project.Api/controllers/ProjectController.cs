using Microsoft.AspNetCore.Mvc;

namespace crm.Project.Api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["Bebel", "Pedro"];
        }

    }
}