using Flunt.Validations;
using CadastroImoveisContext.Shared.ValueObjects;

namespace CadastroImoveisContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")
                .HasMinLen(Neighborhood, 3, "Address.Neighborhood", "O bairro deve conter pelo menos 3 caracteres") 
                .HasMinLen(City, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres")                       
                .HasLen(State, 2, "Address.State", "O estado deve conter 2 caracteres")                       
                .HasLen(Country, 2, "Address.Country", "O país deve conter 2 caracteres")                       
                .HasLen(ZipCode, 8, "Address.ZipCode", "O cep deve conter 8 caracteres")                       
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}