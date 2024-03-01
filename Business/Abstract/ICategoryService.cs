using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICategoryService
{
    CategoryAddResponse Add(CategoryAddRequest categoryAddRequest);
    CategoryUpdateResponse Update(CategoryUpdateRequest categoryUpdateRequest);
    CategoryDeleteResponse Delete(CategoryDeleteRequest categoryDeleteRequest);
    List<CategoryGetAllResponse> GetAll();
    CategoryGetByIdResponse GetById(int id);
    
}
