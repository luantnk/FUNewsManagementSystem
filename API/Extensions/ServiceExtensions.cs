using Repositories.Base.Implementation;
using Repositories.Base.Interface;
using Services.Implementation;
using Services.Interface;

namespace API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    public static void ConfigureServices(this IServiceCollection services)
    {
        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<INewsArticleService, NewsArticleService>();
        services.AddScoped<INewsTagService, NewsTagService>();
        services.AddScoped<ISystemAccountService, SystemAccountService>();
        services.AddScoped<ITagService, TagService>();
        #endregion
    }

}