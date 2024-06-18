using System;
namespace Fiorello_API.Services.Interface
{
	public interface IFileService
	{
        Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions);
        void DeleteFile(string fileNameWithExtension);
    }
}

