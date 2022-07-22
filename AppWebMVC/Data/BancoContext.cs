using AppWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<PessoaModel> Pessoas { get; set; } 
        public DbSet<EnderecoModel> Enderecos { get; set; } 
    }
}
