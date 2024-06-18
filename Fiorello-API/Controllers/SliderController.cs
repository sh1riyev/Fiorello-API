using System;
using AutoMapper;
using Fiorello_API.Data;
using Fiorello_API.DTOs.Sliders;
using Fiorello_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Controllers
{
	public class SliderController :BaseController
	{
		private readonly ISliderService _service;
		private readonly IMapper _mapper;
		public SliderController(ISliderService service,
			IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _service.GetAll();

			var mappedDatas = _mapper.Map<List<SliderDto>>(response);

			return Ok(mappedDatas);
		}
	}
}

