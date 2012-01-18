using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.Domain.Repositories;
using AtomBlog.Domain.Services;

namespace AtomBlog.BlogServices
{
    public class GenericService<TType> : IService<TType,string>
    {
        private IDocumentRepository<TType,string>_repository;

        public GenericService(IDocumentRepository<TType, string> repository)
        {
            _repository = repository;
        }

        public IQueryable<TType> GetAll()
        {
            return _repository.GetAll();
        }

        public TType Get(string id)
        {
            return _repository.Get(id);
        }

        public void Create(TType item)
        {
            _repository.Create(item);
        }

        public void Update(TType item)
        {
            _repository.Update(item);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }
    }
}
