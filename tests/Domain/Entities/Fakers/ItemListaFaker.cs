using System.Collections.Generic;

using Bogus;

namespace Domain.Entities.Fakers;

internal sealed class ItemListaFaker : Faker<ItemLista>
{
    public ItemListaFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Id, (fk) => fk.Random.Int(min: 1));
        RuleFor(e => e.Descricao, (fk) => fk.Commerce.Department());
    }

    public static IEnumerable<ItemLista> GerarLista() => GerarLista((new Faker()).Random.Int(min: 1, max: 10));

    public static IEnumerable<ItemLista> GerarLista(int qtd)
    {
        ItemListaFaker faker = new();
        return faker.Generate(qtd);
    }
}
