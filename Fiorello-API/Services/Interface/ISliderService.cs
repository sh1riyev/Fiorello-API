using System;
using Fiorello_API.Models;

namespace Fiorello_API.Services.Interface
{
	public interface ISliderService
	{
		Task<List<Slider>> GetAll();
		Task<Slider> Create(Slider slider);
		Task Delete(Slider slider);
		Task<Slider> FindById(int id);
		Task<Slider> Update(Slider slider);
	}
}

