using System;
using AutoMapper;
using Fiorello_API.DTOs.Experts;
using Fiorello_API.DTOs.Infos;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_API.Controllers.Admin
{
    public class InfoAdminController : BaseController
    {
        private readonly IInfoService _service;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public InfoAdminController(IInfoService service,
            IFileService fileService,
            IMapper mapper)
        {
            _service = service;
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InfoCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (request.NewImage?.Length > 1 * 1024 * 1024)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
            }
            string[] allowedFileExtentions = { ".jpg", ".jpeg", ".png" };
            string createdImageName = await _fileService.SaveFileAsync(request.NewImage, allowedFileExtentions);
            var result = _mapper.Map<Info>(request);
            result.Image = createdImageName;
            await _service.Create(result);
            return CreatedAtAction(nameof(Create), result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var info = await _service.FindById((int)id);
            if (info is null) return NotFound();

            await _service.Delete(info);
            _fileService.DeleteFile(info.Image);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] InfoUpdateDto request, int? id)
        {
            if (id is null) return BadRequest();
            var blog = await _service.FindById((int)id);
            if (blog is null) return NotFound();

            if (request.NewImage != null)
            {
                if (request.NewImage?.Length > 1 * 1024 * 1024)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File size should not exceed 1 MB");
                }
                string[] allowedFileExtentions = { ".jpg", ".jpeg", ".png" };
                string createdImageName = await _fileService.SaveFileAsync(request.NewImage, allowedFileExtentions);
                _fileService.DeleteFile(blog.Image);
                request.Image = createdImageName;
            }
            var updatedExpert = _service.Update(_mapper.Map<Info>(request));
            return Ok(updatedExpert);
        }
    }
}
