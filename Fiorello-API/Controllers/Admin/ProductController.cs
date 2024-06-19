using System;
using AutoMapper;
using Fiorello_API.DTOs;
using Fiorello_API.DTOs.Products;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiorello_API.Controllers.Admin
{
	public class ProductController :BaseController
	{
        private readonly IProductService _service;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService service,
            IFileService fileService,
            IMapper mapper,
            ICategoryService categoryService)
        {
            _service = service;
            _fileService = fileService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existCategory = await _categoryService.FindById(request.CategoryId);
            if (existCategory is null) return NotFound();
            if (request.NewImages == null || !request.NewImages.Any())
                return BadRequest("At least one image is required.");
            List<ProductImage> images = new();
            foreach (var item in request.NewImages)
            {
                if (item?.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }

                string[] allowedFileExtentions = { ".jpg", ".jpeg", ".png" };
                string createdImageName = await _fileService.SaveFileAsync(item, allowedFileExtentions);
                images.Add(new ProductImage { Name = createdImageName });
            }
            images.FirstOrDefault().IsMain = true;
            var product = _mapper.Map<Product>(request);
            product.ProductImages = images;
            await _service.Create(product);
            return CreatedAtAction(nameof(Create), product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var product = await _service.FindById((int)id);
            if (product is null) return NotFound();

            await _service.Delete(product);
            foreach (var item in product.ProductImages)
            {
                _fileService.DeleteFile(item.Name);
            }
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int? id, [FromForm] ProductUpdateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existCategory = await _categoryService.FindById((int)request.CategoryId);
            if (existCategory is null) return NotFound();
            if (id is null) return BadRequest();
            var product = await _service.FindById((int)id);
            if (product is null) return NotFound();
            return Ok();

        }
    }
}

