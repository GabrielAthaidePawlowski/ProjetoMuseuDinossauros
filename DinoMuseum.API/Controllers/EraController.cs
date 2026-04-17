using DinoMuseum.API.Data;
using DinoMuseum.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DinoMuseum.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EraController : ControllerBase
{
    private readonly IMongoCollection<Era> _eras;

    public EraController(MongoDbService mongoDbService)
    {
        // Cria a coleção "Eras" no MongoDB
        _eras = mongoDbService.GetDatabase.GetCollection<Era>("Eras");
    }

    [HttpGet] // Listar todas as Eras
    public async Task<IEnumerable<Era>> Get() =>
        await _eras.Find(_ => true).ToListAsync();

    [HttpGet("{id}")] // Buscar uma Era específica
    public async Task<ActionResult<Era>> GetById(string id)
    {
        var era = await _eras.Find(x => x.Id == id).FirstOrDefaultAsync();
        return era is null ? NotFound() : era;
    }

    [HttpPost] // Cadastrar nova Era
    public async Task<IActionResult> Post(Era novaEra)
    {
        await _eras.InsertOneAsync(novaEra);
        return CreatedAtAction(nameof(GetById), new { id = novaEra.Id }, novaEra);
    }

    [HttpPut("{id}")] // Editar uma Era
    public async Task<IActionResult> Put(string id, Era eraEditada)
    {
        var result = await _eras.ReplaceOneAsync(x => x.Id == id, eraEditada);
        if (result.MatchedCount == 0) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")] // Deletar uma Era
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _eras.DeleteOneAsync(x => x.Id == id);
        if (result.DeletedCount == 0) return NotFound();
        return NoContent();
    }
}