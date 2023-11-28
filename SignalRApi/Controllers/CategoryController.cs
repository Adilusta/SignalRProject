using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //AUTOMAPPER
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);

            //_categoryService.TAdd(new Category()
            //{
            //    CategoryName = createCategoryDto.CategoryName,
            //    CategoryStatus = true
            //});
            return Ok("Kategori Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _mapper.Map<ResultCategoryDto>(_categoryService.TGetById(id));
            //var value = _categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            //_categoryService.TUpdate(new Category()
            //{
            //    CategoryName = updateCategoryDto.CategoryName,
            //    CategoryID = updateCategoryDto.CategoryID,
            //    CategoryStatus = updateCategoryDto.CategoryStatus
            //});
            return Ok("Kategori Güncellendi");
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var count = _categoryService.TGetCategoryCount();
            return Ok(count);
        }
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			var activeCategoryCount = _categoryService.TGetActiveCategoryCount();
			return Ok(activeCategoryCount);
		}
		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			var passiveCategoryCount = _categoryService.TGetPassiveCategoryCount();
			return Ok(passiveCategoryCount);
		}
	}
}
