using System;
using Fiorello_API.Models;

namespace Fiorello_API.Services.Interface
{
	public interface IInfoService
	{
        Task<List<Info>> GetAll();
        Task<Info> Create(Info info);
        Task Delete(Info info);
        Task<Info> FindById(int id);
        Task<Info> Update(Info info);
    }
}

