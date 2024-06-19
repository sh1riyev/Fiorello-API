using System;
using Fiorello_API.Models;

namespace Fiorello_API.Services.Interface
{
	public interface IProductService
	{
        Task<List<Product>> GetAll();
        Task<Product> Create(Product product);
        Task Delete(Product product);
        Task<Product> FindById(int id);
        Task<Product> Update(Product product);
    }
}

