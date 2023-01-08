using System.Collections.Generic;

namespace PostManager.DAL.DataSource
{
    public  interface IDataSource<TEntity>
    {
        IList<TEntity> GetList();
        TEntity Find(int id);
        void Remove(int id);
        TEntity Add(TEntity entity);
        void Update(int id, TEntity entity);

    }
}
