using IE_Clinics.Models.Access_Layer;
using IE_Clinics.Models.Dominio;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ICHostweb.Controllers.DomainControllers
{
    public class EmailController : Controller
    {
        private Contexto contexto = new Contexto();

        public async Task<ActionResult> EnviarEmail(string assunto, string mensagem, string destinatario, bool feedback = true)
        {
            if (ModelState.IsValid)
            {
                MailMessage message = new MailMessage();

                message.To.Add(new MailAddress(destinatario));
                message.From = new MailAddress("no-reply@ichostweb.com");
                message.Subject = assunto;
                message.Body = mensagem;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    try
                    {
                        await smtp.SendMailAsync(message);
                    }
                    catch (SmtpException)
                    {
                        return RedirectToAction("Error", "ErrorManager");
                    }

                    if (feedback)
                        return RedirectToAction("Index", "Marcacao");
                    //Content("Mensagem enviada!", MediaTypeNames.Text.Plain);
                    else
                        return null;
                }
            }

            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Content("Não foi possível enviar a mensagem hoje!", MediaTypeNames.Text.Plain);
        }

        //public string Mensagem(string userId, string url)
        //{
        //    string mensagem;
        //    string ficheiro = "~/Content/html/novo_registo.html";
        //    using (StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(ficheiro)))
        //    {
        //        mensagem = sr.ReadToEnd();
        //    }

        //    mensagem = mensagem.Replace("{Nome}", repositorio.GetUserNameById(userId));
        //    mensagem = mensagem.Replace("{Url}", url);

        //    return mensagem;
        //}

        public string Mensagem(Marcacao marcacao)
        {
            string mensagem;
            string ficheiro = "~/Content/html/nova-consulta.html";
            using (StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(ficheiro)))
            {
                mensagem = sr.ReadToEnd();
            }

            var marcacaoIndividual = contexto.Marcacoes.Include(m => m.Medico)
                .Include(m => m.Paciente).Where(m => m.PacienteID == marcacao.PacienteID).FirstOrDefault();

            mensagem = mensagem.Replace("{Nome}", marcacaoIndividual.Paciente.Nome);
            mensagem = mensagem.Replace("{TipoMarcacao}", marcacao.TipoMarcacao);
            mensagem = mensagem.Replace("{Especialidade}", marcacao.Especialidade);
            mensagem = mensagem.Replace("{Data}", marcacao.Data.ToShortDateString());
            mensagem = mensagem.Replace("{Horario}", string.Concat(
                marcacao.Data.ToShortTimeString(), " - ",
                marcacao.Data.AddMinutes(45).ToShortTimeString()
                ));
            mensagem = mensagem.Replace("{Medico}", marcacaoIndividual.Medico.Nome);
            return mensagem;
        }
    }
}