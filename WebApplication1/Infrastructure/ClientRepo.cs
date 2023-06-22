using MicroServices.ClientService.Application;
using MicroServices.ClientService.Core;

namespace MicroServices.ClientService.Infrastructure
{
    public class ClientRepo : IClienRepo
    {
        private readonly ClientDbContext _dbContext;
        public ClientRepo(ClientDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task DeleteClientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SendClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClientById(int id, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
