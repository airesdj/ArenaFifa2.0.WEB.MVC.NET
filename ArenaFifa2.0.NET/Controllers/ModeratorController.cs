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
                                return RedirectToAction("Bench", "Moderator");
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
        // GET: Moderator/AcceptingNewSeason
        [UserModerator]
        public ActionResult AcceptingNewSeason()
        {

            HttpResponseMessage response = null;
            AcceptingNewSeasonViewModel modelReturnJSON = null;

            setViewBagVariables();

            try
            {
                response = GlobalVariables.WebApiClient.GetAsync("AcceptingNewSeason").Result;
                modelReturnJSON = response.Content.ReadAsAsync<AcceptingNewSeasonViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            for (int i = 0; i< modelReturnJSON.listOfAccepting.Count;i++)
                            {
                                modelReturnJSON.listOfAccepting[i].championshipName = getChampionshipNameNewSeason(modelReturnJSON.listOfAccepting[i].championshipID);
                            }

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Renovação Próxima Temporada. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Renovação Próxima Temporada. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Renovação Próxima Temporada: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }

        // GET: Moderator/AcceptingNewSeasonDetails
        [UserModerator]
        public ActionResult AcceptingNewSeasonDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            AcceptingNewSeasonViewModel modelReturnJSON = new AcceptingNewSeasonViewModel();
            AcceptingDetails modelReturnJSON2 = new AcceptingDetails();
            List<UserDetailsModel> listOfUser = new List<UserDetailsModel>();
            List<ChampionshipDetailsModel> listOChampionship = new List<ChampionshipDetailsModel>();
            ChampionshipDetailsModel championshipDetails = new ChampionshipDetailsModel();
            returnJSON_UserLoginModel userDetails = new returnJSON_UserLoginModel();
            UserDetailsModel userDetails2 = new UserDetailsModel();
            string championshipName = String.Empty;
            
            string actionForm = formHTML["actionForm"].ToLower();
            string primaryKey = String.Empty;
            string[] arrayPK = null;

            setViewBagVariables();
            ViewBag.actionFormHiddenValue = "";

            try
            {

                if (actionForm == "save")
                {

                    modelReturnJSON.seasonID = Convert.ToUInt16(formHTML["seasonID"]);
                    modelReturnJSON.userID = Convert.ToUInt16(formHTML["cmbTecnico"]);
                    modelReturnJSON.championshipID = Convert.ToUInt16(formHTML["cmbCampeonato"]);

                    modelReturnJSON.actionUser = actionForm;
                    modelReturnJSON.teamName = formHTML["txtTime"];
                    modelReturnJSON.confirmation = formHTML["cmbConfirma"];
                    if (modelReturnJSON.confirmation=="-") { modelReturnJSON.confirmation = String.Empty; }
                    if (!String.IsNullOrEmpty(formHTML["txtOrdem"]))
                        modelReturnJSON.ordering = formHTML["txtOrdem"];
                    else
                        modelReturnJSON.ordering = "0";

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("AcceptingNewSeason", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<AcceptingNewSeasonViewModel>().Result;
                    TempData["actionSuccessfully"] = "Registro incluído/alterado com sucesso";

                }
                else if (actionForm == "add" || actionForm == "view" || actionForm == "edit")
                {

                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save")
                            {
                                return RedirectToAction("AcceptingNewSeason", "Moderator");
                            }
                            else
                            {
                                if (actionForm == "view" || actionForm == "edit")
                                {

                                    primaryKey = formHTML["selectedID"];
                                    arrayPK = primaryKey.Split(Convert.ToChar(";"));

                                    modelReturnJSON.seasonID = Convert.ToUInt16(arrayPK[0]);
                                    modelReturnJSON.userID = Convert.ToUInt16(arrayPK[1]);
                                    modelReturnJSON.championshipID = Convert.ToUInt16(arrayPK[2]);

                                    response = GlobalVariables.WebApiClient.GetAsync("HomeUser/" + Convert.ToString(modelReturnJSON.userID)).Result;
                                    userDetails = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

                                    userDetails2 = new UserDetailsModel();
                                    userDetails2.id = userDetails.id;
                                    userDetails2.name = userDetails.name;
                                    userDetails2.psnID = userDetails.psnID;
                                    listOfUser.Add(userDetails2);

                                    response = GlobalVariables.WebApiClient.GetAsync("AcceptingNewSeason/" + primaryKey).Result;
                                    modelReturnJSON2 = response.Content.ReadAsAsync<AcceptingDetails>().Result;

                                    championshipDetails = new ChampionshipDetailsModel();
                                    championshipDetails.id = modelReturnJSON.championshipID;
                                    championshipDetails.name = getChampionshipNameNewSeason(championshipDetails.id);
                                    listOChampionship.Add(championshipDetails);

                                    modelReturnJSON2.listOfUser = listOfUser;
                                    modelReturnJSON2.listOfChampionship = listOChampionship;
                                }
                                else if (actionForm == "add")
                                {
                                    response = GlobalVariables.WebApiClient.GetAsync("HomeUser").Result;
                                    modelReturnJSON2 = response.Content.ReadAsAsync<AcceptingDetails>().Result;
                                    modelReturnJSON2.seasonID = 0;
                                    modelReturnJSON2.userID = 0;
                                    modelReturnJSON2.championshipID = 999;
                                    modelReturnJSON2.ordering = "0";

                                    for (int i = 0; i < 15; i++)
                                    {
                                        championshipName = getChampionshipNameNewSeason(i);
                                        if (championshipName!=String.Empty)
                                        {
                                            championshipDetails = new ChampionshipDetailsModel();
                                            championshipDetails.id = i;
                                            championshipDetails.name = championshipName;
                                            listOChampionship.Add(championshipDetails);
                                        }
                                    }
                                    modelReturnJSON2.DateconfirmationFormatted = DateTime.Now.Date.ToString("dd/MM/yyyy");
                                    modelReturnJSON2.listOfChampionship = listOChampionship;
                                }
                                modelReturnJSON2.actionUser = actionForm.ToUpper();
                                return View(modelReturnJSON2);
                            }
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Renovação Próxima Temporada - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Renovação Próxima Temporada - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Renovação Próxima Temporada - " + actionForm + ": (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                listOChampionship = null;
                championshipDetails = null;
                listOfUser = null;
                userDetails = null;
                userDetails2 = null;
            }
        }

        // GET: Moderator/ScorerH2H
        [UserModerator]
        public ActionResult ScorerH2H()
        {

            HttpResponseMessage response = null;
            ScorerViewModel modelReturnJSON = null;

            setViewBagVariables();

            try
            {

                response = GlobalVariables.WebApiClient.GetAsync("Scorer/H2H").Result;
                modelReturnJSON = response.Content.ReadAsAsync<ScorerViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            modelReturnJSON.scorerType = "H2H";
                            return View("Scorer", modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Artilheiros H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View("Scorer", modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Artilheiros H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("Scorer", modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Artilheiros H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("Scorer", modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }


        // GET: Moderator/ScorerPRO
        [UserModerator]
        public ActionResult ScorerPRO()
        {

            HttpResponseMessage response = null;
            ScorerViewModel modelReturnJSON = null;

            setViewBagVariables();

            try
            {

                response = GlobalVariables.WebApiClient.GetAsync("Scorer/PRO").Result;
                modelReturnJSON = response.Content.ReadAsAsync<ScorerViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            modelReturnJSON.scorerType = "PRO";
                            return View("Scorer", modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Artilheiros PRO CLUB. (" + modelReturnJSON.returnMessage + ")";
                            return View("Scorer", modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Artilheiros PRO CLUB. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("Scorer", modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Artilheiros PRO CLUB: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("Scorer", modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }


        // GET: Moderator/ScorerDetails
        [UserModerator]
        public ActionResult ScorerDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ScorerViewModel modelReturnJSON = new ScorerViewModel();
            ScorerDetails modelReturnJSON2 = new ScorerDetails();
            ScorerDetails scorerDetailsTeam = new ScorerDetails();
            List<TeamDetailsModel> listOfTeam = new List<TeamDetailsModel>();
            TeamDetailsModel teamDetails = new TeamDetailsModel();
            string championshipName = String.Empty;

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.actionFormHiddenValue = "";

            try
            {

                if (actionForm == "save")
                {

                    modelReturnJSON2.actionUser = actionForm;
                    modelReturnJSON2.scorerType = formHTML["scorerType"];

                    modelReturnJSON2.id = Convert.ToInt32(formHTML["selectedID"]);
                    if (!String.IsNullOrEmpty(formHTML["cmbTime"]))
                        modelReturnJSON2.teamID = Convert.ToInt16(formHTML["cmbTime"]);

                    modelReturnJSON2.nickname = formHTML["txtNomeAbrev"];
                    modelReturnJSON2.name = formHTML["txtNomeCompl"];
                    modelReturnJSON2.link = formHTML["txtUrl"];

                    if (!String.IsNullOrEmpty(formHTML["txtIdSofifa"]))
                        modelReturnJSON2.sofifaTeamID = formHTML["txtIdSofifa"];

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Scorer", modelReturnJSON2).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ScorerViewModel>().Result;
                    TempData["actionSuccessfully"] = "Registro incluído/alterado com sucesso";

                }
                else if (actionForm == "add" || actionForm == "view" || actionForm == "edit")
                {

                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save")
                            {
                                return RedirectToAction("Scorer" + formHTML["scorerType"], "Moderator");
                            }
                            else
                            {
                                if (actionForm == "view" || actionForm == "edit")
                                {

                                    response = GlobalVariables.WebApiClient.GetAsync("Scorer/" + formHTML["selectedID"]).Result;
                                    modelReturnJSON2 = response.Content.ReadAsAsync<ScorerDetails>().Result;

                                    response = GlobalVariables.WebApiClient.GetAsync("Team/" + Convert.ToString(modelReturnJSON2.teamID)).Result;
                                    teamDetails = response.Content.ReadAsAsync<TeamDetailsModel>().Result;

                                    string scorerLogoPath = ConfigurationManager.AppSettings["scorer.path.image"].ToString() + "/" + formHTML["selectedID"] + ".jpg";

                                    if (System.IO.File.Exists(HttpContext.Server.MapPath(scorerLogoPath)))
                                         { modelReturnJSON2.imagePath = scorerLogoPath; }
                                    else { modelReturnJSON2.imagePath = ConfigurationManager.AppSettings["avatar.path.default"].ToString(); }

                                    listOfTeam.Add(teamDetails);
                                    modelReturnJSON2.listOfTeam = listOfTeam;

                                }
                                else if (actionForm == "add")
                                {
                                    response = GlobalVariables.WebApiClient.GetAsync("Team/" + formHTML["scorerType"]).Result;
                                    scorerDetailsTeam = response.Content.ReadAsAsync<ScorerDetails>().Result;

                                    modelReturnJSON2.listOfTeam = scorerDetailsTeam.listOfTeam;

                                    modelReturnJSON2.id = 0;
                                }
                                modelReturnJSON2.scorerType = formHTML["scorerType"];
                                modelReturnJSON2.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON2.returnMessage) && modelReturnJSON2.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON2.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                return View(modelReturnJSON2);
                            }
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Artilheiros - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            modelReturnJSON2.listOfTeam = new List<TeamDetailsModel>();
                            return View(modelReturnJSON2);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Artilheiros - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        modelReturnJSON2.listOfTeam = new List<TeamDetailsModel>();
                        return View(modelReturnJSON2);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Artilheiros - " + actionForm + ": (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                modelReturnJSON2.listOfTeam = new List<TeamDetailsModel>();
                return View(modelReturnJSON2);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                scorerDetailsTeam = null;
                listOfTeam = null;
                teamDetails = null;
            }
        }

        // GET: Moderator/User
        [UserModerator]
        public ActionResult User()
        {

            HttpResponseMessage response = null;
            UserViewModel modelReturnJSON = null;

            setViewBagVariables();

            try
            {
                response = GlobalVariables.WebApiClient.GetAsync("User").Result;
                modelReturnJSON = response.Content.ReadAsAsync<UserViewModel>().Result;

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
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Técnicos. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Técnicos. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Técnicos: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }

        // GET: Moderator/UserDetails
        [UserModerator]
        public ActionResult UserDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            UserViewModel modelReturnJSON = new UserViewModel();
            UserDetailsModel modelReturnJSON2 = new UserDetailsModel();
            var objFunctions = new Commons.functions();


            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.actionFormHiddenValue = "";

            try
            {

                if (actionForm == "delete")
                {

                    modelReturnJSON2.actionUser = "dellCrud";
                    modelReturnJSON2.id = Convert.ToUInt16(formHTML["selectedID"]);
                    modelReturnJSON2.idOperator = Convert.ToUInt16(Session["user.id"].ToString());
                    modelReturnJSON2.psnIDOperator = Session["user.psnID"].ToString();

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("User", modelReturnJSON2).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<UserViewModel>().Result;
                    TempData["actionSuccessfully"] = "Técnico inativado com sucesso";

                }
                else if (actionForm == "save")
                {

                    modelReturnJSON2.actionUser = actionForm;

                    modelReturnJSON2.id = Convert.ToInt32(formHTML["selectedID"]);
                    modelReturnJSON2.name = formHTML["txtNome"];
                    modelReturnJSON2.birthday = Convert.ToDateTime(formHTML["txtDtNascimento"]);
                    modelReturnJSON2.state = formHTML["cmbState"];
                    modelReturnJSON2.Email = formHTML["txtEmail"];
                    modelReturnJSON2.psnID = formHTML["txtPsn"];
                    modelReturnJSON2.howfindus = formHTML["cmbHeardUs"];
                    modelReturnJSON2.whatkindofmedia = formHTML["whatkindofmedia"];
                    modelReturnJSON2.team = formHTML["cmbTeam"];
                    if (formHTML["chkActive"]=="on")
                        modelReturnJSON2.userActive = true;
                    if (formHTML["chkModerator"] == "on")
                        modelReturnJSON2.userModerator = true;
                    if (formHTML["chkReceiveWarningEachRound"] == "on")
                        modelReturnJSON2.receiveWarningEachRound = 1;
                    if (formHTML["chkReceiveTeamTable"] == "on")
                        modelReturnJSON2.receiveTeamTable = 1;
                    if (formHTML["chkWishParticipate"] == "on")
                        modelReturnJSON2.wishParticipate = 1;

                    modelReturnJSON2.idOperator = Convert.ToUInt16(Session["user.id"].ToString());
                    modelReturnJSON2.psnIDOperator = Session["user.psnID"].ToString();

                    if (modelReturnJSON2.id==0) { modelReturnJSON2.Password = formHTML["txtPassword"];  }

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("User", modelReturnJSON2).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<UserViewModel>().Result;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        if (modelReturnJSON2.id == 0) { TempData["actionSuccessfully"] = "Registro incluído com sucesso"; }
                        else { TempData["actionSuccessfully"] = "Registro alterado com sucesso"; }
                    }
                    else if (modelReturnJSON2.id == 0) { actionForm = "ADD"; }
                    else if (modelReturnJSON2.id > 0) { actionForm = "EDIT"; }
                }
                else if (actionForm == "add" || actionForm == "view" || actionForm == "edit")
                {

                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save" || actionForm == "delete")
                            {
                                return RedirectToAction("User", "Moderator");
                            }
                            else
                            {
                                if (actionForm == "view" || actionForm == "edit")
                                {

                                    response = GlobalVariables.WebApiClient.GetAsync("User/" + formHTML["selectedID"]).Result;
                                    modelReturnJSON2 = response.Content.ReadAsAsync<UserDetailsModel>().Result;

                                    modelReturnJSON2.listWhatHowFindUs = GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                                    modelReturnJSON2.listStates = GetSelectListItems(objFunctions.GetAllStatesRegister());
                                    modelReturnJSON2.listTeams = GetSelectListItems(objFunctions.GetAllTeamsRegister());

                                    if (!String.IsNullOrEmpty(modelReturnJSON2.state))
                                        modelReturnJSON2.state = objFunctions.RemoveSpecialCharacters(modelReturnJSON2.state);
                                    if (!String.IsNullOrEmpty(modelReturnJSON2.team))
                                        modelReturnJSON2.team = objFunctions.RemoveSpecialCharacters(modelReturnJSON2.team);

                                    if (modelReturnJSON2.birthday.Year > 1)
                                        modelReturnJSON2.birthdayFormatted = modelReturnJSON2.birthday.ToString("dd/MM/yyyy");

                                    string avatarPath = ConfigurationManager.AppSettings["avatar.path.coach"].ToString() + "/" + formHTML["selectedID"] + ".jpg";

                                    if (System.IO.File.Exists(HttpContext.Server.MapPath(avatarPath)))
                                    { modelReturnJSON2.avatarPath = avatarPath; }
                                    else { modelReturnJSON2.avatarPath = ConfigurationManager.AppSettings["avatar.path.default"].ToString(); }

                                }
                                else if (actionForm == "add")
                                {
                                    modelReturnJSON2.id = 0;

                                    modelReturnJSON2.birthday = DateTime.Now.Date;

                                    modelReturnJSON2.listWhatHowFindUs = GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                                    modelReturnJSON2.listStates = GetSelectListItems(objFunctions.GetAllStatesRegister());
                                    modelReturnJSON2.listTeams = GetSelectListItems(objFunctions.GetAllTeamsRegister());
                                }
                                modelReturnJSON2.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON2.returnMessage) && modelReturnJSON2.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON2.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                return View(modelReturnJSON2);
                            }
                        }
                        else
                        {
                            modelReturnJSON2.actionUser = actionForm;
                            modelReturnJSON2.listWhatHowFindUs = GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                            modelReturnJSON2.listStates = GetSelectListItems(objFunctions.GetAllStatesRegister());
                            modelReturnJSON2.listTeams = GetSelectListItems(objFunctions.GetAllTeamsRegister());
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Técnicos - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON2);
                        }
                    default:
                        modelReturnJSON2.actionUser = actionForm;
                        modelReturnJSON2.listWhatHowFindUs = GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                        modelReturnJSON2.listStates = GetSelectListItems(objFunctions.GetAllStatesRegister());
                        modelReturnJSON2.listTeams = GetSelectListItems(objFunctions.GetAllTeamsRegister());
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Técnicos - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON2);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Técnicos - " + actionForm + ": (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON2);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                objFunctions = null;
            }
        }


        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        private string getChampionshipNameNewSeason(int championshipID)
        {
            string strReturn = String.Empty;
            if (championshipID == 0)
                strReturn = "Banco - H2H";
            else if (championshipID == 1)
                strReturn = "Série A - H2H";
            else if (championshipID == 2)
                strReturn = "Série B - H2H";
            else if (championshipID == 3)
                strReturn = "Série C - H2H";
            else if (championshipID == 4)
                strReturn = "Série D - H2H";
            else if (championshipID == 5)
                strReturn = "Copa do Mundo - H2H";
            else if (championshipID == 7)
                strReturn = "Banco - F.U.T.";
            else if (championshipID == 8)
                strReturn = "Série A - F.U.T.";
            else if (championshipID == 9)
                strReturn = "Série B - F.U.T.";
            else if (championshipID == 13)
                strReturn = "Série A - Pro Club";
            else if (championshipID == 14)
                strReturn = "Banco - Pro Club";

            return strReturn;
        }
    }
}