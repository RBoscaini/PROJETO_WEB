using ProjetoWeb_Stories.Backend.Models;
using ProjetoWeb_Stories.Models;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoWeb_Stories.Mapping
{
    public static class StorieMapping
    {
        public static StorieConsultaModel ToStorieConsulta(Storie storie)
        {
            StorieConsultaModel storieConsulta = new StorieConsultaModel(); 

            storieConsulta.Conteudo = storie.Conteudo;
            storieConsulta.NumVisualização = storie.NumVisualização;
            storieConsulta.DataEnvio = storie.DataEnvio;
            storieConsulta.Id = storie.Id;
            storieConsulta.IdUsuario = storie.IdUsuario;
            storieConsulta.Situacao = storie.Situacao;
            storieConsulta.Usuario = storie.Usuario;
            return storieConsulta;
        }

       
    }
}
