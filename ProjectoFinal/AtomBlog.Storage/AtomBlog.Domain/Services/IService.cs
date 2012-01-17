using System.Collections.Generic;

namespace AtomBlog.Domain.Services
{
    public interface IService<TType, in TKey>
    {
        IEnumerable<TType> GetAll();

        TType Get(TKey id);

        void Create(TType item);

        void Update(TType item);

        void Delete(TKey id);
    }
}
