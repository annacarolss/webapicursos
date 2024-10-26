Contexto: 
Criação de uma nova Web API para uma empresa que oferece cursos de idiomas. 
 
Requisitos obrigatórios: 
 
A API deve utilizar o Entity Framework com Code First Mapping para trabalhar com o banco de dados; 
Aluno (Nome, CPF e e-mail) 
Turma (Código, nível) 
A API deverá ter os seguintes endpoints: 
CRUD de Aluno  
Cadastro  
Edição  
Listagem  
Exclusão 
 
CRUD de Turma 
Cadastro  
Listagem  
Exclusão 
 
Requisitos bônus: 
 
Restringir o cadastro de aluno repetido (pelo CPF) 
Garantir que no cadastro do aluno, ele esteja sendo matriculado em uma turma; 
Permitir o mesmo aluno ser matriculado em várias turmas diferentes, porém restringir matrícula repetida na mesma turma; 
Uma turma vai ter um número máximo de 5 alunos. Quando esse número for atingido, não deve ser permitido cadastrar mais nenhum aluno novo; 
Restringir exclusão de turma se ela possuir alunos; 
Incluir filtros nas listagens. Podendo filtrar não só pelas informações obrigatórias, como também por informações adicionadas a sua escolha. 
Utilizar princípios do SOLID 
 
API entregue com Swagger para visualização dos endpoints criados. 
