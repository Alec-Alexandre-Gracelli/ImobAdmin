namespace ImobAdmin.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }
        public string ImagemNome { get; set; }
        public bool EhDestaque { get; set; }
        public virtual ICollection<Imovel> Imoveis { get; set; }

    }
}
