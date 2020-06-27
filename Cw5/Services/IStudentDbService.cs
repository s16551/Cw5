using Cw5.DTOs.Requests;
using Cw5.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw5.Services
{
    interface IStudentDbService
    {
        void EnrollStudent(EnrollStudentRequest request);
        void PromoteStudents(int semester, string studies);
    }
}
