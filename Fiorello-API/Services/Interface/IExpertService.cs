using System;
using Fiorello_API.Models;

namespace Fiorello_API.Services.Interface
{
	public interface IExpertService
	{
        Task<List<Expert>> GetAll();
        Task<Expert> Create(Expert expert);
        Task Delete(Expert expert);
        Task<Expert> FindById(int id);
        Task<Expert> Update(Expert expert);
    }
}

