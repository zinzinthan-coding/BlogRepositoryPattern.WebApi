using BlogRepositoryPattern.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogRepositoryPattern.WebApi.Features.Blog
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            try
            {
                var blogs = await _blogRepository.GetAllBlogs();
                return Ok(blogs);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            try
            {
                var blog = await _blogRepository.GetBlog(id);
                if (blog is null) return NotFound();

                return Ok(blog);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogDataModel reqModel)
        {
            try
            {
                var blog = await _blogRepository.CreateBlog(reqModel);
                return Ok(blog);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id , BlogDataModel reqModel)
        {
            try
            {
                var blog = await _blogRepository.UpdateBlog(id, reqModel);
                if (blog is not null) return Ok(blog);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBlog(int id, BlogDataModel reqModel)
        {
            try
            {
                var blog = await _blogRepository.PatchBlog(id, reqModel);
                if (blog is not null) return Ok(blog);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var blog = await _blogRepository.DeleteBlog(id);
                if (blog is null) return NotFound();

                return Ok(blog);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }
    }
}
