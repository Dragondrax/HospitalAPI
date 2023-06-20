namespace Hospital.Application.API.Model
{
    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenModel UserToken { get; set; }
    }

    public class UserTokenModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimModel> Claim { get; set; }
        public IList<string> Role { get; set; }
    }
    public class ClaimModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

}
