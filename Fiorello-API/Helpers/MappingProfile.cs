using System;
using AutoMapper;
using Fiorello_API.DTOs.Blogs;
using Fiorello_API.DTOs.Sliders;
using Fiorello_API.Models;

namespace Fiorello_API.Helpers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Slider, SliderDto>();
			CreateMap<BlogCreateDto,Blog >();
        }
	}
}

