using Domain.Entities;
using Domain.Entities.Fakers;

using FluentAssertions;

using Xunit;

namespace Domain.Validators;

public class ItemListaValidatorTests
{
    [Fact]
    public void ValidarObjetoOk()
    {
        // Setup
        ItemLista item = new ItemListaFaker();

        //Execute
        var validator = new ItemListaValidator();
        var resultado = validator.Validate(item);

        //Validar
        resultado.IsValid.Should().BeTrue();
    }
}
