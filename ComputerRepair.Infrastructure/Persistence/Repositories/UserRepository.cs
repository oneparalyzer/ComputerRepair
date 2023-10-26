using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.UserAggregate;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;
using Microsoft.AspNetCore.Identity;

namespace ComputerRepair.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly RoleManager<CustomIdentityRole> _roleManager;

    public UserRepository(
        UserManager<CustomIdentityUser> userManager,
        RoleManager<CustomIdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task CreateAsync(User user)
    {
        CustomIdentityUser identityUser = ConvertToIdentityUser(user);
        await _userManager.CreateAsync(identityUser, user.Password.Value);
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        CustomIdentityUser? identityUser = await _userManager.FindByNameAsync(userName);
        if (identityUser is null)
        {
            return null;
        }

        User user = ConvertToUser(identityUser);
        return user;
    }

    public async Task<User?> GetByEmailAsync(EmailAddress emailAddress)
    {
        CustomIdentityUser? identityUser = await _userManager.FindByEmailAsync(emailAddress.Value);
        if (identityUser is null)
        {
            return null;
        }

        User user = ConvertToUser(identityUser);
        return user;
    }

    public async Task<bool> IsExistByEmailAsync(EmailAddress emailAddress)
    {
        CustomIdentityUser? userByEmail = await _userManager
            .FindByEmailAsync(emailAddress.Value);

        return userByEmail is not null;
    }

    public async Task<bool> IsExistByUserNameAsync(string userName)
    {
        CustomIdentityUser? userByName = await _userManager
            .FindByNameAsync(userName);

        return userByName is not null;
    }

    public async Task<User?> GetByIdAsync(UserId userId)
    {
        CustomIdentityUser? identityUser = await _userManager.FindByIdAsync(userId.Value.ToString());
        if (identityUser is null)
        {
            return null;
        }

        User user = ConvertToUser(identityUser);
        return user;
    }

    private User ConvertToUser(CustomIdentityUser identityUser)
    {
        //return User.Create(
        //    EmailAddress.Create(identityUser.Email),
        //    identityUser.UserName,
        //    Password.Create(identityUser.PasswordHash));
        throw new NotImplementedException();
    }

    private CustomIdentityUser ConvertToIdentityUser(User user)
    {
        return new CustomIdentityUser(
            user.UserName,
            user.EmailAddress.Value);
    }


}
