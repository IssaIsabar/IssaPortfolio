﻿namespace IssaPortfolio.Library
{
    public class PortfolioItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public PortfolioItem(string name, string description, string imageUrl)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }


    }

}
