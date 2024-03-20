using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Service.PrescriptionRepo.interfaces;
using student_medical_card.Service.MedicineServ.Interfaces;
using student_medical_card.Service.TestServ.Interfaces;

namespace student_medical_card.Controllers.prescriptionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly p_IAddServ _addPrescription;
        private readonly m_IAddServ _addMedicine;
        private readonly t_IAddServ _addTests;

        public PrescriptionController(p_IAddServ addPrescription,m_IAddServ addMedicine , t_IAddServ addTests)
        {

            _addPrescription = addPrescription;
            _addMedicine = addMedicine;
            _addTests = addTests;
        }

        // [Authorize]
        [HttpPost]
        [Route("AddPrescription")]
        public p2_Response AddPrescription(Prescription2 prescription)
        {
            p2_Response response = new p2_Response();

            response = _addPrescription.p_Add(prescription);
            return response;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddMedicine")]
        public m_Response AddMedicines(Medicine medicine)
        {

            m_Response response = new m_Response();

            response = _addMedicine.m_add(medicine);
            return response;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddTests")]
        public t_Response AddTests(Test t)
        {

            t_Response response = new t_Response();

            response = _addTests.t_add(t);
            return response;
        }

    }
}
