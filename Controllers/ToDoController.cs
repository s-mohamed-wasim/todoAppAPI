using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Model;

namespace ToDoAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly string? _connectionString;

        public ToDoController(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("WasimDBConnection");
        }

        [HttpPost]
        [Route("task/create")]
        public ActionResult<ResponseModel> CreateTask(TaskModel task)
        {
            
            ResponseModel responseModel = new ResponseModel();
            return responseModel;

        }
    }
}
