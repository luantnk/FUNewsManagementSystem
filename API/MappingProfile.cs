using BusinessObjects.Dto.Category;
using BusinessObjects.Dto.NewsArticle;
using BusinessObjects.Dto.NewsTag;
using BusinessObjects.Dto.SystemAccount;
using BusinessObjects.Dto.Tag;
using BusinessObjects.Entities;
using Mapster;

namespace API
{
    public class MappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            #region Category
            config.NewConfig<Category, CategoryDto>();
            config.NewConfig<CategoryForCreationDto, Category>();
            config.NewConfig<CategoryForUpdateDto, Category>();
            #endregion

            #region NewsArticle
            config.NewConfig<NewsArticle, NewsArticleDto>();
            config.NewConfig<NewsArticleForCreationDto, NewsArticle>();
            config.NewConfig<NewsArticleForUpdateDto, NewsArticle>();
            #endregion

            #region NewsTag
            config.NewConfig<NewsTag, NewsTagDto>();
            config.NewConfig<NewsTagForCreationDto, NewsTag>();
            config.NewConfig<NewsTagForUpdateDto, NewsTag>();
            #endregion

            #region SystemAccount
            config.NewConfig<SystemAccount, SystemAccountDto>();
            config.NewConfig<SystemAccountForCreationDto, SystemAccount>();
            config.NewConfig<SystemAccountForUpdateDto, SystemAccount>();
            #endregion

            #region Tag
            config.NewConfig<Tag, TagDto>();
            config.NewConfig<TagForCreationDto, Tag>();
            config.NewConfig<TagForUpdateDto, Tag>();
            #endregion
        }
    }
}