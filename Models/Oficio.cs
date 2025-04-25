namespace GerenciamentoOficios.Models;
    public class Oficio
    {
        public int ID {  get; set; }
        public string Conteudo { get; set; }
        public string CaminhoArquivo { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime? DataRecebimento { get; set; }
        public int RemetenteID { get; set; }
        public Usuario Remetente { get;set; }
        public int DestinatarioID { get; set; }
        public Usuario Destinatario { get;set; }
        public bool status {  get; set; }
    }

