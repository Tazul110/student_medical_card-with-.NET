using Azure;
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.DTO;

namespace student_medical_card.Repository.StudentRepo.Interfaces
{
    public interface s_IGetRepo
    {
        Student GetById(int s_Id);
    }
}
