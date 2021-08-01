using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity // Herança
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get;  set; } //não é private porque é uma propriedade de navegação
        public Category Category { get;  set; } //não é private porque é uma propriedade de navegação

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id, it has to be bigger than 0");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            
            DomainExceptionValidation.When(name.Length < 3, "Name too short. Name has to have 3 characters at least");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 3, "Description too short. Description has to have 3 characters at least");

            DomainExceptionValidation.When(price < 0, "Price invalid. It has to be higher than 0");

            DomainExceptionValidation.When(stock < 0, "Stock invalid. It has to be higher than 0");

            DomainExceptionValidation.When(image?.Length > 250, "Image name invalid. It can't trespass 250 characters"); // used ? because, doing this if image is null, Exception will not thrown

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
