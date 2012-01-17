using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomBlog.Domain.AtomDomainModel
{
    public class Blog
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
