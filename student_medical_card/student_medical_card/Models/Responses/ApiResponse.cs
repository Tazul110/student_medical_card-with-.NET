namespace student_medical_card.Models.Responses
{
    public class ApiResponse: APIResponseFormat
    {
        public int ResponseCode { get; set; }
        public string Result { get; set; }
        public string Errormessage { get; set; }


    }
}
