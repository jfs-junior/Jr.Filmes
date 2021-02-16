using System.Collections.Generic;
using Jr.Filmes.Interfaces;

namespace Jr.Filmes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>();
        public void Atualizar(int id, Filme objeto)
        {
            listaFilme[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Insere(Filme entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Filme> Lista()
        {
            throw new System.NotImplementedException();
        }

        public int ProximoId()
        {
            throw new System.NotImplementedException();
        }

        public Filme RetornaPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}