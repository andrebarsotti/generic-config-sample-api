
using Api.Mappers;
using Api.ViewModels;

using AutoMapper;

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
    private readonly IRegrasService _service;
    private readonly IValidator<RegraDto> _validator;
    private readonly IMapper _mapper;

    public RegrasController(IRegrasService servie,
                            IValidator<RegraDto> validator,
                            IMapper mapper)
    {
        _service = servie;
        _validator = validator;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Post([FromBody] RegraVM model)
    {

        var regraDto = _mapper.Map<RegraDto>(model);
        regraDto.Responsavel = "João da Silva";

        ValidationResult validation = _validator.Validate(regraDto);

        if (validation.IsValid)
        {
            Regra regra = _service.Adicionar(regraDto);

            return Ok(regra.Id);
        }

        return BadRequest(validation.Errors);
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.ListarTodas());

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        Regra regra = _service.ObterPorId(id);

        return regra is not null ? Ok(_mapper.Map<RegraVM>(regra)) : NotFound();
    }
}
