
using Api.Mappers;
using Api.ViewModels;

using Domain.Dto;
using Domain.Entities;
using Domain.Services;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
[ApiController]
public class RegrasController : ControllerBase
{
    private readonly IRegrasService _servie;

    public RegrasController(IRegrasService servie)
    {
        _servie = servie;
    }

    [HttpPost]
    public IActionResult Post([FromBody] RegrasVM model)
    {

        RegraDto regraDto = RegrasVMMapper.ToRegraDto(model);
        
        // Aplicar validator.
        
        Regra regra = _servie.Adicionar(regraDto);

        return Ok(regra);
    }
}
