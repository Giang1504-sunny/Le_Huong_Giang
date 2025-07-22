using Microsoft.AspNetCore.Identity;

namespace DeMoMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }
    }
}
