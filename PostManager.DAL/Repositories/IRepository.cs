using System.Collections.Generic;

namespace PostManager.DAL.Repositories
{
    public  interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> Get();
        TEntity Get(int id);
        void Delete(int id);
        TEntity Add(TEntity entity);
        void Update(int id, TEntity entity);
    }
}
