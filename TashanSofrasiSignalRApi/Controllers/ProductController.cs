using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TashanSofrasi.BusinessLayer.Abstract;
using TashanSofrasi.DTOLayer.ProductDTO;
using TashanSofrasi.EntityLayer.Entities;

namespace TashanSofrasiSignalRApi.Controllers
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
        public IActionResult ListProduct()
        {
            var values = _mapper.Map<List<ResultProductDTO>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("ListProductWithCategory")]
        public IActionResult ListProductWithCategory() 
        {
            var value = _mapper.Map<List<ResultProductWithCategoryDTO>>(_productService.TGetProductWithCategories());
            return Ok(value);
        }   

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO createProductDTO)
        {
            var newValue = _mapper.Map<Product>(createProductDTO);
            _productService.TAdd(newValue);
            return Ok("Yeni ürün kaydı başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün kaydı başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var newValue = _mapper.Map<Product>(updateProductDTO);
            _productService.TUpdate(newValue);
            return Ok("Ürün kaydı başarıyla güncellendi!");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }

    }
}
