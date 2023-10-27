using ComputerRepair.Domain.AggregateModels.EmployeeAggregate;
using ComputerRepair.Domain.AggregateModels.EmployeeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.Enums;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Infrastructure.Persistence;

public class DataSeeder : IDataSeeder
{
    private readonly UserManager<CustomIdentityUser> _userManager;

    public DataSeeder(UserManager<CustomIdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task SeedAsync(ModelBuilder builder)
    {
        var office = Office.Create(
                "Офис-1",
                Address.Create(
                    "Архангельская область",
                    "Северодвинск",
                    "Ломоносова",
                    "100"),
                OfficeType.ForManagement);

        var user = new CustomIdentityUser("admin@gmail.com", "oneparalyzer");

        builder.Entity<MeasureUnit>().HasData(new List<MeasureUnit>
        { 
            MeasureUnit.Piece
        });

        builder.Entity<OfficeType>().HasData(new List<OfficeType>
        {
            OfficeType.ForProvideServices, 
            OfficeType.ForManagement
        });

        builder.Entity<Office>().HasData(new List<Office>
        {
            office
        });

        builder.Entity<CustomIdentityRole>().HasData(new List<CustomIdentityRole>
        {
            new CustomIdentityRole("boss")
        });

        await _userManager.CreateAsync(user, "Admin1337@");
        await _userManager.AddToRoleAsync(user, "boss");

        builder.Entity<Employee>().HasData(new List<Employee>
        {
            Employee.Create(
                FullName.Create(
                    "Пескишев",
                    "Андрей",
                    "Юрьевич"),
                new DateTime(2003, 9, 26),
                office.Id,
                UserId.Create(user.Id))
        });
    }
}
