using System;
using Fiorello_API.Data;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Services
{
	public class CategoryService : ICategoryService
	{
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> FindById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}

