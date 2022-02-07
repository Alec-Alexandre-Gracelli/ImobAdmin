namespace ImobAdmin.Models
{
    public class Imoveis
    {
        public int ImoveisId { get; set; }
        public int TipoImovelId { get; set; }
        public virtual TipoImovel TipoImovel { get; set; }
        public int DescricaoId{ get; set; }
        public virtual Descricao Descricao { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int ImagemId { get; set; }
        public virtual Imagem Imagem { get; set; }
        public decimal Preco { get; set; }
        public string NomeContato { get; set; }
        public int TelContato { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
