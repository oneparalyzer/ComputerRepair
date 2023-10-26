using Microsoft.AspNetCore.Identity;

namespace ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;

public sealed class CustomIdentityRole : IdentityRole<Guid>
{
    private CustomIdentityRole() { }
    public CustomIdentityRole(string title)
    {
        Id = Guid.NewGuid();
        Name = title;
    }
}
