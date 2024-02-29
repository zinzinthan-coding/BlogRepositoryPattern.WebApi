using BlogRepositoryPattern.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogRepositoryPattern.WebApi.Features.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;
        int result;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogDataModel>> GetAllBlogs()
        {
            return await _context.Blogs.AsNoTracking().ToListAsync();
        }

        public async Task<BlogResponseModel> GetBlog(int id)
        {
            var item = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);

            return new BlogResponseModel
            {
                IsSuccess = item is not null,
                Message = item is not null ? "Success" : "Blog doesn't found",
                BlogData = item
            };
        }

        public async Task<BlogResponseModel> CreateBlog(BlogDataModel reqModel)
        {
            var blog = new BlogDataModel
            {
                BlogTitle = reqModel.BlogTitle,
                BlogAuthor = reqModel.BlogAuthor,
                BlogContent = reqModel.BlogContent
            };

            await _context.Blogs.AddAsync(blog);
            result = await _context.SaveChangesAsync();

            return new BlogResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Create Successful." : "Create Failed.",
                BlogData = blog
            };
        }

        public async Task<BlogResponseModel> UpdateBlog(int id, BlogDataModel reqModel)
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null) goto result;

            item.BlogTitle = reqModel.BlogTitle;
            item.BlogAuthor = reqModel.BlogAuthor;
            item.BlogContent = reqModel.BlogContent;

            result = await _context.SaveChangesAsync();

        result:
            return new BlogResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Successful." : "Update Failed.",
                BlogData = item!
            };
        }

        public async Task<BlogResponseModel> PatchBlog(int id, BlogDataModel reqModel)
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null) goto result;

            if (!string.IsNullOrEmpty(reqModel.BlogTitle))
            {
                item.BlogTitle = reqModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(reqModel.BlogAuthor))
            {
                item.BlogAuthor = reqModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(reqModel.BlogContent))
            {
                item.BlogContent = reqModel.BlogContent;
            }
            result = await _context.SaveChangesAsync();

        result:
            return new BlogResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Successful." : "Update Failed.",
                BlogData = item!
            };
        }

        public async Task<BlogResponseModel> DeleteBlog(int id)
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null) goto result;

            _context.Blogs.Remove(item);
            result = await _context.SaveChangesAsync();

        result:
            return new BlogResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Delete Successful." : "Delete Failed.",
            };
        }

    }
}
