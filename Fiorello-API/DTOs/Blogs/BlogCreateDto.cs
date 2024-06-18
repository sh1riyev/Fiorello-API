using System;
namespace Fiorello_API.DTOs.Blogs
{
	public class BlogCreateDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile NewImage { get; set; }
	}
}

