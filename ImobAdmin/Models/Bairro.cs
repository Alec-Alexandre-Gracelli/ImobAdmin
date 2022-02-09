using System.ComponentModel.DataAnnotations;

namespace ImobAdmin.Models
{
    public class Bairro
    {
        public int BairroId { get; set; }
        public int CidadeId { get; set; }
        [Required(ErrorMessage = "O nome do bairro deve ser informado")]
        [Display(Name = "Bairro")]
        [StringLength(50, ErrorMessage = "Ultrapassou o limite de caracteres possíveis...")]
        public string BairroNome { get; set; }


        public virtual Cidade Cidade { get; set; }

    }
}
