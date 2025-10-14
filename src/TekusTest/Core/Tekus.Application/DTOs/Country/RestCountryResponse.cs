namespace Tekus.Application.DTOs.Country
{
    public class RestCountryResponse
    {
        public NameData name { get; set; }
        public string cca2 { get; set; }

        public class NameData
        {
            public string official { get; set; }
            public string common { get; set; }
        }
    }
}
