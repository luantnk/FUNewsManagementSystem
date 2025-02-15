using API;
using API.Extensions;
using Mapster;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Mapster
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(MappingProfile).Assembly);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, Mapper>();

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();