using BlogApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Interfaces
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
    }
}
