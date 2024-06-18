using System;
using Fiorello_API.Data;
using Fiorello_API.Models;
using Fiorello_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_API.Services
{
	public class SliderService : ISliderService
	{
        private readonly AppDbContext _context;
		public SliderService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<Slider> Create(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return slider;
        }

        public async Task Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<Slider> FindById(int id)
        {
            return await _context.Sliders.FindAsync(id);
        }

        public async Task<List<Slider>> GetAll()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<Slider> Update(Slider slider)
        {
            _context.Sliders.Update(slider);
            await _context.SaveChangesAsync();
            return slider;
        }
    }
}

