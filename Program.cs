using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TrackerContext>();

builder.Services
    .AddIdentity<User, IdentityRole>(o =>
    {
        o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        o.Lockout.MaxFailedAccessAttempts = 5;
    })
    .AddEntityFrameworkStores<TrackerContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
        CookieAuthenticationDefaults.AuthenticationScheme,
        o =>
        {
            // o.Cookies.ApplicationCookie.AutomaticChallenge = false;
            o.Cookie.SameSite = SameSiteMode.Unspecified;
            o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            o.ExpireTimeSpan = TimeSpan.FromDays(7);
            o.SlidingExpiration = true;
        }
    );

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromDays(7);
});

builder.Services.Configure<IdentityOptions>(o =>
{
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequireDigit = true;
    o.Password.RequireUppercase = true;
    o.Password.RequireLowercase = true;
    o.Password.RequiredLength = 6;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

                app.UseCors(b => b
                                  .WithOrigins("http://localhost:3000")
                                  .WithOrigins("http://localhost:3001")
                                  .WithOrigins("http://localhost:3002")
                                  .WithOrigins("http://localhost:8080")
                                  .WithOrigins("http://localhost:8081")
                                  .WithOrigins("http://localhost:8082")
                                  .AllowCredentials()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader()
                  );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
