using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IE_Clinics.Models.Access_Layer;
using IE_Clinics.Models.Dominio;

namespace IE_Clinics.Controllers
{
    public class MedicosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Medico
        public async Task<ActionResult> Index()
        {
            var medicos = db.Medicos.Include(m => m.Especialidade);
            return View(await medicos.ToListAsync());
        }

        // GET: Medico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Include(m => m.Especialidade).Where(m => m.ID == id).FirstOrDefault();
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medico/Create
        public ActionResult Adicionar()
        {
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Nome");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Adicionar([Bind(Include = "ID,EspecialidadeID,Nome,UltimoNome,DataNascimento,Sexo,Pais,Provincia,Endereco,Telefone,TelefoneAlternativo,Email,GrupoSanguineo")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,EspecialidadeID,Nome,UltimoNome,DataNascimento,Sexo,Profissao,Pais,Provincia,Endereco,Telefone,TelefoneAlternativo,Email,GrupoSanguineo")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // GET: Medico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
