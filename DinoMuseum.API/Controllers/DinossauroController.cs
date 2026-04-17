using DinoMuseum.API.Data;
using DinoMuseum.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DinoMuseum.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DinossauroController : ControllerBase
{
    private readonly IMongoCollection<Dinossauro> _dinossauros;

    public DinossauroController(MongoDbService mongoDbService)
    {
        _dinossauros = mongoDbService.GetDatabase.GetCollection<Dinossauro>("Dinossauros");
    }

    [HttpGet] // LISTAR TODOS
    public async Task<IEnumerable<Dinossauro>> Get() =>
        await _dinossauros.Find(_ => true).ToListAsync();

    [HttpGet("{id}")] // BUSCAR POR ID
    public async Task<ActionResult<Dinossauro>> GetById(string id)
    {
        var dino = await _dinossauros.Find(x => x.Id == id).FirstOrDefaultAsync();
        return dino is null ? NotFound() : dino;
    }

    [HttpPost] // CADASTRAR
    public async Task<IActionResult> Post(Dinossauro novoDino)
    {
        await _dinossauros.InsertOneAsync(novoDino);
        return CreatedAtAction(nameof(GetById), new { id = novoDino.Id }, novoDino);
    }

    [HttpPut("{id}")] // EDITAR
    public async Task<IActionResult> Put(string id, Dinossauro dinoEditado)
    {
        var result = await _dinossauros.ReplaceOneAsync(x => x.Id == id, dinoEditado);
        if (result.MatchedCount == 0) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")] // DELETAR
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _dinossauros.DeleteOneAsync(x => x.Id == id);
        if (result.DeletedCount == 0) return NotFound();
        return NoContent();
    }
}