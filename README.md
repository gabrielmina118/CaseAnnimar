# CaseAnnimar

## Descrição
Este projeto consiste na criação de endpoints relacionados a informações de pessoas, com integração ao banco de dados. Os usuários podem interagir com esses endpoints por meio do Swagger.

## Início
Para começar, é necessário criar um banco de dados com a seguinte tabela:

```sql
CREATE TABLE Pessoas (
    ID INT PRIMARY KEY,
    Nome VARCHAR(50),
    Sobrenome VARCHAR(50),
    DataNascimento DATE,
    DataInsercao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Profissao VARCHAR(50)
);

```

## Métodos API

As requisições para a API devem seguir os padrões a seguir:

| Método | Descrição                                      |
|--------|-------------------------------------------------|
| GET    | Retorna informações de um ou mais registros.   |
| POST   | Utilizado para criar um novo registro.          |
| PUT    | Atualiza dados de um registro ou altera sua situação. |
| DELETE | Remove um registro do sistema.                 |

### Utilização do Swagger

A documentação Swagger pode ser acessada para interagir com os endpoints e entender os parâmetros necessários para cada método. O Swagger facilita a visualização e teste das funcionalidades da API.

#### Acesso ao Swagger

O Swagger está disponível no endpoint `/swagger`. Após iniciar o servidor, acesse este endpoint em seu navegador para explorar e interagir com os endpoints disponíveis.

## Exemplo de Uso

### GET
- **Endpoint**: `/api/pessoas`
- **Descrição**: Retorna informações de todas as pessoas cadastradas.

### POST
- **Endpoint**: `/api/pessoas`
- **Descrição**: Cria um novo registro de pessoa.
- **Parâmetros**:
  - `Nome` (string): Nome da pessoa.
  - `Sobrenome` (string): Sobrenome da pessoa.
  - `DataNascimento` (date): Data de nascimento da pessoa.
  - `Profissao` (string): Profissão da pessoa.

### PUT
- **Endpoint**: `/api/pessoas/{id}`
- **Descrição**: Atualiza informações de uma pessoa existente.
- **Parâmetros**:
  - `id` (int): Identificador da pessoa a ser atualizada.
  - (Outros parâmetros conforme necessidade de atualização).

### DELETE
- **Endpoint**: `/api/pessoas/{id}`
- **Descrição**: Remove uma pessoa do sistema.
- **Parâmetros**:
  - `id` (int): Identificador da pessoa a ser removida.

## Considerações Finais

Certifique-se de seguir as boas práticas de segurança ao lidar com informações sensíveis. Este projeto é um exemplo básico e pode ser expandido conforme as necessidades específicas do sistema em desenvolvimento.
