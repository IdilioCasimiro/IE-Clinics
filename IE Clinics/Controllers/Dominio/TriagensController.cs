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

namespace IE_Clinics.Controllers.Dominio
{
    public class TriagensController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Triagem
        public async Task<ActionResult> Index()
        {
            var Triagens = db.Triagens.Include(t => t.Marcacao);
            return View(await Triagens.ToListAsync());
        }

        // GET: Triagem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Triagem triagem = await db.Triagens.FindAsync(id);
            if (triagem == null)
            {
                return HttpNotFound();
            }
            return View(triagem);
        }

        [ActionName("Efectuar-Triagem")]
        public ActionResult EfectuarTriagem(int id)
        {
            if (id != 0)
            {
                var idPaciente = db.Marcacoes.Find(id).PacienteID;
                ViewBag.NomePaciente = db.Pacientes.Find(idPaciente).Nome;
                return View(new Triagem() { ID = id});
            }

            return RedirectToAction("Index", "Marcacao");
        }

        // POST: Triagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Efectuar-Triagem")]
        public async Task<ActionResult> EfectuarTriagem([Bind(Include = "ID,Peso,FrenquenciaCardiaca,PressaoArterial,Temperatura,Observacoes")] Triagem triagem)
        {
            if (ModelState.IsValid)
            {
                db.Triagens.Add(triagem);
                var marcacao = db.Marcacoes.Find(triagem.ID);
                marcacao.Estado = EstadoMarcacao.Aguardando_Atendimento;
                db.Entry(marcacao).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", triagem.ID);
            return View(triagem);
        }

        // GET: Triagem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Triagem triagem = await db.Triagens.FindAsync(id);
            if (triagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", triagem.ID);
            return View(triagem);
        }

        // POST: Triagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Peso,FrenquenciaCardiaca,PressaoArterial,Observacoes")] Triagem triagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triagem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", triagem.ID);
            return View(triagem);
        }

        // GET: Triagem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Triagem triagem = await db.Triagens.FindAsync(id);
            if (triagem == null)
            {
                return HttpNotFound();
            }
            return View(triagem);
        }

        // POST: Triagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Triagem triagem = db.Triagens.Find(id);
            db.Triagens.Remove(triagem);
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
