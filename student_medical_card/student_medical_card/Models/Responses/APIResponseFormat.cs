namespace student_medical_card.Models.Responses
{
    public interface APIResponseFormat
    {
        int ResponseCode { get; set; }
        string Result { get; set; }
        string Errormessage { get; set; }
    }
}
