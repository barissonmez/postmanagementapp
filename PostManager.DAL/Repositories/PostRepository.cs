using PostManager.DAL.DataSource;
using PostManager.DAL.Entities;
using System.Collections.Generic;

namespace PostManager.DAL.Repositories
{
    public sealed class PostRepository : IRepository<PostEntity>
    {
        private readonly IDataSource<PostEntity> _dataSource;

        public PostRepository(IDataSource<PostEntity> dataSource)
        {
            _dataSource = dataSource;
        }

        public void Delete(int id)
        {
            _dataSource.Remove(id);
        }

        public IList<PostEntity> Get()
        {
            return _dataSource.GetList();
        }

        public PostEntity Get(int id)
        {
            return _dataSource.Find(id);
        }

        public PostEntity Add(PostEntity entity)
        {
            return _dataSource.Add(entity);
        }

        public void Update(int id, PostEntity entity)
        {
            var post = Get(id);

            if (post == null) return;

            entity.SetId(post.Id);
            entity.SetUserId(post.UserId);

            _dataSource.Update(id, entity);
        }
    }
}
