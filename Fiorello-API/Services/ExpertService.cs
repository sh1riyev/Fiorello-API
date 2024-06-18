using System;
using Fiorello_API.Data;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Services
{
	public class ExpertService : IExpertService
	{
        private readonly AppDbContext _context;
        public ExpertService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Expert> Create(Expert expert)
        {
            await _context.Experts.AddAsync(expert);
            await _context.SaveChangesAsync();
            return expert;
        }

        public async Task Delete(Expert expert)
        {
            _context.Experts.Remove(expert);
            await _context.SaveChangesAsync();
        }

        public async Task<Expert> FindById(int id)
        {
            return await _context.Experts.FindAsync(id);
        }

        public async Task<List<Expert>> GetAll()
        {
            return await _context.Experts.ToListAsync();
        }

        public async Task<Expert> Update(Expert expert)
        {
            _context.Experts.Update(expert);
            await _context.SaveChangesAsync();
            return expert;
        }
    }
}

