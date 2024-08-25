using SistemaCursos.Dados.Repositories;
using SistemaCursos.Model.Entities;

class Program
{
    static void Main(string[] args)
    {
        IncuirAluno();
        var alunos = ConsultarTodosAluno();

        if (alunos?.Count > 0)
            AlterarNomeAluno(alunos[0]);
            ExcluirAluno(alunos[1].Id);
    }

    private static void IncuirAluno()
    {
        var repoAluno = new AlunoRepository();
        Aluno aluno = new Aluno("Tati", "endereço", "email@email.com");
        repoAluno.Incluir(aluno);
        Aluno aluno2 = new Aluno("Tati", "endereço", "email@email.com");
        repoAluno.Incluir(aluno2);
    }
    private static void AlterarNomeAluno(Aluno aluno)
    {
        var repoAluno = new AlunoRepository();
        repoAluno.AlterarAluno(aluno.AlterarNome("Layla"));

    }
    private static List<Aluno> ConsultarTodosAluno()
    {
        var repoAluno = new AlunoRepository();        
        return repoAluno.SelectionarTudo();
    }
    private static void ExcluirAluno(int id)
    {
        var repoAluno = new AlunoRepository();
        repoAluno.Excluir(id);

    }

}