using Microsoft.AspNetCore.Mvc;
using ProgramAndApplicationForm.Models;
using ProgramAndApplicationForm.Services;

namespace ProgramAndApplicationForm.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public IActionResult Index()
        {
            return View();
        }
        public QuestionsController (ICosmosDbService cosmosDbService) //create constructor 
        {
            _cosmosDbService = cosmosDbService;
        }
        [HttpGet]
        public async Task<IEnumerable<QuestionsML>> Get()
        {
            return await _cosmosDbService.GetQuestionsAsync("select * from c");
        }
    }
}
