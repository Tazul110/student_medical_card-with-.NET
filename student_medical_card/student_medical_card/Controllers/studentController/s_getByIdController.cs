using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_medical_card.Service.StudentServ.Interfaces;

namespace student_medical_card.Controllers.studentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class s_getByIdController : ControllerBase
    {
        private readonly s_IGetServ _crudGetBy;
      

        public s_getByIdController(s_IGetServ crudGetBy)
        {
            
            _crudGetBy = crudGetBy;
        }
        [Authorize]
        [HttpGet("{s_Id}")]
        public IActionResult GetStudentWithPrescriptions(int s_Id)
        {
            var studentPrescription = _crudGetBy.sGetById(s_Id);

            if (studentPrescription == null)
            {
                return NotFound();
            }

            return Ok(studentPrescription);
        }
    }
}
