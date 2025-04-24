using AutoMapper;
using JornadaAPI.Data;
using JornadaAPI.Data.DTOs;
using JornadaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JornadaAPI.Controllers;

[ApiController]
[Route("api/destino")]
public class DestinoController : ControllerBase
{
    private JornadaContext _context;
    private IMapper _mapper;

    public DestinoController(JornadaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarDestino([FromBody] CreateDestinoDto destinoDto)
    {
        Destinos destino = _mapper.Map<Destinos>(destinoDto);
        _context.Destinos.Add(destino);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaDestinoPorId), new { id = destino.Id }, destino);
    }

    [HttpGet]
    public IEnumerable<ReadDestinoDto> RecuperaDestino([FromQuery] int skip = 0,
        [FromQuery] int take = 6)
    {
        return _mapper.Map<List<ReadDestinoDto>>(_context.Destinos.Skip(skip).Take(take));
    }    

    [HttpGet("busca")]
    public ActionResult BuscaDestinoPorPalavraChave([FromQuery] string nome)
    {
        var destino = _context.Destinos
            .FirstOrDefault(d => d.Nome.ToLower().Contains(nome.ToLower()));

        if (destino == null)
        {
            return NotFound("Destino não encontrado.");
        }

        return Ok(_mapper.Map<ReadDestinoDto>(destino));
    }

    [HttpGet("{id:int}")]
    public IActionResult RecuperaDestinoPorId(int id)
    {
        var destino = _context.Destinos.FirstOrDefault(destino => destino.Id == id);
        if (destino == null) return NotFound();
        var destinoDto = _mapper.Map<ReadDestinoDto>(destino);
        return Ok(destinoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaDestino(int id, [FromBody] UpdateDestinoDto destinoDto)
    {
        var destino = _context.Destinos.FirstOrDefault(
            destino => destino.Id == id);
        if (destino == null) return NotFound();
        _mapper.Map(destinoDto, destino);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDEstino(int id)
    {
        var destino = _context.Destinos.FirstOrDefault(
            destino => destino.Id == id);
        if (destino == null) return NotFound();
        _context.Remove(destino);
        _context.SaveChanges();
        return NoContent();
    }

}
