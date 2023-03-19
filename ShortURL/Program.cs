using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using Repository;
using Service;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShortUrlDBContext>
(o => o.UseInMemoryDatabase("MyDatabase"));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IServices, Services>();
builder.Services.AddTransient<IRepo, Repo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

//Return original url
app.MapFallback(async (ShortUrlDBContext db, HttpContext ctx) =>
{
    var path = ctx.Request.Path.ToUriComponent().Trim('/');
    var urlmatch = await db.ShortUrl.FirstOrDefaultAsync(x => x.ShortUrls.Trim() == path.Trim());

    if (urlmatch == null)
        return Results.BadRequest("Bad Request");

    return Results.Redirect(urlmatch.MainUrl);
});
app.Run();
