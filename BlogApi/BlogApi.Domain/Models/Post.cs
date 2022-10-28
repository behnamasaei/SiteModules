using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public CategoryPost Category { get; set; }
        public string? Writer { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? LastModifier { get; set; }
        public List<Tag>? Tags { get; set; }
        public PostStatus PostStatus { get; set; }
        public uint SeenCount{ get; set; }
    }
}
