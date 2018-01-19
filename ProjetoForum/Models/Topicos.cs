using System;

namespace ProjetoForum.Models
{
    public class Topicos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public Topicos()
        {
        }

        public Topicos(int Id, string Titulo, string Descricao, DateTime DataCadastro)
        {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.DataCadastro = DataCadastro;
        }
    }


}