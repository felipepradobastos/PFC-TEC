using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;
using PFC.SGP.UI.Validation;
using PFC.SGP.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PFC.SGP.UI.Controllers
{
    [CustomAuthorize(Roles = "Coordenador")]
    public class TrabalhosController : Controller
    {
        private readonly ITrabalhoRepository _trabalhoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IOrientadorRepository _orientadorRepository;

        public TrabalhosController(ITrabalhoRepository trabalhoRepository, IAlunoRepository alunoRepository, IOrientadorRepository orientadorRepository)
        {
            _trabalhoRepository = trabalhoRepository;
            _alunoRepository = alunoRepository;
            _orientadorRepository = orientadorRepository;
        }

        public ActionResult Index()
        {

            List<TrabalhoVM> trabalhos = ObterListaTrabalhos().Where
                                            (t => t.Aluno.Turma.Curso.Coordenador.Login.Equals(User.Identity.Name))
                                            .ToTrabalhoVM()
                                            .ToList();
            return View(trabalhos);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<AlunoVM> alunos = ObterListaAlunos().Where
                (a => a.Turma.Curso.Coordenador.Login.Equals(User.Identity.Name))
                .ToAlunoVM()
                .ToList();
            ViewBag.Orientadores = ObterListaOrientadores().ToOrientadorVM();
            ViewBag.Alunos = alunos;
            return View(new TrabalhoVM());
        }

        [HttpPost]
        public ActionResult Add(TrabalhoVM trabalhoRecebido, String descricaoAluno, String descricaoOrientador)
        {
            String matriculaAluno = descricaoAluno.Split(' ', '-', ' ').First();
            String codigoOrientador = descricaoOrientador.Split(' ', '-', ' ').First();

            Aluno alunoEscolhido = ObterListaAlunos()
                                        .Where(a => a.Matricula.Equals(matriculaAluno))
                                        .FirstOrDefault();
            Orientador orientadorEscolhido = ObterListaOrientadores()
                                                .Where(a => a.Codigo.Equals(codigoOrientador))
                                                .FirstOrDefault();

            if (alunoEscolhido == null || orientadorEscolhido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            Trabalho novoTrabalho = trabalhoRecebido.ToTrabalho(alunoEscolhido, orientadorEscolhido);
            ModelState["Correcao"].Errors.Clear();
            ModelState["Apresentacao"].Errors.Clear();
            ModelState["Turma"].Errors.Clear();
            if (ModelState.IsValid)
            {
                _trabalhoRepository.Persist(novoTrabalho);
                return RedirectToAction("Index");
            }
            List<AlunoVM> alunos = ObterListaAlunos().Where
                                (a => a.Turma.Curso.Coordenador.Login.Equals(User.Identity.Name))
                                .ToAlunoVM()
                                .ToList();
            ViewBag.Orientadores = ObterListaOrientadores()
                                        .ToOrientadorVM();

            ViewBag.Alunos = alunos;
            trabalhoRecebido.Aluno = alunoEscolhido.ToAlunoVM();
            trabalhoRecebido.Orientador = orientadorEscolhido.ToOrientadorVM();

            return View(trabalhoRecebido);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Trabalho trabalhoSalvo = ObterListaTrabalhos()
                                        .Where(t => t.Id == id)
                                        .FirstOrDefault();
            if (trabalhoSalvo == null) return RedirectToAction("404", "Erro");

            ViewBag.alunos = ObterListaAlunos()
                                .ToAlunoVM();
            ViewBag.orientadores = ObterListaOrientadores()
                                    .ToOrientadorVM();

            return View(trabalhoSalvo.ToTrabalhoVM());
        }

        [HttpPost]
        public ActionResult Edit(TrabalhoVM trabRecebido, String descricaoAluno, String descricaoOrientador)
        {
            String matriculaAluno = descricaoAluno.Split(' ', '-', ' ').First();
            String codigoOrientador = descricaoOrientador.Split(' ', '-', ' ').First();

            Aluno alunoEscolhido = ObterListaAlunos()
                            .Where(a => a.Matricula.Equals(matriculaAluno))
                            .FirstOrDefault();
            Orientador orientadorEscolhido = ObterListaOrientadores()
                            .Where(a => a.Codigo.Equals(codigoOrientador))
                            .FirstOrDefault();
            if (alunoEscolhido == null || orientadorEscolhido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            ModelState["Correcao"].Errors.Clear();
            ModelState["Apresentacao"].Errors.Clear();
            ModelState["Turma"].Errors.Clear();

            if (ModelState.IsValid)
            {
                bool podeEditar = ObterListaTrabalhos()
                                    .Where(a => a.Id == trabRecebido.Id)
                                    .FirstOrDefault() != null;
                if (!podeEditar) return RedirectToAction("Unauthorized", "Erro");

                Trabalho novoTrabalho = trabRecebido.ToTrabalho(alunoEscolhido, orientadorEscolhido);
                Trabalho trabalhoSalvo = _trabalhoRepository.Find(novoTrabalho.Id);
                _trabalhoRepository.Update(trabalhoSalvo, novoTrabalho);

                return RedirectToAction("Index");
            }
            ViewBag.alunos = ObterListaAlunos()
                                .ToAlunoVM();
            ViewBag.orientadores = ObterListaOrientadores()
                                        .ToOrientadorVM();

            return View(trabRecebido);
        }

        public ActionResult DelTrab(long id)
        {
            var trab = ObterListaTrabalhos()
                            .Where(t => t.Id == id)
                            .FirstOrDefault();

            if (trab == null) RedirectToAction("Unauthorized", "Erro");

            _trabalhoRepository.Delete(trab);

            return null;
        }

        protected override void Dispose(bool disposing)
        {

        }

        private int[] ObterDataPrevistaApresentacao(Trabalho trab)
        {
            int ano = trab.Aluno.AnoIngresso;
            int semestre = trab.Aluno.MesIngresso;
            int semestresFaltando = (trab.Aluno.Turma.Curso.QtdSemestres - 1) + 1;
            while (semestresFaltando > 0)
            {
                if (semestre > 1)
                {
                    ano++;
                    semestre = 1;
                }
                else
                {
                    semestre++;
                }
                semestresFaltando--;
            }

            return new int[] { ano, semestre };
        }

        private List<Trabalho> ObterListaTrabalhos()
        {
            return _trabalhoRepository.Find(User.Identity.Name).ToList();
        }

        private List<Aluno> ObterListaAlunos()
        {
            return _alunoRepository.Find(User.Identity.Name).ToList();
        }

        private List<Orientador> ObterListaOrientadores()
        {
            return _orientadorRepository.Find(User.Identity.Name).ToList();
        }
    }
}
