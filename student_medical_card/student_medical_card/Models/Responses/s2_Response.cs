namespace student_medical_card.Models.Responses
{
    public class s2_Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Student2? Student { get; set; }

        public List<Student2>? listStudent { get; set; }
    }
}
