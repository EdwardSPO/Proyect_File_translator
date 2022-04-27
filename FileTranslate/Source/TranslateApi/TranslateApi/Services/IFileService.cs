using Microsoft.AspNetCore.Http;


namespace TranslateApi.Services
{
    public interface IFileService
    {
     
        void Upload(IFormFile file, string subDirectory);
    }
}