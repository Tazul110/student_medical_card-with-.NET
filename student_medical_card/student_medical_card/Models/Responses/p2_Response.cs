namespace student_medical_card.Models.Responses
{
    public class p2_Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Prescription2? Prescription2 { get; set; }

        public List<Prescription2>? listPrescription2 { get; set; }
    }
}
