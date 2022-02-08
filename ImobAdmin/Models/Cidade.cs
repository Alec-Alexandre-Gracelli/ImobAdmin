namespace ImobAdmin.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string CidadeNome { get; set; }

        public virtual ICollection<Bairro> Bairros { get; set; }

    }
}