
using Api.Mappers;
using Api.ViewModels;

using Domain.Dto;
using Domain.Entities;
using Domain.Services;

using FluentValidation;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
[ApiController]
public class RegrasController : ControllerBase
{
    private readonly IRegrasService _servie;
    private readonly IValidator<RegraDto> _validator;

    public RegrasController(IRegrasService servie,
                            IValidator<RegraDto> validator)
    {
        _servie = servie;
        _validator = validator;
    }

    [HttpPost]
    public IActionResult Post([FromBody] RegrasVM model)
    {

        RegraDto regraDto = RegrasVMMapper.ToRegraDto(model);

        ValidationResult validation = _validator.Validate(regraDto);

        if (validation.IsValid)
        {
            Regra regra = _servie.Adicionar(regraDto);

            return Ok(regra);
        }

        return BadRequest(validation.Errors);
    }
}
