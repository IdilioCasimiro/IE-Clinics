using IE_Clinics.Models.Access_Layer;
using IE_Clinics.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IE_Clinics.Controllers
{
    public class PacienteController : Controller
    {
        private Contexto contexto = new Contexto();

        public async Task<ActionResult> Index()
        {
            var pacientes = await contexto.Pacientes.ToListAsync();
            return View(pacientes);
        }

        [ActionName("Adicionar-Paciente")]
        public ActionResult AdicionarPaciente()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Adicionar-Paciente")]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarPaciente([Bind(Include = "Nome, UltimoNome, DataNascimento, Sexo, Pais, Provincia, Endereco, Telefone, TelefoneAlternativo, Email, GrupoSanguineo")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                contexto.Pacientes.Add(paciente);
                contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Reveja todos os campos antes de submeter o formulário, por favor!");
                return View();
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contexto.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}