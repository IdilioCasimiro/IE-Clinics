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
    public class MedicamentosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Medicamentos
        public async Task<ActionResult> Index()
        {
            return View(await db.Medicamentos.ToListAsync());
        }

        // GET: Medicamentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = await db.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nome,Descricao,Quantidade,Valor")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Medicamentos.Add(medicamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = await db.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MedicamentoID,Nome,Descricao,Quantidade,Valor")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = await db.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Medicamento medicamento = await db.Medicamentos.FindAsync(id);
            db.Medicamentos.Remove(medicamento);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult EfectuarVenda(int? id)
        {
            ViewBag.MedicamentoID = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EfectuarVenda(int medicamentoID, [Bind(Include = "NomeCliente, Quantidade")] Venda venda)
        {
            var medicamento = db.Medicamentos.Find(medicamentoID);
            venda.ValorTotal = venda.Quantidade * medicamento.Valor;
            venda.Farmaco = medicamento.Nome;

            if (ModelState.IsValid)
            {
                db.Vendas.Add(venda);
                await db.SaveChangesAsync();

                medicamento.Quantidade -= venda.Quantidade;
                db.Entry(medicamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Historico()
        {
            var vendas = await db.Vendas.ToListAsync();
            return View(vendas);
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
