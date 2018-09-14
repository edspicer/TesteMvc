using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteMvc.DAL.Context;
using TesteMvc.DAL.Repository;
using TesteMvc.EF;

namespace TesteMvc.Web.Controllers
{
    public class DetalheUsuarioController : Controller
    {
        private DetalheUsuarioRepository _repDet = new DetalheUsuarioRepository();

        // GET: DetalheUsuario
        public ActionResult Index()
        {
            var detalheUsuario = _repDet.GetAll();
            return View(detalheUsuario.ToList());
        }

        // GET: DetalheUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalheUsuario detalheUsuario = _repDet.Find(id);
            if (detalheUsuario == null)
            {
                return HttpNotFound();
            }
            return View(detalheUsuario);
        }

        // GET: DetalheUsuario/Create
        public ActionResult Create()
        {
            List<Usuario> lst = new List<Usuario>();
            using (var rep = new UsuarioRepository())
            {
                lst = rep.GetAll().ToList();
            }

            ViewBag.Usuarioid = new SelectList(lst, "UsuarioId", "Nome");
            return View();
        }

        // POST: DetalheUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetalheId,Usuarioid,Telefone,Endereco")] DetalheUsuario detalheUsuario)
        {
            if (ModelState.IsValid)
            {
                _repDet.Add(detalheUsuario);
                _repDet.Commit();

                return RedirectToAction("Index");
            }


            List<Usuario> lst = new List<Usuario>();
            using (var rep = new UsuarioRepository())
            {
                lst = rep.GetAll().ToList();
            }
            ViewBag.Usuarioid = new SelectList(lst, "UsuarioId", "Nome", detalheUsuario.Usuarioid);
            return View(detalheUsuario);
        }

        // GET: DetalheUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalheUsuario detalheUsuario = _repDet.Find(id);
            if (detalheUsuario == null)
            {
                return HttpNotFound();
            }

            List<Usuario> lst = new List<Usuario>();
            using (var rep = new UsuarioRepository())
            {
                lst = rep.GetAll().ToList();
            }

            ViewBag.Usuarioid = new SelectList(lst, "UsuarioId", "Nome", detalheUsuario.Usuarioid);
            return View(detalheUsuario);
        }

        // POST: DetalheUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetalheId,Usuarioid,Telefone,Endereco")] DetalheUsuario detalheUsuario)
        {
            if (ModelState.IsValid)
            {

                _repDet.Update(detalheUsuario);
                _repDet.Commit();

                return RedirectToAction("Index");
            }
            List<Usuario> lst = new List<Usuario>();
            using (var rep = new UsuarioRepository())
            {
                lst = rep.GetAll().ToList();
            }
            ViewBag.Usuarioid = new SelectList(lst, "UsuarioId", "Nome", detalheUsuario.Usuarioid);
            return View(detalheUsuario);
        }

        // GET: DetalheUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalheUsuario detalheUsuario =_repDet.Find(id);
            if (detalheUsuario == null)
            {
                return HttpNotFound();
            }
            return View(detalheUsuario);
        }

        // POST: DetalheUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalheUsuario detalheUsuario = _repDet.Find(id);
            _repDet.Delete(x=> x.DetalheId==id);
            _repDet.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repDet.Dispose();
            base.Dispose(disposing);
        }
    }
}
