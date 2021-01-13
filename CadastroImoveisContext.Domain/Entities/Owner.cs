using System.Collections.Generic;
using System.Linq;
using CadastroImoveisContext.Domain.ValueObjects;
using CadastroImoveisContext.Shared.Entities;

namespace CadastroImoveisContext.Domain.Entities
{
    public class Owner : Entity
    {
        private readonly IList<Propertie> _properties;
         public Owner(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;            
            _properties = new List<Propertie>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Propertie> Properties { get { return _properties.ToArray(); } }
    }
}