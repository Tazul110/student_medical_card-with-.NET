using Microsoft.AspNetCore.Mvc;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Service.PrescriptionRepo.interfaces;


namespace student_medical_card.Controllers.prescriptionController
{
    [Route("api/")]
    [ApiController]
    public class p_addController : ControllerBase
    {
       
            private readonly p_IAddServ _service;
           

            public p_addController( p_IAddServ service)
            {
               
                _service = service;
            }

       // [Authorize]
        [HttpPost]
            [Route("AddPrescription")]
            public p2_Response AddPrescription(Prescription2 prescription)
            {
                p2_Response response = new p2_Response();

                response = _service.p_Add(prescription);
                return response;
            }
        
    }
}
