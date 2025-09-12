using GerenciadorLivro.AppConsole.Entidades;

namespace GerenciadorLivro.AppConsole.Repositorio
{
    public class LivroRepositorio
    {
        private List<Livro> _listaDeLivros = new List<Livro>();
        private int proximoId = 1;
        public void Adicionar(Livro livro)
        {
            _listaDeLivros.Add(livro);
        }

        public List<Livro> ListarTodos()
        {
            return _listaDeLivros;
        }
        public Livro? BuscarPorId(int id)
        {
            return _listaDeLivros.Find(livro => livro.Id == id);
        }

        public void Remover(Livro livro)
        {
            _listaDeLivros.Remove(livro);
        }
        public int ObterProximoId()
        {
            return proximoId++;
        }
    }
}