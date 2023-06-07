using Microsoft.AspNetCore.Identity;

namespace DoctorAp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }
        public string Firstname { get; set; }


        public string Lastname { get; set; }
    }
}
