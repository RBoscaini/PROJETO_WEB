using Ftec.RedeSocialUniftec.Stories.Domain.Entities;
using Ftec.RedeSocialUniftec.Stories.Domain.Repository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.RedeSocialUniftec.Stories.Repository.Repository
{
    public class StorieRepository : IStorieRepository
    {

        private string strConexao = "";
        public StorieRepository(string Conexao)
        {
            strConexao = Conexao;
        }

        public void Arquivar(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE public.storie " +
                        "SET situacao=@situacao WHERE id=@id;";
                    cmd.Parameters.AddWithValue("situacao", Convert.ToInt16(SituacaoStorie.Arquivado));
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM public.storie WHERE id=@id;";
                    cmd.Parameters.AddWithValue("id", id);
   
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Postar(Storie storie)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO public.storie " +
                        "(id, conteudo, dataenvio, numvisualizacao, situacao, idusuario)" +
                        " VALUES(@id, @conteudo, @dataenvio, @numvisualizacao, @situacao, @idusuario);";
                    cmd.Parameters.AddWithValue("id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("conteudo", storie.Conteudo);
                    cmd.Parameters.AddWithValue("dataenvio", storie.DataEnvio);
                    cmd.Parameters.AddWithValue("numvisualizacao", storie.NumVisualização);
                    cmd.Parameters.AddWithValue("situacao", Convert.ToInt16(storie.Situacao));
                    cmd.Parameters.AddWithValue("idusuario", storie.IdUsuario);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Temporizador()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE public.storie SET situacao=@situacao WHERE dataenvio < NOW() - INTERVAL '1 day' ";
                    cmd.Parameters.AddWithValue("situacao", Convert.ToInt16(SituacaoStorie.Finalizado));
  
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Storie Visualizar(Guid id)
        {

              Storie storie = null;
       //     Usuario usuario = null;

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT public.storie.id, conteudo, dataenvio, numvisualizacao, situacao, idusuario, public.usuario.nome as nomeUsuario" +
                        " FROM public.storie, public.usuario" +
                        " WHERE public.storie.id=@id;";
                    cmd.Parameters.AddWithValue("id", id);
                    var leitor = cmd.ExecuteReader();
                    while (leitor.Read())
                    {
                        storie = new Storie();
                        storie.Usuario = new Usuario();
                        storie.Id = Guid.Parse(leitor["id"].ToString());
                        storie.Conteudo = (byte[])leitor["conteudo"];
                        storie.DataEnvio = (DateTime)leitor["dataenvio"];
                        storie.NumVisualização = Convert.ToInt16(leitor["numvisualizacao"]);
                        storie.Situacao = (SituacaoStorie)leitor["situacao"];
                        storie.IdUsuario = Guid.Parse(leitor["idusuario"].ToString());
                        storie.Usuario.Id = storie.IdUsuario;
                        storie.Usuario.Nome = leitor["nomeUsuario"].ToString();
                    }

                    leitor.Close();


                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE public.storie SET numvisualizacao=@numvisualizacao WHERE id=@id;";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("numvisualizacao", (storie.NumVisualização + 1));
                    cmd.ExecuteNonQuery();

                }
            }
            return storie;

        }

        public List<Storie> VisualizarTodos()
        {

            List<Storie>stories = new List<Storie>();


            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandText = "SELECT public.storie.id, conteudo, dataenvio, numvisualizacao, situacao, idusuario, public.usuario.nome as nomeUsuario" +
                    //    " FROM public.storie INNER JOIN public.usuario ON public.usuario.id = public.storie.idusuario" +
                    //    " WHERE situacao <> 2 ORDER BY dataenvio DESC";

                    cmd.CommandText = "SELECT public.storie.id, conteudo, dataenvio, numvisualizacao, situacao, idusuario, public.usuario.nome as nomeUsuario" +
                        " FROM public.storie, public.usuario" +
                        " WHERE situacao <> 2 ORDER BY dataenvio DESC";



                    var leitor = cmd.ExecuteReader();
                    while (leitor.Read())
                    {
                        Storie storie = null;

                        storie = new Storie();
                        storie.Usuario = new Usuario();
                        storie.Id = Guid.Parse(leitor["id"].ToString());
                        storie.Conteudo = (byte[])leitor["conteudo"];
                        storie.DataEnvio = (DateTime)leitor["dataenvio"];
                        storie.NumVisualização = Convert.ToInt16(leitor["numvisualizacao"]);
                        storie.Situacao = (SituacaoStorie)leitor["situacao"];
                        storie.IdUsuario = Guid.Parse(leitor["idusuario"].ToString());
                        storie.Usuario.Id = storie.IdUsuario;
                        storie.Usuario.Nome = leitor["nomeUsuario"].ToString();

                        stories.Add(storie);
                    }

                    leitor.Close();

                }
            }
            return stories;

        }
    }
}
