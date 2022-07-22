using System.ComponentModel.DataAnnotations;

namespace AppWebMVC.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Telefone do Usuário")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o CPF do Usuário")]
        public string CPF { get; set; }
    }
}
