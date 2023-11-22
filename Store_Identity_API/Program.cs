using BLL.Service;
using DLL;
using DLL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Store_Identity_API.Models;
using DLL.Models;
using System.Text;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using Microsoft.ApplicationInsights.Metrics;
using Azure.Identity;
using System.Configuration;
using DLL.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
var conStr2 ="";

if (builder.Environment.IsDevelopment())
{
    conStr2 = builder.Configuration["ConnectionStore"];
}
else
    if (builder.Environment.IsProduction())
{
    var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
    builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
    conStr2 = builder.Configuration["CS"];
}
ConfigureService(builder.Services);
builder.Services.AddApplicationInsightsTelemetry();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void ConfigureService(IServiceCollection services)
{
    services.AddControllersWithViews();
    //services.AddTransient<ApplicationDbContextFactory>();

  //  services.AddDbContext<Store_Identity_APIContext>(
  //options =>
  //options.UseSqlServer(
  //Configuration.GetConnectionString("conStr2"),
  //x => x.MigrationsAssembly("WebApplication1.Migrations")));


    services.AddDbContext<Store_Identity_APIContext>(
        op => 
        op.UseSqlServer()
    );

    services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<Store_Identity_APIContext>().AddDefaultTokenProviders();
    services.AddTransient<ProductRepository>();
    services.AddTransient<ProductService>();
    services.AddTransient<CardRepository>();
    services.AddTransient<CardService>();
    services.AddTransient<BrandRepository>();
    services.AddTransient<BrandService>();
    services.AddTransient<CategoryRepository>();
    services.AddTransient<CategoryService>();



    services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        options.JsonSerializerOptions.WriteIndented = true; // Для удобного форматирования JSON
    });

    services.AddAuthentication(op =>
    {
        op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }
    ).AddJwtBearer(op =>
    {
        op.SaveToken = true;
        op.RequireHttpsMetadata = false;
        op.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuier"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))


        };
    });
}