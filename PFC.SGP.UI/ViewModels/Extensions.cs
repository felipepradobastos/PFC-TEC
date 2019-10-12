using PFC.SGP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PFC.SGP.UI.ViewModels
{
    public static class Extensions
    {
        //ALUNO
        public static AlunoVM ToAlunoVM(this Aluno aluno)
        {
            return new AlunoVM()
            {
                Id = aluno.Id,
                AnoIngresso = aluno.AnoIngresso,
                Email = aluno.Email,
                DataCadastro = aluno.DataCadastro,
                Matricula = aluno.Matricula,
                Nome = aluno.Nome,
                MesIngresso = aluno.MesIngresso,
                Sobrenome = aluno.Sobrenome,
                Status = aluno.Status,
                Telefone = aluno.Telefone,
                Turma = aluno.Turma.Codigo,
                AnoApresentacao = aluno.AnoApresentacao,
                MesApresentacao = aluno.MesApresentacao
            };
        }
        public static IEnumerable<AlunoVM> ToAlunoVM(this IEnumerable<Aluno> data)
        {
            return data.Select(aluno => new AlunoVM()
            {
                Id = aluno.Id,
                AnoIngresso = aluno.AnoIngresso,
                Email = aluno.Email,
                DataCadastro = aluno.DataCadastro,
                Matricula = aluno.Matricula,
                Nome = aluno.Nome,
                MesIngresso = aluno.MesIngresso,
                Sobrenome = aluno.Sobrenome,
                Status = aluno.Status,
                Telefone = aluno.Telefone,
                Turma = aluno.Turma.Codigo,
                AnoApresentacao = aluno.AnoApresentacao,
                MesApresentacao = aluno.MesApresentacao
            });
        }
        public static Aluno ToAluno(this AlunoVM aluno, Turma turma)
        {
            return new Aluno()
            {
                Id = aluno.Id,
                AnoIngresso = aluno.AnoIngresso,
                Email = aluno.Email,
                DataCadastro = aluno.DataCadastro,
                Matricula = aluno.Matricula,
                Nome = aluno.Nome,
                MesIngresso = aluno.MesIngresso,
                Sobrenome = aluno.Sobrenome,
                Status = aluno.Status,
                Telefone = aluno.Telefone,
                Turma = turma,
                AnoApresentacao = aluno.AnoApresentacao,
                MesApresentacao = aluno.MesApresentacao
            };
        }
        public static IEnumerable<Aluno> ToAluno(this IEnumerable<AlunoVM> data, Turma turma)
        {
            return data.Select(aluno => new Aluno()
            {
                Id = aluno.Id,
                AnoIngresso = aluno.AnoIngresso,
                Email = aluno.Email,
                DataCadastro = aluno.DataCadastro,
                Matricula = aluno.Matricula,
                Nome = aluno.Nome,
                MesIngresso = aluno.MesIngresso,
                Sobrenome = aluno.Sobrenome,
                Status = aluno.Status,
                Telefone = aluno.Telefone,
                Turma = turma,
                AnoApresentacao = aluno.AnoApresentacao,
                MesApresentacao = aluno.MesApresentacao
            });
        }

        //TURMA
        public static TurmaVM ToTurmaVM(this Turma turma)
        {
            return new TurmaVM()
            {
                Id = turma.Id,
                Codigo = turma.Codigo,
                AlunosCadastrados = turma.AlunosCadastrados(),
                Curso = turma.Curso.Nome,
            };
        }
        public static IEnumerable<TurmaVM> ToTurmaVM(this IEnumerable<Turma> data)
        {
            return data.Select(turma => new TurmaVM()
            {
                Id = turma.Id,
                Codigo = turma.Codigo,
                AlunosCadastrados = turma.AlunosCadastrados(),
                Curso = turma.Curso.Nome,
            });
        }
        public static Turma ToTurma(this TurmaVM turma, Curso curso, List<Aluno> alunos)
        {   
            return new Turma()
            {
                Id = turma.Id,
                Codigo = turma.Codigo,
                Alunos = alunos,
                Curso = curso,
                
            };
        }
        public static IEnumerable<Turma> ToTurma(this IEnumerable<TurmaVM> data, Curso curso, List<Aluno> alunos)
        {
            return data.Select(turma => new Turma()
            {
                Id = turma.Id,
                Codigo = turma.Codigo,
                Curso = curso,
                Alunos = alunos,
            });
        }

        //ORIENTADORES
        public static OrientadorVM ToOrientadorVM(this Orientador orientador)
        {
            return new OrientadorVM()
            {
                Id = orientador.Id,
                Codigo = orientador.Codigo,
                DataCadastro = orientador.DataCadastro,
                Email = orientador.Email,
                Nome = orientador.Nome,
                Sobrenome = orientador.Sobrenome,
                Telefone = orientador.Telefone
            };
        }
        public static IEnumerable<OrientadorVM> ToOrientadorVM(this IEnumerable<Orientador> data)
        {
            return data.Select(orientador => new OrientadorVM()
            {
                Id = orientador.Id,
                Codigo = orientador.Codigo,
                DataCadastro = orientador.DataCadastro,
                Email = orientador.Email,
                Nome = orientador.Nome,
                Sobrenome = orientador.Sobrenome,
                Telefone = orientador.Telefone
            });
        }
        public static Orientador ToOrientador(this OrientadorVM orientadorVM)
        {
            return new Orientador()
            {
                Id = orientadorVM.Id,
                Codigo = orientadorVM.Codigo,
                DataCadastro = orientadorVM.DataCadastro,
                Email = orientadorVM.Email,
                Nome = orientadorVM.Nome,
                Sobrenome = orientadorVM.Sobrenome,
                Telefone = orientadorVM.Telefone

            };
        }
        public static IEnumerable<Orientador> ToOrientador(this IEnumerable<OrientadorVM> data)
        {
            return data.Select(orientadorVM => new Orientador()
            {
                Id = orientadorVM.Id,
                Codigo = orientadorVM.Codigo,
                DataCadastro = orientadorVM.DataCadastro,
                Email = orientadorVM.Email,
                Nome = orientadorVM.Nome,
                Sobrenome = orientadorVM.Sobrenome,
                Telefone = orientadorVM.Telefone
            });
        }
        //Trabalho
        public static TrabalhoVM ToTrabalhoVM(this Trabalho trabalho)
        {
            return new TrabalhoVM()
            {
                Aluno = trabalho.Aluno.ToAlunoVM(),
                Apresentacao = trabalho.Aluno.MesApresentacao+ "/"+trabalho.Aluno.AnoApresentacao,
                Correcao = trabalho.Aluno.MesApresentacao + "/" + trabalho.Aluno.AnoApresentacao,
                DataCadastro = trabalho.DataCadastro,
                Id = trabalho.Id,
                Nome = trabalho.Nome,
                Orientador = trabalho.Orientador.ToOrientadorVM(),
                Turma = trabalho.Aluno.Turma.Codigo
                
            };
        }
        public static IEnumerable<TrabalhoVM> ToTrabalhoVM(this IEnumerable<Trabalho> data)
        {
            return data.Select(trabalho => new TrabalhoVM()
            {
                Aluno = trabalho.Aluno.ToAlunoVM(),
                Apresentacao = trabalho.Aluno.MesApresentacao + "/" + trabalho.Aluno.AnoApresentacao,
                Correcao = trabalho.Aluno.MesApresentacao + "/" + trabalho.Aluno.AnoApresentacao,
                DataCadastro = trabalho.DataCadastro,
                Id = trabalho.Id,
                Nome = trabalho.Nome,
                Orientador = trabalho.Orientador.ToOrientadorVM(),
                Turma = trabalho.Aluno.Turma.Codigo
            });
        }
            
        public static Trabalho ToTrabalho(this TrabalhoVM trabalhoVM, Aluno aluno, Orientador orientador)
        {
            return new Trabalho()
            {
                Aluno = aluno,
                DataCadastro = trabalhoVM.DataCadastro,
                Id = trabalhoVM.Id,
                Nome = trabalhoVM.Nome,
                Orientador = orientador

            };
        }
        public static IEnumerable<Trabalho> ToTrabalho(this IEnumerable<TrabalhoVM> data, Aluno aluno, Orientador orientador)
        {
            return data.Select(trabalhoVM => new Trabalho()
            {
                Aluno = aluno,
                DataCadastro = trabalhoVM.DataCadastro,
                Id = trabalhoVM.Id,
                Nome = trabalhoVM.Nome,
                Orientador = orientador
            });
        }
        //-TRAB2
        public static Home.Dashboard.TrabalhoDashboardVM ToTrabalhoDashboardVM(this Trabalho trabalho)
        {
            return new Home.Dashboard.TrabalhoDashboardVM()
            {
                Aluno = trabalho.Aluno.ToAlunoVM(),
                AnoApresentacao = trabalho.Aluno.AnoApresentacao.ToString(),
                MesApresentacao = trabalho.Aluno.MesApresentacao.ToString(),
                DataCadastro = trabalho.DataCadastro,
                Id = trabalho.Id,
                Nome = trabalho.Nome,
                Orientador = trabalho.Orientador.ToOrientadorVM(),
                Turma = trabalho.Aluno.Turma.Codigo

            };
        }
        public static IEnumerable<Home.Dashboard.TrabalhoDashboardVM> ToTrabalhoDashboardVM(this IEnumerable<Trabalho> data)
        {
            return data.Select(trabalho =>
                {
                    return new Home.Dashboard.TrabalhoDashboardVM()
                    {
                        Aluno = trabalho.Aluno.ToAlunoVM(),
                        AnoApresentacao = trabalho.Aluno.AnoApresentacao.ToString(),
                        MesApresentacao = trabalho.Aluno.MesApresentacao.ToString(),
                        DataCadastro = trabalho.DataCadastro,
                        Id = trabalho.Id,
                        Nome = trabalho.Nome,
                        Orientador = trabalho.Orientador.ToOrientadorVM(),
                        Turma = trabalho.Aluno.Turma.Codigo
                    };
                }
            );
        }
        //CONTA
        public static UsuarioVM ToUsuarioVM(this Usuario u)
        {
            return new UsuarioVM()
            {
                Id = u.Id,
                Login = u.Login,
                Codigo = u.Codigo,
                Nome = u.Nome,
                Sobrenome = u.Sobrenome,
                Email = u.Email,
                Telefone = u.Telefone,
                Cursos = u.Cursos,
                DataCadastro = u.DataCadastro
            };
        }
        public static IEnumerable<UsuarioVM> ToUsuarioVM(this IEnumerable<Usuario> data)
        {
            return data.Select(u => new UsuarioVM()
            {
                Id = u.Id,
                Login = u.Login,
                Codigo = u.Codigo,
                Nome = u.Nome,
                Sobrenome = u.Sobrenome,
                Email = u.Email,
                Telefone = u.Telefone,
                Cursos = u.Cursos,
                DataCadastro = u.DataCadastro
                
            });
        }

        public static Usuario ToUsuario(this UsuarioVM u)
        {
            return new Usuario()
            {
                Id = u.Id,
                Login = u.Login,
                Codigo = u.Codigo,
                Nome = u.Nome,
                Sobrenome = u.Sobrenome,
                Email = u.Email,
                Telefone = u.Telefone,
                Cursos = u.Cursos,
                DataCadastro = u.DataCadastro
                
            };
        }
        //Curso
        public static CursoVM ToCursoVM(this Curso curso)
        {
            return new CursoVM()
            {
                Id = curso.Id,
                Nome = curso.Nome,
                QtdSemestres = curso.QtdSemestres,
                Turmas = curso.Turmas,
                DataCadastro = curso.DataCadastro

            };
        }
        public static IEnumerable<CursoVM> ToCursoVM(this IEnumerable<Curso> data)
        {
            return data.Select(curso => new CursoVM()
            {
                Id = curso.Id,
                Nome = curso.Nome,
                QtdSemestres = curso.QtdSemestres,
                Turmas = curso.Turmas,
                DataCadastro = curso.DataCadastro
            });
        }
        public static Curso ToCurso(this CursoVM cursoVM)
        {
            return new Curso()
            {
                Id = cursoVM.Id,
                Nome = cursoVM.Nome,
                QtdSemestres = cursoVM.QtdSemestres,
                DataCadastro = cursoVM.DataCadastro

            };
        }
        public static IEnumerable<Curso> ToCurso(this IEnumerable<CursoVM> data, ICollection<Turma> turmas, Usuario coordenador)
        {
            return data.Select(cursoVM => new Curso()
            {
                Id = cursoVM.Id,
                Nome = cursoVM.Nome,
                QtdSemestres = cursoVM.QtdSemestres,
                Turmas = turmas,
                DataCadastro = cursoVM.DataCadastro,
                Coordenador = coordenador
            });
        }
    }
}
