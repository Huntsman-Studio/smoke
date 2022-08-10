using Microsoft.AspNetCore.Identity;

namespace Core.Models;

public class User : IdentityUser
{
    public string CompanyName { get; set; }
    public string VAT { get; set; }
    public int MyProperty { get; set; }
}
