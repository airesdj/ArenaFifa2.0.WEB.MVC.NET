using ArenaFifa20.NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using static ArenaFifa20.NET.App_Start.CheckUserModerator;

namespace ArenaFifa20.NET.Controllers
{
    public class ModeratorController : Controller
    {

        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inModeratorMenu = "1";
        }

        // GET: Moderator/Summary
        [UserModerator]
        public ActionResult Summary()
        {

            HttpResponseMessage response = null;
            ModeratorSummaryViewModel modelReturnJSON = null;
            ModeratorSummaryViewModel ModeratorMenuMode = new ModeratorSummaryViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "summary";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Moderator", ModeratorMenuMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<ModeratorSummaryViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador. (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }

        // GET: Moderator/SpoolerSummary
        [UserModerator]
        public ActionResult SpoolerSummary()
        {

            HttpResponseMessage response = null;
            SpoolerViewModel modelReturnJSON = null;
            SpoolerViewModel ModeratorMenuMode = new SpoolerViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "spooler";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Moderator", ModeratorMenuMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<SpoolerViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Spooler. (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Spooler. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Spooler: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: Moderator/Seasons
        [UserModerator]
        public ActionResult Seasons()
        {

            HttpResponseMessage response = null;
            SeasonListModesViewModel modelReturnJSON = null;
            SeasonListModesViewModel ModeratorMenuMode = new SeasonListModesViewModel();

            setViewBagVariables();

            try
            {
                response = GlobalVariables.WebApiClient.GetAsync("Season").Result;
                modelReturnJSON = response.Content.ReadAsAsync<SeasonListModesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Temporadas. (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Temporadas. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Temporadas: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: Moderator/Bench
        [UserModerator]
        public ActionResult Bench()
        {

            HttpResponseMessage response = null;
            BenchModesViewModel modelReturnJSON = null;
            BenchModesViewModel ModeratorMenuMode = new BenchModesViewModel();

            setViewBagVariables();

            try
            {
                response = GlobalVariables.WebApiClient.GetAsync("Bench").Result;
                modelReturnJSON = response.Content.ReadAsAsync<BenchModesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Banco de Reservas. (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Banco de Reservas. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Banco de Reservas: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }

        // GET: Moderator/BenchDetails
        [UserModerator]
        public ActionResult BenchDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            BenchModesViewModel modelReturnJSON = new BenchModesViewModel();
            BenchModesViewModel ModeratorMenuMode = new BenchModesViewModel();
            BenchDetailsModel benchDetails = new BenchDetailsModel();
            List<BenchDetailsModel> listOfBench = new List<BenchDetailsModel>();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.actionFormHiddenValue = "";

            try
            {
                if (actionForm=="delete")
                {

                    modelReturnJSON.actionUser = "dellCrud";
                    benchDetails = new BenchDetailsModel();
                    benchDetails.id = Convert.ToUInt16(formHTML["selectedID"]);
                    listOfBench.Add(benchDetails);
                    modelReturnJSON.listOfBench = listOfBench;

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Bench", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<BenchModesViewModel>().Result;
                    TempData["actionSuccessfully"] = "Registro excluído com sucesso";

                }
                else if (actionForm == "move")
                {

                    modelReturnJSON.actionUser = "moveCrud";
                    benchDetails = new BenchDetailsModel();
                    benchDetails.id = Convert.ToUInt16(formHTML["selectedID"]);
                    listOfBench.Add(benchDetails);
                    modelReturnJSON.listOfBench = listOfBench;

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Bench", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<BenchModesViewModel>().Result;
                    TempData["actionSuccessfully"] = "Registro movido para o fim da fila com sucesso";

                }
                else if (actionForm == "save")
                {

                    modelReturnJSON.actionUser = "addCrud";
                    benchDetails = new BenchDetailsModel();
                    benchDetails.userID = Convert.ToUInt16(formHTML["cmbTecnico"]);
                    benchDetails.team = formHTML["txtTime"];
                    benchDetails.typeBench = formHTML["rdoTipo"];
                    listOfBench.Add(benchDetails);
                    modelReturnJSON.listOfBench = listOfBench;

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Bench", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<BenchModesViewModel>().Result;
                    TempData["actionSuccessfully"] = "Registro incluído com sucesso";

                }
                else if (actionForm == "add" || actionForm == "view")
                {
                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "delete" || actionForm == "move" || actionForm == "save")
                            {
                                return RedirectToAction("Bench", "Moderator", modelReturnJSON);
                            }
                            else
                            {
                                if (actionForm == "view")
                                {
                                    response = GlobalVariables.WebApiClient.GetAsync("Bench/"+ formHTML["selectedID"].ToString()).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<BenchModesViewModel>().Result;
                                    modelReturnJSON.actionUser = actionForm.ToUpper();

                                    UserDetailsModel userDetails = new UserDetailsModel();
                                    List<UserDetailsModel> listOfUser = new List<UserDetailsModel>();
                                    userDetails.id = modelReturnJSON.listOfBench[0].userID;
                                    userDetails.name = modelReturnJSON.listOfBench[0].name;
                                    userDetails.psnID = modelReturnJSON.listOfBench[0].psnID;
                                    listOfUser.Add(userDetails);
                                    modelReturnJSON.listOfUser = listOfUser;

                                    userDetails = null;
                                    listOfUser = null;
                                }
                                else if (actionForm == "add")
                                {
                                    response = GlobalVariables.WebApiClient.GetAsync("HomeUser").Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<BenchModesViewModel>().Result;
                                    modelReturnJSON.actionUser = actionForm.ToUpper();

                                    benchDetails = new BenchDetailsModel();
                                    listOfBench = new List<BenchDetailsModel>();
                                    benchDetails.id = 0;
                                    benchDetails.userID = 0;
                                    benchDetails.name = String.Empty;
                                    benchDetails.team = String.Empty;
                                    benchDetails.typeBench = String.Empty;
                                    listOfBench.Add(benchDetails);
                                    modelReturnJSON.listOfBench = listOfBench;
                                }
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Banco de Reservas - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Banco de Reservas - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Banco de Reservas - " + actionForm + ": (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                benchDetails = null;
                listOfBench = null;
            }
        }
    }
}