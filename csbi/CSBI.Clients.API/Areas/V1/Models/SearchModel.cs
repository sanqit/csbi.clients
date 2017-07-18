namespace CSBI.Clients.API.Areas.V1.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            Offset = 0;
            Limit = 20;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }

        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}