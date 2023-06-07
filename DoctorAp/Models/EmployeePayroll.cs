namespace DoctorAp.Models
{
    namespace DoctorAp.Models
    {
        public class EmployeePayroll
        {
            public int Id { get; set; }
            public string EmployeeId { get; set; }

            public string EmployeeName { get; set; }
            public decimal HourlyRate { get; set; }
            public decimal HoursWorked { get; set; }
            public decimal TaxWithholdingRate { get; set; }

            public decimal NetPay { get; set; }
            public decimal CalculateGrossWages()
            {
                return HourlyRate * HoursWorked;
            }

            public decimal CalculateDeductions()
            {
                return CalculateGrossWages() * (TaxWithholdingRate / 100);
            }

            public decimal CalculateNetPay()
            {
                return CalculateGrossWages() - CalculateDeductions();
            }
        }
    }
}