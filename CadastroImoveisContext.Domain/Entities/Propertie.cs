using CadastroImoveisContext.Shared.Entities;
using CadastroImoveisContext.Domain.ValueObjects;

namespace CadastroImoveisContext.Domain.Entities
{
    public class Propertie : Entity
    {
        public Propertie(Address address, Owner owner)
        {
            Address = address;
            Owner = owner;

            AddNotifications(Address, Owner);
        }

        public Address Address { get; private set; }
        public Owner Owner { get; private set; }
        
    }

    
}