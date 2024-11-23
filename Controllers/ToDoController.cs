using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
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
            ResponseModel responseModel = new ResponseModel();
            DataTable res = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.CreateTask", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                    cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                    cmd.Parameters.AddWithValue("@TaskPriority", task.TaskPriority);
                    cmd.Parameters.AddWithValue("@Out", -1).Direction = System.Data.ParameterDirection.Output;

                    SqlDataReader reader = cmd.ExecuteReader();

                    res.Load(reader);

                    var paramsList = cmd.Parameters;

                    if (paramsList.Contains("@Out"))
                    {
                        responseModel.Out = (int)cmd.Parameters["@Out"].Value;
                    }

                    con.Close();

                    responseModel.Result = res;

                    return responseModel;

                }
                catch (Exception ex)
                {
                    con.Close();
                    return responseModel;
                }
            }

        }

        [HttpPost]
        [Route("task/update")]
        public ActionResult<dynamic> UpdateTask(TaskModel task)
        {
            ResponseModel responseModel = new ResponseModel();
            DataTable res = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.UpdateTask", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskId", task.TaskId);
                    cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                    cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                    cmd.Parameters.AddWithValue("@TaskPriority", task.TaskPriority);
                    cmd.Parameters.AddWithValue("@Out", -1).Direction = System.Data.ParameterDirection.Output;

                    SqlDataReader reader = cmd.ExecuteReader();

                    res.Load(reader);

                    var paramsList = cmd.Parameters;

                    if (paramsList.Contains("@Out"))
                    {
                        responseModel.Out = (int)cmd.Parameters["@Out"].Value;
                    }

                    con.Close();

                    responseModel.Result = res;

                    return responseModel;

                }
                catch (Exception ex)
                {
                    con.Close();
                    return responseModel;
                }
            }

        }

        [HttpPost]
        [Route("task/delete")]
        public ActionResult<dynamic> DeleteTask(TaskModel task)
        {
            ResponseModel responseModel = new ResponseModel();
            DataTable res = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.DeleteTask", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskId", task.TaskId);
                    cmd.Parameters.AddWithValue("@Out", -1).Direction = System.Data.ParameterDirection.Output;

                    SqlDataReader reader = cmd.ExecuteReader();

                    res.Load(reader);

                    var paramsList = cmd.Parameters;

                    if (paramsList.Contains("@Out"))
                    {
                        responseModel.Out = (int)cmd.Parameters["@Out"].Value;
                    }

                    con.Close();

                    responseModel.Result = res;

                    return responseModel;

                }
                catch (Exception ex)
                {
                    con.Close();
                    return responseModel;
                }
            }

        }

        [HttpGet]
        [Route("task/getAll")]
        public ActionResult<dynamic> GetAllTasks()
        {
            ResponseModel responseModel = new ResponseModel();
            DataTable res = new DataTable();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.GetAllTasks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Out", -1).Direction = System.Data.ParameterDirection.Output;

                    SqlDataReader reader = cmd.ExecuteReader();

                    res.Load(reader);

                    var paramsList = cmd.Parameters;

                    if (paramsList.Contains("@Out"))
                    {
                        responseModel.Out = (int)cmd.Parameters["@Out"].Value;
                    }

                    con.Close();

                    responseModel.Result = res;

                    return responseModel;

                }
                catch (Exception ex)
                {
                    con.Close();
                    return responseModel;
                }
            }

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
