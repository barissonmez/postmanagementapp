using PostManager.CL.Data;
using PostManager.Common.DTO;
using PostManager.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PostManager.DAL.DataSource
{
    public sealed class PostDataSource : IDataSource<PostEntity>
    {
        private readonly ICachedDataProvider<PostDTO> _cachedDataProvider;

        public PostDataSource(ICachedDataProvider<PostDTO> cachedDataProvider)
        {
            _cachedDataProvider = cachedDataProvider;
            _cachedDataProvider.Seed();
        }

        public PostEntity Find(int id)
        {
            var cachedData = _cachedDataProvider.Get(id.ToString());

            return cachedData == null ? null : new PostEntity(cachedData.Id, cachedData.UserId, cachedData.Title, cachedData.Body);
        }

        public IList<PostEntity> GetList()
        {
            return _cachedDataProvider.Get().Select(p => new PostEntity(p.Id, p.UserId, p.Title, p.Body)).ToList();
        }

        public void Remove(int id)
        {
            _cachedDataProvider.Remove(id.ToString());
        }


        public PostEntity Add(PostEntity entity)
        {
            var id = _cachedDataProvider.Get().Max(p => p.Id) + 1;
            var userId = _cachedDataProvider.Get().Max(p => p.UserId) + 1;

            entity.SetId(id);
            entity.SetUserId(userId);

            _cachedDataProvider.Add(new PostDTO(entity.Id, entity.UserId, entity.Title, entity.Body));

            return new PostEntity(entity.Id, entity.UserId, entity.Title, entity.Body);

        }

        public void Update(int id, PostEntity entity)
        {
            _cachedDataProvider.Update(id.ToString(), new PostDTO(entity.Id, entity.UserId, entity.Title, entity.Body));
        }
    }
}
