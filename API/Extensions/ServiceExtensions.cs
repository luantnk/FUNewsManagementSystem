using BusinessObjects.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Base.Implementation;
using Repositories.Base.Interface;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Implementation;
using Services.Interface;

namespace API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<INewsArticleRepository, NewsArticleRepository>();
        services.AddScoped<INewsTagRepository, NewsTagRepository>();
        services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }
      


    public static void ConfigureServices(this IServiceCollection services)
    {
        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<INewsArticleService, NewsArticleService>();
        services.AddScoped<INewsTagService, NewsTagService>();
        services.AddScoped<ISystemAccountService, SystemAccountService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IAuthService, AuthService>();
        #endregion
    }
    
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("FUNewsManagementSystem")));


}