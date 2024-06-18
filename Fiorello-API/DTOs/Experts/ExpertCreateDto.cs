using System;
namespace Fiorello_API.DTOs.Experts
{
	public class ExpertCreateDto
	{
        public IFormFile NewImage { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }
}

