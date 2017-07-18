namespace CSBI.Clients.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(AddressMetadata.TableName)]
    public class AddressEntity : BaseEntity
    {
        [Column(AddressMetadata.AddressType)]
        public int AddressType { get; set; }
        [Column(AddressMetadata.ClientId)]
        public Guid ClientId { get; set; }
        [Column(AddressMetadata.RawAddress)]
        public string RawAddress { get; set; }
    }
}