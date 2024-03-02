using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly CategoryBusinessRules _categoryBusinessRules;
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(CategoryBusinessRules categoryBusinessRules, ICategoryDal categoryDal)
    {
        _categoryBusinessRules = categoryBusinessRules;
        _categoryDal = categoryDal;
    }

    public CategoryAddResponse Add(CategoryAddRequest categoryAddRequest)
    {
        _categoryBusinessRules.CategoryNameShouldBeCanNotDuplicatedWhenInserted(categoryAddRequest.Name);
        Category category = new Category();
        category.Name = categoryAddRequest.Name;
        category.CreatedDate = DateTime.Now;
        Category createdCategory = _categoryDal.Add(category);
        CategoryAddResponse categoryAddResponse = new CategoryAddResponse();
        categoryAddResponse.Id = createdCategory.Id;
        categoryAddResponse.CreatedDate = createdCategory.CreatedDate;
        categoryAddResponse.Name = createdCategory.Name;

        return categoryAddResponse;
    }

    public CategoryUpdateResponse Update(CategoryUpdateRequest categoryUpdateRequest)
    {


        Category category = _categoryDal.Get(c => c.Id == categoryUpdateRequest.Id);

        _categoryBusinessRules.CategoryShouldBeExistsWhenSelected(category);
        

        category.Name = categoryUpdateRequest.Name;
        category.UpdatedDate = DateTime.Now;

        _categoryBusinessRules.CategoryNameShouldBeCanNotDuplicatedWhenUpdated(category);
        

        var updatedCategory = _categoryDal.Update(category);

        CategoryUpdateResponse categoryUpdateResponse = new CategoryUpdateResponse();
        categoryUpdateResponse.Id = updatedCategory.Id;
        categoryUpdateResponse.Name = updatedCategory.Name;
        categoryUpdateResponse.CreatedDate = updatedCategory.CreatedDate;
        categoryUpdateResponse.UpdatedDate = updatedCategory.UpdatedDate;

        return categoryUpdateResponse;

    }
    public CategoryDeleteResponse Delete(CategoryDeleteRequest categoryDeleteRequest)
    {

        Category category = _categoryDal.Get(c=>c.Id == categoryDeleteRequest.Id);
        _categoryBusinessRules.CategoryShouldBeExistsWhenSelected(category);

        category.DeletedDate = DateTime.Now;

        Category deletedCategory = _categoryDal.Delete(category);

        CategoryDeleteResponse deletedCategoryResponse = new CategoryDeleteResponse();
        deletedCategoryResponse.Id = deletedCategory.Id;
        deletedCategoryResponse.Name = deletedCategory.Name;
        deletedCategoryResponse.DeletedDate = deletedCategory.DeletedDate;
        deletedCategoryResponse.CreatedDate = deletedCategory.CreatedDate;
        return deletedCategoryResponse;
    }

    public List<CategoryGetAllResponse> GetAll()
    {
        List<CategoryGetAllResponse> list = new List<CategoryGetAllResponse>();
        List<Category> categories = _categoryDal.GetAll();
        foreach (var category in categories)
        {
            CategoryGetAllResponse categoryGetAllResponse = new CategoryGetAllResponse();
            categoryGetAllResponse.Id = category.Id;
            categoryGetAllResponse.CreatedDate = category.CreatedDate;
            categoryGetAllResponse.Name = category.Name;
            list.Add(categoryGetAllResponse);

        }
        return list;
    }

    public CategoryGetByIdResponse GetById(int id)
    {
        Category category = _categoryDal.Get(c => c.Id == id);
        _categoryBusinessRules.CategoryShouldBeExistsWhenSelected(category);
        CategoryGetByIdResponse categoryGetByIdResponse = new CategoryGetByIdResponse();

        categoryGetByIdResponse.Id = category.Id;
        categoryGetByIdResponse.Name = category.Name;
        categoryGetByIdResponse.CreatedDate = category.CreatedDate;

        return categoryGetByIdResponse;
    }

    
}
