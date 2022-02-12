namespace IssaPortfolio.Library
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
