namespace Mantasflowers.Contracts.User.Response
{
    public class GetDetailedUserResponse : GetUserResponse
    {
        public GetUserAddressResponse Address { get; set; }

        public GetUserContactDetailsResponse ContactDetails { get; set; }

        public string LoginEmail { get; set; }

        public bool IsLoginEmailVerified { get; set; }
    }
}
