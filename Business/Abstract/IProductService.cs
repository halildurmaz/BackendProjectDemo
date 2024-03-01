using Business.Dtos.Requests;
using Business.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IProductService
{
    ProductAddResponse Add(ProductAddRequest productAddRequest);
    ProductUpdateResponse Update(ProductUpdateRequest productUpdateRequest);
    ProductDeleteResponse Delete(ProductDeleteRequest productDeleteRequest);
    List<ProductGetAllResponse> GetAll();
    ProductGetByIdResponse GetById(int id);
}
