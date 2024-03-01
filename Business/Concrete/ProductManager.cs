using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public ProductAddResponse Add(ProductAddRequest productAddRequest)
    {
        Product product = new Product();

        product.Name = productAddRequest.Name;
        product.UnitPrice = productAddRequest.UnitPrice;
        product.CategoryId = productAddRequest.CategoryId;
        product.StockAmount = productAddRequest.StockAmount;
        product.CreatedDate = DateTime.Now;

        Product createdProduct = _productDal.Add(product);

        ProductAddResponse productAddResponse = new ProductAddResponse();

        productAddResponse.Id = createdProduct.Id;
        productAddResponse.CategoryId = createdProduct.CategoryId;
        productAddResponse.Name = createdProduct.Name;
        productAddResponse.UnitPrice = createdProduct.UnitPrice;
        productAddResponse.StockAmount = createdProduct.StockAmount;
        productAddResponse.CreatedDate = createdProduct.CreatedDate;

        return productAddResponse;
    }

    public ProductDeleteResponse Delete(ProductDeleteRequest productDeleteRequest)
    {
        Product product = _productDal.Get(c => c.Id == productDeleteRequest.Id);
        product.DeletedDate = DateTime.Now;

        var deletedProduct = _productDal.Delete(product);

        ProductDeleteResponse deletedProductResponse = new ProductDeleteResponse();

        deletedProductResponse.Id = deletedProduct.Id;
        deletedProductResponse.Name = deletedProduct.Name;
        deletedProductResponse.CategoryId = deletedProduct.CategoryId;
        deletedProductResponse.UnitPrice = deletedProduct.UnitPrice;
        deletedProductResponse.StockAmount = deletedProduct.StockAmount;
        deletedProductResponse.DeletedDate = deletedProduct.DeletedDate;
        deletedProductResponse.CreatedDate = deletedProduct.CreatedDate;
        return deletedProductResponse;
    }

    public List<ProductGetAllResponse> GetAll()
    {
        List<ProductGetAllResponse> list = new List<ProductGetAllResponse>();
        List<Product> products = _productDal.GetAll();
        foreach (var product in products)
        {
            ProductGetAllResponse productGetAllResponse = new ProductGetAllResponse();
            productGetAllResponse.Id = product.Id;
            productGetAllResponse.CategoryId = product.CategoryId;
            productGetAllResponse.Name = product.Name;
            productGetAllResponse.UnitPrice = product.UnitPrice;
            productGetAllResponse.StockAmount = product.StockAmount;
            productGetAllResponse.CreatedDate = product.CreatedDate;
            list.Add(productGetAllResponse);

        }
        return list;
    }

    public ProductGetByIdResponse GetById(int id)
    {
        Product product = _productDal.Get(c => c.Id == id);

        ProductGetByIdResponse productGetByIdResponse = new ProductGetByIdResponse();

        productGetByIdResponse.Id = product.Id;
        productGetByIdResponse.Name = product.Name;
        productGetByIdResponse.UnitPrice = product.UnitPrice;
        productGetByIdResponse.StockAmount = product.StockAmount;
        productGetByIdResponse.CategoryId = product.CategoryId;
        productGetByIdResponse.CreatedDate = product.CreatedDate;

        return productGetByIdResponse;
    }

    public ProductUpdateResponse Update(ProductUpdateRequest productUpdateRequest)
    {
        Product product = _productDal.Get(c => c.Id == productUpdateRequest.Id);

        product.Id = productUpdateRequest.Id;
        product.Name = productUpdateRequest.Name;
        product.UnitPrice = productUpdateRequest.UnitPrice;
        product.StockAmount = productUpdateRequest.StockAmount;
        product.CategoryId = productUpdateRequest.CategoryId;
        product.UpdatedDate = DateTime.Now;


        var updatedProduct = _productDal.Update(product);
        ProductUpdateResponse productUpdateResponse = new ProductUpdateResponse();
        productUpdateResponse.Id = updatedProduct.Id;
        productUpdateResponse.Name = updatedProduct.Name;
        productUpdateResponse.UnitPrice = updatedProduct.UnitPrice;
        productUpdateResponse.StockAmount = updatedProduct.StockAmount;
        productUpdateResponse.CategoryId = updatedProduct.CategoryId;
        productUpdateResponse.CreatedDate = updatedProduct.CreatedDate;
        productUpdateResponse.UpdatedDate = updatedProduct.UpdatedDate;

        return productUpdateResponse;
    }
}
