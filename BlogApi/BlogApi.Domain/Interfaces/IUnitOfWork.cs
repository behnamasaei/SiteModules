using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPostRepository Post { get; }
        ICategoryRepository Category { get; }
        ITagRepository Tag { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
