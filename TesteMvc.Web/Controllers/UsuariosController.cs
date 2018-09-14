using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteMvc.DAL;
using TesteMvc.DAL.Repository;
using TesteMvc.EF;

namespace TesteMvc.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _repUser = new UsuarioRepository();


        public ActionResult Index()
        {
            return View(_repUser.GetAll().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario user = _repUser.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
            //return Json(user, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="UsuarioId,Nome,Sobrenome,Email")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _repUser.Add(usuario);
                _repUser.Commit();

                return RedirectToAction("Index");
            }


            return View(usuario);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario user = _repUser.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
            //return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,Nome,Sobrenome,Email")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _repUser.Update(usuario);
                _repUser.Commit();

                return RedirectToAction("Index");
            }


            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Usuario user = _repUser.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {


            using (var repDet = new DetalheUsuarioRepository())
            {
                List<DetalheUsuario> lst = repDet.GetAll().Where(x => x.Usuarioid == id).ToList();

                if (lst.Count > 0)
                    lst.ForEach(z=> {
                        repDet.Delete(a => a.DetalheId == z.DetalheId);
                    });
                repDet.Commit();
            }


            Usuario user = _repUser.Find(id);

            _repUser.Delete(c => c == user);

            
            _repUser.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repUser.Dispose();
            base.Dispose(disposing);
        }

    }
}
