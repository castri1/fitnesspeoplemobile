using FitnessPeopleMobile.Models;
using Services;
using System;
using System.Linq;
using System.Web.Http;

namespace FitnessPeopleMobile.Controllers
{
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                var prod = new ProductModel
                {
                    Id = product.Id,
                    FullDescription = product.FullDescription,
                    Name = product.Name,
                    ShortDescription = product.ShortDescription,
                    VendorPrice = product.VendorPrice,
                    ProductAttributes = product.ProductVariantAttributeCombinations.Where(j => j.StockQuantity > 0).SelectMany(i => i.ProductUnits.Select(j => new ProductAttributesModel
                    {
                        Name = j.ProductAttributes,
                    })).ToList()
                };

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("category/{categoryId:int}")]
        public IHttpActionResult GetByCategory(int categoryId)
        {
            try
            {
                string order = "";
                var products = _productService.GetProductsByCategoryId(categoryId, order).Select(i => new ProductModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    VendorPrice = i.VendorPrice,
                    Url = string.Format("http://www.fitnesspeople.com.co/content/images/thumbs/{0}", i.Picture),
                    DisplayOrder = i.DisplayOrder
                });
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
