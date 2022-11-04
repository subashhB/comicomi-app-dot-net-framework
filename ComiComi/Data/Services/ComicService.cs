using ComiComi.Data.Base;
using ComiComi.Data.ViewModel;
using ComiComi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web;

namespace ComiComi.Data.Services
{
    public class ComicService :EntityBaseRepository<Comic>, IComicService
    {
        private readonly AppDbContext _context;
        public ComicService(AppDbContext context): base(context)
        {
            _context = context;        
        }

        public async Task AddNewComic(NewComicVM data)
        {
            var newComic = new Comic()
            {
                Title=data.Title,
                CoverPhotoURL=data.CoverPhotoURL,
                Description=data.Description,
                Price=data.Price,
                Volume=data.Volume,
                Status=data.Status,
                UploadDate = DateTime.Now,
                Genre=data.Genre,
                Serializaton=data.Serializaton,
                Day=data.Day,
                AuthorId = data.AuthorId,
                ArtistId = data.ArtistId,
                PublisherId = data.PublisherId,
            };
            await _context.Comics.AddAsync(newComic);
            await _context.SaveChangesAsync(); 


        }

        public async Task<Comic> GetComicByIdAsync(int id)
        {
            var comicDetails = await _context.Comics
                .Include(ar => ar.Artist)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefaultAsync(n => n.Id == id);
            return comicDetails;
        }

        public async Task<ComicDropDownVM> GetComicDropDownValues()
        {
            var response = new ComicDropDownVM()
            {
                Artists = await _context.Artists.OrderBy(n => n.ArtistName).ToListAsync(),
                Authors = await _context.Authors.OrderBy(n => n.AuthorName).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.PublisherName).ToListAsync()
            };           
            return response;
        }

        public async Task UpdateComicAsync(NewComicVM data)
        {
            var dbComic = await _context.Comics.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbComic != null)
            {
                dbComic.Title = data.Title;
                dbComic.CoverPhotoURL = data.CoverPhotoURL;
                dbComic.Description = data.Description;
                dbComic.Price = data.Price;
                dbComic.Volume = data.Volume;
                dbComic.Status = data.Status;
                dbComic.Genre = data.Genre;
                dbComic.Serializaton = data.Serializaton;
                dbComic.Day = data.Day;
                dbComic.AuthorId = data.AuthorId;
                dbComic.ArtistId = data.ArtistId;
                dbComic.PublisherId = data.PublisherId;
 
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
