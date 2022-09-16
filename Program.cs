using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Pomelo.EntityFrameworkCore.MySql;
using System.Data.SqlClient;
using LoginWebAPI.Context;
using LoginWebAPI.Data;
using LoginWebAPI.Models;
using LoginWebAPI.Utils;

var builder = WebApplication.CreateBuilder(args);


var connstring = builder.Configuration.GetConnectionString("Roben");
builder.Services.AddDbContext<robenContext>(options=> options.UseMySQL(connstring));


builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<robenContext>()
    .AddDefaultTokenProviders(); ;



builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                       new OpenApiInfo
                       {
                           Title = SwaggerConfiguration.DocInfoTitle,
                           Version = SwaggerConfiguration.DocInfoVersion,
                           Description = SwaggerConfiguration.DocInfoDescription
                       });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = SwaggerConfiguration.SecuritySchemeDescription,
        Name = SwaggerConfiguration.SecuritySchemeName,
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = SwaggerConfiguration.SecurityScheme.ToLower(),
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = SwaggerConfiguration.SecurityScheme
        }
    };

    swagger.AddSecurityDefinition(SwaggerConfiguration.SecurityScheme, securitySchema);

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("PowerUser", new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .RequireClaim("role", "Administrators")
//        .Build());
//});

builder.Services.AddAuthentication(f =>
{
    f.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    f.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(k =>
{
    k.SaveToken = true;
    k.IncludeErrorDetails = true;
    k.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = builder.Configuration["JWT:Issuer"],
        //ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("JWT:ServerSecret").Value)),
        //ClockSkew = TimeSpan.Zero
    };

});
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Admin",
        authBuilder =>
        {
            authBuilder.RequireRole("Administrators");
        });
    options.AddPolicy("PowerUser",
        authBuilder =>
        {
            authBuilder.RequireRole("PowerUser");
        });
    options.AddPolicy("Attendant",
        authBuilder =>
        {
            authBuilder.RequireRole("Attendant");
        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapControllers();

app.Run();

//LGIN & REGISTER URL
//https://localhost:7020/api/SysLogins/login
//https://localhost:7020/api/SysLogins/register
//CREATE USER 'root'@'ip_address' IDENTIFIED BY 'some_pass';
//GRANT ALL PRIVILEGES ON *.* TO 'root'@'ip_address';
//SELECT host FROM mysql.user WHERE User = 'root';