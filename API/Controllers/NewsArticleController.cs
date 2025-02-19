using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using BusinessObjects.Entities;
using BusinessObjects.Dto.NewsArticle;
using System;
using System.Threading.Tasks;
using System.Linq;
using Mapster;

namespace API.Controllers
{
    [Route("NewsArticles")]
    public class NewsArticleController : Controller
    {
        private readonly INewsArticleService _newsArticleService;

        public NewsArticleController(INewsArticleService newsArticleService) 
            => _newsArticleService = newsArticleService;
        
        public IActionResult NewArticles()
        {
            var articles = new List<NewsArticleDto>(); // Sample empty list
            return View(articles); // Ensure you are returning a model that matches the view
        }
        
        [HttpGet]
        public async Task<IActionResult> Form(Guid? id)
        {
            if (id.HasValue) // Update case
            {
                var existingArticle = await _newsArticleService.GetNewsArticleByIdAsync(id.Value);
                if (existingArticle == null)
                {
                    return NotFound();
                }
                var updateDto = existingArticle.Adapt<NewsArticleForUpdateDto>();
                return View("NewsArticleForm", updateDto);
            }
            return View("NewsArticleForm", new NewsArticleForCreationDto()); 
        }

        [HttpPost]
        public async Task<IActionResult> Form(object model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewsArticleForm", model);
            }

            if (model is NewsArticleForCreationDto createDto) 
                await _newsArticleService.CreateNewsArticleAsync(createDto);

            else if (model is NewsArticleForUpdateDto updateDto)
                await _newsArticleService.UpdateNewsArticleAsync(updateDto);
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var newsArticleDtos = await _newsArticleService.GetAllNewsArticlesAsync();
            return View("NewsArticles", newsArticleDtos); 
        }
        
        public async Task<IActionResult> Delete(Guid id)
        {
            await _newsArticleService.DeleteNewsArticleAsync(id);
            return RedirectToAction("Index");
        }
    }
}