using Domain.Entities;
using Domain.Entities.Fakers;

using FluentAssertions;

using Xunit;

namespace Domain.Validators;

public class FiltroValorValidatorTests
{
    [Fact]
    public void ValidarObjetoOk()
    {
        // Setup
        FiltroValor filtro = new FiltroValorFaker();

        //Execute
        var validator = new FiltroValorValidator();
        var resultado = validator.Validate(filtro);

        //Validar
        resultado.IsValid.Should().BeTrue();
    }
}