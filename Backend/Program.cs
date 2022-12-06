using Backend.Common;
using Backend.DBContext;
using Backend.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        config.AddEnvironmentVariables();
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseIIS();
builder.WebHost.UseIISIntegration();
builder.Services.AddDbContext<BackendSystemContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 27)),
                     options => options.EnableRetryOnFailure());
});
builder.Services.AddScoped<DbContext>(serviceProvider => serviceProvider.GetRequiredService<BackendSystemContext>());


var settingsSection = builder.Configuration.GetSection("ConnectionStrings");
var identitySettings = settingsSection.Get<IdentitySettings>();
identitySettings.ServerUrl = builder.Configuration["ServerUrl"];
DataConstants.IdentitySettings = identitySettings;

#region Dependency Service - creation
builder.Services.AddTransient<IDbContextFactory, DbContextFactory>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IMeetingService, MeetingService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IReportService, ReportService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
