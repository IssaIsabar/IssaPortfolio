using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssaPortfolio.Library
{
    public class PortfolioItemDetails : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string DateCreated { get; set; }
        public PortfolioItem PortfolioItem { get; set; }

        public PortfolioItemDetails(string name, string description, string imageURL, string dateCreated)
        {
            Name = name;
            Description = description;
            ImageURL = imageURL;
            DateCreated = dateCreated;
        }
    }
}
