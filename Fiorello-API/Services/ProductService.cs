using System;
using Fiorello_API.Data;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Services
{
	public class ProductService: IProductService
	{
		private readonly AppDbContext _context;
		public ProductService(AppDbContext context)
		{
			_context = context;
		}

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> FindById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}

