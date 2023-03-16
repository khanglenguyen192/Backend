using Backend;
using Backend.Common;
using Backend.DBContext;
using Backend.Service;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var settingsSection = builder.Configuration.GetSection("ConnectionStrings");
var identitySettings = settingsSection.Get<IdentitySettings>();
identitySettings.ServerUrl = builder.Configuration["ServerUrl"];
DataConstants.IdentitySettings = identitySettings;

#region Dependency Service - creation
builder.Services.AddSingleton<IJwtHandler, JwtHandler>();
builder.Services.AddTransient<IDbContextFactory, DbContextFactory>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IMeetingService, MeetingService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<ISalaryService, SalaryService>();
builder.Services.Configure<SecurityConfig>(builder.Configuration.GetSection("SecurityConfig"));
#endregion

var securityConfig = builder.Configuration.GetSection("SecurityConfig").Get<SecurityConfig>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtBearerOptions =>
{
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityConfig.TokenSymmetricKey)),
        ValidIssuer = Constants.API_ISSUER,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
