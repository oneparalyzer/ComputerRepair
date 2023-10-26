using ComputerRepair.Domain.SeedWorks;
using ComputerRepair.Domain.AggregateModels.UserAggregate.DomainEvents;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.RoleAggregate.ValueObjects;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace ComputerRepair.Domain.AggregateModels.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<RoleId> _roleIds = new();

    public User(UserId id) : base(id) { }

    private User(
        UserId id, 
        EmailAddress emailAddress, 
        string userName, 
        Password password,
        List<RoleId> roleIds) : base(id)
    {
        EmailAddress = emailAddress;
        UserName = userName;
        Password = password;
        _roleIds = roleIds;
    }

    public EmailAddress EmailAddress { get; private set; }
    public string UserName { get; private set; }
    public Password Password { get; private set; }
    public RefreshToken? RefreshToken { get; private set; }
    public IReadOnlyList<RoleId> RoleIds => _roleIds.AsReadOnly();

    public static Result<User> Create(
        EmailAddress email, 
        string userName, 
        Password password, 
        List<RoleId> roleIds)
    {
        Result checkResult = CheckForExistenceRoleIds(roleIds);
        if (!checkResult.IsSuccess)
        {
            return Result.Failure<User>(checkResult.Errors);
        }

        var user = new User(
            UserId.Create(), 
            email, 
            userName, 
            password, 
            roleIds);

        user.AddDomainEvent(new UserCreatedDomainEvent(user));

        return Result.Success(user);
    }

    private static Result CheckForExistenceRoleIds(List<RoleId> roleIds)
    {
        var errors = new List<Error>();
        var uniqueRoleIds = new HashSet<RoleId>();

        foreach (var roleId in roleIds)
        {
            if (!uniqueRoleIds.Add(roleId))
            {
                errors.Add(Errors.Role.IdСantBeRepeated(roleId.ToString()));
            }
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        return Result.Success();
    }

    public void SetRefreshToken()
    {
        RefreshToken = RefreshToken.Create();
    }
}
