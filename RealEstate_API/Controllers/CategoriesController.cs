﻿using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Repositories.CategoryRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryByID(byte id)
        {
            return Ok(await _categoryRepository.GetByIDCategoryAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            return Ok(await _categoryRepository.GetAllCategoryAsync());
        }
        [HttpPost]
        public IActionResult CategoryCreate(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.AddCategory(createCategoryDto);
            return Ok("Kategori Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(byte id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Kategori Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Kategori Başarılı Bir Şekilde Güncellendi");
        }
    }
}