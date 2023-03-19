using Model;
using Model.Dto;

namespace Service
{
    public interface IServices
    {
        Task CreateShortUrl(string url);
        Task<string> GetShortUrl(string urlData);
        Task<List<ShortUrl>> GetAllShortedUrls();
    }
}