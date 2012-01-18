using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.Domain.Repositories;
using AtomBlog.Domain.Services;

namespace AtomBlog.BlogServices
{
    public class BlogService : GenericService<Blog>
    {
        public BlogService(IDocumentRepository<Blog, string> repository) : base(repository)
        {
        }
    }
}
