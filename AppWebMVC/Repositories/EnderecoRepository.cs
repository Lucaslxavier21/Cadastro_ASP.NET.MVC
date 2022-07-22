using AppWebMVC.Data;
using AppWebMVC.Models;

namespace AppWebMVC.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly BancoContext _context;
        public EnderecoRepository(BancoContext context)
        {
            _context = context; 
        }

        public EnderecoModel ListarPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(x => x.Id == id);
        }
        public List<EnderecoModel> GetAll()
        {
            return _context.Enderecos.ToList();
        }
        public EnderecoModel Adicionar(EnderecoModel endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return endereco;
        }

        public EnderecoModel Atualizar(EnderecoModel endereco)
        {
            EnderecoModel enderecoDB = ListarPorId(endereco.Id);

            if (enderecoDB == null)
            {
                throw new Exception("Houve um erro na Atualização do Usuário");
            }
            enderecoDB.Endereco = endereco.Endereco;
            enderecoDB.CEP = endereco.CEP;
            enderecoDB.Cidade = endereco.Cidade;
            enderecoDB.Estado = endereco.Estado;

            _context.Enderecos.Update(enderecoDB);
            _context.SaveChanges();

            return enderecoDB;
        }
        public bool Remove(int id)
        {
            EnderecoModel enderecoDB = ListarPorId(id);

            if (enderecoDB == null)
            {
                throw new Exception("Houve um erro ao Deletar este Usuário");
            }
            _context.Enderecos.Remove(enderecoDB);
            _context.SaveChanges();

            return true;
        }
    }
}
