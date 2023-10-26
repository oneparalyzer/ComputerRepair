﻿using ComputerRepair.Api.Middlewares;

namespace ComputerRepair.Api.Extentions;

public static class ExceptionHandlerMiddlewareExtension
{
    public static IServiceCollection AddExceptionHandlerMiddleware(this IServiceCollection services)
    {
        services.AddScoped<ExceptionHandlerMiddleware>();

        return services; 
    }

    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        return app;
    }
}
