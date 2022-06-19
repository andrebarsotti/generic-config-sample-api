using System.Collections.Generic;

using Domain.Enums;
using Domain.Fakers;

namespace Domain.Entities.Fakers;

using Bogus;

public sealed class RegraFaker : Faker<Regra>
{
    public const string RegraComId = "regra-com-id";
    public const string RegraComUmFiltroDeCada = "regra-com-um-filtro-de-cada";

    public RegraFaker() : base(FakerConstants.Locale)
    {
        RuleFor(e => e.Nome, fk => fk.Lorem.Sentence());
        RuleFor(e => e.DataInclusao, fk => fk.Date.Recent());
        RuleFor(e => e.IncluidoPor, fk => fk.Person.FullName);
        RuleFor(e => e.Filtros, _ => FiltroFaker.GerarListaDeFiltros());
        RuleSet(RegraComId, set =>
                set.RuleFor(e => e.Id, fk => fk.Random.Hash())
            );
        RuleSet(RegraComUmFiltroDeCada, set =>
                set.RuleFor(e => e.Filtros, _ =>
                {
                    List<Filtro> filtros = new();
                    
                    filtros.Add(FiltroFaker.GerarFiltro(Tipo.Lista));
                    filtros.Add(FiltroFaker.GerarFiltro(Tipo.Range));
                    filtros.Add(FiltroFaker.GerarFiltro(Tipo.Valor));
                    
                    return filtros;
                })
            );
    }
}
