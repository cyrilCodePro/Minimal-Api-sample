using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        //For entity framework 
        private Product()
        {

        }
        public Product(ProductId productId,
                       Price price,
                       string name,
                       string description)
        {
            ProductId = productId;
            Price = price;
            Name = name;
            Description = description;
          
        }
        public void SetImageUrl(string imageUrl)=>ImageUrl = imageUrl;

        public ProductId ProductId { get;  private set; }
        public Price Price { get; private set; }
        public string Name { get;private set; }
        public string Description { get;private set; }
        public string ImageUrl { get; private set; }
        public CategoryId CategoryId { get;private set; }
    }
    public record ProductId(Guid Id); 
    public record Price(string currency,decimal Value);
}
