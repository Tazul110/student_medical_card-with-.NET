using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.DTO;

namespace student_medical_card.Service.StudentServ.Interfaces
{
    public interface s_IGetServ
    {
      Student sGetById(int s_Id);
    }
}
