using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using QuizMaster.Helpers;
using QuizMaster.Models;
using QuizMaster.Repos;

namespace QuizMaster
{
    class QuizRepository : RepositoryBase<QuestionsDTO>, IQuizRepository
    {
        HttpClient _client;

        public QuizRepository()
        {
            _client = new HttpClient();
        }

        public Task<IEnumerable<QuestionsDTO>> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public override async Task<QuestionsDTO> AddAsync(QuestionsDTO item)
        {
            var uri = new Uri(string.Format(Constants.baseURI + Constants.questionsAPI));
            var json = JsonConvert.SerializeObject(item);
            var response = await _client.PostAsync(uri, new StringContent(json));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QuestionsDTO>(content);
            }
            throw new Exception("Something went wrong");
        }

        public override async Task<QuestionsDTO> Delete(QuestionsDTO item)
        {
            var uri = new Uri(string.Format(Constants.baseURI + Constants.questionsAPI +"/" + item.Id));
            var json = JsonConvert.SerializeObject(item);
            var response = await _client.DeleteAsync(uri);
            return item;
        }

        public override async Task<IEnumerable<QuestionsDTO>> Get()
        {
            var uri = new Uri(string.Format(Constants.baseURI + Constants.questionsAPI));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<QuestionsDTO>>(content);
            }
            return Enumerable.Empty<QuestionsDTO>();
        }

        public override async Task<QuestionsDTO> Update(int id, QuestionsDTO item)
        {
            var uri = new Uri(string.Format(Constants.baseURI + Constants.questionsAPI + "/" + id));
            var response = await _client.PutAsync(uri, new StringContent(JsonConvert.SerializeObject(item)));
            return item;
        }

        public async Task<List<QuestionsDTO>> RefreshDataAsync()
        {
            List<QuestionsDTO> questions = new List<QuestionsDTO>();
            var uri = new Uri(string.Format(Constants.baseURI + Constants.questionsAPI));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                questions = JsonConvert.DeserializeObject<List<QuestionsDTO>>(content);
            }
            else
            {
                //.... add something if not successcode and it goes haywire
            }
            return questions;
        }
    }
}