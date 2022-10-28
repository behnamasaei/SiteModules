using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Models
{
    public class CategoryPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }

    }
}
