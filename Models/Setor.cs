namespace GerenciamentoOficios.Models;

    public class Setor
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }

