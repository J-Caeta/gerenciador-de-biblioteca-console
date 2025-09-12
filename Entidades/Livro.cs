namespace GerenciadorLivro.AppConsole.Entidades
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }

        public Livro(int id, string titulo, string autor, string isbn, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoPublicacao = anoPublicacao;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}, Autor: {Autor}, ISBN: {ISBN}, Ano de Publicação: {AnoPublicacao}";
        }
    }
}