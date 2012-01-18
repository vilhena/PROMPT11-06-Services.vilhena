using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.Domain.Repositories;
using AtomBlog.Domain.Services;

namespace AtomBlog.BlogServices
{
    public class PostService : GenericService<Post>
    {
        public PostService(IDocumentRepository<Post, string> repository) : base(repository)
        {
        }
    }
}
