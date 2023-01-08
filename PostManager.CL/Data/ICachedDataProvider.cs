using System.Collections.Generic;

namespace PostManager.CL.Data
{
    public interface ICachedDataProvider<T>
    {
        void Add(T entity);
        void Update(string key, T entity);

        void Remove(string key);

        T Get(string key);

        IList<T> Get();

        void Seed();
    }
}
