using Model;
using Model.Dto;

namespace Repository
{
    public interface IRepo : IDisposable
    {
        Task CreateShortUrl(ShortUrlDto shortUrl);
        Task<string> GetShortUrl(string urlData);
        Task<List<ShortUrl>> GetAllShortedUrls();
        Task Save();
    }
}