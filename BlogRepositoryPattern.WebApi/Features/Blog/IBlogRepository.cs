using BlogRepositoryPattern.WebApi.Models;

namespace BlogRepositoryPattern.WebApi.Features.Blog
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogDataModel>> GetAllBlogs();
        Task<BlogResponseModel> GetBlog(int id);
        Task<BlogResponseModel> CreateBlog(BlogDataModel reqModel);
        Task<BlogResponseModel> UpdateBlog(int id, BlogDataModel reqModel);
        Task<BlogResponseModel> PatchBlog(int id, BlogDataModel reqModel);
        Task<BlogResponseModel> DeleteBlog(int id);
    }
}
