using ComiComi.Data.Base;
using ComiComi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComiComi.Data.Services
{
    public class ArtistService : EntityBaseRepository<Artist>, IArtistService
    {
        public ArtistService(AppDbContext context): base(context){}
    }
}
