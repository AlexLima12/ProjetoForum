using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ProjetoForum.Models
{
    public class DAOUsuario
    {
        SqlConnection cn = null;
        SqlDataReader sdr = null;
        SqlCommand cmd = null;

        string conexao = @"Data source=.\SqlExpress;Initial Catalog=Forum;User Id=sa;Password=senai@123;";


        public bool CadastrarUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                cn = new SqlConnection(conexao);

                string sqlQuery = "INSERT INTO usuario(nome,login,senha,datacadastro)VALUES(@n,@l,@s,@d)";
                cn.Open();
                cmd = new SqlCommand(sqlQuery, cn);

                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@l", usuario.Login);
                cmd.Parameters.AddWithValue("@s", usuario.Senha);
                //pegar data atual do sistema
                usuario.Datacadastro = DateTime.Now;
                cmd.Parameters.AddWithValue("@d", usuario.Datacadastro);

                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    resultado = true;
                }
                cmd.Parameters.Clear();

            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao cadastrar dados no banco" + e);
            }
            catch (SystemException ex)
            {
                throw new Exception("Erro inesperado do sistema" + ex);
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }


        public List<Usuario> Consultar(){
            List<Usuario> usuarios = new List<Usuario>();

            try{
                 cn = new SqlConnection(conexao);                
                string sqlQuery = "SELECT * FROM usuario";
                cmd = new SqlCommand(sqlQuery, cn);              
                cn.Open();              
                sdr = cmd.ExecuteReader();              
                while (sdr.Read())
                {
                    Usuario usuario = new Usuario(Convert.ToInt32(sdr["id"]), 
                    sdr["nome"].ToString(), 
                    sdr["login"].ToString(), 
                    sdr["senha"].ToString(),                    
                    DateTime.Parse(sdr["datacadastro"].ToString()));

                    usuarios.Add(usuario);
                }

            }

            catch (SqlException e)
            {
                
                throw new Exception("erro ao ler dados" + e.Message);
            }
           
            catch (System.Exception ex)
            {
                throw new Exception("erro inesperado do sistema" + ex.Message);
            }
            
            finally
            {
                //fechanco conexão
                cn.Close();
            }


            return usuarios;
        }


        public string DeletarUsuario(int Id)
        {
            string resultado = null;
            try
            {
                cn = new SqlConnection(conexao);
                string sqlQuery = "DELETE FROM usuario WHERE Id = @Id";
                cn.Open();
                cmd = new SqlCommand(sqlQuery, cn);
                cmd.Parameters.AddWithValue("@Id", Id);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    resultado = "Dado deletado com sucesso.";
                }
                else
                {
                    resultado = "não foi possivel excluir dado";
                }

                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao excluir dados do banco " + ex);
            }
            catch (SystemException e)
            {
                throw new Exception("Erro inesperado do sistema " + e);
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }

    }
}