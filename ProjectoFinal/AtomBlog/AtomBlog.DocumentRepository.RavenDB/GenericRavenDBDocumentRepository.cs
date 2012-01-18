using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.Domain.Repositories;
using Raven.Client.Document;

namespace AtomBlog.DocumentRepository.RavenDB
{
    public class GenericRavenDBDocumentRepository<TType> : IDocumentRepository<TType,string> where TType : class
    {
        private readonly DocumentStore _store;

        public GenericRavenDBDocumentRepository()
        {
            _store = new DocumentStore { Url = "http://localhost:8080" };
            _store.Conventions.IdentityPartsSeparator = "-";
            _store.Initialize();
        }


        public IQueryable<TType> GetAll()
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<TType>();
            }
        }

        public TType Get(string id)
        {
            using (var session = _store.OpenSession())
            {
                return session.Load<TType>(id);
            }
        }

        public void Create(TType item)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
        }

        public void Update(TType item)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            
            using (var session = _store.OpenSession())
            {
                var item = session.Load<TType>(id);

                if (item == null) return;

                session.Delete<TType>(item);
                session.SaveChanges();
            }
        }
    }
}
