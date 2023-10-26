using ComputerRepair.Domain.AggregateModels.UserAggregate;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;

namespace ComputerRepair.Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<User?> GetByUserNameAsync(string userName);
    Task<User?> GetByEmailAsync(EmailAddress emailAddress);
    Task<User?> GetByIdAsync(UserId userId);
    Task<bool> IsExistByEmailAsync(EmailAddress emailAddress);
    Task<bool> IsExistByUserNameAsync(string userName);
}
