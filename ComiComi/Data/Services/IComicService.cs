using ComiComi.Data.Base;
using ComiComi.Data.ViewModel;
using ComiComi.Models;

namespace ComiComi.Data.Services
{
    public interface IComicService: IEntityBaseRepository<Comic>
    {
        Task<Comic> GetComicByIdAsync(int id);
        Task<ComicDropDownVM> GetComicDropDownValues();
        Task AddNewComic(NewComicVM data);
        Task UpdateComicAsync(NewComicVM data);


    }
}
