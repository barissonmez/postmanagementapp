using PostManager.CL.Manager;
using PostManager.Common.DTO;
using PostManager.IL.TypicodeApi;
using System.Collections.Generic;

namespace PostManager.CL.Data
{
    public sealed class CachedPostDataProvider : ICachedDataProvider<PostDTO>
    {
        private readonly ICacheManager _cacheManager;
        private readonly ITypicodeApiProvider _typicodeApiProvider;

        public CachedPostDataProvider(ICacheManager cacheManager, ITypicodeApiProvider typicodeApiProvider)
        {
            _cacheManager = cacheManager;
            _typicodeApiProvider = typicodeApiProvider;
        }

        public void Add(PostDTO dto)
        {
            _cacheManager.Set(dto.Id.ToString(), dto);
        }


        public PostDTO Get(string key)
        {
            return _cacheManager.Get<PostDTO>(key);
        }

        public IList<PostDTO> Get()
        {
            return _cacheManager.Get<PostDTO>();
        }

        public void Remove(string key)
        {
            _cacheManager.Remove(key);
        }

        public void Seed()
        {
            var rawData = _typicodeApiProvider.GetPosts();

            foreach (var rd in rawData)
                Add(rd);
        }

        public void Update(string key, PostDTO dto)
        {
            _cacheManager.Set(key, dto);
        }
    }
}
