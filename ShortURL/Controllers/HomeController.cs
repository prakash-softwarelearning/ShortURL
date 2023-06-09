﻿using Microsoft.AspNetCore.Mvc;
using Service;
using Model.Dto;

namespace ShortURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IServices _service;
        public HomeController(IServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllShortedUrls()
        {
            return Ok(await _service.GetAllShortedUrls());
        }


        /// <summary>
        /// Saving the Main Url and Shorted Url
        /// </summary>
        /// <param name = "originalUrl" ></ param >
        /// < returns ></ returns >
        [HttpPost]
        public async Task<ActionResult> ShortUrlCreate(string originalUrl)
        {
            await _service.CreateShortUrl(originalUrl);

            return Ok(true);
        }
    }
}
