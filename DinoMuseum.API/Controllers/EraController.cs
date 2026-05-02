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
        _eras = mongoDbService.GetDatabase.GetCollection<Era>("Eras");
    }

    /// <summary>
    /// Lista todas as eras geológicas cadastradas.
    /// </summary>
    /// <returns>Uma lista de eras geológicas.</returns>
    [HttpGet]
    public async Task<IEnumerable<Era>> Get() =>
        await _eras.Find(_ => true).ToListAsync();

    /// <summary>
    /// Obtém os detalhes de uma era específica através do ID.
    /// </summary>
    /// <param name="id">ID da era no MongoDB.</param>
    /// <response code="200">Retorna a era solicitada.</response>
    /// <response code="404">Era não encontrada.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Era>> GetById(string id)
    {
        var era = await _eras.Find(x => x.Id == id).FirstOrDefaultAsync();
        return era is null ? NotFound() : era;
    }

    /// <summary>
    /// Cadastra uma nova era geológica.
    /// </summary>
    /// <param name="novaEra">Objeto contendo os dados da nova era.</param>
    /// <response code="201">Era criada com sucesso.</response>
    [HttpPost]
    public async Task<IActionResult> Post(Era novaEra)
    {
        await _eras.InsertOneAsync(novaEra);
        return CreatedAtAction(nameof(GetById), new { id = novaEra.Id }, novaEra);
    }

    /// <summary>
    /// Atualiza uma era geológica existente.
    /// </summary>
    /// <param name="id">ID da era a ser modificada.</param>
    /// <param name="eraEditada">Novos dados da era.</param>
    /// <response code="204">Alteração realizada com sucesso.</response>
    /// <response code="404">ID não encontrado.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Era eraEditada)
    {
        var result = await _eras.ReplaceOneAsync(x => x.Id == id, eraEditada);
        if (result.MatchedCount == 0) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Remove uma era geológica do sistema.
    /// </summary>
    /// <param name="id">ID da era a ser excluída.</param>
    /// <response code="204">Removida com sucesso.</response>
    /// <response code="404">ID não encontrado.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _eras.DeleteOneAsync(x => x.Id == id);
        if (result.DeletedCount == 0) return NotFound();
        return NoContent();
    }
}