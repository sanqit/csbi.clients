namespace CSBI.Clients.DAL.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository
    {
        Task<IEnumerable<ClientEntity>> GetListAsync(Dictionary<string, object> filter, int? offset = null, int? limit = null);
        Task<int> GetCountAsync();
    }
}
