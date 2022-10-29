using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Host.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _unitOfWork.Post.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var post = await _unitOfWork.Post.GetById(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = Guid.NewGuid();

                await _unitOfWork.Post.Add(post);
                await _unitOfWork.CompleteAsync();
                return Ok(post);
            }

            return new JsonResult("Something Went wrong") { StatusCode = 500 };
        }

        [HttpPut]
        public async Task<IActionResult> Update(Post post)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Post.Update(post);
                await _unitOfWork.CompleteAsync();
                return Ok(post);
            }
            return new JsonResult("Something Went wrong") { StatusCode = 500 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (Guid id)
        {
            if (await _unitOfWork.Post.Delete(id))
                return Ok(true);
            return NotFound();
        }
    }
}
