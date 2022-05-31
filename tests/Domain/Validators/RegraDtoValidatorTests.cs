using Domain.Dto;
using Domain.Dto.Fakers;

using FluentAssertions;

using Xunit;

namespace Domain.Validators;

public class RegraDtoValidatorTests
{
    [Fact]
    public void ValidarObjetoOk()
    {
        // Setup
        RegraDto filtro = new RegraDtoFaker();

        //Execute
        var validator = new RegraDtoValidator();
        var resultado = validator.Validate(filtro);

        //Validar
        resultado.IsValid.Should().BeTrue();
    }
}