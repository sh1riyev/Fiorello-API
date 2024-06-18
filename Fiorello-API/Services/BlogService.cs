using System;
using Fiorello_API.Data;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Services
{
	public class BlogService : IBlogService
	{
        private readonly AppDbContext _context;
		public BlogService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<Blog> Create(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task Delete(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<Blog> FindById(int id)
        {
           return await _context.Blogs.FindAsync(id);
        }

        public async Task<List<Blog>> GetAll()
        {
           return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> Update(Blog blog)
        {
             _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
            return blog;
        }
    }
}

