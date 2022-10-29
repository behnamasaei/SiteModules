using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Models
{
    public class CategoryPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public CategoryPost Parent { get; set; }
        public Guid? ParentId { get; set; }
        public ICollection<CategoryPost> Children { get; } = new List<CategoryPost>();


        public string Path { get; set; }
        public bool Active { get; set; }

    }
}
