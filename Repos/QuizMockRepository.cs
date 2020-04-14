using QuizMaster.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaster.Repos
{
    public class QuizMockRepository : RepositoryBase<QuestionsDTO>, IQuizRepository
    {
        public Task<IEnumerable<QuestionsDTO>> GetByCategory(int categoryId)
        {
            return Task.FromResult(Items.Where(q => q.CategoryId == categoryId));
        }
    }
}