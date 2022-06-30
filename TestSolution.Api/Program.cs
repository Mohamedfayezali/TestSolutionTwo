
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TestSolution.Application;
using TestSolution.Application.Services;
using TestSolutoin.Infrastructure;
using TestSolutoin.Infrastructure.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    // Automatic registration of validators in assembly
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddUserInfrastructure(builder.Configuration);
builder.Services.AddUserInfrastructure(builder.Configuration);

builder.Services.Addvalidations();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddAuthentication(auth =>
    {
        //var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidAudience = builder.Configuration["AuthSettings:Audiance"],
            ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
            RequireExpirationTime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:Key"])),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddApplication();


//builder.Services.Addvalidations();
//builder.Services.AddMvc()
//  .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PersonValidator>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var userContext = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    AddUserToDB.SeedData(userContext);
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
 