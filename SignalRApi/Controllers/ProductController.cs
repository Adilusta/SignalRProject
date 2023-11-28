using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _mapper.Map<List<ResultProductWithCategoryDto>>(_productService.GetProductsWithCategories());
            return Ok(value);
            //var context = new SignalRDbContext();
            //var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            //{
            //    Description = y.Description,
            //    ImageUrl = y.ImageUrl,
            //    Price = y.Price,
            //    ProductID = y.ProductID,
            //    ProductName = y.ProductName,
            //    ProductStatus = y.ProductStatus,
            //    CategoryName = y.Category.CategoryName
            //}).ToList();

        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            return Ok("Ürün Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _mapper.Map<ResultProductDto>(_productService.TGetById(id));
            //var value = _productService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Ürün Bilgisi Güncellendi");
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var count = _productService.GetProductCount();
            return Ok(count);
        }
    }
}
