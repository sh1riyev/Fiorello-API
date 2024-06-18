using System;
namespace Fiorello_API.DTOs.Infos
{
	public class InfoUpdateDto
	{
        public IFormFile ?NewImage { get; set; }
        public string Image { get; set; }
        public string ?Title { get; set; }
        public string ?Description { get; set; }
    }
}

