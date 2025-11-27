using Microsoft.OpenApi.Models;
using Serilog;
using Shared;

namespace SkillBoard.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        return services
            .AddWebDependencies()
            .AddSerilog()
            // React чтобы сделать один запрос с одного домена на другой домен
            .AddCors(options =>
            {
                options.AddPolicy("SkillBoardReact", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader() // Разрешаем любые заголовки в запросах
                        .AllowAnyMethod() // Разрешаем любые HTTP методы
                        .AllowCredentials(); // Разрешаем отправку cookies и authentication credentials
                });
            });
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddHttpLogging();
        
        services.AddOpenApi(options =>
        {
            options.AddSchemaTransformer((schema, context, _) =>
            {
                if (context.JsonTypeInfo.Type == typeof(Envelope<Errors>))
                {
                    if (schema.Properties.TryGetValue("errors", out var errorsProp))
                    {
                        errorsProp.Items.Reference = new OpenApiReference
                        {
                            Type = ReferenceType.Schema, Id = "Error",
                        };
                    }
                }

                return Task.CompletedTask;
            });
        });
        
        return services;
    }
}