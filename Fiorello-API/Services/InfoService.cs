using System;
using Fiorello_API.Data;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Services
{
	public class InfoService : IInfoService
	{
        private readonly AppDbContext _context;
		public InfoService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<Info> Create(Info info)
        {
            await _context.Infos.AddAsync(info);
            await _context.SaveChangesAsync();
            return info;
        }

        public async Task Delete(Info info)
        {
            _context.Infos.Remove(info);
            await _context.SaveChangesAsync();
        }

        public async Task<Info> FindById(int id)
        {
            return await _context.Infos.FindAsync(id);
        }

        public async Task<List<Info>> GetAll()
        {
            return await _context.Infos.ToListAsync();
        }

        public async Task<Info> Update(Info info)
        {
            _context.Infos.Update(info);
            await _context.SaveChangesAsync();
            return info;
        }
    }
}

