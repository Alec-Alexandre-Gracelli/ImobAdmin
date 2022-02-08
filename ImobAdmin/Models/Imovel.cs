namespace ImobAdmin.Models
{
    public class Imovel
    {

        //--- PK e FK's primeiras coisas, na ordem
        public int ImovelId { get; set; }
        public int CategoriaId { get; set; }
        public int BairroId { get; set; }
        public int ImagemId { get; set; }


        //--- resto

        public decimal Preco { get; set; }
        public string NomeContato { get; set; }
        public int TelContato { get; set; }

        [Obsolete]
        public bool EhVenda { get; set; }
        public TipoAcao TipoAcao { get; set; } //bonitao

        public bool EstaEmDestaque { get; set; }

        public string DescricaoNome { get; set; }
        public int Dormitorios { get; set; }
        public int Banheiros { get; set; }
        public int Sala { get; set; }
        public int Cozinha { get; set; }
        public int Vagas { get; set; }
        public bool Churrasqueira { get; set; }
        public bool Piscina { get; set; }
        public bool Edicula { get; set; }






        //------------ Virtual é a última coisa
        public virtual Categoria Categoria { get; set; }//FK

        public virtual Imagem Imagem { get; set; }

        public virtual Bairro Bairro { get; set; }

    }

    public enum TipoAcao
    {
        Venda = 0,
        Locacao = 1,

        VendaAndLocacao = 2,
        Temporario = 3

    }
}
