
using Microsoft.AspNetCore.Mvc;
using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Service.MedicineServ.Interfaces;

namespace student_medical_card.Controllers.medicineController
{
    [Route("api/")]
    [ApiController]
    public class m_addController : ControllerBase
    {
        private readonly m_IAddServ _service;
        
        public m_addController(m_IAddServ service)
        {
           
            _service = service;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddMedicine")]
        public m_Response AddMedicines(Medicine medicine)
        {
            
            m_Response response = new m_Response();

            response = _service.m_add( medicine);
            return response;
        }
    }
}
