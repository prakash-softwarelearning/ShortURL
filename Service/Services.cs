using Model;
using Model.Dto;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Services : IServices
    {
        private readonly IRepo _repo;
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public Services(IRepo repo)
        {
            _repo = repo;
        }

        public async Task CreateShortUrl(string url)
        {
            var random = new Random();
            var randomstr = new string(Enumerable.Repeat(chars, 8)
                .Select(x => x[random.Next(x.Length)]).ToArray());
            var shortUrl = new ShortUrlDto() {
                MainUrl = url,
                ShortUrls = randomstr
            };
            await _repo.CreateShortUrl(shortUrl);
        }

        public async Task<string> GetShortUrl(string urlData)
        {
            return await _repo.GetShortUrl(urlData);
        }

        public async Task<List<ShortUrl>> GetAllShortedUrls()
        { 
          return await _repo.GetAllShortedUrls();
        }
    }
}
