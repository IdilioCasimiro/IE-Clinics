using IE_Clinics.Models.Access_Layer;
using IE_Clinics.Models.Dominio;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IE_Clinics.Controllers.Dominio
{
    public class PrescricoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Prescricoes
        public async Task<ActionResult> Index()
        {
            var prescricoes = db.Prescricoes.Include(p => p.Marcacao);
            return View(await prescricoes.ToListAsync());
        }

        // GET: Prescricoes/Details/5
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

        // GET: Prescricoes/Create
        public ActionResult Create(int id)
        {
            if(id != 0){
                var marcacao = db.Marcacoes.Find(id);
                ViewBag.NomePaciente = db.Pacientes.Find(marcacao.PacienteID).Nome;
                return View(new Prescricao { PrescricaoID = id });
            }
            
            return RedirectToAction("Index", "Marcacoes");
        }

        // POST: Prescricoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrescricaoID, Medicamentos")] Prescricao prescricao)
        {
            if (ModelState.IsValid)
            {
                db.Prescricoes.Add(prescricao);
                await db.SaveChangesAsync();

                var marcacao = await db.Marcacoes.FindAsync(prescricao.PrescricaoID);
                ViewBag.NomePaciente = db.Pacientes.Find(marcacao.PacienteID).Nome;
                return RedirectToAction("Create", "AnalisesMedicas", new { id = marcacao.ID});
            }

            ViewBag.PrescricaoID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", prescricao.PrescricaoID);
            return View(prescricao);
        }

        // GET: Prescricoes/Edit/5
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
            ViewBag.PrescricaoID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", prescricao.PrescricaoID);
            return View(prescricao);
        }

        // POST: Prescricoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrescricaoID")] Prescricao prescricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescricao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PrescricaoID = new SelectList(db.Marcacoes, "ID", "TipoMarcacao", prescricao.PrescricaoID);
            return View(prescricao);
        }

        // GET: Prescricoes/Delete/5
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

        // POST: Prescricoes/Delete/5
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
