using AppWebMVC.Models;

namespace AppWebMVC.Repositories
{
    public interface IPessoaRepository
    {
        PessoaModel ListarPorId(int id);
        List<PessoaModel> GetAll();
        PessoaModel Adicionar(PessoaModel pessoa);
        PessoaModel Atualizar(PessoaModel pessoa);
        bool Remove(int id);

    }
}
