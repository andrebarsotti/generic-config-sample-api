using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Api.Mappers;
using Api.ViewModels;
using Api.ViewModels.Fakers;

using AutoMapper;

using Domain.Dto;
using Domain.Entities;
using Domain.Entities.Fakers;
using Domain.Enums;

using FluentAssertions;

using Xunit;

namespace ApiTests.Mappers;

public class ViewModelProfileTests
{
    private readonly IMapper _mapper;

    public ViewModelProfileTests()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<VieModelProfile>();
        }));
    }

    [Fact]
    public void MappersTest()
    {
        _mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    [Fact]
    public void RegraVMToRegraDto_RegrasOk()
    {
        // Setup
        RegraVM model = (new RegraVMFaker()).Generate($"default, {RegraVMFaker.ComUmFiltroDeCada}");

        // Execute
        var resultado = _mapper.Map<RegraDto>(model);

        // Validate
        resultado.Should().NotBeNull()
            .And
            .BeEquivalentTo(model, cfg => cfg.Excluding(e => e.Filtros)
                                                                                 .ExcludingMissingMembers());

        ValidarFiltros(model.Filtros, resultado.Filtros);
    }

    private static void ValidarFiltros(IEnumerable<FiltroVM> filtrosVM, IEnumerable<IFiltro>? filtros)
    {
        filtros.Should().NotBeNull();
        
        foreach (var filtroVM in filtrosVM)
        {
            IFiltro filtro = filtros.First(filtro => filtro.Tipo == filtroVM.Tipo);
            filtro.Should().BeEquivalentTo(filtroVM, cfg => cfg.Excluding(e => e.Valor));
            
            ValidarFiltro(filtroVM, filtro);
        }
    }

    private static void ValidarFiltro(FiltroVM filtroVM, IFiltro filtro)
    {
        switch (filtroVM.Tipo)
        {
            case Tipo.Lista:
                ValidarFiltroLista(filtroVM, filtro);
                break;
            case Tipo.Range:
                ValidarFiltroRange(filtroVM, filtro);
                break;
            case Tipo.Valor:
                ValidarFiltroValor(filtroVM, filtro);
                break;
        }
    }

    private static void ValidarFiltroValor(FiltroVM filtroVM, IFiltro filtro)
    {
        var valorVM = filtroVM.Valor.Deserialize<string>();
        var valor = ((FiltroValor)filtro).Valor;

        valor.Should().Be(valorVM);
    }

    private static void ValidarFiltroRange(FiltroVM filtroVM, IFiltro filtro)
    {
        var rangeVm = filtroVM.Valor.Deserialize<RangeVM>();
        var range = ((FiltroRange)filtro).Valor;

        range.Should().BeEquivalentTo(rangeVm);
    }

    private static void ValidarFiltroLista(FiltroVM filtroVM, IFiltro filtro)
    {
        var listaVM = filtroVM.Valor.Deserialize<IEnumerable<ItemListaVM>>();
        var lista = ((FiltroLista)filtro).Valor;

        lista.Should().BeEquivalentTo(listaVM);
    }
    
    [Fact]
    public void RegraVMToRegraDto_ListaInvalida()
    {
        // Setup
        RegraVM model = (new RegraVMFaker()).Generate($"default, {RegraVMFaker.SemFiltros}");
        FiltroVM filtro = (new FiltroVMFaker()).Generate(FiltroVMFaker.FiltroValor);
        filtro.Tipo = Tipo.Lista;
        model.Filtros.Add(filtro);

        // Execute
        var resultado = _mapper.Map<RegraDto>(model);

        // Validate
        resultado.Should().NotBeNull()
            .And
            .BeEquivalentTo(model, cfg => cfg.Excluding(e => e.Filtros)
                .ExcludingMissingMembers());
        
        var filtroLista = (FiltroLista)resultado.Filtros.First();
        filtroLista.Should().BeEquivalentTo(filtro, cfg => cfg.Excluding(e => e.Valor));
        filtroLista.Valor.Should().BeEmpty();
    }
    
    [Fact]
    public void RegraVMToRegraDto_RangeInvalido()
    {
        // Setup
        RegraVM model = (new RegraVMFaker()).Generate($"default, {RegraVMFaker.SemFiltros}");
        FiltroVM filtro = (new FiltroVMFaker()).Generate(FiltroVMFaker.FiltroValor);
        filtro.Tipo = Tipo.Range;
        model.Filtros.Add(filtro);

        // Execute
        var resultado = _mapper.Map<RegraDto>(model);
        // RegraDto resultado = model.ToRegraDto();

        // Validate
        resultado.Should().NotBeNull()
            .And
            .BeEquivalentTo(model, cfg => cfg.Excluding(e => e.Filtros)
                .ExcludingMissingMembers());
        
        var filtroLista = (FiltroRange)resultado.Filtros.First();
        filtroLista.Should().BeEquivalentTo(filtro, cfg => cfg.Excluding(e => e.Valor));
        filtroLista.Valor.De.Should().Be(0);
        filtroLista.Valor.Ate.Should().Be(0);
    }    

    [Fact]
    public void RegraToRegraVM_RegraOK()
    {
        // Setup
        Regra regra = (new RegraFaker())
            .Generate($"default, {RegraFaker.RegraComId}, {RegraFaker.RegraComUmFiltroDeCada}");
        
        // Execute
        var resultado = _mapper.Map<RegraVM>(regra);
        // RegraVM resultado = regra.ToRegraVM();
        
        // Validate
        resultado.Should().BeEquivalentTo(regra, cfg => cfg.ExcludingMissingMembers()
                                                                                             .Excluding(e => e.Filtros));
        
        ValidarFiltros(resultado.Filtros, regra.Filtros);
    }
}