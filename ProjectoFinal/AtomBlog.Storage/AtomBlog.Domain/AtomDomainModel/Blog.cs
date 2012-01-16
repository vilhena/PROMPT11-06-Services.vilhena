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
        public DateTime Updated { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
