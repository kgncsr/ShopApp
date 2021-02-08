using ETicaret.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicaret.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class//TEntity bizim için bir class olacak yani tentity yerine clas göndereceksin
    where TContext : DbContext, new()//tcontext yerine dbcontexten türüyen clas göndermen gerekiyor ve burada gönderdiğin tipler newlenebilir instance olabilir tipler olacak
    {
        public void Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);//setle eTEntity'e konumlandım
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }


        public List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}