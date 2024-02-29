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

public class ProductDal : EfRepositoryBase<Product, int, BaseDbContext>, IProductDal
{
    public ProductDal(BaseDbContext context) : base(context)
    {
    }
}
