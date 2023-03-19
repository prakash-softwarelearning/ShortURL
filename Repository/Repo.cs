using Microsoft.EntityFrameworkCore;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repo : IRepo, IDisposable
    {
        private ShortUrlDBContext context;

        public Repo(ShortUrlDBContext context)
        {
            this.context = context;
        }

        public async Task CreateShortUrl(ShortUrlDto shortUrl)
        {
            var shorttbl = new ShortUrl()
            {
                 MainUrl = shortUrl.MainUrl,
                 ShortUrls = shortUrl.ShortUrls,
            };
           await context.ShortUrl.AddRangeAsync(shorttbl);
           await Save();
        }

        public async Task<string> GetShortUrl(string urlData)
        {
            return await context.ShortUrl.Where(x=>x.ShortUrls.Trim() == urlData.Trim()).Select(x=>x.ShortUrls).FirstOrDefaultAsync();
        }

        public async Task<List<ShortUrl>> GetAllShortedUrls()
        { 
           return await context.ShortUrl.AsNoTracking().OrderByDescending(x=>x.Id).ToListAsync();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
             context.SaveChanges();
        }
    }
}
