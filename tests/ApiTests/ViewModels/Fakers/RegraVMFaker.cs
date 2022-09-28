using System.Collections.Generic;

using Api.Fakers;

namespace Api.ViewModels.Fakers;

using Bogus;

public sealed class RegraVMFaker : Faker<RegraVM>
{
    public const string ComUmFiltroDeCada = "com-um-filtro-de-cada";
    public const string SemFiltros = "sem-filtros";
    
    public RegraVMFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.DataInclusao, fk => fk.Date.Recent());
        RuleFor(e => e.Filtros, fk => (new FiltroVMFaker()).Generate(fk.Random.Int(1,10)));

        RuleSet(ComUmFiltroDeCada, set =>
        {
            RuleFor(e => e.Filtros, _ =>
            {
                List<FiltroVM> lista = new();
                FiltroVMFaker filtroFaker = new();
                
                lista.Add(filtroFaker.Generate(FiltroVMFaker.FiltroLista));
                lista.Add(filtroFaker.Generate(FiltroVMFaker.FiltroRange));
                lista.Add(filtroFaker.Generate(FiltroVMFaker.FiltroValor));

                return lista;
            });
        });

        RuleSet(SemFiltros, set => set.RuleFor(e => e.Filtros, _ => new List<FiltroVM>()));
    }
}
