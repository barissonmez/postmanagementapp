using System.Collections.Generic;

namespace PostManager.BLL.Services
{
    public  interface IService<TModel>
    {
        IList<TModel> Get();
        TModel Get(int id);
        void Delete(int id);
        TModel Add(TModel entity);
        TModel Update(int id, TModel entity);
    }
}
