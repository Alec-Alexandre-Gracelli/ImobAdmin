namespace ImobAdmin.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public bool Venda { get; set; }
        public bool Locacao { get; set; }
        public List<Imoveis> Imoveis { get; set; }
    }
}
