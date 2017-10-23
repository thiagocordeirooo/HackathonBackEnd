namespace HackathonBackEnd.Models.Dominio
{
    public class Lead
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public bool Decisor { get; set; }
    }
}