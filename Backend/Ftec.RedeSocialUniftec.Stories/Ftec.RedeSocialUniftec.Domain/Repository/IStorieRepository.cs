using Ftec.RedeSocialUniftec.Stories.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.RedeSocialUniftec.Stories.Domain.Repository
{
    public interface IStorieRepository
    {
        void Postar(Storie storie);
        Storie Visualizar(Guid id);
        void Excluir(Guid id);
        void Arquivar(Guid id);
        void Temporizador(Guid id);
    }
}
