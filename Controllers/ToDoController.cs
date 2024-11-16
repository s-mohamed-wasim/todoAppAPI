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
        public ActionResult<dynamic> CreateTask(TaskModel task)
        {
            string ?myConnectionString = this._connectionString;
            //ResponseModel responseModel = new ResponseModel();
            //responseModel.Result.Add(myConnectionString);
            //responseModel.Out
            //return responseModel;

            return Ok(myConnectionString);

        }

        [HttpGet]
        [Route("task/check")]
        public ActionResult<dynamic> Check()
        {
            string ?myConnectionString = this._connectionString;
            //ResponseModel responseModel = new ResponseModel();
            //responseModel.Result.Add(myConnectionString);
            //responseModel.Out
            //return responseModel;

            return Ok($"My connection string is: {myConnectionString}");

        }
    }
}
