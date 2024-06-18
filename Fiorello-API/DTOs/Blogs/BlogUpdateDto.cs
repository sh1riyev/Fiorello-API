using System;
namespace Fiorello_API.DTOs.Blogs
{
	public class BlogUpdateDto
	{
        public string ?Title { get; set; }
        public string ?Description { get; set; }
        public string Image { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}

