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
    public class PrescricoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Prescricaes
        public async Task<ActionResult> Index()
        {
            var prescricoes = db.Prescricoes.Include(p => p.Marcacao);
            return View(await prescricoes.ToListAsync());
        }

        // GET: Prescricaes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescricao prescricao = await db.Prescricoes.FindAsync(id);
            if (prescricao == null)
            {
                return HttpNotFound();
            }
            return View(prescricao);
        }

        // GET: Prescricaes/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao");
            return View();
        }

        // POST: Prescricaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID")] Prescricao prescricao)
        {
            if (ModelState.IsValid)
            {
                db.Prescricoes.Add(prescricao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", prescricao.ID);
            return View(prescricao);
        }

        // GET: Prescricaes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescricao prescricao = await db.Prescricoes.FindAsync(id);
            if (prescricao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", prescricao.ID);
            return View(prescricao);
        }

        // POST: Prescricaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID")] Prescricao prescricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescricao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", prescricao.ID);
            return View(prescricao);
        }

        // GET: Prescricaes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescricao prescricao = await db.Prescricoes.FindAsync(id);
            if (prescricao == null)
            {
                return HttpNotFound();
            }
            return View(prescricao);
        }

        // POST: Prescricaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prescricao prescricao = await db.Prescricoes.FindAsync(id);
            db.Prescricoes.Remove(prescricao);
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
