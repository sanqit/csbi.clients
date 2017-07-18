namespace CSBI.Clients.BLL.Models
{
    public class ClientsFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }

        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
