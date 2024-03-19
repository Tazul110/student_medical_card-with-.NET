using Dapper;
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.StudentRepo.Interfaces;

namespace student_medical_card.Repository.StudentRepo.Implements
{
    public class s_AddRepo:s_IAddRepo
    {
        private readonly IConfiguration _configuration;
        public s_AddRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public s2_Response AddStudent(Student2 student)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            s2_Response s_response = new s2_Response();


            //int i = connection.Execute("INSERT INTO student2 (s_Id, s_Name, s_Dept, s_Gender, s_Email, b_Date) VALUES (@s_Id, @s_Name, @s_Dept, @s_Gender, @s_Email, @b_Date)", student);
            int i = connection.Execute("INSERT INTO student2 (s_Id, s_Name, s_Dept, s_Gender, s_Email, b_Date) VALUES (@s_Id, @s_Name, @s_Dept, @s_Gender, @s_Email, @b_Date)", student);

            if (i > 0)
            {

                s_response.StatusCode = 200;
                s_response.StatusMessage = "Student added.";
                s_response.Student = student;

            }
            else
            {
                s_response.StatusCode = 100;
                s_response.StatusMessage = "No Data inserted";


            }
            return s_response;
        }
        
    }
}
