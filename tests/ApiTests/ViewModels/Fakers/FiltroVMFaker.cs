using System;
using System.Text.Json;

using Api.Fakers;

using Bogus;

using Domain.Enums;

namespace Api.ViewModels.Fakers;

public class FiltroVMFaker : Faker<FiltroVM>
{
    public const string FiltroLista = "filtro-lista";
    public const string FiltroRange = "filtro-range";
    public const string FiltroValor = "filtro-valor";
    
    public FiltroVMFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Tipo, fk => fk.Random.Enum<Tipo>());
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.Valor, (fk, e) => GerarValor(fk, e));

        RuleSet(FiltroLista, set =>
        {
            RuleFor(e => e.Tipo, _ => Tipo.Lista);
            RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
            RuleFor(e => e.Valor, (fk, e) => GerarValor(fk, e));
        });

        RuleSet(FiltroRange, set =>
        {
            RuleFor(e => e.Tipo, _ => Tipo.Range);
            RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
            RuleFor(e => e.Valor, (fk, e) => GerarValor(fk, e));
        });
        
        RuleSet(FiltroValor, set =>
        {
            RuleFor(e => e.Tipo, _ => Tipo.Valor);
            RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
            RuleFor(e => e.Valor, (fk, e) => GerarValor(fk, e));
        });
        
    }

    private static JsonElement GerarValor(Faker fk, FiltroVM filtroVm) =>
        filtroVm.Tipo switch
        {
            Tipo.Lista => GerarLista(),
            Tipo.Range => GerarRange(),
            Tipo.Valor => JsonSerializer.SerializeToElement(fk.Lorem.Sentence()),
            _ => throw new NotImplementedException()
        };

    private static JsonElement GerarRange() 
        => JsonSerializer.SerializeToElement(new RangeVMFaker().Generate());

    private static JsonElement GerarLista()
        => JsonSerializer.SerializeToElement(ItemListaVMFaker.GerarLista());
}

