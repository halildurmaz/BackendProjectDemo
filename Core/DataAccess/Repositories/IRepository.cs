using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories;

public interface IRepository<TEntity, TEntityId>
    where TEntity : BaseEntity<TEntityId>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    List<TEntity> GetAll();
    TEntity Get(Expression<Func<TEntity, bool>> predicate);


}
