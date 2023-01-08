using System.Collections.Generic;

namespace PostManager.CL.Manager
{
    public  interface ICacheManager
    {
        void Set<T>(string key, T value);
        IList<T> Get<T>();
        T Get<T>(string key);
        bool IsExist(string key);
        void Remove(string key);
    }
}
