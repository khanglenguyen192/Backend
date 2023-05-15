using Backend;
using Backend.Common;
using Backend.DBContext;
using Backend.DBContext.Repositories.Impl;
using Backend.Service;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "JWT Authentication",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
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

#region Repository
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IDepartmentMapRepository, DepartmentMapRepository>();
builder.Services.AddTransient<IDepartmentUserMapRepository, DepartmentUserMapRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IProjectUserMapRepository, ProjectUserMapRepository>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<ISpecialDayRepository, SpecialDayRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();
builder.Services.AddTransient<IReportFileRepository, ReportFileRepository>();
builder.Services.AddTransient<ITicketFileRepository, TicketFileRepository>();
builder.Services.AddTransient<IOverTimeRepository, OverTimeRepository>();
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

// Run database migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<BackendSystemContext>();

    // Apply any pending migrations
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), Constants.UserDataFolderName)),
    RequestPath = "/" + Constants.UserDataFolderName
});

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
