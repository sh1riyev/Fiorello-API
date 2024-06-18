using System;
using Fiorello_API.Models;

namespace Fiorello_API.Services.Interface
{
	public interface IBlogService
	{
        Task<List<Blog>> GetAll();
        Task<Blog> Create(Blog blog);
        Task Delete(Blog blog);
        Task<Blog> FindById(int id);
        Task<Blog> Update(Blog blog);
    }
}

