using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;
using PFC.SGP.UI.Validation;
using PFC.SGP.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PFC.SGP.UI.Controllers
{
    [CustomAuthorize(Roles = "Coordenador")]
    public class OrientadoresController : Controller
    {
        private readonly IOrientadorRepository _orientadorRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public OrientadoresController(IOrientadorRepository orientadorRepository, IUsuarioRepository usuarioRepository)
        {
            _orientadorRepository = orientadorRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var orientadores = ObterListaOrientadores()
                                    .ToOrientadorVM()
                                    .ToList();
            return View(orientadores);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new OrientadorVM());
        }

        [HttpPost]
        public ActionResult Add(OrientadorVM orientadorRecebido)
        {
            var query = ObterListaUsuarios().Where(c => c.Login.Equals(User.Identity.Name)).ToList();
            if (query.Count == 0) return HttpNotFound();

            Orientador novoOrientador = orientadorRecebido.ToOrientador();

            bool codigoExistente = ObterListaOrientadores()
                .FirstOrDefault(o => o.Codigo.Equals(novoOrientador.Codigo, StringComparison.InvariantCultureIgnoreCase) && !o.Id.Equals(novoOrientador.Id)) != null;

            if (codigoExistente)
            {
                ModelState.AddModelError("Codigo", "Já existe um orientador com esse código");
            }
            if (ModelState.IsValid)
            {
                novoOrientador.Coordenador = ObterListaUsuarios()
                                            .Where(u => u.Login.Equals(User.Identity.Name))
                                            .FirstOrDefault();
                _orientadorRepository.Persist(novoOrientador);
                return RedirectToAction("Index");
            }
            return View(novoOrientador.ToOrientadorVM());

        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var orientador = ObterListaOrientadores().Where(o => o.Id == id).FirstOrDefault();
            if (orientador == null) return RedirectToAction("Unauthorized", "Erro");

            return View(orientador.ToOrientadorVM());
        }

        [HttpPost]
        public ActionResult Edit(OrientadorVM orientadorRecebido)
        {
            orientadorRecebido.Codigo = orientadorRecebido.Codigo.ToUpper();
            var query = ObterListaUsuarios().Where(c => c.Login.Equals(User.Identity.Name)).ToList();
            if (query.Count == 0) return HttpNotFound();

            Orientador novoOrientador = orientadorRecebido.ToOrientador();
            Orientador orientadorSalvo = ObterListaOrientadores()
                                            .Where(o => o.Id == novoOrientador.Id)
                                            .FirstOrDefault();
            if (orientadorSalvo == null) return RedirectToAction("Unauthorized", "Erro");

            bool codigoExistente = ObterListaOrientadores()
                .FirstOrDefault(o => o.Codigo.Equals(orientadorRecebido.Codigo, StringComparison.InvariantCultureIgnoreCase) && !o.Id.Equals(orientadorRecebido.Id)) != null;
            bool podeEditar = ObterListaOrientadores().Where(o => o.Id == orientadorSalvo.Id).FirstOrDefault() != null;
            if (!podeEditar) return RedirectToAction("Unauthorized", "Erro");
            if (codigoExistente)
            {
                ModelState.AddModelError("Codigo", "Já existe um orientador com esse código");
            }
            if (ModelState.IsValid)
            {
                _orientadorRepository.Update(orientadorSalvo, novoOrientador);
                return RedirectToAction("Index");
            }

            return View(novoOrientador.ToOrientadorVM());
        }

        [HttpGet]
        public ActionResult DelOrientador(long id)
        {
            Orientador orientadorSalvo = ObterListaOrientadores().Where(o => o.Id == id).FirstOrDefault();
            if (orientadorSalvo == null) return RedirectToAction("Unauthorized", "Erro");
            if (orientadorSalvo.Trabalhos.Count > 0)
            {
                return new HttpStatusCodeResult(400);
                //Verificação a ser feita em caso de exclusão lógica (atualmente não implementada)
                //foreach (var trab in orientadorSalvo.Trabalhos)
                //{
                //    if (trab.Ativo == 1)
                //    {
                //        return new HttpStatusCodeResult(400);
                //    }
                //}
            }
            _orientadorRepository.Delete(orientadorSalvo);

            return null;
        }

        private List<Orientador> ObterListaOrientadores()
        {
            return _orientadorRepository.Find(User.Identity.Name).ToList();
        }

        private List<Usuario> ObterListaUsuarios()
        {
            return _usuarioRepository.Find().ToList();
        }
    }
}
