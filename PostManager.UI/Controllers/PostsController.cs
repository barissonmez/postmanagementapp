using PostManager.BLL.Services;
using PostManager.Common.DTO;
using System.Linq;
using System.Web.Http;
using UI.Models;
using UI.Validators;

namespace UI.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IService<PostDTO> _postService;

        public PostsController(IService<PostDTO> postService)
        {
            _postService = postService;
        }

        // GET api/posts
        [HttpGet]
        public IHttpActionResult Get()
        {
            var posts = _postService.Get().Select(p => new ResponseModel(p.Id, p.UserId, p.Title, p.Body));

            return Ok(posts);
        }

        // GET api/posts/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var post = _postService.Get(id);

            if (post == null)
                return NotFound();

            return Ok(new ResponseModel(post.Id, post.UserId, post.Title, post.Body));
        }

        // POST api/posts
        [HttpPost]
        public IHttpActionResult Post([FromBody] PostRequestModel model)
        {
            var validator = new PostModelValidator();
            var result = validator.Validate(model);

            if (!result.IsValid)
                return BadRequest(string.Join(" ", result.Errors));

            var post = _postService.Add(new PostDTO(int.MinValue, int.MinValue, model.Title, model.Body));

            return Created("", new ResponseModel(post.Id, post.UserId, post.Title, post.Body));
        }

        // PUT api/posts/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] PostRequestModel model)
        {
            var validator = new PostModelValidator();
            var result = validator.Validate(model);

            if (!result.IsValid)
                return BadRequest(string.Join(" ", result.Errors));

            var post = _postService.Update(id, new PostDTO(int.MinValue, int.MinValue, model.Title, model.Body));

            if (post == null)
                return NotFound();

            return Ok(new ResponseModel(post.Id, post.UserId, post.Title, post.Body));

        }

        // DELETE api/posts/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var post = _postService.Get(id);
            
            if (post == null)
                return NotFound();

            _postService.Delete(id);

            return Ok();
        }
    }
}
