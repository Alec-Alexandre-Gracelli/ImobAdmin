using System.ComponentModel.DataAnnotations;

namespace ImobAdmin.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [MaxLength(100,ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string NomeCategoria { get; set; }

        public virtual ICollection<Imovel> Imoveis { get; set; }
    }
}
