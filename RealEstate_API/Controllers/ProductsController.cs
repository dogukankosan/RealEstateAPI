﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.ProductRepository;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            return Ok(await _productRepository.GetAllProductAsync());
        }
        [HttpGet("GetByCategoryIDProduct")]
        public async Task<IActionResult> GetByCategoryIDProduct()
        {
            return Ok(await _productRepository.GetByCategoryIDProductAsync());
        }
    }
}