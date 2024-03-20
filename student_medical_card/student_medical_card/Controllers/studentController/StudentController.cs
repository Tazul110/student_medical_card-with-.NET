using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Service.StudentServ.Interfaces;
using student_medical_card.Models.LogIn;

namespace student_medical_card.Controllers.studentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly s_IAddServ _addStudent;
        private readonly s_IGetServ _GetBy;
        private readonly s_IGetAllStudentServ _GetAll;

        public StudentController(s_IAddServ addStudent, s_IGetServ getBy, s_IGetAllStudentServ getAll)
        {
            _addStudent = addStudent;
            _GetBy = getBy;
            _GetAll = getAll;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddStudent")]
        public s2_Response AddStudent(Student2 student)
        {
            s2_Response response = new s2_Response();

            response = _addStudent.s_Add(student);
            return response;
        }


        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int s_Id)
        {
            var studentPrescription = _GetBy.sGetById(s_Id);

            if (studentPrescription == null)
            {
                return NotFound();
            }

            return Ok(studentPrescription);
        }


        [HttpGet]
        [Route("GetAll")]
        public s2_Response GetAll_Students()
        {
            s2_Response response = new s2_Response();

            response = _GetAll.Get();
            return response;
        }

    }
}
