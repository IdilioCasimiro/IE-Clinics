using IE_Clinics.Models.Access_Layer;
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
    }
}