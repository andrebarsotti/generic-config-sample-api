
using Api.Mappers;
using Api.ViewModels;
using Api.ViewModels.Fakers;

using AutoMapper;

using Bogus;

using Domain.Dto;
using Domain.Entities;
using Domain.Entities.Fakers;
using Domain.Enums;
using Domain.Services;

using DomainTests.Dto.Fakers;

using FluentAssertions;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;

using Moq;
using Moq.AutoMock;

using Xunit;

using ValidationFailure = FluentValidation.Results.ValidationFailure;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Api.Controllers;

public class RegrasControllerTests
{
    private readonly AutoMocker _autoMoq;
    private readonly Faker _faker;

    public RegrasControllerTests()
    {
        _autoMoq = new AutoMocker();
        _faker = new Faker();
        _autoMoq.Use<IMapper>(new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RegrasVMProfile>();
            cfg.AddProfile<FiltroVMProfile>();
            cfg.AddProfile<ItemListaVMProfile>();
            cfg.AddProfile<RangeVMProfile>();
        })));
    }

    [Fact]
    public void PostOk()
    {
        // Setup
        RegraVM model = new RegraVMFaker();

        Mock<IValidator<RegraDto>> validatorMock = _autoMoq.GetMock<IValidator<RegraDto>>();
        validatorMock.Setup(v => v.Validate(It.IsAny<RegraDto>()))
            .Returns(new ValidationResult())
            .Verifiable();

        Mock<IRegrasService> serviceMock = _autoMoq.GetMock<IRegrasService>();
        serviceMock.Setup(serv => serv.Adicionar(It.IsAny<RegraDto>()))
            .Returns(new Regra() { Id = _faker.Random.Hash() })
            .Verifiable();

        // Execute
        var controller = _autoMoq.CreateInstance<RegrasController>();
        var resultado = controller.Post(model);

        // Validar
        resultado.Should().NotBeNull()
            .And
            .BeOfType<OkObjectResult>();
        validatorMock.Verify();
        serviceMock.Verify();
    }


    [Fact]
    public void PostBadRequest()
    {
        // Setup
        RegraVM model = new RegraVMFaker();

        Mock<IValidator<RegraDto>> validatorMock = _autoMoq.GetMock<IValidator<RegraDto>>();
        validatorMock.Setup(v => v.Validate(It.IsAny<RegraDto>()))
            .Returns(new ValidationResult(new []
            {
                new ValidationFailure("x", "xx")
            }))
            .Verifiable();

        Mock<IRegrasService> serviceMock = _autoMoq.GetMock<IRegrasService>();

        // Execute
        var controller = _autoMoq.CreateInstance<RegrasController>();
        var resultado = controller.Post(model);

        // Validar
        resultado.Should().NotBeNull()
            .And
            .BeOfType<BadRequestObjectResult>();
        validatorMock.Verify();
        serviceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void GetAll()
    {
        // Setup
        Mock<IRegrasService> serviceMock = _autoMoq.GetMock<IRegrasService>();

        serviceMock.Setup(serv => serv.ListarTodas())
            .Returns((new RegraResumoDtoFaker()).Generate(_faker.Random.Int(1, 10)))
            .Verifiable();

        // Execute
        var controller = _autoMoq.CreateInstance<RegrasController>();
        var resultado = controller.Get();

        // Validar
        resultado.Should().NotBeNull()
            .And
            .BeOfType<OkObjectResult>();
        serviceMock.Verify();
        serviceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void GetByIdOk()
    {
        // Setup
        string id = _faker.Random.Hash();
        Mock<IRegrasService> serviceMock = _autoMoq.GetMock<IRegrasService>();

        serviceMock.Setup(serv => serv.ObterPorId(id))
            .Returns<string>(id =>
            {
                Regra regra = new RegraFaker();
                
                regra.Id = id;
                regra.Filtros.Clear();
                regra.Filtros.Add(FiltroFaker.GerarFiltro(Tipo.Lista));
                regra.Filtros.Add(FiltroFaker.GerarFiltro(Tipo.Range));
                regra.Filtros.Add(FiltroFaker.GerarFiltro(Tipo.Valor));
                
                return regra;
            })
            .Verifiable();

        // Execute
        var controller = _autoMoq.CreateInstance<RegrasController>();
        var resultado = controller.Get(id);

        // Validar
        resultado.Should().NotBeNull()
            .And
            .BeOfType<OkObjectResult>();
        serviceMock.Verify();
        serviceMock.VerifyNoOtherCalls();
    }


    [Fact]
    public void GetByIdNotFound()
    {
        // Setup
        string id = _faker.Random.Hash();
        Mock<IRegrasService> serviceMock = _autoMoq.GetMock<IRegrasService>();

        serviceMock.Setup(serv => serv.ObterPorId(id))
            .Returns((Regra)null)
            .Verifiable();

        // Execute
        var controller = _autoMoq.CreateInstance<RegrasController>();
        var resultado = controller.Get(id);

        // Validar
        resultado.Should().NotBeNull()
            .And
            .BeOfType<NotFoundResult>();
        serviceMock.Verify();
        serviceMock.VerifyNoOtherCalls();
    }
}

