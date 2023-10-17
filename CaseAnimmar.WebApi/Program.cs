using CaseAnimmar.Infra.Repository;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddUserSecrets<Program>();

var connectionString = builder.Configuration.GetConnectionString("MyDatabase");

// Configuração do serviço
builder.Services.AddTransient(_ => new MySqlConnection(connectionString)); // Injeta a conexão

// Injeta o repositório no serviço
builder.Services.AddTransient<PessoaRepository>(_ => new PessoaRepository(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
