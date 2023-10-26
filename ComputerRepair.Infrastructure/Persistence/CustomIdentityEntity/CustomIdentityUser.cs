using Microsoft.AspNetCore.Identity;

namespace ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;

public sealed class CustomIdentityUser : IdentityUser<Guid>
{
    private CustomIdentityUser() { }

    public CustomIdentityUser(string email, string userName)
    {
        Email = email;
        UserName = userName;
    }
}
