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
    public class AnalisesMedicasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: AnalisesMedicas
        public async Task<ActionResult> Index()
        {
            var analiseMedicas = db.AnaliseMedicas.Include(a => a.Marcacao);
            return View(await analiseMedicas.ToListAsync());
        }

        // GET: AnalisesMedicas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnaliseMedica analiseMedica = await db.AnaliseMedicas.FindAsync(id);
            if (analiseMedica == null)
            {
                return HttpNotFound();
            }
            return View(analiseMedica);
        }

        // GET: AnalisesMedicas/Create
        public ActionResult Create(int id)
        {
            if (id != 0)
            {
                var marcacao = db.Marcacoes.Find(id);
                ViewBag.NomePaciente = db.Pacientes.Find(marcacao.PacienteID).Nome;
                return View(new AnaliseMedica { AnaliseMedicaID = id });
            }
            ViewBag.AnaliseMedicaID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao");
            return View();
        }

        // POST: AnalisesMedicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AnaliseMedicaID,IndicacaoClinica,Exames")] AnaliseMedica analiseMedica)
        {
            if (ModelState.IsValid)
            {
                db.AnaliseMedicas.Add(analiseMedica);
                var marcacao = await db.Marcacoes.FindAsync(analiseMedica.AnaliseMedicaID);
                marcacao.Estado = EstadoMarcacao.Paciente_Atendido;
                db.Entry(marcacao).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Marcacoes");
            }

            ViewBag.AnaliseMedicaID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", analiseMedica.AnaliseMedicaID);
            return View(analiseMedica);
        }

        // GET: AnalisesMedicas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnaliseMedica analiseMedica = await db.AnaliseMedicas.FindAsync(id);
            if (analiseMedica == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnaliseMedicaID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", analiseMedica.AnaliseMedicaID);
            return View(analiseMedica);
        }

        // POST: AnalisesMedicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AnaliseMedicaID,IndicacaoClinica,Exames")] AnaliseMedica analiseMedica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analiseMedica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AnaliseMedicaID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", analiseMedica.AnaliseMedicaID);
            return View(analiseMedica);
        }

        // GET: AnalisesMedicas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnaliseMedica analiseMedica = await db.AnaliseMedicas.FindAsync(id);
            if (analiseMedica == null)
            {
                return HttpNotFound();
            }
            return View(analiseMedica);
        }

        // POST: AnalisesMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AnaliseMedica analiseMedica = await db.AnaliseMedicas.FindAsync(id);
            db.AnaliseMedicas.Remove(analiseMedica);
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
