using Bogus;
using Domain.Entities;
using System.Collections.Generic;

namespace DomainTests.Fakers
{
    internal sealed class ItemListaFaker : Faker<ItemLista>
    {
        public ItemListaFaker() : base(FakerConstants.Locale)
        {
            RuleFor(e => e.Id, (fk) => fk.Random.Int());
            RuleFor(e => e.Descricao, (fk) => fk.Commerce.Department());
        }

        public static IEnumerable<ItemLista> GenerateList() => GenerateList((new Faker()).Random.Int(0, 10));

        public static IEnumerable<ItemLista> GenerateList(int qtd)
        {
            ItemListaFaker faker = new();
            return faker.Generate(qtd);
        }
    }
}
