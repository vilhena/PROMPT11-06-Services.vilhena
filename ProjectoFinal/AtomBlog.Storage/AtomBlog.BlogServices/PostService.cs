using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.Domain.Repositories;
using AtomBlog.Domain.Services;

namespace AtomBlog.BlogServices
{
    public class PostService : IService<Post,string >
    {
        private IDocumentRepository _repository;

        public PostService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Create(Post item)
        {
            throw new NotImplementedException();
        }

        public void Update(Post item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
