using Microsoft.AspNetCore.Identity;

namespace DemoArquitectura.Web.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public string Department { get; set; }
    }
}
