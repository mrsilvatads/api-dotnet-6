using ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }
        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp,price);
        }
        public Product( int id,string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "Id dever ser informado");
            Id = id;
            Validation(name, codErp, price);
        }
        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome dever ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Código dever ser informado!");
            DomainValidationException.When(price<0, "O preço dever ser informado e maior que zero!");
            Name = name;
            CodErp= codErp;
            Price = price;

        }
    }
}
