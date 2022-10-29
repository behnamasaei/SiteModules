using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using BlogApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApi.Infrastructure.Services
{
    public class CategoryRepository : GenericeRepository<CategoryPost> , ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                            .FirstOrDefaultAsync();

                if (exist == null) return false;
                dbSet.Remove(exist);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(TagRepository));
                return false;
            }
        }

        public override async Task<CategoryPost> GetById(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                            .FirstOrDefaultAsync();

                if (exist == null) return null;
                return exist;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(TagRepository));
                return null;
            }
        }

        public override async Task<CategoryPost> GetByName(string name)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Title == name)
                                            .FirstOrDefaultAsync();

                if (exist == null) return null;
                return exist;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(TagRepository));
                return null;
            }
        }

    }
}
