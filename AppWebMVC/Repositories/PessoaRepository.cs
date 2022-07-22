using AppWebMVC.Data;
using AppWebMVC.Models;

namespace AppWebMVC.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly BancoContext _context;
        public PessoaRepository(BancoContext context)
        {
            _context = context;
        }
        public PessoaModel ListarPorId(int id)
        {
            return _context.Pessoas.FirstOrDefault(x => x.Id == id); 
        }
        public List<PessoaModel> GetAll()
        {
            return _context.Pessoas.ToList();
        }

        public PessoaModel Adicionar(PessoaModel pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return pessoa;
        }

        public PessoaModel Atualizar(PessoaModel pessoa)
        {
            PessoaModel pessoaDB = ListarPorId(pessoa.Id);

            if(pessoaDB == null)
            {
                throw new Exception("Houve um erro na Atualização do Usuário");
            }
            pessoaDB.Nome = pessoa.Nome;
            pessoaDB.Telefone = pessoa.Telefone;
            pessoaDB.CPF = pessoa.CPF;

            _context.Pessoas.Update(pessoaDB);
            _context.SaveChanges();

            return pessoaDB;
        }

        public bool Remove(int id)
        {
            PessoaModel pessoaDB = ListarPorId(id); 

            if (pessoaDB == null)
            {
                throw new Exception("Houve um erro ao Deletar este Usuário");
            }
            _context.Pessoas.Remove(pessoaDB);
            _context.SaveChanges();

            return true;
        }
    }
}
