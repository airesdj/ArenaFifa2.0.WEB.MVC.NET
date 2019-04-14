using ArenaFifa20.NET.Models;
using System;
using System.Web.Mvc;
using SYSEmail;

namespace ArenaFifa20.NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OurTeam()
        {
            return View();
        }


        // GET: /Home/ContactUs
        [AllowAnonymous]
        public ActionResult ContactUs()
        {
            return View();
        }

        // POST: /Home/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactUsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModeState is invalid";
                return View(model);
            }

            systemEmail objEmail = new systemEmail();

            try
            {
                objEmail.SendEmail(getBodyHtml(model), model.Email, "CONTACT-US", model.subject);

                objEmail = null;

                ViewBag.Message = "success";

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "error: "+ ex.Message;
                return View();
            }
            finally
            {
                objEmail = null;
            }

        }

        private string getBodyHtml(ContactUsViewModel model)
        {

            string strBodyHtml = string.Empty;


            strBodyHtml = strBodyHtml + "<span style='PADDING-RIGHT: 0px;PADDING-LEFT: 0px;FONT-SIZE: 11px;PADDING-BOTTOM: 0px;MARGIN: 0px;COLOR: #333333;PADDING-TOP: 0px;BACKGROUND-REPEAT: repeat-x;FONT-FAMILY: Arial, Helvetica, sans-serif;TEXT-ALIGN: left'>";
            strBodyHtml = strBodyHtml + "<p>&nbsp;<br><br></p>";
            strBodyHtml = strBodyHtml + "<span style='font-size:16px;font-family:Verdana;color:red'><b>Assunto: " + model.subject + ".</b></span>";
            strBodyHtml = strBodyHtml + "<br><br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:13px;font-family:Verdana;color:blue'><b>Dados do E-mail:</b></span>";
            strBodyHtml = strBodyHtml + "<br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Nome:</b>&nbsp;&nbsp;" + model.name + "</span>";
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>E-mail:</b>&nbsp;&nbsp;" + model.Email + "</span>";
            strBodyHtml = strBodyHtml + "<br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:blue'><b>Comentário:</b>&nbsp;&nbsp;" + model.message + "</span>";
            strBodyHtml = strBodyHtml + "</span>";

            return strBodyHtml;

        }
    }
}