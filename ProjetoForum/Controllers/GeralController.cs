using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoForum.Models;

namespace ProjetoForum.Controllers
{
    public class GeralController : Controller
    {
        DAOUsuario usuarios = new DAOUsuario();

        [HttpPost]
        [Route("API/CadastrarUsuario")]
        public bool CadastrarUsuario([FromBody] Usuario usuario){
           return usuarios.CadastrarUsuario(usuario);
        }


        [HttpGet]
        [Route("API/ConsultarUsuario")]

        //action que enumera elementos de uma lista
        public IEnumerable<Usuario> Listar()
        {
            //retornando dados da lista
            return usuarios.Consultar();
        }

         [HttpDelete("{Id}")]
         [Route("API/DeletarUsuario/{Id}")]
        public string Deletar(int Id)
        {
            return usuarios.DeletarUsuario(Id);
           
        }
    }
}