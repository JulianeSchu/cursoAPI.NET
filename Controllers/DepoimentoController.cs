using AutoMapper;
using JornadaAPI.Data;
using JornadaAPI.Data.DTOs;
using JornadaAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JornadaAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class DepoimentoController : ControllerBase
{
    private JornadaContext _context;
    private IMapper _mapper;

    public DepoimentoController(JornadaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaDepoimento([FromBody] CreateDepoimentoDto depoimentoDto)
    {
        Depoimentos depoimento = _mapper.Map<Depoimentos>(depoimentoDto);
        _context.Depoimentos.Add(depoimento);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaDepoimentoPorId), new { id = depoimento.Id }, depoimento);
    }

    [HttpGet]
    public IEnumerable<ReadDestinoDto> RecuperaDepoimento([FromQuery] int skip = 0,
        [FromBody] int take = 6)
    {
        return _mapper.Map<List<ReadDestinoDto>>(_context.Depoimentos.Skip(skip).Take(take));
    }

    [HttpGet("home")]
    public IEnumerable<ReadDestinoDto> RecuperaDepoimentosAleatorios([FromQuery] int quantidade = 3)
    {
        var depoimentos = _context.Depoimentos
            .FromSqlRaw($"SELECT * FROM Depoimentos ORDER BY RAND() LIMIT {quantidade}").ToList();
        return _mapper.Map<List<ReadDestinoDto>>(depoimentos);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaDepoimentoPorId(int id)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        var depoimentoDto = _mapper.Map<ReadDestinoDto>(depoimento);
        return Ok(depoimentoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaDepoimento(int id, [FromBody] UpdateDepoimentoDto depoimentoDto)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(
            depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        _mapper.Map(depoimentoDto, depoimento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaDepoimentoParcial(int id, JsonPatchDocument<UpdateDepoimentoDto> patch)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(
            depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();

        var depoimentoParaAtualizar = _mapper.Map<UpdateDepoimentoDto>(depoimento);

        patch.ApplyTo(depoimentoParaAtualizar, ModelState);

        if (!TryValidateModel(depoimentoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(depoimentoParaAtualizar, depoimento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaDepoimento(int id)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(
            depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        _context.Remove(depoimento);
        _context.SaveChanges();
        return NoContent();
    }
}
