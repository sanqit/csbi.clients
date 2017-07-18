namespace CSBI.Clients.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Dapper.FastCrud.DatabaseGeneratedDefaultValue]
        [Column("id")]
        public Guid Id { get; set; }
    }
}