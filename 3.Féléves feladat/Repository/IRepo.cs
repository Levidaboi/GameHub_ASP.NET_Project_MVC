using System;
using System.Linq;

namespace Repository
{
    public interface IRepo<T> where T : new()
    {
        void Add(T item);

        void Delete(T item);

        void Delete(string uid);

        T Read(string uid);

        IQueryable<T> AllItem();

        void Update(string oldid, T newitem);

        void Save();
    }
}
