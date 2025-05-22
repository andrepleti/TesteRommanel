using Microsoft.EntityFrameworkCore;
using TesteRommanel.Api;
using TesteRommanel.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

//builder.Services.AddControllers().AddNewtonsoftJson(o =>
//{
//    o.SerializerSettings.ContractResolver = new DefaultContractResolver();
//    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//});

builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySql"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql")), x => x.MigrationsAssembly("TesteRommanel.Infra.Data.Migrations.MySql"));
});

builder.Services.AddDependencyInjection();

var app = builder.Build();

app.UseCors("AllowAngularOrigins");

using var serviceScope = app.Services
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

serviceScope.ServiceProvider.GetService<DataBaseContext>()!.Database.Migrate();

app.UseRouting();

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();