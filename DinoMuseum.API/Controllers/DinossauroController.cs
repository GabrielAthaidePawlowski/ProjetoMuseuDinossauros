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

    /// <summary>
    /// Lista todos os dinossauros cadastrados no museu.
    /// </summary>
    /// <returns>Uma lista de dinossauros.</returns>
    [HttpGet]
    public async Task<IEnumerable<Dinossauro>> Get() =>
        await _dinossauros.Find(_ => true).ToListAsync();

    /// <summary>
    /// Busca um dinossauro específico pelo seu ID.
    /// </summary>
    /// <param name="id">O ID único do dinossauro no MongoDB.</param>
    /// <response code="200">Retorna o dinossauro encontrado.</response>
    /// <response code="404">Caso o ID não exista no banco de dados.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Dinossauro>> GetById(string id)
    {
        var dino = await _dinossauros.Find(x => x.Id == id).FirstOrDefaultAsync();
        return dino is null ? NotFound() : dino;
    }

    /// <summary>
    /// Cadastra um novo dinossauro no catálogo.
    /// </summary>
    /// <remarks>
    /// Exemplo de requisição:
    /// 
    ///     POST /api/Dinossauro
    ///     {
    ///        "nome": "Irritator",
    ///        "especie": "Irritator challengeri",
    ///        "eraId": "id_da_era_aqui"
    ///     }
    /// </remarks>
    /// <param name="novoDino">Objeto com os dados do dinossauro.</param>
    /// <response code="201">Dinossauro criado com sucesso.</response>
    [HttpPost]
    public async Task<IActionResult> Post(Dinossauro novoDino)
    {
        await _dinossauros.InsertOneAsync(novoDino);
        return CreatedAtAction(nameof(GetById), new { id = novoDino.Id }, novoDino);
    }

    /// <summary>
    /// Atualiza as informações de um dinossauro existente.
    /// </summary>
    /// <param name="id">ID do dinossauro a ser editado.</param>
    /// <param name="dinoEditado">Objeto com as novas informações.</param>
    /// <response code="204">Atualização realizada com sucesso.</response>
    /// <response code="404">ID não encontrado.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Dinossauro dinoEditado)
    {
        var result = await _dinossauros.ReplaceOneAsync(x => x.Id == id, dinoEditado);
        if (result.MatchedCount == 0) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Remove um dinossauro do sistema.
    /// </summary>
    /// <param name="id">ID do dinossauro a ser removido.</param>
    /// <response code="204">Removido com sucesso.</response>
    /// <response code="404">ID não encontrado.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _dinossauros.DeleteOneAsync(x => x.Id == id);
        if (result.DeletedCount == 0) return NotFound();
        return NoContent();
    }
}