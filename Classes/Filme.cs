using System;

namespace Jr.Filmes
{
    public class Filme : EntidadeBase
    {
        private Genero  Genero {get; set;}
        private string  Titulo {get; set;}
        private string  Descricao {get; set;}
        private int     Ano {get; set;}
        private bool    Excluido {get; set;}
        
        public Filme (int id, Genero genero, string titulo, string descricao, int ano) 
        {
            this.Id         = id;
            this.Genero     = genero;
            this.Titulo     = titulo;
            this.Descricao  = descricao;
            this.Ano        = ano;
            this.Excluido   = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno +=  Environment.NewLine;
            retorno += "** INFORMAÇÕES DO FILME **" + Environment.NewLine;
            retorno += "Gênero: "                   + this.Genero + Environment.NewLine;
            retorno += "Título: "                   + this.Titulo + Environment.NewLine;
            retorno += "Descrição: "                + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: "            + this.Ano + Environment.NewLine;
            retorno += "Excluído: "                 + this.Excluido; 
            
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public int RetornaId()
        {
            return this.Id;
        } 
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}