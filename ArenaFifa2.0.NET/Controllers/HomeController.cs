using ArenaFifa20.NET.Models;
using System;
using System.Web.Mvc;
using SYSEmail;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using static ArenaFifa20.NET.App_Start.CheckSessionTimeOut;

namespace ArenaFifa20.NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpResponseMessage response = null;
            SeasonDetails modelReturnJSON = null;
            HomePageViewModel homeMode = new HomePageViewModel();

            try
            {
                homeMode.actionUser = "current";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Season", homeMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<SeasonDetails>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "subscribeBenchSuccessfully")
                        {

                            homeMode.seasonID = modelReturnJSON.id;
                            homeMode.seasonName = modelReturnJSON.name;
                            return View(homeMode);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da Home Page do Arena. (" + modelReturnJSON.returnMessage + ")";
                            return View(homeMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da Home Page do Arena. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(homeMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Home Page Arena: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(homeMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                homeMode = null;
            }
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

        // GET: /Home/SubscribeBenchH2HFUT
        [AllowAnonymous]
        [SessionTimeout]
        public ActionResult SubscribeBenchH2HFUT()
        {
            return View();
        }

        // GET: /Home/SubscribeBenchPROCLUB
        [AllowAnonymous]
        [SessionTimeout]
        public ActionResult SubscribeBenchPROCLUB()
        {
            return View();
        }

        // GET: /Home/Bench
        [AllowAnonymous]
        public ActionResult Bench()
        {

            HttpResponseMessage response = null;
            BenchModesViewModel modelReturnJSON = null;
            BenchModesViewModel model = new BenchModesViewModel();

            try
            {
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Bench", model).Result;

                modelReturnJSON = response.Content.ReadAsAsync<BenchModesViewModel>().Result;

                if (modelReturnJSON.returnMessage!= "getBenchSuccessfully")
                    TempData["returnMessage"] = modelReturnJSON.returnMessage;

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - validando login do usuário: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                model = null;
            }

        }

        // POST: /Home/SubscribeBenchH2HFUT
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [SessionTimeout]
        public ActionResult SubscribeBenchH2HFUT(SubscribeBench model)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModeState is invalid";
                return View(model);
            }

            if (model.checkH2H==false && model.checkFUT==false)
            {
                ModelState.AddModelError("checkH2H", "Nenhuma modalidade selecionada. Você de ve selecionar a Modalidade H2H e/ou FUT.");
                ModelState.AddModelError("checkFUT", "Nenhuma modalidade selecionada. Você de ve selecionar a Modalidade H2H e/ou FUT.");
                return View(model);

            }
            else
            {

                HttpResponseMessage response = null;
                SubscribeBench modelReturnJSON = null;

                try
                {
                    model.id = Convert.ToInt16(Session["user.id"]);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("SubscribeBench", model).Result;

                    modelReturnJSON = response.Content.ReadAsAsync<SubscribeBench>().Result;

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Created:
                            if (modelReturnJSON.returnMessage == "subscribeBenchSuccessfully")
                            {
                                return RedirectToAction("SubscribeBenchConfirmation", "Home", model);
                            }
                            else
                            {
                                //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                                TempData["returnMessage"] = "Ocorreu algum erro na inscrição do banco de Reservas H2H e/ou FUT. (" + modelReturnJSON.returnMessage + ")";
                                return View(model);
                            }
                        default:
                            TempData["returnMessage"] = "Ocorreu algum erro na inscrição do banco de Reservas H2H e/ou FUT. (" + response.StatusCode + ")";
                            ModelState.AddModelError("", "application error.");
                            return View(model);
                    }

                }
                catch (Exception ex)
                {
                    TempData["returnMessage"] = "Erro interno - inscrevendo-se no banco - H2H e/ou FUT: (" + ex.InnerException.Message + ")";
                    ModelState.AddModelError("", "application error.");
                    return View(model);

                }
                finally
                {
                    response = null;
                    modelReturnJSON = null;
                }


            }

        }

        // POST: /Home/SubscribeBenchPROCLUB
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [SessionTimeout]
        public ActionResult SubscribeBenchPROCLUB(SubscribeBench model)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModeState is invalid";
                return View(model);
            }

            if (model.checkPRO == false)
            {
                ModelState.AddModelError("checkPRO", "Nenhuma modalidade selecionada. Você de ve selecionar a Modalidade PRO CLUB.");
                return View(model);

            }
            else
            {

                HttpResponseMessage response = null;
                SubscribeBench modelReturnJSON = null;

                try
                {
                    model.id = Convert.ToInt16(Session["user.id"]);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("SubscribeBench", model).Result;

                    modelReturnJSON = response.Content.ReadAsAsync<SubscribeBench>().Result;

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Created:
                            if (modelReturnJSON.returnMessage == "subscribeBenchSuccessfully")
                            {
                                return RedirectToAction("SubscribeBenchConfirmation", "Home", model);
                            }
                            else
                            {
                                //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                                TempData["returnMessage"] = "Ocorreu algum erro na inscrição do banco de Reservas PRO CLUB. (" + modelReturnJSON.returnMessage + ")";
                                return View(model);
                            }
                        default:
                            TempData["returnMessage"] = "Ocorreu algum erro na inscrição do banco de Reservas PRO CLUB. (" + response.StatusCode + ")";
                            ModelState.AddModelError("", "application error.");
                            return View(model);
                    }

                }
                catch (Exception ex)
                {
                    TempData["returnMessage"] = "Erro interno - inscrevendo-se no banco - PRO CLUB: (" + ex.InnerException.Message + ")";
                    ModelState.AddModelError("", "application error.");
                    return View(model);

                }
                finally
                {
                    response = null;
                    modelReturnJSON = null;
                }


            }

        }

        //
        // GET: /Home/SubscribeBenchConfirmation
        [AllowAnonymous]
        public ActionResult SubscribeBenchConfirmation(SubscribeBench model)
        {
            return View(model);
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

        // GET: /Home/BlackList
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult BlackList(FormCollection formHTML)
        {


            HttpResponseMessage response = null;
            BlackListViewModel modelReturnJSON = null;
            BlackListViewModel model = new BlackListViewModel();

            try
            {

                model.actionUser = "summaryList";
                model.seasonID = Convert.ToInt16(formHTML["seasonID"]);

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", model).Result;

                modelReturnJSON = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "BlackListSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do sumário da Lista Negra. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do sumário da Lista Negra. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibição do sumário da Lista Negra: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                model = null;
            }

        }


        // POST: /Home/BlackList
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult BlackListDetails(FormCollection formHTML)
        {
            HttpResponseMessage response = null;
            BlackListViewModel modelReturnJSON = null;
            BlackListViewModel model = new BlackListViewModel();

            try
            {

                model.actionUser = "detailsList";
                model.seasonID = Convert.ToInt16(formHTML["seasonID"]);
                model.userID = Convert.ToInt16(formHTML["userID"]);

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", model).Result;

                modelReturnJSON = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "BlackListSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do detalhe da Lista Negra. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do detalhe da Lista Negra. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibição do detalhe da Lista Negra: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                model = null;
            }

        }

        // GET: /Home/RankingSupporters
        [AllowAnonymous]
        public ActionResult RankingSupporters()
        {

            HttpResponseMessage response = null;
            RankingSupportersModel modelReturnJSON = null;
            BlackListViewModel model = new BlackListViewModel();

            try
            {

                model.actionUser = "RankingSupporters";

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HomeUser", model).Result;

                modelReturnJSON = response.Content.ReadAsAsync<RankingSupportersModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "rankingSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Ranking das Torcidas do Arena. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Ranking das Torcidas do Arena. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibição do Ranking das Torcidas do Arena: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                model = null;
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