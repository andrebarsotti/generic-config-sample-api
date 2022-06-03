using System;
using System.Text.Json;

using Api.Fakers;

using Bogus;

using Domain.Enums;

namespace Api.ViewModels.Fakers;

public class FiltroVMFaker : Faker<FiltroVM>
{
    public FiltroVMFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Tipo, fk => fk.Random.Enum<Tipo>());
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Valor, (fk, e) => GerarValor(fk, e));
    }

    private JsonElement GerarValor(Faker fk, FiltroVM filtroVm)
    {
        return filtroVm.Tipo switch
        {
            Tipo.Lista => GerarLista(),
            Tipo.Range => GerarRange(),
            Tipo.Valor => JsonSerializer.SerializeToElement(fk.Lorem.Sentence()),
            _ => throw new NotImplementedException()
        }; 
    }

    private JsonElement GerarRange()
    {
        var rangeFaker = new RangeVMFaker();
        return JsonSerializer.SerializeToElement(rangeFaker.Generate());
    }

    private JsonElement GerarLista()
        => JsonSerializer.SerializeToElement(ItemListaVMFaker.GerarLista());
}

