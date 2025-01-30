using Microsoft.AspNetCore.Identity;

namespace personalProject.Domain;

public class AspNetUsers : IdentityUser
{
    public string? TestProperty { get; set; }
}