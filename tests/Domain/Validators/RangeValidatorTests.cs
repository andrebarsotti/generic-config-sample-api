using Domain.Entities;
using Domain.Entities.Fakers;
using Domain.Validators;

using FluentAssertions;

using Xunit;

namespace Domain.Validators;

public class RangeValidatorTests
{
    [Fact]
    public void ValidarObjetoOk()
    {
        // Setup
        Range range = new RangeFaker();

        //Execute
        var validator = new RangeValidator();
        var resultado = validator.Validate(range);

        //Validar
        resultado.IsValid.Should().BeTrue();
    }
}

