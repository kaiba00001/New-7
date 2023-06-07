namespace DoctorAp.Models
{
    public class MedicineReport
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string DirectionsForUse { get; set; }
    }
}
