using ComputerRepair.Domain.AggregateModels.UserAggregate;

namespace ComputerRepair.Application.Common.Interfaces.Autorization;

public interface IJwtTokenGenerator
{
    string Generate(User user, IList<string> roleTitles);
}
