using Core;
using Core.Data;
using Core.Dto;
using Core.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IPagedList<Product> GetAll(int page, int PageSize, string name = null)
        {
            var query = _productRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name.Contains(name));

            query = query.OrderBy(i => i.Id);

            return new PagedList<Product>(query, page, PageSize);
        }

        public IList<Product> GetProductListByName(string name = null)
        {
            var query = _productRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name.Contains(name));

            return query.OrderBy(i => i.Id).Take(10).ToList();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetProductDetailsById(int id)
        {
            if (id == 0)
                return null;

            var prod = _productRepository.GetById(id);
            var product = new Product()
            {
                Id = prod.Id,
                Name = prod.Name,
                ShortDescription = prod.ShortDescription,
                FullDescription = prod.FullDescription,
                ProductVariantAttributeCombinations = prod.ProductVariantAttributeCombinations,
            };
            return prod;
        }

        public IList<ProductDto> GetProductsByCategoryId(int categoryId, string order)
        {
            var query = _productRepository.Table;

            if (!string.IsNullOrEmpty(order))
            {
                if (order == "asc")
                    query = query.OrderBy(i => i.Name);

                if (order == "desc")
                    query = query.OrderByDescending(i => i.Name);
            }

            var result = query.Where(i => i.Product_Category_Mappings.Any(j => j.CategoryId == categoryId) 
                        && !i.Deleted
                        && i.ProductVariantAttributeCombinations.Any(j => j.StockQuantity > 0)).ToList();

            var listOfProduct = result.Select(i => new ProductDto
            {
                Id = i.Id,
                Name = i.Name,
                VendorPrice = i.VendorPrice,
                Picture = string.Format("{0}_{1}.{2}", 
                            i.ProductPictures.First(j => j.DisplayOrder == 0).Picture.Id.ToString("0000000"), 
                            i.ProductPictures.First(j => j.DisplayOrder == 0).Picture.SeoFilename, 
                            GetFileExtensionFromMimeType(i.ProductPictures.First(j => j.DisplayOrder == 0).Picture.MimeType))
            });

            return listOfProduct.ToList();
        }

        protected virtual string GetFileExtensionFromMimeType(string mimeType)
        {
            if (mimeType == null)
                return null;

            string[] parts = mimeType.Split('/');
            string lastPart = parts[parts.Length - 1];
            switch (lastPart)
            {
                case "pjpeg":
                    lastPart = "jpg";
                    break;
                case "x-png":
                    lastPart = "png";
                    break;
                case "x-icon":
                    lastPart = "ico";
                    break;
            }
            return lastPart;
        }
    }
}
