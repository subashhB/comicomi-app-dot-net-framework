using ComiComi.Data.Base;
using ComiComi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComiComi.Data.Services
{
    public class PublisherService : EntityBaseRepository<Publisher>, IPublisherService
    {
        public PublisherService(AppDbContext context): base(context){}
        
    }
}
