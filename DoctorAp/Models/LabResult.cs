namespace DoctorAp.Models
{
    public class LabResult
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public string TestType { get; set; }
        public string Result { get; set; }
        public string ReferenceRange { get; set; }
    }
}
