using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Models;

public class AplicationUser : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}
