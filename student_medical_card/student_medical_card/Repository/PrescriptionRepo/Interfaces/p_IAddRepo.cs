using student_medical_card.Models.Responses;
using student_medical_card.Models;
using Microsoft.Data.SqlClient;

namespace student_medical_card.Repository.PrescriptionRepo.Interfaces
{
    public interface p_IAddRepo
    {
        p2_Response AddPrescription(Prescription2 prescription);
    }
}
