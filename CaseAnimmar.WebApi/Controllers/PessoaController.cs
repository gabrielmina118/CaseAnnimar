using CaseAnimmar.Infra.Repository;
using CaseAnnimar.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CaseAnimmar.WebApi.Controllers;

[ApiController]
[Route("api/pessoas")]
public class PessoaController : ControllerBase
{
    private readonly PessoaRepository _pessoaRepository;

    public PessoaController(PessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    [HttpGet]
    [SwaggerOperation("Retorna uma lista de todas as pessoas.")]
    public async Task<IActionResult> GetPessoas()
    {
        var pessoas = await _pessoaRepository.ListarPessoasAsync();
        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Retorna uma pessoa com base em seu ID.")]
    [SwaggerResponse(200, "A pessoa foi encontrada.", typeof(Pessoa))]
    [SwaggerResponse(404, "Pessoa não encontrada.")]
    public async Task<IActionResult> GetPessoa(int id)
    {
        try
        {
            var pessoa = await _pessoaRepository.ObterPessoaAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message}");
        }
    }

    [HttpPost]
    [SwaggerOperation("Cria uma nova pessoa.")]
    [SwaggerResponse(201, "A pessoa foi criada com sucesso.", typeof(string))]
    [SwaggerResponse(400, "Erro na solicitação. Verifique os dados da pessoa.")]
    public async Task<IActionResult> PostPessoa([FromBody] Pessoa pessoa)
    {
        try
        {
            await _pessoaRepository.InserirPessoaAsync(pessoa);
           
        }
        catch (Exception) { 
            return BadRequest("Erro na solicitação. Verifique os dados da pessoa.");
        }
        return Created(string.Empty, new { Message = "A pessoa foi criada com sucesso." });
    }

    [HttpPut("{id}")]
    [SwaggerOperation("Atualiza uma pessoa com base em seu ID.")]
    [SwaggerResponse(200, "A pessoa foi atualizada com sucesso.")]
    [SwaggerResponse(404, "Pessoa não encontrada.")]
    public async Task<IActionResult> PutPessoa(int id, [FromBody] Pessoa pessoa)
    {
        var existingPessoa = await _pessoaRepository.ObterPessoaAsync(id);
        if (existingPessoa == null)
        {
            return NotFound("Pessoa não encontrada.");
        }

        pessoa.Id = id; 
        await _pessoaRepository.AtualizarPessoaAsync(pessoa);
        return Ok("A pessoa foi atualizada com sucesso.");
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Exclui uma pessoa com base em seu ID.")]
    [SwaggerResponse(200, "A pessoa foi excluída com sucesso.")]
    [SwaggerResponse(404, "Pessoa não encontrada.")]
    public async Task<IActionResult> DeletePessoa(int id)
    {
        var existingPessoa = await _pessoaRepository.ObterPessoaAsync(id);
        if (existingPessoa == null)
        {
            return NotFound("Pessoa não encontrada.");
        }

        await _pessoaRepository.ExcluirPessoaAsync(id);
        return Ok("A pessoa foi excluída com sucesso.");
    }
}