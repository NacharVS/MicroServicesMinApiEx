using MicroServices.ClientService.Core;

namespace MicroServices.ClientService.Application
{
    public interface IClienRepo
    {
        Task SendClient(Client client);
        Task<Client> GetClientByIdAsync(int id);
        Task UpdateClientById(int id, Client client);
        Task DeleteClientByIdAsync(int id);

    }
}
