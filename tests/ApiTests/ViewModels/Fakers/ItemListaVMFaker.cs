using System.Collections.Generic;

using Api.Fakers;

using Bogus;

namespace Api.ViewModels.Fakers;

internal sealed class ItemListaVMFaker : Faker<ItemListaVM>
{
    public ItemListaVMFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Id, (fk) => fk.Random.Int(min: 1));
        RuleFor(e => e.Descricao, (fk) => fk.Commerce.Department());
    }

    public static IEnumerable<ItemListaVM> GerarLista() => GerarLista((new Faker()).Random.Int(min: 1, max: 10));

    public static IEnumerable<ItemListaVM> GerarLista(int qtd)
    {
        ItemListaVMFaker vmFaker = new();
        return vmFaker.Generate(qtd);
    }
}
