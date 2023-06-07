using DoctorAp.Models;
using DoctorAp.Models.DoctorAp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorAp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        


        public DbSet<ApplicationUser> ApplicationUser { get; set; }





        public DbSet<DoctorAp.Models.ScreenLead>? ScreenLead_1 { get; set; }


        public DbSet<PrescriptionLead> PrescriptionLead { get; set; }



        public DbSet<ItemsLead> ItemsLead { get; set; }

        public DbSet<StockTrackerLead> StockTrackerLead { get; set; }

        public DbSet<EmployeePayroll> EmployeePayroll { get; set; }

        public DbSet<Room> Room { get; set; }


        public DbSet<LabResult> LabResult { get; set; }

        public DbSet<MedicineReport> MedicineReports { get; set; }


        public DbSet<Booking> Booking { get; set; }
    }
}