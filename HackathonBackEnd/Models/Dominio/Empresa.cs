using System.Collections.Generic;

namespace HackathonBackEnd.Models.Dominio
{
    public class Empresa
    {
        public string Nome { get; set; }
        public string Origem { get; set; }
        public string SubOrigem { get; set; }
        public string TipoEmpresa { get; set; }
        public string Mercado { get; set; }
        public string Site { get; set; }
        public string Cnpj { get; set; }
        public string telefone1 { get; set; }
        public string telefone2 { get; set; }
        public Endereco Endereco { get; set; }
        public string Observacao { get; set; }
        public int QuantidadeFuncionarios { get; set; }
        public string FrequenciaReunioes { get; set; }
        public string PublicoAlvo { get; set; }
        public int FaturamentoAnual { get; set; }
        public string TipoReuniao { get; set; }
        public IList<Lead> Contatos { get; set; }

    }
}