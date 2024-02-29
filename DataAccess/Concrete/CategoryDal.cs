using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete;

public class CategoryDal : EfRepositoryBase<Category, int, BaseDbContext> , ICategoryDal
{
    public CategoryDal(BaseDbContext context) : base(context)
    {
    }
}
