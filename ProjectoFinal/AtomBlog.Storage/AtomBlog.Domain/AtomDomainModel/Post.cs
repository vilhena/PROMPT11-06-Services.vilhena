using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomBlog.Domain.AtomDomainModel
{
    public class Post
    {
        public string Id { get; set; }
        public string BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
