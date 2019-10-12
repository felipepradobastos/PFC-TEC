using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;
using PFC.SGP.UI.Validation;
using PFC.SGP.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace PFC.SGP.UI.Controllers
{
    [CustomAuthorize(Roles = "Coordenador")]
    public class TurmasController : Controller
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TurmasController(ITurmaRepository turmaRepository, ICursoRepository cursoRepository, IUsuarioRepository usuarioRepository)
        {
            _turmaRepository = turmaRepository;
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var turmas = ObterListaTurmas()
                .ToTurmaVM()
                .ToList();
            ViewBag.Cursos = ObterListaCursos().ToCursoVM();
            return View(turmas);
        }

        [HttpPost]
        public ActionResult Add(TurmaVM turmaRecebida, int idCurso)
        {
            Usuario usuarioAutenticado = ObterListaUsuarios().FirstOrDefault(u => u.Login == User.Identity.Name);
            if (usuarioAutenticado == null) return RedirectToAction("Unauthorized", "Erro");
            List<Curso> cursosDoUsuario = usuarioAutenticado.Cursos.ToList();

            List<Curso> cursos = cursosDoUsuario.Where(c => c.Id == idCurso).ToList();
            if (cursos.Count <= 0) return HttpNotFound();

            Turma turma = turmaRecebida.ToTurma(cursos.First(), new List<Aluno>());
            ModelState["Curso"].Errors.Clear();

            bool codigoExistente = ObterListaTurmas()
                .FirstOrDefault(t => t.Codigo.Equals(turma.Codigo, StringComparison.InvariantCultureIgnoreCase) && !t.Id.Equals(turma.Id)) != null;
            if (codigoExistente)
            {
                ModelState.AddModelError("Codigo", "Já existe uma turma com esse código");
            }

            if (ModelState.IsValid)
            {
                _turmaRepository.Persist(turma);

                return Json("true", JsonRequestBehavior.AllowGet);
            }

            return Json("false", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(TurmaVM turmaRecebida, int idCurso)
        {
            Turma turmaSalva = ObterListaTurmas().Where(t => t.Id == turmaRecebida.Id).FirstOrDefault();
            if (turmaSalva == null) return HttpNotFound();
            Usuario usuarioAutenticado = ObterListaUsuarios().FirstOrDefault(u => u.Login == User.Identity.Name);
            if (usuarioAutenticado == null) return RedirectToAction("Unauthorized", "Erro");

            var curso = ObterListaCursos().Where(c => c.Id.Equals(idCurso)).FirstOrDefault();
            if (curso == null) return HttpNotFound();
            ModelState["Curso"].Errors.Clear();

            bool codigoExistente = ObterListaTurmas()
                .FirstOrDefault(t => t.Codigo.Equals(turmaRecebida.Codigo, StringComparison.InvariantCultureIgnoreCase) && !t.Id.Equals(turmaRecebida.Id)) != null;

            bool podeEditar = ObterListaTurmas().Where(t => t.Id == turmaSalva.Id).FirstOrDefault() != null;
            if (!podeEditar) return RedirectToAction("Unauthorized", "Erro");

            if (codigoExistente)
            {
                ModelState.AddModelError("Codigo", "Já existe uma turma com esse código");
            }

            if (ModelState.IsValid)
            {
                turmaSalva.Codigo = turmaRecebida.Codigo;
                turmaSalva.Curso = curso;
                _turmaRepository.Merge(turmaSalva);

                return Json("true", JsonRequestBehavior.AllowGet);
            }

            return Json("false", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DelTurma(long id)
        {
            var turma = ObterListaTurmas().Where(t => t.Id == id).FirstOrDefault();
            if (turma == null) return RedirectToAction("Unauthorized", "Erro");
            if (turma.Alunos.Count > 0)
            {
                return new HttpStatusCodeResult(400);
                //Verificação a ser feita em caso de exclusão lógica (atualmente não implementada)
                //foreach (var aluno in turma.Alunos)
                //{
                //    if (aluno.Ativo == 1)
                //    {
                //        return new HttpStatusCodeResult(400);
                //    }
                //}
            }
            _turmaRepository.Delete(turma);
            return null;
        }

        protected override void Dispose(bool disposing)
        {

        }

        private List<Curso> ObterListaCursos()
        {
            List<Curso> cursos = _cursoRepository.Find(User.Identity.Name).ToList();

            return cursos;
        }

        private List<Turma> ObterListaTurmas()
        {
            return _turmaRepository.Find(User.Identity.Name).ToList();
        }

        private List<Usuario> ObterListaUsuarios()
        {
            return _usuarioRepository.Find().ToList();
        }
    }

    public class AddCheckViewModel
    {
        public AddCheckViewModel(string IsError, string Message)
        {
            this.IsError = IsError;
            this.Message = Message;
        }

        [DisplayName("IsError")]
        public string IsError { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }
    }
}
