using ProgramAndApplicationForm.Models;

namespace ProgramAndApplicationForm.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<QuestionsML>> GetQuestionsAsync(string query);
        Task<QuestionsML> GetQuestonAsync(string id);
        Task AddQuestionAsync(QuestionsML item);
        Task UpdateItemAsync(string id, QuestionsML item);
        Task DeleteQuestionAsync(string id);
    }
}
