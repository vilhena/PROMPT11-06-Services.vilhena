using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomBlog.Domain.Repositories
{
    public interface IDocumentRepository<TType, in TKey>
    {
        IQueryable<TType> GetAll();

        TType Get(TKey id);

        void Create(TType item);

        void Update(TType item);

        void Delete(TKey id);
    }
}
