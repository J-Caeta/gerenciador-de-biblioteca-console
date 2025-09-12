using GerenciadorLivro.AppConsole.Entidades;
using GerenciadorLivro.AppConsole.Repositorio;

namespace GerenciadorLivro.AppConsole
{
    class Program
    {
        static LivroRepositorio livroRepositorio = new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        CadastrarLivro();
                        break;
                    case "2":
                        ListarLivros();
                        break;
                    case "3":
                        ConsultarLivroPorId();
                        break;
                    case "4":
                        RemoverLivro();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("\nObrigado por usar nosso sistema!");
        }
        private static String ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("Bem-vindo à biblioteca Del Puppo Caetano");
            Console.WriteLine("====================================================");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Cadastrar novo livro");
            Console.WriteLine("2- Listar todos os livros");
            Console.WriteLine("3- Consultar livro por ID");
            Console.WriteLine("4- Deletar livro por ID");
            Console.WriteLine("X- Sair");
            Console.WriteLine("====================================================");
            Console.Write("Opção: ");

            string opcaoUsuario = Console.ReadLine()!.ToUpper();
            return opcaoUsuario;
        }
        private static void CadastrarLivro()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar novo livro");

            Console.Write(" Digite o título do livro: ");
            string titulo = Console.ReadLine()!;

            Console.Write(" Digite o autor do livro: ");
            string autor = Console.ReadLine()!;

            Console.Write(" Digite o ISBN do livro: ");
            string isbn = Console.ReadLine()!;

            Console.Write(" Digite o ano de publicação do livro: ");
            int anoPublicacao = int.Parse(Console.ReadLine()!);

            int id = livroRepositorio.ObterProximoId();
            Livro novoLivro = new Livro(id, titulo, autor, isbn, anoPublicacao);

            livroRepositorio.Adicionar(novoLivro);
            Console.WriteLine("\nLivro cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        private static void ListarLivros()
        {
            Console.Clear();
            Console.WriteLine("Lista de todos os livros cadastrados");

            var listaDeLivros = livroRepositorio.ListarTodos();

            if (listaDeLivros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            else
            {
                foreach (var livro in listaDeLivros)
                {
                    Console.WriteLine(livro);
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        private static void ConsultarLivroPorId()
        {
            Console.Clear();
            Console.WriteLine("Consultar livro por ID");

            Console.Write("Digite o ID do livro: ");
            int id = int.Parse(Console.ReadLine()!);

            var livro = livroRepositorio.BuscarPorId(id);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
            }
            else
            {
                Console.WriteLine(livro);
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        public static void RemoverLivro()
        {
            Console.Clear();
            Console.WriteLine("Remover livro por ID");

            Console.Write("Digite o ID do livro que deseja deletar: ");
            int id = int.Parse(Console.ReadLine()!);

            var livro = livroRepositorio.BuscarPorId(id);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
            }
            else
            {
                Console.WriteLine("\nO livro a seguir será removido:");
                Console.WriteLine(livro);
                Console.WriteLine("Tem certeza que deseja removê-lo? (S/N)");
                string confirmacao = (Console.ReadLine() ?? string.Empty).ToUpper();

                if (confirmacao != "N")
                {

                    livroRepositorio.Remover(livro);
                    Console.WriteLine("Livro removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Operação cancelada. O livro não foi removido.");
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}