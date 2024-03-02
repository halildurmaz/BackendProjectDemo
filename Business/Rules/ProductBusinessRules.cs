using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class ProductBusinessRules
{
    private readonly IProductDal _productDal;

    public ProductBusinessRules(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void ProductNameShouldBeCanNotDuplicatedWhenInserted(string productName)
    {
        var product = _productDal.Get(p => p.Name == productName);
        if (product != null)
        {
            throw new Exception("Product name already exists!");
        }
    }
    public void ProductShouldBeExistsWhenSelected(Product product)
    {
        if (product == null)
        {
            throw new Exception("Product not exists!");
        }
    }

    public void ProductNameShouldBeCanNotDuplicatedWhenUpdated(Product product)
    {
        var resultProduct = _productDal.Get(c => c.Name == product.Name);
        if (resultProduct != null && product.Id != resultProduct.Id)
        {
            throw new Exception("Product name already exists!");
        }
    }
}
