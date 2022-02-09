using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required(ErrorMessage = "Informe o preço do imóvel!")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        [StringLength(50, ErrorMessage = "Ultrapassou o limite de caracteres possíveis...")]
        public string NomeContato { get; set; }
        public int TelContato { get; set; }

        [Obsolete]
        public bool EhVenda { get; set; }
        public TipoAcao TipoAcao { get; set; } //bonitao
        [Display(Name = "Está em destaque?")]
        public bool EstaEmDestaque { get; set; }
        [Required(ErrorMessage = "A descrição do imóvel deve ser informada!")]
        [Display(Name = "Descrição")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres...")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres...")]
        public string Descricao { get; set; }
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
