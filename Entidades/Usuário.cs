namespace GerenciadorLivro.AppConsole.Entidades
{
    public class Usuário
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        public Usuário(string nome, int idade, int id, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Email = email;
            Senha = senha;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Idade: {Idade}, Email: {Email}, Senha: {Senha}";
        }
    }
}