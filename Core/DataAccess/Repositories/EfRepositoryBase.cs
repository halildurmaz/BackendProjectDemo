using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories;

public class EfRepositoryBase<TEntity, TEntityId, TContext> : IRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId> where TContext : DbContext
{
    public TContext Context { get; set; }
    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    public TEntity Add(TEntity entity)
    {
        Context.Add(entity);
        Context.SaveChanges();
        return entity;
    }
    public TEntity Update(TEntity entity)
    {
        Context.Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate )
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public List<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList();

    }

}
