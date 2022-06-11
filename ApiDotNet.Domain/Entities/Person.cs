using ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }
        public Person(string document, string name,string phone)
        {
            Validation(document, name, phone);
        }
        public Person(int id, string document, string name, string phone)
        {
            DomainValidationException.When(id < 0, "Id dever ser informado");
            Id = id;
            Validation(document, name, phone);
        }
        private void Validation(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name),"Nome dever ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento dever ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Telefone dever ser informado!");
            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
