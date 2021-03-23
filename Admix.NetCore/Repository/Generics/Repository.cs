using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Admix.NetCore.Configuration;

namespace Admix.NetCore.Repository.Generics
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public Repository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<T> Create(T item)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(item);
                await data.SaveChangesAsync();
                return item;
            }
        }

        public T CreateItem(T item)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Add(item);
                data.SaveChanges();
                return item;
            }
        }

        public async Task<T> Update(T item)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(item);
                await data.SaveChangesAsync();
                return item;
            }
        }

        public async Task Delete(T item)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(item);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> FindByID(int id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<T> FindByIDString(string id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> FindAll()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }


        #region Disposed https: //docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose

        // Flag: Has Dispose already been called?
        private bool disposed;

        // Instantiate a SafeHandle instance.
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();
            // Free any other managed objects here.
            //

            disposed = true;
        }

        #endregion
    }
}