using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repositories;
using AutoMapper;
using ProductApi.Dtos;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                var products = await _repository.GetAll();
                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
                return Ok(productDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            try
            {
                var product = await _repository.Get(id);

                if (product == null)
                {
                    return NotFound();
                }
                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Add(product);
            await _repository.SaveChanges();
            var createdProductDto = _mapper.Map<ProductDto>(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProductDto.Id }, createdProductDto);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }
        //    var productToUpdate = await _repository.Get(id);
        //    if (productToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _repository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            _repository.Delete(product);
            await _repository.SaveChanges();

            return NoContent();
        }
    }
}
