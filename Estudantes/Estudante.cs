using ApiCursos.Turmas;

namespace ApiCursos.Estudantes
{
    public class Estudante
    {
        public Guid Id { get; init; }
        public string Nome { get; set; } 
        public string CPF { get; set; }
        public string Email { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();

        public Estudante() { }
        public Estudante(string nome, string cpf, string email)
        {
            Nome = nome;
            CPF = cpf;
            Id = Guid.NewGuid();
            Email = email;
        }

    }
}
