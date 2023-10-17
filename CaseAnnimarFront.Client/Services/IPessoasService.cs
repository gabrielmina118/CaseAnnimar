using CaseAnnimarFront.Client.DTO;

namespace CaseAnnimarFront.Client.Services
{
    public interface IPessoasService
    {
        Task<List<PessoaDataDTO>> FindAllPessoas();
    }
}
