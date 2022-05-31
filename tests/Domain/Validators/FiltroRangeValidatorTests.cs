using Domain.Entities;
using Domain.Entities.Fakers;

using FluentAssertions;

using Xunit;

namespace Domain.Validators;

public class FiltroRangeValidatorTests
{
    [Fact]
    public void ValidarObjetoOk()
    {
        // Setup
        FiltroRange filtro = new FiltroRangeFaker();

        //Execute
        var validator = new FiltroRangeValidator();
        var resultado = validator.Validate(filtro);

        //Validar
        resultado.IsValid.Should().BeTrue();
    }
}