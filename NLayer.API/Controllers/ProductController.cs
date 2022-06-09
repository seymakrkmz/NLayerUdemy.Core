using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;


        public ProductController(IService<Product> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));   
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDtos = _mapper.Map<ProductDto>(product);
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));   
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDtos));

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productDtos = _mapper.Map<ProductDto>(product);
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));   
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDtos));

        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));   
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
        //delete api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
      
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));   
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

    }
}