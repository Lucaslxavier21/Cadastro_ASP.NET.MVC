using AppWebMVC.Models;

namespace AppWebMVC.Repositories
{
    public interface IEnderecoRepository
    {
        EnderecoModel ListarPorId(int id);
        List<EnderecoModel> GetAll();
        EnderecoModel Adicionar(EnderecoModel endereco);
        EnderecoModel Atualizar(EnderecoModel endereco); 
        bool Remove(int id);
    }
}
