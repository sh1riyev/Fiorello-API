using System;
using AutoMapper;
using Fiorello_API.DTOs.Sliders;
using Fiorello_API.Helpers;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_API.Controllers.Admin
{
	public class SliderAdminController :BaseController
	{
		private readonly ISliderService _service;
		private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public SliderAdminController(ISliderService service,
			IFileService fileService,
			IMapper mapper)
		{
			_service = service;
			_fileService = fileService;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
            if (request.NewImage?.Length > 1 * 1024 * 1024)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
            }
            string[] allowedFileExtentions = { ".jpg", ".jpeg", ".png" };
            string createdImageName = await _fileService.SaveFileAsync(request.NewImage, allowedFileExtentions);

            var slider = new Slider
            {
                Image = createdImageName
            };
            var createdProduct = await _service.Create(slider);
            return CreatedAtAction(nameof(Create), createdProduct);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int ? id)
        {
            if (id is null) return BadRequest();
            var slider = await  _service.FindById((int)id);
            if (slider is null) return NotFound();

            await _service.Delete(slider);
            _fileService.DeleteFile(slider.Image);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] SliderEditDto request,int?id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id is null) return BadRequest();
            var slider = await _service.FindById((int)id);
            if (slider is null) return NotFound();
            string oldImage = slider.Image;
            if (request.NewImage != null)
            {
                if (request.NewImage?.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = { ".jpg", ".jpeg", ".png" };
                string createdImageName = await _fileService.SaveFileAsync(request.NewImage, allowedFileExtentions);
                _fileService.DeleteFile(slider.Image);
                request.Image = createdImageName;
            }

            slider.Image = request.Image;

            var updatedSlider = await _service.Update(slider);

            if (request.NewImage != null)
                _fileService.DeleteFile(oldImage);

            return Ok(updatedSlider);
        }
    }
}

