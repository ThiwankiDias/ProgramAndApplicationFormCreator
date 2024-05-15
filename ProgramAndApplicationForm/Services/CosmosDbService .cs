using Microsoft.Azure.Cosmos;
using ProgramAndApplicationForm.Models;

namespace ProgramAndApplicationForm.Services
{
    public class CosmosDbService
    {
         
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddQuestionAsync(QuestionsML ques)
        {
            await this._container.CreateItemAsync<QuestionsML>(ques, new PartitionKey(ques.Id));
        }

        public async Task DeleteQuestionAsync(string id)
        {
            await this._container.DeleteItemAsync<QuestionsML>(id, new PartitionKey(id));
        }

        public async Task<QuestionsML> GetQuestonAsync(string id)
        {
            try
            {
                ItemResponse<QuestionsML> response = await this._container.ReadItemAsync<QuestionsML>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<QuestionsML>> GetQuestionsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<QuestionsML>(new QueryDefinition(queryString));
            List<QuestionsML> results = new List<QuestionsML>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateQuestionAsync(string id, QuestionsML ques)
        {
            await this._container.UpsertItemAsync<QuestionsML>(ques, new PartitionKey(id));
        }
    }

}
