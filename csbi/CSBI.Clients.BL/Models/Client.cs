namespace CSBI.Clients.BLL.Models
{
    using System.Collections.Generic;

    public class Client
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Addresses { get; set; }
    }
}
