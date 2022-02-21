using System.ComponentModel.DataAnnotations;

namespace ImobAdmin.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [StringLength(50,ErrorMessage = "O tamanho máximo é 50 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Categoria Nome")]
        public string CategoriaNome { get; set; }

        public virtual ICollection<Imovel> Imoveis { get; set; }
    }
}
