using System.ComponentModel.DataAnnotations;

namespace ImobAdmin.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        [Required(ErrorMessage = "O nome da cidade deve ser informado")]
        [Display(Name = "Cidade")]
        [StringLength(50, ErrorMessage = "Ultrapassou o limite de caracteres possíveis...")]
        public string CidadeNome { get; set; }

        public virtual ICollection<Bairro> Bairros { get; set; }

    }
}