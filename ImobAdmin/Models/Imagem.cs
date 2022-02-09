using System.ComponentModel.DataAnnotations;

namespace ImobAdmin.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }
        [Display(Name = "Caminho da Imagem")]
        [StringLength(100, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemNome { get; set; }
        public bool EhDestaque { get; set; }
        public virtual ICollection<Imovel> Imoveis { get; set; }

    }
}
