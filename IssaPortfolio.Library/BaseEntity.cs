namespace IssaPortfolio.Library
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.Now;
        }
    }
}
