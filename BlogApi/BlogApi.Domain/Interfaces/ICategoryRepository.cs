using BlogApi.Domain.Models;

namespace BlogApi.Domain.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<CategoryPost>
    {
    }
}
