using System.Collections.Generic;
using System.Linq;

namespace AtomBlog.Domain.Services
{
    public interface IService<TType, in TKey>
    {
        IQueryable<TType> GetAll();

        TType Get(TKey id);

        void Create(TType item);

        void Update(TType item);

        void Delete(TKey id);
    }
}
