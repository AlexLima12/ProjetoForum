using System;

namespace ProjetoForum.Models
{
    public class Postagens
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataPublicacao { get; set; }


        public Postagens(){

        }

        public Postagens(int Id, string Mensagem, DateTime DataPublicacao){

        }
    }
}