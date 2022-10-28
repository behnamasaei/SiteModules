using BlogApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetPosts();
        Task<T> GetPostById(Guid id);
        Task<T> GetPostByName(string name);
        Task<HttpResponse> AddPost(T entity);  
        Task<HttpResponse> DeletePost(T entity);
        Task<HttpResponse> UpdatePost(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
