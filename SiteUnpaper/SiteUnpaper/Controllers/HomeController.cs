using SiteUnpaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteUnpaper.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Sobre()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contato()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Processos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Projetos()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create(string nome, string telefone, string email, string assunto)
        {
            try
            {
                //envio para o cliente
                var model = new Contato
                {
                    Assunto = assunto,
                    Email = email,
                    Nome = nome,

                    Cliente = true
                };
                EnvioEmail.EnviaMensagemEmail(model);

                //envio para a unpaper
                var obj = new Contato
                {
                    Assunto = assunto,
                    Email = "daniel.escosteguy@unpaper.com.br",
                    Nome = nome,
                    Telefone = telefone
                };
                model.Cliente = false;
                var enviouEmail = EnvioEmail.EnviaMensagemEmail(obj);
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_FORM", ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RespostaEmail()
        {
            return View();
        }

        public ActionResult RespostaEmailEnviado()
        {
            return View();
        }
    }
}