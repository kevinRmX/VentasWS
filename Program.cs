
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WSVentas.Models.Common;
using WSVentas.Services;


var builder = WebApplication.CreateBuilder(args);
String MiCors = "MiCors";
// Add services to the container.
builder.Services.AddCors(options =>
{
    
    options.AddPolicy(name: MiCors,
        builder =>
        {
            builder.WithHeaders("*");
            builder.WithOrigins("*");
            builder.WithMethods("*");
        });
});
builder.Services.AddControllers();


var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

//JWT
var appSettings = appSettingsSection.Get<AppSettings>();
var llave = System.Text.Encoding.ASCII.GetBytes(appSettings.Secreto);
builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(llave),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    
}

app.UseHttpsRedirection();

app.UseCors(MiCors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
