using System;
namespace Fiorello_API.DTOs.Experts
{
	public class ExpertUpdateDto
	{
        public IFormFile ?NewImage { get; set; }
        public string Image { get; set; }
        public string ?Name { get; set; }
        public string ?Position { get; set; }
    }
}

