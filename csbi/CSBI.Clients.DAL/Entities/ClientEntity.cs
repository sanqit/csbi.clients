namespace CSBI.Clients.DAL.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(ClientsMetadata.TableName)]
    public class ClientEntity : BaseEntity
    {
        [Column(ClientsMetadata.FirstName)]
        public string FirstName { get; set; }

        [Column(ClientsMetadata.MiddleName)]
        public string MiddleName { get; set; }

        [Column(ClientsMetadata.LastName)]
        public string LastName { get; set; }

        public List<AddressEntity> Addresses { get; set; }
    }
}
