using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using vAPI.Models;
using vAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// service: controllers
builder.Services.AddControllers();

// service: customs
builder.Services.AddTransient<IUserDetailsService, UserDetailsService>();
builder.Services.AddTransient<IUserVaccineDetailsService, UserVaccineDetailsService>();
builder.Services.AddTransient<IAppUserService, AppUserService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IHospitalService, HospitalService>();


// service: SQLite AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services
builder.Services.AddIdentity<AppUserModel, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// service: authorization
builder.Services.AddAuthorization();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Your Angular app's URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowAngularApp");

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