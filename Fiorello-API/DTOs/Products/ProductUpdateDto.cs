﻿using System;
namespace Fiorello_API.DTOs.Products
{
	public class ProductUpdateDto
	{
        public string ?Name { get; set; }
        public decimal ?Price { get; set; }
        public string ?Description { get; set; }
        public int ?CategoryId { get; set; }
        public string Image { get; set; }
        public List<IFormFile> ? NewImages { get; set; }
    }
}

