using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabED15_12.Models
{
    class Livros
    {
        private List<Livro> acervo;

        public Livros()
        {
            acervo = new List<Livro>();
        }

        public List<Livro> Acervo
        {
            get { return acervo; }
            set { acervo = value; }
        }

        public void adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            Livro retorno = new Livro();

            foreach (Livro l in acervo)
            {
                if (l.Isbn == livro.Isbn)
                {
                    retorno = l;
                }
            }

            return retorno;
        }
    }
}
