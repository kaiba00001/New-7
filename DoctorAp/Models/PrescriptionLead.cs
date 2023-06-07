namespace DoctorAp.Models
{
    public class PrescriptionLead
    {
        public string Id { get; set; }

        public string Patient_Name { get; set; }

        public string Doctor_Name { get; set; }

        public string Medication{ get; set; }

        public string Dosage { get; set; }

        public string Instructions { get; set; }
    }
}
