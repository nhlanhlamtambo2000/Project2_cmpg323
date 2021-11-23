using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Data;
using PhotoProject.Models;

namespace PhotoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM dbo.Department";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ExampleAppCon");
            SqlDataReader myreader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query,myCon))
                {
                    myreader = myCommand.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPost]

        public JsonResult Post(Department dep)
        {
            string query = "INSERT INTO dbo.Department values('" + dep.DepartmentName + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ExampleAppCon");
            SqlDataReader myreader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myreader = myCommand.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Success");
        }


        [HttpPut]

        public JsonResult Put(Department dep)
        {
            string query = "UPDATE dbo.Department SET DepartmentName = '" + dep.DepartmentName + @"'WHERE DepartmentId = " + dep.DepartmentID + @"" ;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ExampleAppCon");
            SqlDataReader myreader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myreader = myCommand.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Update Successfullly");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string query = "DELETE FROM dbo.Department WHERE DepartmentId = " + id + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ExampleAppCon");
            SqlDataReader myreader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myreader = myCommand.ExecuteReader();
                    table.Load(myreader);

                    myreader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfullly");
        }




    }
}