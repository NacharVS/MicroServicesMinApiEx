using Microsoft.EntityFrameworkCore;

namespace MicroServices.ClientService.Infrastructure
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> opt) : base(opt)
        {

        }
    }
}
