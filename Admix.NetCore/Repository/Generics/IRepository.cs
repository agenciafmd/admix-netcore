using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admix.NetCore.Repository.Generics
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T item);
        Task<T> FindByID(int id);
        Task<T> FindByIDString(string id);
        T CreateItem(T item);
        Task<List<T>> FindAll();
        Task<T> Update(T item);
        Task Delete(T item);
    }
}