using System;
using Xunit;
using CadastroImoveisContext.Domain;
using CadastroImoveisContext.Domain.Entities;
using CadastroImoveisContext.Domain.ValueObjects;
using CadastroImoveisContext.Shared;
using CadastroImoveisContext.Shared.ValueObjects;
using CadastroImoveisContext.Domain.Enums;

namespace CadastroImoveisContext.Tests
{
    public class PropertieTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Owner _owner;

          public PropertieTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            _owner= new Owner(_name, _document, _email);            

        }

        [Fact]
        public void ShouldReturnSucessWhenAddPropertie()
        {
            var owner = _owner;
            var propertie = new Propertie(_address,owner);

            Assert.True(propertie.Valid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPropertieHasNoStreet()
        {
            var owner = _owner;
            var addressImcomplete = new Address("", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            var propertie = new Propertie(addressImcomplete,owner);

            Assert.True(propertie.Invalid);
        }

        
        [Fact]
        public void ShouldReturnErrorWhenPropertieHasNoNeighborhood()
        {
            var owner = _owner;
            var addressImcomplete = new Address("Rua 1", "1234", "", "Gotham", "SP", "BR", "13400000");
            var propertie = new Propertie(addressImcomplete,owner);

            Assert.True(propertie.Invalid);
        }

        [Fact]
        public void ShouldReturnErrorWhenPropertieHasNoCity()
        {
            var owner = _owner;
            var addressImcomplete = new Address("Rua 1", "1234", "Bairro Legal", "", "SP", "BR", "13400000");
            var propertie = new Propertie(addressImcomplete,owner);

            Assert.True(propertie.Invalid);
        }

        
    }
}
