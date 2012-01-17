using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.Domain.Repositories;
using AtomBlog.Domain.Services;

namespace AtomBlog.BlogServices
{
    public class BlogService : IService<Blog,string>
    {
        private IDocumentRepository _repository;

        public BlogService(IDocumentRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Blog> GetAll()
        {
            throw new NotImplementedException();
        }

        public Blog Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Create(Blog item)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
