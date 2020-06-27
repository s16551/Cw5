using System;
using System.Collections.Generic;
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
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {

           
            var st = new Student();
            st.FirstName = request.FirstName;


            var response = new EnrollStudentResponse();
            response.LastName = st.LastName;

            return Ok();
        }
    }
}