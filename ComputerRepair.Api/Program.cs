using ComputerRepair.Api.Extentions;
using ComputerRepair.Application;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
using ComputerRepair.Domain.SeedWorks;
using ComputerRepair.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddLogging();
    builder.Services.AddExceptionHandlerMiddleware();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseExceptionHandlerMiddleware();
    app.UseDatabaseMigrations();
    app.Run();
}