namespace ApiCursos.Turmas
{
    public class Turma
    {
        public Guid Id { get; init; }
        public string Nivel { get; set; }
        public int Codigo { get; set; }

        public Turma() { }

        public Turma(String nivel, int codigo)
        {
            Nivel = nivel;
            Id = Guid.NewGuid();
            Codigo = codigo;
        }
    }
}
