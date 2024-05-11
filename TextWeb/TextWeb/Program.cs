using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TextWeb.Data;
using TextWeb.Data.Abstract;
using TextWeb.Data.Concrete;
using TextWeb.Entity;
using VueCliMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TextWebDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TextWebDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IPageRepository,PageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
       );
});

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "vue-project";
});

var app = builder.Build();

app.UseCors();
app.UseRouting();
app.UseSpaStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    if (app.Environment.IsDevelopment())
        spa.Options.SourcePath = "vue-project/";
    else
        spa.Options.SourcePath = "dist";

    spa.UseVueCli(npmScript: "serve");
});

app.Run();
