using ICHostweb.Controllers.DomainControllers;
using IE_Clinics.Models.Access_Layer;
using IE_Clinics.Models.Dominio;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IE_Clinics.Controllers.Dominio
{
    public class MarcacoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Marcacoes
        public async Task<ActionResult> Index()
        {
            var marcacoes = db.Marcacoes.Include(m => m.Medico).Include(m => m.Paciente);
            return View(await marcacoes.ToListAsync());
        }

        // GET: Marcacoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacao marcacao = await db.Marcacoes.FindAsync(id);
            if (marcacao == null)
            {
                return HttpNotFound();
            }
            return View(marcacao);
        }

        [ActionName("Efectuar-Marcacao")]
        public ActionResult EfectuarMarcacao(int id, string especialidade, string tipoMarcacao, int? medicoID)
        {
            if (id != 0)
            {

                if (especialidade == null)
                {

                    var paciente = db.Pacientes.Find(id);
                    ViewBag.Paciente = paciente;

                    var marcacao = new Marcacao()
                    {
                        PacienteID = paciente.ID,
                        Especialidade = especialidade,
                        TipoMarcacao = tipoMarcacao
                    };

                    ViewBag.Especialidade = new SelectList(db.Especialidades, "Nome", "Nome");
                    return View(marcacao);
                }
                else
                {
                    ViewBag.Paciente = db.Pacientes.Find(id);
                    ViewBag.Especialidade = new SelectList(db.Especialidades, "Nome", "Nome");

                    var marcacao = new Marcacao()
                    {
                        PacienteID = id,
                        Especialidade = especialidade,
                        TipoMarcacao = tipoMarcacao
                    };

                    ViewBag.Medicos = db.Medicos.Where(x => x.Especialidade.Nome == especialidade).ToList();
                    return View(marcacao);

                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //return RedirectToAction("Efectuar-Marcacao", new { id = id });
        }

        //[HttpPost]
        //[ActionName("Efectuar-Marcacao")]
        //public ActionResult EfectuarMarcacao([Bind(Include = "PacienteID, Especialidade, TipoMarcacao")] Marcacao marcacao)
        //{
        //    ViewBag.Paciente = db.Pacientes.Find(marcacao.PacienteID);
        //    ViewBag.Especialidade = new SelectList(db.Especialidades, "Nome", "Nome");

        //    ViewBag.Medicos = db.Medicos.Where(x => x.Especialidade.Nome == marcacao.Especialidade).ToList();
        //    return View(marcacao);
        //}

        [HttpPost]
        public async Task<ActionResult> Adicionar([Bind(Include = "PacienteID, MedicoID, Especialidade, TipoMarcacao, Data, Observacao")] Marcacao marcacao, string hora)
        {
            marcacao.Data = DateTime.Parse(marcacao.Data.ToShortDateString() + " " + hora);
            marcacao.Estado = EstadoMarcacao.Agendado;
            marcacao.Duracao = 45;

            EmailController email = new EmailController();

            if (ModelState.IsValid)
            {
                db.Marcacoes.Add(marcacao);
                await db.SaveChangesAsync();

                var mensagem = email.Mensagem(marcacao);
                var destinatario = await db.Pacientes.Where(x => x.ID == marcacao.PacienteID).FirstOrDefaultAsync();
                await email.EnviarEmail("Nova consulta", mensagem, destinatario.Email, true);

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.Paciente = db.Pacientes.Find(marcacao.PacienteID);
                ViewBag.Especialidade = new SelectList(db.Especialidades, "ID", "Nome");

                ViewBag.Medicos = db.Medicos.Where(x => x.Especialidade.ID.ToString() == marcacao.Especialidade).ToList();

                return View(marcacao);
            }


            //return RedirectToAction("EfectuarMarcacao");
        }

        [ActionName("Calendario-Marcacoes")]
        public ActionResult CalendarioMarcacoes()
        {
            return View();
        }

        public async Task<JsonResult> ObterMarcacoes()
        {
            var marcacoes = await (
                from medico in db.Medicos
                join marcacao in db.Marcacoes
                on medico.ID equals marcacao.MedicoID
                select new MarcacaoCalendario
                {
                    TipoMarcacao = marcacao.TipoMarcacao,
                    Especialidade = marcacao.Especialidade,
                    Data = marcacao.Data,
                    Duracao = marcacao.Duracao,
                    Observacao = marcacao.Observacao,
                    Paciente = marcacao.Paciente.Nome,
                    Medico = marcacao.Medico.Nome
                }).ToListAsync();

            return new JsonResult { Data = marcacoes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //public async Task<JsonResult> ObterMarcacoesMedico(int id)
        //{
        //    var marcacoes = await (
        //        from medico in db.Medicos
        //        join marcacao in db.Marcacoes
        //        on medico.ID equals marcacao.MedicoID
        //        where medico.ID == id
        //        select new MarcacaoCalendario
        //        {
        //            TipoMarcacao = marcacao.TipoMarcacao,
        //            Especialidade = marcacao.Especialidade,
        //            Data = marcacao.Data,
        //            Duracao = marcacao.Duracao,
        //            Observacao = marcacao.Observacao,
        //            Paciente = marcacao.Paciente.Nome,
        //            Medico = marcacao.Medico.Nome
        //        }).ToListAsync();

        //    return new JsonResult { Data = marcacoes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        // GET: Marcacoes/Create
        public ActionResult Create()
        {
            ViewBag.MedicoID = new SelectList(db.Medicos, "ID", "Nome");
            ViewBag.PacienteID = new SelectList(db.Pacientes, "ID", "Nome");

            return View();
        }

        // POST: Marcacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TipoMarcacao,Data,Duracao,Observacao,PacienteID,MedicoID")] Marcacao marcacao)
        {
            if (ModelState.IsValid)
            {
                db.Marcacoes.Add(marcacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MedicoID = new SelectList(db.Medicos, "ID", "Departamento", marcacao.MedicoID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "ID", "Nome", marcacao.PacienteID);

            return View(marcacao);
        }

        // GET: Marcacoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacao marcacao = await db.Marcacoes.FindAsync(id);
            if (marcacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicoID = new SelectList(db.Medicos, "ID", "Departamento", marcacao.MedicoID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "ID", "Nome", marcacao.PacienteID);
            return View(marcacao);
        }

        // POST: Marcacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TipoMarcacao,Data,Duracao,Observacao,PacienteID,MedicoID")] Marcacao marcacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MedicoID = new SelectList(db.Medicos, "ID", "Departamento", marcacao.MedicoID);
            ViewBag.PacienteID = new SelectList(db.Pacientes, "ID", "Nome", marcacao.PacienteID);
            return View(marcacao);
        }

        // GET: Marcacoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacao marcacao = await db.Marcacoes.FindAsync(id);
            if (marcacao == null)
            {
                return HttpNotFound();
            }
            return View(marcacao);
        }

        // POST: Marcacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Marcacao marcacao = db.Marcacoes.Find(id);
            db.Marcacoes.Remove(marcacao);
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
