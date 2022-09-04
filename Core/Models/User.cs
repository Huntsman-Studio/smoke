using Microsoft.AspNetCore.Identity;

namespace Core.Models;

public class User : IdentityUser<int>
{
    public string CompanyName { get; set; }
    public string VATNumber { get; set; }
    public string TaxOffice { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string RegisteredJob { get; set; }
    public ICollection<Message> MessageSent { get; set; }
    public ICollection<Message> MessageReceived { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
