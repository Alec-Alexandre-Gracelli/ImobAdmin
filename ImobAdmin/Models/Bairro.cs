namespace ImobAdmin.Models
{
    public class Bairro
    {
        public int BairroId { get; set; }
        public int CidadeId { get; set; }
        public string BairroNome { get; set; }


        public virtual Cidade Cidade { get; set; }

    }
}
