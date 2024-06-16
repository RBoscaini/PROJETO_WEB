using Ftec.RedeSocialUniftec.Stories.Application.Adapter;
using Ftec.RedeSocialUniftec.Stories.Application.Dto;
using Ftec.RedeSocialUniftec.Stories.Domain.Entities;
using Ftec.RedeSocialUniftec.Stories.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.RedeSocialUniftec.Stories.Application.Application
{
    public class StorieApplication
    {
        private StorieRepository storieRepository;

        public StorieApplication()
        {
            string strConexao = "Server=localhost;Port=5432;Database=redesocial;User Id=postgres;Password=1234;";
            this.storieRepository = new StorieRepository(strConexao);   
        }

        public Guid Postar(StorieDto storie)
        {
            Storie sto = StorieAdapter.ToDomain(storie);
            sto.Id = Guid.NewGuid();
            storieRepository.Postar(sto);

            return sto.Id;
        }

        public void Arquivar(Guid id)
        {
            storieRepository.Arquivar(id);
        }

        public void Excluir(Guid id)
        {
            storieRepository.Excluir(id);
        }

        public StorieDto Visualizar(Guid id)
        {
            Storie sto = storieRepository.Visualizar(id);
            return StorieAdapter.ToDto(sto);
        }

        public void Temporizador()
        {
            storieRepository.Temporizador();    
        }
    }
}
