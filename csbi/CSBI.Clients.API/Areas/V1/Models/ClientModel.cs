namespace CSBI.Clients.API.Areas.V1.Models
{
    using System.Collections.Generic;

    public class ClientModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Addresses { get; set; }
    }
}
