namespace ImobAdmin.Models
{
    public class Descricao
    {
        public int DescricaoId { get; set; }
        public string DescricaoNome { get; set; }
        public int Dormitorios { get; set; }
        public int Banheiros { get; set; }
        public int Sala { get; set; }
        public int Cozinha { get; set; }
        public int Vagas { get; set; }
        public bool Churrasqueira { get; set; }
        public bool Piscina { get; set; }
        public bool Edicula { get; set; }
        public int ImoveisId { get; set; }
    }
}
