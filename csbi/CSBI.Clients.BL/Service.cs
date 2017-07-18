namespace CSBI.Clients.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Contracts;
    using DAL;
    using DAL.Contracts;
    using Models;

    public class Service : IService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public Service(IRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(ClientsFilter clientsFilter)
        {
            var result = await _repository.GetListAsync(new Dictionary<string, object>
            {
                {ClientsMetadata.FirstName, clientsFilter.FirstName },
                {ClientsMetadata.MiddleName, clientsFilter.MiddleName },
                {ClientsMetadata.LastName, clientsFilter.LastName },
                {AddressMetadata.RawAddress, clientsFilter.Address },
            }, clientsFilter.Offset, clientsFilter.Limit);

            return result.Any() ? _mapper.Map<IEnumerable<Client>>(result) : null;
        }

        public async Task<int> GetClientsCountAsync()
        {
            return await _repository.GetCountAsync();
        }
    }
}