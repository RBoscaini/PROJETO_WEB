﻿namespace ProjetoWeb_Stories.Models
{
	public class FeedModel
	{
		public UsuarioModel Usuario { get; set; } = new UsuarioModel();

		public List<String>? ListaURLMidia { get; set; } 

		public  string? Descricao { get; set; }

		public DateTime DataPublicacao { get; set; }

		public int Curtidas { get; set; }

		public bool IsUsuarioAutenticadoCurtiu { get; set; }

		//public List<ComentarioModel> ListaComentarios { get; set; } = [];

	}
}
