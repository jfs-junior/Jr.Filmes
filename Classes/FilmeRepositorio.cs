using System.Collections.Generic;
using Jr.Filmes.Interfaces;

namespace Jr.Filmes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>();
        public void Atualizar(int id, Filme entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new System.NotImplementedException();
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