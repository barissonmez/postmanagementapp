using PostManager.Common.DTO;
using PostManager.DAL.Entities;
using PostManager.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PostManager.BLL.Services
{
    public class PostService : IService<PostDTO>
    {
        private readonly IRepository<PostEntity> _postRepository;

        public PostService(IRepository<PostEntity> postRepository)
        {
            _postRepository = postRepository;
        }

        public PostDTO Add(PostDTO dto)
        {
            var entity = _postRepository.Add(new PostEntity(dto.Id, dto.UserId, dto.Title, dto.Body));

            return Get(entity.Id);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IList<PostDTO> Get()
        {
            return _postRepository.Get().Select(p => new PostDTO(p.Id, p.UserId, p.Title, p.Body)).ToList();
        }

        public PostDTO Get(int id)
        {
            var entity = _postRepository.Get(id);

            return entity == null ? null : new PostDTO(entity.Id, entity.UserId, entity.Title, entity.Body);
        }

        public PostDTO Update(int id, PostDTO dto)
        {
            _postRepository.Update(id, new PostEntity(dto.Id, dto.UserId, dto.Title, dto.Body));

            return Get(id);
        }
    }
}
