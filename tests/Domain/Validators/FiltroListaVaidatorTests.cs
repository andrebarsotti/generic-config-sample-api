using Domain.Entities;
using Domain.Entities.Fakers;

using FluentAssertions;

using Xunit;

namespace Domain.Validators;

public class FiltroListaVaidatorTests
{
    [Fact]
    public void ValidarObjetoOk()
    {
        // Setup
        FiltroLista filtro = new FiltroListaFaker();

        //Execute
        var validator = new FiltroListaValidator();
        var resultado = validator.Validate(filtro);

        //Validar
        resultado.IsValid.Should().BeTrue();
    }
}

