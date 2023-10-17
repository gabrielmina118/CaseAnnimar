using CaseAnnimar.Application.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace CaseAnimmar.Infra.Repository;

public class PessoaRepository
{
    private readonly string _connectionString;

    public PessoaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<int> InserirPessoaAsync(Pessoa pessoa)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        const string sql = "INSERT INTO Pessoas (ID, Nome, Sobrenome, DataNascimento, Profissao) VALUES (@Id, @Nome, @Sobrenome, @DataNascimento, @Profissao); SELECT LAST_INSERT_ID()";
        return await connection.ExecuteScalarAsync<int>(sql, pessoa);
    }

    public async Task<Pessoa> ObterPessoaAsync(int pessoaId)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        const string sql = "SELECT * FROM Pessoas WHERE ID = @pessoaId";
        return await connection.QuerySingleOrDefaultAsync<Pessoa>(sql, new { pessoaId });
    }

    public async Task<IEnumerable<Pessoa>> ListarPessoasAsync()
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        const string sql = "SELECT * FROM Pessoas";
        return await connection.QueryAsync<Pessoa>(sql);
    }

    public async Task AtualizarPessoaAsync(Pessoa pessoa)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        const string sql = "UPDATE Pessoas SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DataNascimento, Profissao = @Profissao WHERE ID = @Id";
        await connection.ExecuteAsync(sql, pessoa);
    }

    public async Task ExcluirPessoaAsync(int pessoaId)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        const string sql = "DELETE FROM Pessoas WHERE ID = @pessoaId";
        await connection.ExecuteAsync(sql, new { pessoaId });
    }
}