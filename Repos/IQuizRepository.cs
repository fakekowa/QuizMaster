using QuizMaster.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizMaster.Repos
{
    public interface IQuizRepository : IRepository<QuestionsDTO>
    {
        Task<IEnumerable<QuestionsDTO>> GetByCategory(int categoryId);
    }
}