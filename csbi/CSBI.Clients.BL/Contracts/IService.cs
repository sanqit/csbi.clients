namespace CSBI.Clients.BLL.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IService
    {
        Task<IEnumerable<Client>> GetClientsAsync(ClientsFilter clientsFilter);
        Task<int> GetClientsCountAsync();
    }
}
