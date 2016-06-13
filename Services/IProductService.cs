using Core;
using Core.Dto;
using Core.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
        IPagedList<Product> GetAll(int page, int PageSize, string name = null);
        IList<Product> GetProductListByName(string name = null);
        IList<ProductDto> GetProductsByCategoryId(int categoryId, string order);
        Product GetProductDetailsById(int id);
    }
}
