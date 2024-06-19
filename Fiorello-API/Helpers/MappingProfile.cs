using System;
using AutoMapper;
using Fiorello_API.DTOs;
using Fiorello_API.DTOs.Blogs;
using Fiorello_API.DTOs.Category;
using Fiorello_API.DTOs.Experts;
using Fiorello_API.DTOs.Infos;
using Fiorello_API.DTOs.Products;
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
			CreateMap<BlogUpdateDto,Blog >();
			CreateMap<Blog,BlogDto >();
			CreateMap<Expert,ExpertDto >();
			CreateMap<ExpertCreateDto,Expert >();
			CreateMap<ExpertUpdateDto,Expert >();
			CreateMap<Info,InfoDto >();
			CreateMap<InfoUpdateDto,Info >();
			CreateMap<InfoCreateDto,Info >();
			//CreateMap<Category, CategoryDto>();
			CreateMap<CategoryCreateDto,Category >();
			CreateMap<CategoryUpdateDto,Category >();
			CreateMap<ProductCreateDto,Product >();
			CreateMap<ProductCreateDto,Product >();
        }
	}
}

