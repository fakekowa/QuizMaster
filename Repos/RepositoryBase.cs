using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizMaster.Repos
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : RepositoryItem
    {
        protected List<T> Items;

        public virtual Task<T> AddAsync(T item)
        {
            Items.Add(item);
            return Task.FromResult(item);
        }

        public virtual Task<T> Delete(T item)
        {
            Items.Remove(item);
            return Task.FromResult(item);
        }

        public virtual Task<T> Update(int id, T item)
        {
            var toUpdate = Items.Find(i => i.Id == id);

            if (toUpdate == null)
                throw new ArgumentException("Could´t find item");

            toUpdate = item;
            return Task.FromResult(item);
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await Task.FromResult(Items).ConfigureAwait(false);
        }
    }
}