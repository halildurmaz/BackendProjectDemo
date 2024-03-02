using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryDal _categoryDal;

    public CategoryBusinessRules(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void CategoryNameShouldBeCanNotDuplicatedWhenInserted(string categoryName)
    {
        var category = _categoryDal.Get(c => c.Name == categoryName);
        if (category != null)
        {
            throw new Exception("Category name already exists!");
        }
    }
    public void CategoryShouldBeExistsWhenSelected(Category category)
    {
        if (category == null)
        {
            throw new Exception("Category not exists!");
        }
    }

    public void CategoryNameShouldBeCanNotDuplicatedWhenUpdated(Category category)
    {
        var resultCategory = _categoryDal.Get(c => c.Name == category.Name);
        if (resultCategory != null && category.Id != resultCategory.Id)
        {
            throw new Exception("Category name already exists!");
        }
    }
}
