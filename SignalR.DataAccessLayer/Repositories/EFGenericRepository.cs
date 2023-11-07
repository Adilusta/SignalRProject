using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    public class EFGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly SignalRDbContext _context;

        public EFGenericRepository(SignalRDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
           _context.Add(entity); 
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
           _context.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetListAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
