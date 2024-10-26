using ApiCursos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System;

namespace ApiCursos.Turmas
{
    public static class TurmasEndpoints
    {
        public static void AddEndpointsTurma(this WebApplication app)
        {
            var rotasTurmas = app.MapGroup(prefix: "turmas");

            rotasTurmas.MapPost("", handler:
                    async (AddTurmaRequest request, AppDbContext context) =>
                    {
                        // Verifica se já existe turma com o código passado
                        var codigoExistente = await context.Turmas.AnyAsync(turma => turma.Codigo == request.Codigo);

                        if (codigoExistente)
                            return Results.Conflict("Já existe turma com o código informado.");

                        var novaTurma = new Turma(request.Nivel, request.Codigo);
                        await context.Turmas.AddAsync(novaTurma);
                        await context.SaveChangesAsync();

                        return Results.Ok(novaTurma);
                    });

            //Retornar as turmas
            rotasTurmas.MapGet("", async (int? codigo, AppDbContext context) =>
            {
                var turmas = context.Turmas.AsQueryable();

                if (codigo != null)
                {
                    turmas = turmas.Where(t => t.Codigo == codigo);
                }

                var resultado = await turmas.ToListAsync();
                return Results.Ok(resultado);
            });

            //Deletar
            rotasTurmas.MapDelete("{id}", async (Guid id, AppDbContext context) =>
            {
                var turma = await context.Turmas
                   .SingleOrDefaultAsync(turma => turma.Id == id);

                if (turma == null)
                    return Results.NotFound();

                // Verifica se há alunos para aquela turma
                var turmaComAlunos = await context.Estudantes.AnyAsync(estudante => estudante.Turmas.Any(t => t.Codigo == turma.Codigo));
                if (turmaComAlunos)
                    return Results.BadRequest("Não é possível excluir a turma, pois há alunos matriculados nela.");


                context.Turmas.Remove(turma);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
