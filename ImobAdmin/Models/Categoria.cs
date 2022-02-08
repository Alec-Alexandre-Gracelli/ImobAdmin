using System.ComponentModel.DataAnnotations;

namespace ImobAdmin.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [MaxLength(100)]
        public string NomeCategoria { get; set; }


        public virtual ICollection<Imovel> Imoveis { get; set; }
    }
}
