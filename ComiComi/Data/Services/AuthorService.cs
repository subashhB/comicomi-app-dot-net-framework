using ComiComi.Data.Base;
using ComiComi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComiComi.Data.Services
{
    public class AuthorService : EntityBaseRepository<Author>, IAuthorService
    {
        public AuthorService(AppDbContext context) : base(context) { }
        
    }
}
