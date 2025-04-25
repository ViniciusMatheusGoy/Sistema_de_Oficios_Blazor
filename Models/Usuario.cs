namespace GerenciamentoOficios.Models;
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string SenhaHash { get; set; }
        public string Contato { get; set; }
        public int SetorID { get; set; }
        public Setor Setor { get; set; }
        public string Role { get; set; }
    }
