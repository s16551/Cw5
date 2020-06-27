using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Cw5.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw5.Controllers
{
    [Route("api/[enrollments]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        public IActionResult EnrollStudent(EnrollStudentRequest newStudent)
        {


            return Ok();
        }
    }
}