using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizMaster.Repos
{
    public interface IRepository<T> where T : RepositoryItem
    {
        Task<IEnumerable<T>> Get();

        Task<T> AddAsync(T item);

        Task<T> Update(int id, T item);

        Task<T> Delete(T item);
    }
}