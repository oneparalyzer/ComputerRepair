using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Infrastructure.Persistence;

public interface IDataSeeder
{
    Task SeedAsync(ModelBuilder builder);
}
