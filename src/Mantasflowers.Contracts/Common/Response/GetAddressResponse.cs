namespace Mantasflowers.Contracts.Common.Response
{
    public abstract class GetAddressResponse
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Zipcode { get; set; }
    }
}
