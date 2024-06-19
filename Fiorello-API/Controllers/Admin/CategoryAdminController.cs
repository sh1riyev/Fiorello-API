using System;
using AutoMapper;
using Fiorello_API.DTOs.Category;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_API.Controllers.Admin
{
	public class CategoryAdminController : BaseController
	{
        private readonly ICategoryService _service;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public CategoryAdminController(ICategoryService service,
            IFileService fileService,
            IMapper mapper)
        {
            _service = service;
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var categories = await _service.GetAll();
            if(categories.Any(m=>m.Name==request.Name))
            {
                ModelState.AddModelError("Name", "This name is used,try another");
                return BadRequest(ModelState);
            }

            var newCategory = _mapper.Map<Category>(request);
            await _service.Create(newCategory);
            return CreatedAtAction(nameof(Create), newCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var category = await _service.FindById((int)id);
            if (category is null) return NotFound();

            await _service.Delete(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateDto request, int? id)
        {
            if (id is null) return BadRequest();
            var category = await _service.FindById((int)id);
            if (category is null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var categories = await _service.GetAll();
            if (categories.Any(m => m.Name == request.Name&&m.Id!=id))
            {
                ModelState.AddModelError("Name", "This name is used,try another");
                return BadRequest(ModelState);
            }
            var updatedCategory = _mapper.Map(request, category);
            await _service.Update(updatedCategory);
            return Ok(updatedCategory);
        }
    }
}

