using GerenciadorLivro.AppConsole.Entidades;

namespace GerenciadorLivro.AppConsole.Repositorios
{
    public class UsuarioRepositorio
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }
        public List<Usuario> ObterTodos()
        {
            return usuarios;
        }
        public Usuario? ObterPorEmail(string email)
        {
            return usuarios.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
        public void Remover(Usuario usuario)
        {
            usuarios.Remove(usuario);
        }
        public void Atualizar(Usuario usuario)
        {
            var usuarioExistente = ObterPorEmail(usuario.Email);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Senha = usuario.Senha;
            }
            else
            {
                throw new Exception("Usuário não encontrado.");
        }
    }
    }
}
