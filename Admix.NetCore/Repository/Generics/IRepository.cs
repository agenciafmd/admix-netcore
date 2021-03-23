using System.Collections.Generic;

namespace Admix.NetCore.Repository.Generics
{
    public interface IRepository<T> where T : class
    {
        T Create(T item);
        T FindByID(int id);
        T FindByIDString(string id);
        List<T> FindAll();
        T Update(T item);
        void Delete(T item);
    }
}