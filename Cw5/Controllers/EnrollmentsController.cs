using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Cw5.DTOs.Requests;
using Cw5.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw5.Controllers
{
    [Route("api/[enrollments]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            if (!ModelState.IsValid)
            {

            }
           
            var st = new Student();
            st.FirstName = request.FirstName;

            using(var con = new SqlConnection(""))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();

                var tran = con.BeginTransaction();

                try
                {
                    com.CommandText = "select IdStudies from studies where name=@name";
                    com.Parameters.AddWithValue("name", request.Studies);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        tran.Rollback();
                        return BadRequest("Studia nie istnieja");
                    }

                    int idstudies = (int)dr["IdStudies"];

                    com.CommandText = "INSERT INTO dbo.Student(IndexNumber, FirstName) VALUES(@Index, @name)";

                    com.Parameters.AddWithValue("index", request.IndexNumber);

                    com.ExecuteNonQuery();

                    tran.Commit();
                }
                catch(SqlException exc)
                {
                    tran.Rollback();
                }
            }


                var response = new EnrollStudentResponse();
            response.LastName = st.LastName;

            return Ok();
        }
    }
}