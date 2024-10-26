using ApiCursos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System;

namespace ApiCursos.Estudantes
{
        public static class EstudantesEndpoints
        {
            public static void AddEndpointsEstudantes(this WebApplication app)
            {
                var rotasEstudantes = app.MapGroup(prefix: "estudantes");

                rotasEstudantes.MapPost("", handler: 
                    async (AddEstudanteRequest request, AppDbContext context) =>
                {
                    // Verifica se já existe um estudante com o mesmo CPF
                    var cpfExistente = await context.Estudantes.AnyAsync(estudante => estudante.CPF == request.CPF);

                    if (cpfExistente)
                        return Results.Conflict("Um estudante com este CPF já está cadastrado.");

                    var turma = await context.Turmas.SingleOrDefaultAsync(t => t.Codigo == request.CodigoTurma);
                    if (turma == null)
                        return Results.BadRequest("A turma especificada não existe.");

                    // Verifica se a turma ainda aceita estudantes
                    var quantidadeEstudantes = await context.Estudantes
                        .CountAsync(estudante => estudante.Turmas.Any(t => t.Codigo == request.CodigoTurma));
                    if (quantidadeEstudantes == 5)
                        return Results.BadRequest("A turma já possui o número máximo de estudantes.");


                    var novoEstudante = new Estudante(request.Nome, request.CPF, request.Email);
                    novoEstudante.Turmas.Add(turma);

                    await context.Estudantes.AddAsync(novoEstudante);
                    await context.SaveChangesAsync();

                    return Results.Ok(novoEstudante);
                });

                //Retornar todos os estudantes
                rotasEstudantes.MapGet("", async (string? nome, string? cpf, string? email, AppDbContext context) =>
                {
                    var query = context.Estudantes.AsQueryable();
                    if (!string.IsNullOrEmpty(nome))
                    {
                        query = query.Where(estudante => estudante.Nome.Contains(nome));
                    }
                    if (!string.IsNullOrEmpty(cpf))
                    {
                        query = query.Where(estudante => estudante.CPF.Contains(cpf));
                    }
                    if (!string.IsNullOrEmpty(email))
                    {
                        query = query.Where(estudante => estudante.Email.Contains(email));
                    }

                    var estudantesFiltrados = await query.ToListAsync();
                    return Results.Ok(estudantesFiltrados);
                });

                //Atualizar estudantes
                rotasEstudantes.MapPut("{id:guid}", async (Guid id, UpdateEstudanteRequest request, AppDbContext context) =>
                {
                    var estudante = await context.Estudantes.SingleOrDefaultAsync(estudante => estudante.Id == id);

                    if (estudante == null)
                        return Results.NotFound();

                    estudante.Nome = request.Nome;

                    await context.SaveChangesAsync();
                    return Results.Ok(estudante);
                });

                //Deletar
                rotasEstudantes.MapDelete("{id}", async (Guid id, AppDbContext context) =>
                {
                    var estudante = await context.Estudantes
                       .SingleOrDefaultAsync(estudante => estudante.Id == id);

                    if (estudante == null)
                        return Results.NotFound();

                    context.Estudantes.Remove(estudante);
                    await context.SaveChangesAsync();

                    return Results.NoContent();
                });

            }
        }
}
