using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Admix.NetCore.Configuration;

namespace Admix.NetCore.Repository.Generics
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ContextBase _context;
        private DbSet<T> entities;

        public Repository(ContextBase context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public T Create(T item)
        {
            entities.Add(item);
            _context.SaveChanges();
            return item;
        }
        

        public T Update(T item)
        {
            entities.Update(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(T item)
        {
            entities.Remove(item);
            _context.SaveChanges();
        }

        public T FindByID(int id)
        {
            return entities.Find(id);
        }

        public T FindByIDString(string id)
        {
            return entities.Find(id);
        }

        public List<T> FindAll()
        {
            return entities.ToList();
        }
       
    }
}