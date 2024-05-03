using Microsoft.AspNetCore.Identity;

namespace personalProjectAPI.Domains;

public class AspNetUsers : IdentityUser
{
    public string? TestProperty { get; set; }
}