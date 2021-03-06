﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Cw5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    { 

        private const string ConString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = db - mssql; Integrated Security = True;";

        

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from dbo.students where indexnumber='"+indexNumber+"'";
                com.Parameters.AddWithValue("index", indexNumber);
                

                con.Open();
                var dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();



                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirsName"].ToString();
                    st.LastName = dr["LastName"].ToString();

                    return Ok(st);
                }

            }
                return NotFound();
        }
        //Procedury
        [HttpGet]
        public IActionResult GetStudents2()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "TestProc3";
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("LastName", "Kowalski");

                var dr = com.ExecuteReader();

            }

            return NotFound();
        }
        //transakcje
        [HttpGet]
        public IActionResult GetStudents3()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "insert into Student(FirstName) values (@firstName)";

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();


                try
                {


                    int affectedRows = com.ExecuteNonQuery();

                    com.CommandText = "update into ...";
                    com.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                }

            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            

            return Ok("Utworzona studenta");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Student student)
        {
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")] 
        IActionResult DeleteStudent(Student student)
        {
            //executenon query
            return Ok("Usuwanie ukonczone");
        }
    }
}