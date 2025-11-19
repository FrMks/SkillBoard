using DirectoryService.Web.Middlewares;
using Serilog;
using Serilog.Events;
using SkillBoard.Presentation;
using SkillBoard.Infrastructure.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgramDependencies();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.Seq(builder.Configuration.GetConnectionString("Seq")
                 ?? throw new ArgumentNullException("Seq"))
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .CreateLogger();

builder.Services.AddScoped<SkillBoardDbContext>(_ =>
    new SkillBoardDbContext(builder.Configuration.GetConnectionString("DirectoryServiceDb")!));

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DirectoryService"));
}

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();