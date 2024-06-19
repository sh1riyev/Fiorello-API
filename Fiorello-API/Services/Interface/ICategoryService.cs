using System;
using Fiorello_API.Models;

namespace Fiorello_API.Services.Interface
{
	public interface ICategoryService
	{
        Task<List<Category>> GetAll();
        Task<Category> Create(Category category);
        Task Delete(Category category);
        Task<Category> FindById(int id);
        Task<Category> Update(Category category);
    }
}

