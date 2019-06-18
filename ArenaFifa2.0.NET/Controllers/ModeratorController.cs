using ArenaFifa20.NET.Models;
using SYSEmail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
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
            ViewBag.inModeratorMenuTextEditor = String.Empty;
            ViewBag.inLaunchResult = "0";
            ViewBag.inUsingAjaxRazor = "0";
            ViewBag.inCalculateScore = "0";
            ViewBag.inScorerDetails = "0";
            ViewBag.inSmartWizardMenu = "0";
            ViewBag.inDrawTeamsUsersJustHasBeenDone = "0";
            ViewBag.inDrawGroupsJustHasBeenDone = "0";
            ViewBag.justDidDrawGroups = "0";
            ViewBag.justDidDrawMatchTable = "0";
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

            try
            {

                if (actionForm == "delete")
                {

                    modelReturnJSON2.actionUser = "dellCrud";
                    modelReturnJSON2.id = Convert.ToUInt16(formHTML["selectedID"]);
                    modelReturnJSON2.idOperator = Convert.ToInt32(Session["user.id"].ToString());
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

                                    modelReturnJSON2.listWhatHowFindUs = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                                    modelReturnJSON2.listStates = GlobalFunctions.GetSelectListItems(objFunctions.GetAllStatesRegister());
                                    modelReturnJSON2.listTeams = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTeamsRegister());

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

                                    modelReturnJSON2.listWhatHowFindUs = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                                    modelReturnJSON2.listStates = GlobalFunctions.GetSelectListItems(objFunctions.GetAllStatesRegister());
                                    modelReturnJSON2.listTeams = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTeamsRegister());
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
                            modelReturnJSON2.listWhatHowFindUs = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                            modelReturnJSON2.listStates = GlobalFunctions.GetSelectListItems(objFunctions.GetAllStatesRegister());
                            modelReturnJSON2.listTeams = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTeamsRegister());
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Técnicos - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON2);
                        }
                    default:
                        modelReturnJSON2.actionUser = actionForm;
                        modelReturnJSON2.listWhatHowFindUs = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTypeHowFindUsRegister());
                        modelReturnJSON2.listStates = GlobalFunctions.GetSelectListItems(objFunctions.GetAllStatesRegister());
                        modelReturnJSON2.listTeams = GlobalFunctions.GetSelectListItems(objFunctions.GetAllTeamsRegister());
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


        // GET: Moderator/Team
        [UserModerator]
        public ActionResult Team()
        {

            HttpResponseMessage response = null;
            TeamListViewModel modelReturnJSON = null;

            setViewBagVariables();

            try
            {
                response = GlobalVariables.WebApiClient.GetAsync("Team").Result;
                modelReturnJSON = response.Content.ReadAsAsync<TeamListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Times. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Times. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Times: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }

        // GET: Moderator/TeamDetails
        [UserModerator]
        public ActionResult TeamDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            TeamDetailsModel modelReturnJSON = new TeamDetailsModel();
            List<UserDetailsModel> listOfUser = new List<UserDetailsModel>();
            List<StandardDetailsModel> listOfType = new List<StandardDetailsModel>();


            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();

            try
            {

                if (actionForm == "delete")
                {

                    modelReturnJSON.actionUser = "dellCrud";
                    modelReturnJSON.id = Convert.ToInt32(formHTML["selectedID"]);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Team", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<TeamDetailsModel>().Result;
                    TempData["actionSuccessfully"] = "Registro excluído com sucesso";

                }
                else if (actionForm == "save")
                {

                    modelReturnJSON.actionUser = actionForm;

                    modelReturnJSON.id = Convert.ToInt32(formHTML["selectedID"]);
                    modelReturnJSON.name = formHTML["txtNome"];
                    modelReturnJSON.typeModeID = Convert.ToInt16(formHTML["cmbTipo"]);
                    modelReturnJSON.teamSofifaURL = formHTML["txtUrl"];
                    if (!String.IsNullOrEmpty(formHTML["txtIdSofifa"]))
                        modelReturnJSON.teamSofifaID = Convert.ToInt32(formHTML["txtIdSofifa"]);
                    if (!String.IsNullOrEmpty(formHTML["cmbTecnico"]))
                        modelReturnJSON.userID = Convert.ToInt32(formHTML["cmbTecnico"]);
                    modelReturnJSON.psnID = formHTML["txtPsn"];

                    modelReturnJSON.pathLogo = GlobalFunctions.getPathLogoTeam(formHTML["txtNome"]);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Team", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<TeamDetailsModel>().Result;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        if (modelReturnJSON.id == 0) { TempData["actionSuccessfully"] = "Registro incluído com sucesso"; }
                        else { TempData["actionSuccessfully"] = "Registro alterado com sucesso"; }
                    }
                    else if (modelReturnJSON.id == 0) { actionForm = "ADD"; }
                    else if (modelReturnJSON.id > 0) { actionForm = "EDIT"; }
                }
                else if (actionForm == "add" || actionForm == "view" || actionForm == "edit")
                {

                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully" )
                        {

                            if (actionForm == "save" || actionForm == "delete")
                            {
                                return RedirectToAction("Team", "Moderator");
                            }
                            else
                            {
                                if (actionForm == "add" || actionForm == "edit")
                                {
                                    GlobalFunctions.getLists(ref listOfUser, ref listOfType, response);
                                }

                                if (actionForm == "view" || actionForm == "edit")
                                {

                                    response = GlobalVariables.WebApiClient.GetAsync("Team/" + formHTML["selectedID"]).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<TeamDetailsModel>().Result;

                                    if (actionForm=="view")
                                    {
                                        UserDetailsModel userDetails = new UserDetailsModel();
                                        userDetails.id = modelReturnJSON.userID;
                                        userDetails.name = modelReturnJSON.userName;
                                        userDetails.psnID = modelReturnJSON.psnID;
                                        listOfUser.Add(userDetails);
                                        modelReturnJSON.listOfUser = listOfUser;

                                        userDetails = null;

                                        StandardDetailsModel typeDetails = new StandardDetailsModel();
                                        typeDetails.id = modelReturnJSON.typeModeID;
                                        typeDetails.name = modelReturnJSON.typeMode;
                                        listOfType.Add(typeDetails);
                                        modelReturnJSON.listOfType = listOfType;

                                        typeDetails = null;
                                    }
                                    else
                                    {
                                        modelReturnJSON.listOfUser = listOfUser;
                                        modelReturnJSON.listOfType = listOfType;
                                    }
                                    modelReturnJSON.pathLogo = GlobalFunctions.getPathLogoTeam(modelReturnJSON.name);

                                }
                                else if (actionForm == "add")
                                {
                                    modelReturnJSON.listOfUser = listOfUser;
                                    modelReturnJSON.listOfType = listOfType;
                                    modelReturnJSON.id = 0;
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            modelReturnJSON.actionUser = actionForm;
                            if (modelReturnJSON.listOfType==null)
                            {
                                GlobalFunctions.getLists(ref listOfUser, ref listOfType, response);
                                modelReturnJSON.listOfType = listOfType;
                                modelReturnJSON.listOfUser = listOfUser;
                            }
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Times - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.actionUser = actionForm;
                        if (modelReturnJSON.listOfType==null)
                        {
                            GlobalFunctions.getLists(ref listOfUser, ref listOfType, response);
                            modelReturnJSON.listOfType = listOfType;
                            modelReturnJSON.listOfUser = listOfUser;
                        }
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Times - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.actionUser = actionForm;
                if (modelReturnJSON.listOfType==null)
                {
                    GlobalFunctions.getLists(ref listOfUser, ref listOfType, response);
                    modelReturnJSON.listOfType = listOfType;
                    modelReturnJSON.listOfUser = listOfUser;
                }
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Times - " + actionForm + ": (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                listOfUser = null;
                listOfType = null;
            }
        }

        // GET: Moderator/UpdateTeamPlayersList
        [UserModerator]
        public ActionResult UpdateTeamPlayersList(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            TeamDetailsModel modelReturnJSON = new TeamDetailsModel();


            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();

            try
            {

                modelReturnJSON.actionUser = "updateTeamPlayersList";
                modelReturnJSON.id = Convert.ToInt32(formHTML["selectedID"]);
                modelReturnJSON.teamSofifaURL = formHTML["selectedIDTeamURL"].Replace("http://", "https://");
                modelReturnJSON.name = formHTML["selectedIDTeamNameWithType"];
                modelReturnJSON.pathLogo = GlobalFunctions.getPathLogoTeam(formHTML["selectedIDTeamName"]);

                if (ConfigurationManager.AppSettings["use.url.standard.sofifa.html"].ToString()=="1")
                {
                    var arrayUrlTEamSofifa = modelReturnJSON.teamSofifaURL.Split(Convert.ToChar("/"));
                    modelReturnJSON.teamSofifaURL = ConfigurationManager.AppSettings["url.team.sofifa.html.standard"].ToString();
                    modelReturnJSON.teamSofifaURL += "?teamSofifaID=" + arrayUrlTEamSofifa[arrayUrlTEamSofifa.Length - 1];
                    modelReturnJSON.teamSofifaID = Convert.ToInt32(arrayUrlTEamSofifa[arrayUrlTEamSofifa.Length - 1]);
                }

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Team", modelReturnJSON).Result;
                modelReturnJSON = response.Content.ReadAsAsync<TeamDetailsModel>().Result;
                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    TempData["actionSuccessfully"] = "Lista de Jogadores atualizada com sucesso";

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.actionUser = actionForm;
                            modelReturnJSON.listOfScorer = new List<ScorerDetails>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Times -UpdateTeamPlayersList. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.actionUser = actionForm;
                        modelReturnJSON.listOfScorer = new List<ScorerDetails>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Times - UpdateTeamPlayersList. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.actionUser = actionForm;
                modelReturnJSON.listOfScorer = new List<ScorerDetails>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Times - UpdateTeamPlayersList: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }


        // GET: Moderator/Blog
        [UserModerator]
        public ActionResult Blog()
        {

            HttpResponseMessage response = null;
            BlogListViewModel modelReturnJSON = null;

            setViewBagVariables();

            try
            {
                response = GlobalVariables.WebApiClient.GetAsync("Blog").Result;
                modelReturnJSON = response.Content.ReadAsAsync<BlogListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Blogs. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Blogs. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Blogs: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }

        // GET: Moderator/BlogDetails
        [UserModerator]
        [ValidateInput(false)]
        public ActionResult BlogDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            BlogDetailsModel modelReturnJSON = new BlogDetailsModel();
            List<ChampionshipUserDetailsModel> listOfUser = new List<ChampionshipUserDetailsModel>();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.inModeratorMenuTextEditor = "1";

            try
            {

                if (actionForm == "delete")
                {

                    modelReturnJSON.actionUser = "dellCrud";
                    modelReturnJSON.id = Convert.ToInt32(formHTML["selectedID"]);
                    modelReturnJSON.userID = Convert.ToInt32(formHTML["selectedUserID"]);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Blog", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<BlogDetailsModel>().Result;
                    TempData["actionSuccessfully"] = "Registro excluído com sucesso";

                }
                else if (actionForm == "save")
                {

                    modelReturnJSON.actionUser = actionForm;

                    modelReturnJSON.id = Convert.ToInt32(formHTML["selectedID"]);
                    modelReturnJSON.userID = Convert.ToInt32(formHTML["cmbTecnico"]);
                    modelReturnJSON.title = formHTML["txtTitulo"];
                    modelReturnJSON.text = Server.HtmlDecode(formHTML["txtConteudo"]);
                    if (modelReturnJSON.id==0)
                    {
                        modelReturnJSON.registerDate = DateTime.Now.Date;
                        modelReturnJSON.registerTime = DateTime.Now.ToString("HH:mm");
                    }
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Blog", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<BlogDetailsModel>().Result;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        if (modelReturnJSON.id == 0) { TempData["actionSuccessfully"] = "Registro incluído com sucesso"; }
                        else { TempData["actionSuccessfully"] = "Registro alterado com sucesso"; }
                    }
                    else if (modelReturnJSON.id == 0) { actionForm = "ADD"; }
                    else if (modelReturnJSON.id > 0) { actionForm = "EDIT"; }
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
                                return RedirectToAction("Blog", "Moderator");
                            }
                            else
                            {
                                if (actionForm == "add")
                                {
                                    GlobalFunctions.getListModerator(ref listOfUser, response);
                                }

                                if (actionForm == "view" || actionForm == "edit")
                                {

                                    response = GlobalVariables.WebApiClient.GetAsync("Blog/" + (formHTML["selectedUserID"] + "|" + formHTML["selectedID"])).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<BlogDetailsModel>().Result;

                                    ChampionshipUserDetailsModel userDetails = new ChampionshipUserDetailsModel();
                                    userDetails.id = modelReturnJSON.userID;
                                    userDetails.name = modelReturnJSON.userName;
                                    userDetails.psnID = modelReturnJSON.psnID;
                                    listOfUser.Add(userDetails);
                                    modelReturnJSON.listOfUser = listOfUser;

                                    userDetails = null;

                                }
                                else if (actionForm == "add")
                                {
                                    modelReturnJSON.listOfUser = listOfUser;
                                    modelReturnJSON.id = 0;
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            modelReturnJSON.actionUser = actionForm;
                            if (modelReturnJSON.listOfUser == null)
                            {
                                GlobalFunctions.getListModerator(ref listOfUser, response);
                                modelReturnJSON.listOfUser = listOfUser;
                            }
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Blogs - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.actionUser = actionForm;
                        if (modelReturnJSON.listOfUser == null)
                        {
                            GlobalFunctions.getListModerator(ref listOfUser, response);
                            modelReturnJSON.listOfUser = listOfUser;
                        }
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Blogs - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.actionUser = actionForm;
                if (modelReturnJSON.listOfUser == null)
                {
                    GlobalFunctions.getListModerator(ref listOfUser, response);
                    modelReturnJSON.listOfUser = listOfUser;
                }
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Blogs - " + actionForm + ": (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                listOfUser = null;
            }
        }


        // GET: Moderator/Championship
        [UserModerator]
        public ActionResult Championship()
        {

            HttpResponseMessage response = null;
            ChampionshipListViewModel modelReturnJSON = null;

            setViewBagVariables();

            try
            {
                response = GlobalVariables.WebApiClient.GetAsync("Championship").Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Campeonatos. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Campeonatos. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Campeonatos: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }


        // GET: Moderator/ChampionshipDetails
        [UserModerator]
        public ActionResult ChampionshipDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipDetailsModel modelReturnJSON = new ChampionshipDetailsModel();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();

            try
            {

                if (actionForm == "save")
                {

                    modelReturnJSON.actionUser = actionForm;

                    modelReturnJSON.id = Convert.ToInt32(formHTML["selectedID"]);
                    modelReturnJSON.userID1 = Convert.ToInt32(formHTML["cmbModerador1"]);
                    modelReturnJSON.userID2 = Convert.ToInt32(formHTML["cmbModerador2"]);
                    modelReturnJSON.name = formHTML["txtDescricao"];
                    modelReturnJSON.totalQualify = Convert.ToInt16(formHTML["txtQtClassificados"]);
                    modelReturnJSON.totalRelegation = Convert.ToInt16(formHTML["txtQtRebaixados"]);
                    modelReturnJSON.totalQualifyNextStage = Convert.ToInt16(formHTML["txtQtClassifMoreThan"]);
                    modelReturnJSON.totalDayStagePlayoff = Convert.ToInt16(formHTML["txtQtDiaPartidaPlayoff"]);
                    if (formHTML["chkAtivo"] == "on")
                        modelReturnJSON.active = true;
                    modelReturnJSON.started = Convert.ToInt32(formHTML["drawDone"]);

                    modelReturnJSON.startDate = Convert.ToDateTime(formHTML["txtDtInicio"]);
                    modelReturnJSON.drawDate = Convert.ToDateTime(formHTML["txtDtSorteio"]);
                    if (formHTML["chkTurnoReturno"] == "on")
                        modelReturnJSON.twoTurns = true;
                    if (formHTML["chkPorGupos"] == "on")
                        modelReturnJSON.forGroup = true;
                    if (formHTML["chkPlayoff"] == "on")
                        modelReturnJSON.playoff = true;
                    if (formHTML["chkTurno"] == "on")
                        modelReturnJSON.justOneTurn = true;
                    if (formHTML["chkIdaVolta"] == "on")
                        modelReturnJSON.twoLegs = true;

                    modelReturnJSON.type = formHTML["cmbTipo"];

                    modelReturnJSON.totalTeam = Convert.ToInt16(formHTML["txtQtTimes"]);
                    modelReturnJSON.totalGroup = Convert.ToInt16(formHTML["txtQtGrupos"]);
                    modelReturnJSON.totalDayStageOne = Convert.ToInt16(formHTML["txtQtDiaPartidaFaseInicial"]);

                    modelReturnJSON.listTeamsAdd = formHTML["listTimesPorCampeonato"];
                    modelReturnJSON.listTeamsStage0Add = formHTML["listTimesPreCopa"];
                    modelReturnJSON.listUsersAdd = formHTML["listTecnicosPorCampeonato"];
                    modelReturnJSON.listUsersStage2Add = formHTML["listTecnicoProxFase"];
                    modelReturnJSON.listStagesAdd = formHTML["listStageIDs"];

                    modelReturnJSON.idUserOperation = Convert.ToUInt16(Session["user.id"].ToString());
                    modelReturnJSON.psnOperation = Session["user.psnID"].ToString();

                    modelReturnJSON.console = formHTML["consoleID"];

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", modelReturnJSON).Result;
                    modelReturnJSON = new ChampionshipDetailsModel();
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        if (modelReturnJSON.id == 0) { TempData["actionSuccessfully"] = "Registro incluído com sucesso"; }
                        else { TempData["actionSuccessfully"] = "Registro alterado com sucesso"; }
                    }
                    else if (modelReturnJSON.id == 0) { actionForm = "ADD"; }
                    else if (modelReturnJSON.id > 0) { actionForm = "EDIT"; }
                }
                else if (actionForm == "view" || actionForm == "edit")
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
                                return RedirectToAction("Championship", "Moderator");
                            }
                            else
                            {
                                if (actionForm == "view" || actionForm == "edit")
                                {

                                    response = GlobalVariables.WebApiClient.GetAsync("Championship/" + formHTML["selectedID"]).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;

                                    List<StandardDetailsModel_v2> listOfType = new List<StandardDetailsModel_v2>();
                                    StandardDetailsModel_v2 typeDetails = new StandardDetailsModel_v2();
                                    typeDetails.id = modelReturnJSON.type;
                                    typeDetails.name = modelReturnJSON.typeName;
                                    listOfType.Add(typeDetails);
                                    modelReturnJSON.listOfType = listOfType;

                                    List<ChampionshipUserDetailsModel> listOfUser = new List<ChampionshipUserDetailsModel>();
                                    GlobalFunctions.getListModerator(ref listOfUser, response);
                                    modelReturnJSON.listOfModerator = listOfUser;

                                    TeamTypeListViewModel teamTypeModel = new TeamTypeListViewModel();
                                    response = GlobalVariables.WebApiClient.GetAsync("TeamType").Result;
                                    teamTypeModel = response.Content.ReadAsAsync<TeamTypeListViewModel>().Result;

                                    modelReturnJSON.listOfTeamType = teamTypeModel.listOfType;


                                    ChampionshipDetailsModel championshipModel = new ChampionshipDetailsModel();
                                    ChampionshipListViewModel championshipListModel = new ChampionshipListViewModel();

                                    championshipModel.actionUser = "getAllActive";
                                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", championshipModel).Result;
                                    championshipListModel = response.Content.ReadAsAsync<ChampionshipListViewModel>().Result;

                                    modelReturnJSON.listOfChampionship = championshipListModel.listOfChampionship;

                                    listOfType = null;
                                    typeDetails = null;
                                    listOfUser = null;
                                    teamTypeModel = null;
                                    championshipModel = null;
                                    championshipListModel = null;
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            modelReturnJSON.actionUser = actionForm;
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Campeonatos - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.actionUser = actionForm;
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Campeonatos - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.actionUser = actionForm;
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Campeonatos - " + actionForm + ": (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }



        // GET: Moderator/ManageChampionshipDetails
        [UserModerator]
        public ActionResult ManageChampionshipDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipDetailsModel modelReturnJSON = new ChampionshipDetailsModel();

            string actionForm = formHTML["actionForm"].ToLower();
            string typeSearch = String.Empty;


            setViewBagVariables();

            try
            {

                if (actionForm.IndexOf("save") > -1)
                {
                    systemEmail objEmail = new systemEmail();

                    string[] arrayIN = formHTML["cmbInputIN"].Split(Convert.ToChar(";"));
                    string[] arrayOUT = formHTML["cmbInputOUT"].Split(Convert.ToChar(";"));
                    string subjectEmail = String.Empty;
                    string divisionName = String.Empty;

                    modelReturnJSON.actionUser = actionForm;
                    modelReturnJSON.seasonName = formHTML["selectedIDSeasonName"];
                    modelReturnJSON.type = formHTML["selectedIDType"];
                    modelReturnJSON.userID1 = Convert.ToInt32(arrayIN[0]);
                    modelReturnJSON.userName1 = arrayIN[1];
                    modelReturnJSON.psnID1 = arrayIN[2];
                    modelReturnJSON.userID2 = Convert.ToInt32(arrayOUT[0]);
                    modelReturnJSON.userName2 = arrayOUT[1];
                    modelReturnJSON.psnID2 = arrayOUT[2];

                    if (actionForm == "save_send_invite")
                    {
                        modelReturnJSON.teamName1 = arrayIN[1];
                        if (modelReturnJSON.type.Substring(0, 3) == "DIV")
                            modelReturnJSON.teamName1 += " (" + arrayIN[2] + ")";

                        if (modelReturnJSON.type == "DIV1" || modelReturnJSON.type == "FUT1") { divisionName = "Série A"; }
                        else if (modelReturnJSON.type == "DIV2" || modelReturnJSON.type == "FUT2") { divisionName = "Série B"; }
                        else if (modelReturnJSON.type == "DIV3" || modelReturnJSON.type == "FUT3") { divisionName = "Série C"; }
                        else if (modelReturnJSON.type == "DIV4" || modelReturnJSON.type == "FUT4") { divisionName = "Série D"; }


                        if (modelReturnJSON.type == "FUT2") { subjectEmail = "Convite para participar da " + modelReturnJSON.seasonName + " do Campeonatos de FUT"; }
                        else if (modelReturnJSON.type == "FUT1") { subjectEmail = "Convite para participar da " + modelReturnJSON.seasonName + " do Campeonatos de FUT"; }
                        else if (modelReturnJSON.type == "DIV3" || modelReturnJSON.type == "DIV4") { subjectEmail = "Convite para participar da " + modelReturnJSON.seasonName + " do Campeonatos de H2H"; }
                        else if (modelReturnJSON.type == "DIV1" || modelReturnJSON.type == "FUT2") { subjectEmail = "Convite para acesso a " + divisionName + " da " + modelReturnJSON.seasonName + " do Campeonatos de H2H"; }

                        objEmail.SendEmail(getBodyHtml(modelReturnJSON, divisionName), arrayOUT[3], "CONTACT-US", subjectEmail);

                        response.StatusCode = HttpStatusCode.Created;
                        modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                        TempData["actionSuccessfully"] = "Email convite para o técnico: " + modelReturnJSON.userName2 + " (" + modelReturnJSON.psnID2 + "), foi enviado com sucesso.";

                    }
                    else if (actionForm == "save_manager_swap")
                    {

                        modelReturnJSON.actionUser = "userExchange";
                        modelReturnJSON.idUserOperation = Convert.ToUInt16(Session["user.id"].ToString());
                        modelReturnJSON.psnOperation = Session["user.psnID"].ToString();

                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", modelReturnJSON).Result;
                        modelReturnJSON = new ChampionshipDetailsModel();
                        modelReturnJSON = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;

                        if (modelReturnJSON.type == "DIV3" || modelReturnJSON.type == "DIV4" || modelReturnJSON.type == "FUT1" || modelReturnJSON.type == "PRO1")
                            subjectEmail = "Re: Convite para participar";
                        else if (modelReturnJSON.type == "DIV1" || modelReturnJSON.type == "DIV2")
                            subjectEmail = "Re: Convite para Acesso";

                        objEmail.SendEmail(getBodyHtmlSwapManager(modelReturnJSON), arrayIN[3], "CONTACT-US", subjectEmail);

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            if (modelReturnJSON.type.Substring(0,3)=="DIV")
                                TempData["actionSuccessfully"] = "A troca de técnicos dos campeonatos de H2H foi efetuada com sucesso.";
                            else if (modelReturnJSON.type.Substring(0, 3) == "FUT")
                                TempData["actionSuccessfully"] = "A troca de times & técnicos dos campeonatos de FUT foi efetuada com sucesso.";
                            else if (modelReturnJSON.type.Substring(0, 3) == "PRO")
                                TempData["actionSuccessfully"] = "A troca de clubes & manager dos campeonatos de PRO CLUB foi efetuada com sucesso.";
                        }

                    }
                    else if (actionForm == "save_club_swap")
                    {
                        modelReturnJSON.actionUser = "managerexchange";
                        modelReturnJSON.idUserOperation = Convert.ToUInt16(Session["user.id"].ToString());
                        modelReturnJSON.psnOperation = Session["user.psnID"].ToString();

                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", modelReturnJSON).Result;
                        modelReturnJSON = new ChampionshipDetailsModel();
                        modelReturnJSON = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;

                        subjectEmail = "Re: Troca de Managers";

                        objEmail.SendEmail(getBodyHtmlSwapManagerPRO(modelReturnJSON), arrayIN[3], "CONTACT-US", subjectEmail);

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            TempData["actionSuccessfully"] = "A Troca de Clubes no PRO CLUB foi efetuada com sucesso.";
                        }
                    }

                    objEmail = null;
                }
                else if (actionForm == "send_invite" || actionForm == "manager_swap" || actionForm == "club_swap")
                {

                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm.IndexOf("save") > -1)
                            {
                                return RedirectToAction("Championship", "Moderator");
                            }
                            else
                            {
                                if (actionForm == "send_invite" || actionForm == "manager_swap" || actionForm == "club_swap")
                                {

                                    response = GlobalVariables.WebApiClient.GetAsync("Championship/" + formHTML["selectedID"]).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;

                                    ChampionshipUserListViewModel listOfUserGetIn = new ChampionshipUserListViewModel();
                                    ChampionshipUserListViewModel listOfUserGetOut = new ChampionshipUserListViewModel();
                                    ChampionshipTeamListViewModel listOfTeam = new ChampionshipTeamListViewModel();

                                    string pathChampionshipLogo = String.Empty;
                                    string pathTypeLogo = String.Empty;

                                    GlobalFunctions.getPathLogoChampionship(modelReturnJSON.name, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                                    modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                                    modelReturnJSON.pathLogoType = pathTypeLogo;

                                    if (actionForm == "send_invite")
                                    {
                                        modelReturnJSON.titleView = "Enviar E-mail Convite Temporada";
                                        modelReturnJSON.labelActionButton = "Enviar E-mail";

                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipTeam/" + formHTML["selectedID"]).Result;
                                        listOfTeam = response.Content.ReadAsAsync<ChampionshipTeamListViewModel>().Result;
                                        modelReturnJSON.listOfTeam = listOfTeam.listOfTeam;
                                        modelReturnJSON.labelUserGetIn = "Escolha um Time do Campeonato";

                                        if (formHTML["selectedType"] == "DIV1")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico da Série B do H2H";
                                            typeSearch = "DIV2";
                                        }
                                        else if (formHTML["selectedType"] == "DIV2")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico da Série C do H2H";
                                            typeSearch = "DIV3";
                                        }
                                        else if (formHTML["selectedType"] == "DIV3")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico do Banco de reservas do H2H";
                                            typeSearch = "BCO-H2H";
                                        }
                                        else if (formHTML["selectedType"] == "FUT1")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico da Banco de reservas do FUT";
                                            typeSearch = "BCO-FUT";
                                        }
                                        else if (formHTML["selectedType"] == "PRO1")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico da Banco de reservas do PRO CLUB";
                                            typeSearch = "BCO-PRO";
                                        }


                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipUser/" + typeSearch).Result;
                                        listOfUserGetOut = response.Content.ReadAsAsync<ChampionshipUserListViewModel>().Result;
                                        modelReturnJSON.listOfUserGetOut = listOfUserGetOut.listOfUser;

                                        modelReturnJSON.listOfUserGetIn = new List<ChampionshipUserDetailsModel>();
                                    }
                                    else
                                    {
                                        if (actionForm == "manager_swap")
                                        {
                                            if (formHTML["selectedType"].Substring(0,3)=="DIV")
                                                modelReturnJSON.titleView = "Efetuar APENAS Troca de Técnico nos campeonatos de H2H (X1)";
                                            else if (formHTML["selectedType"].Substring(0, 3) == "FUT")
                                                modelReturnJSON.titleView = "Efetuar Troca de Time & Técnico nos campeonatos de FUT (Ultimate Team)";
                                            else if (formHTML["selectedType"].Substring(0, 3) == "PRO")
                                                modelReturnJSON.titleView = "Efetuar Troca de Clube & Manager nos campeonatos de PRO CLUB";
                                        }
                                        else if (actionForm == "club_swap")
                                        {
                                            modelReturnJSON.titleView = "Efetuar Troca APENAS de Manager do Clube nos campeonatos de PRO CLUB";
                                        }
                                        modelReturnJSON.labelActionButton = "Efetuar Troca";

                                        modelReturnJSON.listOfTeam = new List<StandardDetailsModel>();

                                        typeSearch = formHTML["selectedType"];

                                        if (formHTML["selectedType"] == "DIV1")
                                        {
                                            modelReturnJSON.labelUserGetIn = "Escolha um Técnico para ENTRAR da Série A do H2H";
                                        }
                                        else if (formHTML["selectedType"] == "DIV2")
                                        {
                                            modelReturnJSON.labelUserGetIn = "Escolha um Técnico para ENTRAR da Série B do H2H";
                                        }
                                        else if (formHTML["selectedType"] == "DIV3")
                                        {
                                            modelReturnJSON.labelUserGetIn = "Escolha um Técnico para ENTRAR da Série C do H2H";
                                        }
                                        else if (formHTML["selectedType"] == "FUT1")
                                        {
                                            modelReturnJSON.labelUserGetIn = "Escolha um Técnico para ENTRAR da Série A do FUT";
                                        }
                                        else if (formHTML["selectedType"] == "PRO1")
                                        {
                                            modelReturnJSON.labelUserGetIn = "Escolha um Técnico para ENTRAR da Série A do PRO CLUB";
                                        }
                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipUser/" + (formHTML["selectedID"] + "|" + typeSearch)).Result;
                                        listOfUserGetIn = response.Content.ReadAsAsync<ChampionshipUserListViewModel>().Result;
                                        modelReturnJSON.listOfUserGetIn = listOfUserGetIn.listOfUser;



                                        if (formHTML["selectedType"] == "DIV1")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico para SAIR da Série A do H2H";
                                        }
                                        else if (formHTML["selectedType"] == "DIV2")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico para SAIR da Série B do H2H";
                                        }
                                        else if (formHTML["selectedType"] == "DIV3")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico para SAIR da Série C do H2H";
                                        }
                                        else if (formHTML["selectedType"] == "FUT1")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico para SAIR da Série A do FUT";
                                        }
                                        else if (formHTML["selectedType"] == "PRO1")
                                        {
                                            modelReturnJSON.labelUserGetOut = "Escolha um Técnico para SAIR da Série A do PRO CLUB";
                                        }
                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipUser/" + typeSearch).Result;
                                        listOfUserGetOut = response.Content.ReadAsAsync<ChampionshipUserListViewModel>().Result;
                                        modelReturnJSON.listOfUserGetOut = listOfUserGetOut.listOfUser;

                                    }

                                    listOfUserGetIn = null;
                                    listOfUserGetOut = null;
                                    listOfTeam = null;
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            modelReturnJSON.actionUser = actionForm;
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Campeonatos - Gerenciar Ação - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.actionUser = actionForm;
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Cadastro de Campeonatos - Gerenciar Ação - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.actionUser = actionForm;
                modelReturnJSON.listOfUserGetIn = new List<ChampionshipUserDetailsModel>();
                modelReturnJSON.listOfTeam = new List<StandardDetailsModel>();
                modelReturnJSON.listOfUserGetOut = new List<ChampionshipUserDetailsModel>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Cadastro de Campeonatos - Gerenciar Ação - " + actionForm + ": (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }



        // GET: Moderator/LaunchResult
        [UserModerator]
        public ActionResult LaunchResult()
        {

            HttpResponseMessage response = null;
            ChampionshipListViewModel modelReturnJSON = null;
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();

            setViewBagVariables();

            try
            {

                ModeratorMenuMode.actionUser = "getAllActive";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Lançar Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Lançar Resultado. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Lançar Resultado: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: Moderator/LaunchResultDetails
        [UserModerator]
        public ActionResult LaunchResultDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipDetailsModel modelReturnJSON = new ChampionshipDetailsModel();
            ChampionshipMatchTableDetailsModel modelReturnJSON2 = new ChampionshipMatchTableDetailsModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode2 = new ChampionshipMatchTableDetailsModel();
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.inLaunchResult = "1";

            try
            {

                if (actionForm == "delete_all_by_match")
                {
                    ModeratorMenuMode2.matchID = Convert.ToInt32(formHTML["matchID"]);
                    ModeratorMenuMode2.championshipID = Convert.ToInt32(formHTML["selectedID"]);

                    ModeratorMenuMode2.actionUser = "delete_result_launched";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", ModeratorMenuMode2).Result;
                    modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Todo resultado e seus detalhes foram excluídos com sucesso.";
                }
                else
                {
                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save")
                            {
                                return RedirectToAction("LaunchResult", "Moderator");
                            }
                            else
                            {
                                if (actionForm == "show_championship_details" || actionForm == "delete_all_by_match" || actionForm == "save_simple_result")
                                {
                                    modelReturnJSON = GlobalFunctions.ShowChampionshipDetails(formHTML["selectedID"]);
                                }
                                 modelReturnJSON.actionUser = actionForm.ToUpper();
                                if ((!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully"))
                                {
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                    return View(modelReturnJSON);
                                }
                                else if (modelReturnJSON.drawDoneMatchTable == 0)
                                {
                                    TempData["returnMessage"] = "A Funcionalidade não está disponível. O Sorteio, deste campeonato, ainda não foi gerado.";
                                    return View("LaunchResult", (ChampionshipListViewModel)TempData["FullModel"]);
                                }
                                else
                                    return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Lançar Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Lançar Resultado. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfGroup = new List<StandardDetailsModel>();
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.listOfTeamTable = new List<ChampionshipTeamTableDetailsModel>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Lançar Resultado: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                modelReturnJSON2 = null;
                ModeratorMenuMode2 = null;
            }
        }


        // GET: Moderator/DecreeResult
        [UserModerator]
        public ActionResult DecreeResult(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            ChampionshipDetailsModel modelReturnJSON2 = new ChampionshipDetailsModel();
            ChampionshipDetailsModel ModeratorMenuMode2 = new ChampionshipDetailsModel();
            ChampionshipCommentMatchUsersListViewModel modelReturnJSON3 = new ChampionshipCommentMatchUsersListViewModel();
            ChampionshipCommentMatchDetailsModel commentMatchMode = new ChampionshipCommentMatchDetailsModel();
            ChampionshipCommentMatchDetailsModel modelReturnJSON4 = new ChampionshipCommentMatchDetailsModel();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.inLaunchResult = "1";

            try
            {

                if (actionForm == "save_decree_result")
                {
                    ModeratorMenuMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                    ModeratorMenuMode.championshipID = Convert.ToInt32(formHTML["selectedID"]);
                    ModeratorMenuMode.actionUser = "decree_result";

                    ModeratorMenuMode.userIDAction = Convert.ToUInt16(Session["user.id"].ToString());
                    ModeratorMenuMode.psnIDAction = Session["user.psnID"].ToString();

                    ModeratorMenuMode.typeBlackList = formHTML["cmbDecree"];
                    ModeratorMenuMode.messageBlackList = "<b>" + formHTML["cmbMessageDecree"].Replace("|Home", String.Empty).Replace("|Away", String.Empty) + "</b>";

                    string goalsTeamHome = "0";
                    string goalsTeamAway = "0";

                    if (formHTML["cmbMessageDecree"].IndexOf("(3x0)") >-1)
                    {
                        if (formHTML["cmbMessageDecree"].IndexOf("|Home") > -1) { goalsTeamHome = "3"; } else { goalsTeamAway = "3"; }
                    }

                    ModeratorMenuMode.totalGoalsHome = goalsTeamHome;
                    ModeratorMenuMode.totalGoalsAway = goalsTeamAway;

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        TempData["actionSuccessfully"] = "Decreto da partida efetuado com sucesso.";

                        commentMatchMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                        commentMatchMode.comment = Server.HtmlDecode("<b>Placar atualizado.</b>");
                        commentMatchMode.actionUser = "save_comment";
                        commentMatchMode.userID = Convert.ToUInt16(Session["user.id"].ToString());

                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentMatch", commentMatchMode).Result;
                        modelReturnJSON4 = response.Content.ReadAsAsync<ChampionshipCommentMatchDetailsModel>().Result;

                        modelReturnJSON.returnMessage = modelReturnJSON4.returnMessage;

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                            GlobalFunctions.SendEmailCommentAllUsersByGame(modelReturnJSON, commentMatchMode.comment, formHTML["matchID"]);
                        }
                    }
                }
                else
                {
                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save_decree_result")
                            {
                                modelReturnJSON2 = GlobalFunctions.ShowChampionshipDetails(formHTML["selectedID"]);
                                modelReturnJSON2.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON2.returnMessage) && modelReturnJSON2.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON2.returnMessage + " - " + actionForm + ". (" + modelReturnJSON2.returnMessage + ")";

                                return View("LaunchResultDetails", modelReturnJSON2);
                            }
                            else
                            {
                                if (actionForm == "show_championshipmatchtable_details")
                                {
                                    response = GlobalVariables.WebApiClient.GetAsync("ChampionshipMatchTable/" + (formHTML["selectedID"] + ";" + formHTML["matchID"])).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    {
                                        modelReturnJSON.pathLogoTeamHome = GlobalFunctions.getPathLogoTeam(modelReturnJSON.teamNameHome);
                                        modelReturnJSON.pathLogoTeamAway = GlobalFunctions.getPathLogoTeam(modelReturnJSON.teamNameAway);

                                        string pathChampionshipLogo = string.Empty;
                                        string pathTypeLogo = string.Empty;

                                        GlobalFunctions.getPathLogoChampionship(modelReturnJSON.championshipName, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                                        modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                                        modelReturnJSON.pathLogoType = pathTypeLogo;
                                    }
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";

                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Decretar Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Decretar Resultado. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Decretar Resultado: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                modelReturnJSON2 = null;
                ModeratorMenuMode2 = null;
                commentMatchMode = null;
                modelReturnJSON3 = null;
                modelReturnJSON4 = null;
            }
        }


        // GET: Moderator/CommentMatch
        [UserModerator]
        [ValidateInput(false)]
        public ActionResult CommentMatch(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            ChampionshipCommentMatchListViewModel modelReturnJSON2 = new ChampionshipCommentMatchListViewModel();
            ChampionshipCommentMatchUsersListViewModel modelReturnJSON3 = new ChampionshipCommentMatchUsersListViewModel();
            ScorerMatchViewModel scorersMatcModel = new ScorerMatchViewModel();
            ChampionshipDetailsModel championshipModel = new ChampionshipDetailsModel();
            ChampionshipMatchTableViewModel listOfMatchTable = new ChampionshipMatchTableViewModel();
            ChampionshipCommentMatchDetailsModel commentMatchMode = new ChampionshipCommentMatchDetailsModel();
            ChampionshipCommentMatchDetailsModel modelReturnJSON4 = new ChampionshipCommentMatchDetailsModel();
            BlackListViewModel modelReturnJSON5 = new BlackListViewModel();
            BlackListViewModel blackListMode = new BlackListViewModel();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.inLaunchResult = "1";

            try
            {

                if (actionForm == "save_comment")
                {
                    commentMatchMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                    commentMatchMode.comment = Server.HtmlDecode(formHTML["txtComment"]);
                    commentMatchMode.actionUser = "save_comment";
                    commentMatchMode.userID = Convert.ToUInt16(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentMatch", commentMatchMode).Result;
                    modelReturnJSON4 = response.Content.ReadAsAsync<ChampionshipCommentMatchDetailsModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON4.returnMessage;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                        GlobalFunctions.SendEmailCommentAllUsersByGame(modelReturnJSON, commentMatchMode.comment, formHTML["matchID"]);

                        TempData["actionSuccessfully"] = "Comentário efetuado com sucesso";
                    }
                }
                else if (actionForm == "save_user_comment")
                {
                    commentMatchMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                    commentMatchMode.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    commentMatchMode.actionUser = actionForm;
                    commentMatchMode.userID = Convert.ToInt32(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentUsers", commentMatchMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Ação efetuada com sucesso. Você agora estará recebendo os comentários desta partida";
                }
                else if (actionForm == "cancel_user_comment")
                {
                    commentMatchMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                    commentMatchMode.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    commentMatchMode.actionUser = actionForm;
                    commentMatchMode.userID = Convert.ToInt32(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentUsers", commentMatchMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Ação efetuada com sucesso. Você NÃO receberá mais os comentários desta partida";
                }
                else if (actionForm == "add_blacklist")
                {
                    blackListMode.actionUser = "add_by_match";
                    blackListMode.seasonID = 0;
                    blackListMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                    blackListMode.championshipID = Convert.ToInt32(formHTML["selectedID"]);
                    blackListMode.userID = Convert.ToInt32(formHTML["userID"]);
                    blackListMode.messageBlackList = formHTML["blackListSelected"];

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", blackListMode).Result;
                    modelReturnJSON5 = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON5.returnMessage.Replace("BlackList", "Moderator");

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        TempData["actionSuccessfully"] = "A Lista Negra para o usuário: " + blackListMode.userID + " foi regristrada com sucesso";

                        modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                        if (formHTML["blackListSelected"] == "LN_OMT")
                        {
                            modelReturnJSON.messageBlackList = "<br><br>          <b>Foi inserída uma pontuação negativa refrerente a Omissão Total para esta partida.</b>";
                        }
                        else if (formHTML["blackListSelected"] == "LN_OMP")
                        {
                            modelReturnJSON.messageBlackList = "<br><br>          <b>Foi inserída uma pontuação negativa refrerente a Omissão Parcial para esta partida.</b>";
                        }
                        else if (formHTML["blackListSelected"] == "LN_ADP")
                        {
                            modelReturnJSON.messageBlackList = "<br><br>          <b>Foi inserída uma pontuação negativa refrerente a Atitude Antidesportiva para esta partida.</b>";
                        }
                        else if (formHTML["blackListSelected"] == "LN_ADV")
                        {
                            modelReturnJSON.messageBlackList = "<br><br>          <b>Foi inserída uma pontuação negativa refrerente a Advertência para esta partida.</b>";
                        }

                        if (blackListMode.userID == modelReturnJSON.userHomeID)
                        {
                            modelReturnJSON.messageBlackList = "Atenção técncico " + modelReturnJSON.psnIDHome + modelReturnJSON.messageBlackList;
                        }
                        else
                        {
                            modelReturnJSON.messageBlackList = "Atenção técncico " + modelReturnJSON.psnIDAway + modelReturnJSON.messageBlackList;
                        }


                        commentMatchMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                        commentMatchMode.comment = Server.HtmlDecode(modelReturnJSON.messageBlackList);
                        commentMatchMode.actionUser = "save_comment";
                        commentMatchMode.userID = Convert.ToUInt16(Session["user.id"].ToString());

                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentMatch", commentMatchMode).Result;
                        modelReturnJSON4 = response.Content.ReadAsAsync<ChampionshipCommentMatchDetailsModel>().Result;

                        modelReturnJSON.returnMessage = modelReturnJSON4.returnMessage;

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                            GlobalFunctions.SendEmailCommentAllUsersByGame(modelReturnJSON, commentMatchMode.comment, formHTML["matchID"]);
                        }
                    }
                }
                else if (actionForm == "delete_blacklist")
                {
                    blackListMode.actionUser = "delete_by_match";
                    blackListMode.matchID = Convert.ToInt32(formHTML["matchID"]);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", blackListMode).Result;
                    modelReturnJSON5 = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON5.returnMessage.Replace("BlackList", "Moderator");

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        TempData["actionSuccessfully"] = "TODA Lista Negra para esta partida foi excluída com sucesso";

                        modelReturnJSON.messageBlackList = modelReturnJSON5.messageBlackList;

                        commentMatchMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                        commentMatchMode.comment = Server.HtmlDecode(modelReturnJSON.messageBlackList);
                        commentMatchMode.actionUser = "save_comment";
                        commentMatchMode.userID = Convert.ToUInt16(Session["user.id"].ToString());

                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentMatch", commentMatchMode).Result;
                        modelReturnJSON4 = response.Content.ReadAsAsync<ChampionshipCommentMatchDetailsModel>().Result;

                        modelReturnJSON.returnMessage = modelReturnJSON4.returnMessage;

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                            GlobalFunctions.SendEmailCommentAllUsersByGame(modelReturnJSON, commentMatchMode.comment, formHTML["matchID"]);
                        }
                    }
                }
                else
                {
                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save_comment")
                            {
                                ViewBag.inScorerDetails = "1";

                                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentMatch/" + formHTML["matchID"]).Result;
                                modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipCommentMatchListViewModel>().Result;

                                modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                {
                                    modelReturnJSON.listOfCommentMatch = modelReturnJSON2.listOfCommentMatch;

                                }
                                return View(modelReturnJSON);
                            }
                            else if (actionForm == "save_user_comment" || actionForm == "cancel_user_comment")
                            {
                                ViewBag.inScorerDetails = "1";
                                modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentUsers/" + formHTML["matchID"]).Result;
                                modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipCommentMatchUsersListViewModel>().Result;

                                modelReturnJSON.returnMessage = modelReturnJSON3.returnMessage;

                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    modelReturnJSON.listOfUsersCommentMatch = modelReturnJSON3.listOfUsersCommentMatch;

                                return View(modelReturnJSON);
                            }
                            else if (actionForm == "add_blacklist" || actionForm == "delete_blacklist")
                            {
                                ViewBag.inScorerDetails = "1";

                                blackListMode.actionUser = "get_by_match_user";
                                blackListMode.matchID = modelReturnJSON.matchID;
                                blackListMode.userID = modelReturnJSON.userHomeID;

                                response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", blackListMode).Result;
                                modelReturnJSON5 = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                                modelReturnJSON.returnMessage = modelReturnJSON5.returnMessage.Replace("BlackList", "Moderator");

                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                {
                                    modelReturnJSON.blackListIDUser1 = modelReturnJSON5.valueBlackList;
                                    modelReturnJSON.messageBlackListUser1 = modelReturnJSON5.messageBlackList;

                                    blackListMode = new BlackListViewModel();
                                    modelReturnJSON5 = new BlackListViewModel();

                                    blackListMode.actionUser = "get_by_match_user";
                                    blackListMode.matchID = modelReturnJSON.matchID;
                                    blackListMode.userID = modelReturnJSON.userAwayID;

                                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", blackListMode).Result;
                                    modelReturnJSON5 = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                                    modelReturnJSON.returnMessage = modelReturnJSON5.returnMessage.Replace("BlackList", "Moderator");

                                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    {
                                        modelReturnJSON.blackListIDUser2 = modelReturnJSON5.valueBlackList;
                                        modelReturnJSON.messageBlackListUser2 = modelReturnJSON5.messageBlackList;

                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentMatch/" + formHTML["matchID"]).Result;
                                        modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipCommentMatchListViewModel>().Result;

                                        modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                        {
                                            modelReturnJSON.listOfCommentMatch = modelReturnJSON2.listOfCommentMatch;

                                        }
                                    }
                                }

                                return View(modelReturnJSON);
                            }
                            else
                            {
                                if (actionForm == "show_championshipmatchtable_details")
                                {
                                    ViewBag.inScorerDetails = "1";

                                    response = GlobalVariables.WebApiClient.GetAsync("ChampionshipMatchTable/" + (formHTML["selectedID"] + ";" + formHTML["matchID"])).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    {
                                        modelReturnJSON.pathLogoTeamHome = GlobalFunctions.getPathLogoTeam(modelReturnJSON.teamNameHome);
                                        modelReturnJSON.pathLogoTeamAway = GlobalFunctions.getPathLogoTeam(modelReturnJSON.teamNameAway);

                                        string pathChampionshipLogo = string.Empty;
                                        string pathTypeLogo = string.Empty;

                                        GlobalFunctions.getPathLogoChampionship(modelReturnJSON.championshipName, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                                        modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                                        modelReturnJSON.pathLogoType = pathTypeLogo;

                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentMatch/" + formHTML["matchID"]).Result;
                                        modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipCommentMatchListViewModel>().Result;

                                        modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                        {
                                            modelReturnJSON.listOfCommentMatch = modelReturnJSON2.listOfCommentMatch;

                                            response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentUsers/" + formHTML["matchID"]).Result;
                                            modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipCommentMatchUsersListViewModel>().Result;

                                            modelReturnJSON.returnMessage = modelReturnJSON3.returnMessage;

                                            if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                            {
                                                modelReturnJSON.listOfUsersCommentMatch = modelReturnJSON3.listOfUsersCommentMatch;

                                                response = GlobalVariables.WebApiClient.GetAsync("ScorerMatch/" + (formHTML["selectedID"] + "|" + formHTML["matchID"])).Result;
                                                scorersMatcModel = response.Content.ReadAsAsync<ScorerMatchViewModel>().Result;

                                                modelReturnJSON.returnMessage = scorersMatcModel.returnMessage;

                                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                                {
                                                    if (scorersMatcModel.listOfScorerMatch != null)
                                                        modelReturnJSON.listOfScorerMatch = scorersMatcModel.listOfScorerMatch;
                                                    else
                                                        modelReturnJSON.listOfScorerMatch = new List<ScorerMatchDetails>();

                                                    response = GlobalVariables.WebApiClient.GetAsync("Championship/" + formHTML["selectedID"]).Result;
                                                    championshipModel = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;

                                                    modelReturnJSON.returnMessage = championshipModel.returnMessage;

                                                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                                    {
                                                        modelReturnJSON.userID1 = championshipModel.userID1;
                                                        modelReturnJSON.userName1 = championshipModel.userName1;
                                                        modelReturnJSON.psnID1 = championshipModel.psnID1;

                                                        modelReturnJSON.userID2 = championshipModel.userID2;
                                                        modelReturnJSON.userName2 = championshipModel.userName2;
                                                        modelReturnJSON.psnID2 = championshipModel.psnID2;

                                                        modelReturnJSON.totalRecordsOfHistoric = Convert.ToInt16(ConfigurationManager.AppSettings["total.records.historic.each.team"].ToString());

                                                        modelReturnJSON.actionUser = "show_historic_each_team";

                                                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", modelReturnJSON).Result;
                                                        listOfMatchTable = response.Content.ReadAsAsync<ChampionshipMatchTableViewModel>().Result;

                                                        modelReturnJSON.returnMessage = listOfMatchTable.returnMessage;

                                                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                                        {
                                                            if (listOfMatchTable.listOfMatch!=null)
                                                                modelReturnJSON.listOfMatch = listOfMatchTable.listOfMatch;
                                                            else
                                                                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();

                                                            blackListMode.actionUser = "get_by_match_user";
                                                            blackListMode.matchID = modelReturnJSON.matchID;
                                                            blackListMode.userID = modelReturnJSON.userHomeID;

                                                            response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", blackListMode).Result;
                                                            modelReturnJSON5 = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                                                            modelReturnJSON.returnMessage = modelReturnJSON5.returnMessage.Replace("BlackList", "Moderator");

                                                            if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                                            {
                                                                modelReturnJSON.blackListIDUser1 = modelReturnJSON5.valueBlackList;
                                                                modelReturnJSON.messageBlackListUser1 = modelReturnJSON5.messageBlackList;

                                                                blackListMode = new BlackListViewModel();
                                                                modelReturnJSON5 = new BlackListViewModel();

                                                                blackListMode.actionUser = "get_by_match_user";
                                                                blackListMode.matchID = modelReturnJSON.matchID;
                                                                blackListMode.userID = modelReturnJSON.userAwayID;

                                                                response = GlobalVariables.WebApiClient.PostAsJsonAsync("BlackList", blackListMode).Result;
                                                                modelReturnJSON5 = response.Content.ReadAsAsync<BlackListViewModel>().Result;

                                                                modelReturnJSON.returnMessage = modelReturnJSON5.returnMessage.Replace("BlackList", "Moderator");

                                                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                                                {
                                                                    modelReturnJSON.blackListIDUser2 = modelReturnJSON5.valueBlackList;
                                                                    modelReturnJSON.messageBlackListUser2 = modelReturnJSON5.messageBlackList;
                                                                }
                                                            }
                                                        }
                                                        else
                                                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();

                                                    }

                                                }

                                            }
                                        }


                                    }

                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";

                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Decretar Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Decretar Resultado. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(TempData["FullModel"]);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Decretar Resultado: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                modelReturnJSON2 = null;
                modelReturnJSON3 = null;
                modelReturnJSON4 = null;
                scorersMatcModel = null;
                championshipModel = null;
                listOfMatchTable = null;
                commentMatchMode = null;
                modelReturnJSON5 = null;
                blackListMode = null;
            }
        }


        // GET: Moderator/LaunchSimpleResult
        [UserModerator]
        public ActionResult LaunchSimpleResult(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            ChampionshipDetailsModel modelReturnJSON3 = new ChampionshipDetailsModel();
            var objFunctions = new Commons.functions();

            string actionForm = formHTML["actionForm"].ToLower();
            string loadScorers = String.Empty;
            string loadGoals = String.Empty;

            setViewBagVariables();
            ViewBag.inLaunchResult = "1";
            ViewBag.inCalculateScore = "1";

            try
            {

                if (actionForm == "save_simple_result")
                {

                    ModeratorMenuMode.matchID = Convert.ToInt32(formHTML["matchID"]);
                    ModeratorMenuMode.championshipID = Convert.ToInt32(formHTML["selectedID"]);

                    ModeratorMenuMode.totalGoalsHome = formHTML["goalsTeamHome"];
                    ModeratorMenuMode.totalGoalsAway = formHTML["goalsTeamAway"];

                    ModeratorMenuMode.userIDAction = Convert.ToUInt16(Session["user.id"].ToString());
                    ModeratorMenuMode.psnIDAction = Session["user.psnID"].ToString();

                    ModeratorMenuMode.actionUser = actionForm;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully" && (ModeratorMenuMode.totalGoalsHome != "0" || ModeratorMenuMode.totalGoalsAway != "0"))
                    {
                        ScorerMatchViewModel scorerMatchModel = new ScorerMatchViewModel();
                        ScorerMatchViewModel modelReturnJSON2 = new ScorerMatchViewModel();

                        scorerMatchModel.matchID = Convert.ToInt32(formHTML["matchID"]);
                        scorerMatchModel.championshipID = Convert.ToInt32(formHTML["selectedID"]);

                        if (formHTML["scorersTeamHome"].Trim() != String.Empty)
                        {
                            objFunctions.sortOutScorersGoalsByMatch(formHTML["scorersTeamHome"], ref loadScorers, ref loadGoals);
                            scorerMatchModel.loadScorersIDHome = loadScorers;
                            scorerMatchModel.loadScorersGoalsHome = loadGoals;
                        }

                        if (formHTML["scorersTeamAway"].Trim() != String.Empty)
                        {
                            objFunctions.sortOutScorersGoalsByMatch(formHTML["scorersTeamAway"], ref loadScorers, ref loadGoals);
                            scorerMatchModel.loadScorersIDAway = loadScorers;
                            scorerMatchModel.loadScorersGoalsAway = loadGoals;
                        }

                        scorerMatchModel.actionUser = "save_all_by_match";

                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("ScorerMatch", scorerMatchModel).Result;
                        modelReturnJSON2 = response.Content.ReadAsAsync<ScorerMatchViewModel>().Result;

                        modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                            TempData["actionSuccessfully"] = "Resultado e Artilharia atualizados com sucesso.";

                        scorerMatchModel = null;
                        modelReturnJSON2 = null;
                    }
                    else if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Resultado atualizado com sucesso.";

                }
                else
                {
                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save_simple_result")
                            {

                                modelReturnJSON3 = GlobalFunctions.ShowChampionshipDetails(formHTML["selectedID"]);
                                modelReturnJSON3.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON3.returnMessage) && modelReturnJSON3.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON3.returnMessage + " - " + actionForm + ". (" + modelReturnJSON3.returnMessage + ")";

                                return View("LaunchResultDetails", modelReturnJSON3);
                            }
                            else
                            {
                                if (actionForm == "show_launch_simple_result_details")
                                {

                                    response = GlobalVariables.WebApiClient.GetAsync("ChampionshipMatchTable/" + (formHTML["selectedID"] + ";" + formHTML["matchID"])).Result;
                                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                                    ScorerViewModel scorersTeamHomeModel = new ScorerViewModel();
                                    ScorerViewModel scorersTeamAwayModel = new ScorerViewModel();
                                    ScorerDetails scorersDetailsModel = new ScorerDetails();
                                    ScorerMatchViewModel scorersMatcModel = new ScorerMatchViewModel();

                                    string pathChampionshipLogo = String.Empty;
                                    string pathTypeLogo = String.Empty;

                                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    {
                                        scorersDetailsModel.actionUser = "getListOfScorerByTeam";
                                        scorersDetailsModel.teamID = modelReturnJSON.teamHomeID;
                                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("Scorer", scorersDetailsModel).Result;
                                        scorersTeamHomeModel = response.Content.ReadAsAsync<ScorerViewModel>().Result;

                                        if (scorersTeamHomeModel.returnMessage == "ModeratorSuccessfully")
                                        {
                                            scorersDetailsModel.actionUser = "getListOfScorerByTeam";
                                            scorersDetailsModel.teamID = modelReturnJSON.teamAwayID;
                                            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Scorer", scorersDetailsModel).Result;
                                            scorersTeamAwayModel = response.Content.ReadAsAsync<ScorerViewModel>().Result;

                                            if (scorersTeamAwayModel.returnMessage == "ModeratorSuccessfully")
                                            {
                                                modelReturnJSON.listOfScorerTeamHome = scorersTeamHomeModel.listOfScorer;
                                                modelReturnJSON.listOfScorerTeamAway = scorersTeamAwayModel.listOfScorer;

                                                response = GlobalVariables.WebApiClient.GetAsync("ScorerMatch/" + (formHTML["selectedID"] + "|" + formHTML["matchID"])).Result;
                                                scorersMatcModel = response.Content.ReadAsAsync<ScorerMatchViewModel>().Result;

                                                modelReturnJSON.returnMessage = scorersMatcModel.returnMessage;

                                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                                {
                                                    if (scorersMatcModel.listOfScorerMatch != null)
                                                        modelReturnJSON.listOfScorerMatch = scorersMatcModel.listOfScorerMatch;
                                                    else
                                                        modelReturnJSON.listOfScorerMatch = new List<ScorerMatchDetails>();
                                                }

                                            }
                                            else
                                                modelReturnJSON.returnMessage = scorersTeamAwayModel.returnMessage;

                                        }
                                        else
                                            modelReturnJSON.returnMessage = scorersTeamHomeModel.returnMessage;

                                        GlobalFunctions.getPathLogoChampionship(modelReturnJSON.championshipName, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                                        modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                                        modelReturnJSON.pathLogoType = pathTypeLogo.Replace("white", "beige");
                                        modelReturnJSON.pathLogoTeamHome = GlobalFunctions.getPathLogoTeam(modelReturnJSON.teamNameHome);
                                        modelReturnJSON.pathLogoTeamAway = GlobalFunctions.getPathLogoTeam(modelReturnJSON.teamNameAway);
                                    }

                                    scorersTeamHomeModel = null;
                                    scorersTeamAwayModel = null;
                                    scorersDetailsModel = null;
                                    scorersMatcModel = null;

                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully") {
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                    modelReturnJSON.listOfScorerTeamHome = new List<ScorerDetails>();
                                    modelReturnJSON.listOfScorerTeamAway = new List<ScorerDetails>();
                                    modelReturnJSON.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                                }

                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            modelReturnJSON.listOfScorerTeamHome = new List<ScorerDetails>();
                            modelReturnJSON.listOfScorerTeamAway = new List<ScorerDetails>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Lançar Simples Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.listOfScorerTeamHome = new List<ScorerDetails>();
                        modelReturnJSON.listOfScorerTeamAway = new List<ScorerDetails>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Lançar Simples Resultado. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfScorerTeamHome = new List<ScorerDetails>();
                modelReturnJSON.listOfScorerTeamAway = new List<ScorerDetails>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Lançar Simples Resultado: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                objFunctions = null;
                modelReturnJSON3 = null;
            }
        }


        // GET: Moderator/GenerateStage
        [UserModerator]
        public ActionResult GenerateStage()
        {

            HttpResponseMessage response = null;
            ChampionshipListViewModel modelReturnJSON = null;
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();

            setViewBagVariables();

            try
            {

                ModeratorMenuMode.actionUser = "getAllActive";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Gerar Fase. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Gerar Fase. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Gerar Fase: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: Moderator/GenerateStageDetails
        [UserModerator]
        public ActionResult GenerateStageDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipStageListViewModel modelReturnJSON = new ChampionshipStageListViewModel();
            ChampionshipStageListViewModel ModeratorMenuMode = new ChampionshipStageListViewModel();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();

            try
            {
                if (actionForm != "edit")
                {
                    modelReturnJSON = (ChampionshipStageListViewModel)TempData["FullModel"];
                }

                if (actionForm == "generate_stage")
                {
                    string previousStageID = formHTML["previousStageID"];
                    string stageID = formHTML["stageID"];
                    string championshipID = formHTML["selectedID"];
                    string startStageDate = formHTML["startStageDate"];

                    if (previousStageID == GlobalVariables.STAGE_TEAM_TABLE)
                    {
                        ModeratorMenuMode.championshipID = Convert.ToInt16(championshipID);
                        ModeratorMenuMode.stageID = Convert.ToInt16(stageID);
                        ModeratorMenuMode.startStageDate = Convert.ToDateTime(startStageDate);
                        ModeratorMenuMode.actionUser = "generate_stage_playoff_stage0";
                    }
                    else if (previousStageID != GlobalVariables.STAGE_QUALIFY1 && previousStageID != GlobalVariables.STAGE_QUALIFY2)
                    {
                        ModeratorMenuMode.championshipID = Convert.ToInt16(championshipID);
                        ModeratorMenuMode.stageID = Convert.ToInt16(stageID);
                        ModeratorMenuMode.previousStageID = Convert.ToInt16(previousStageID);
                        ModeratorMenuMode.startStageDate = Convert.ToDateTime(startStageDate);
                        ModeratorMenuMode.actionUser = "generate_stage_playoff_from_playoff";
                    }
                    else if (previousStageID == GlobalVariables.STAGE_QUALIFY1)
                    {
                        ModeratorMenuMode.championshipID = Convert.ToInt16(championshipID);
                        ModeratorMenuMode.stageID = Convert.ToInt16(stageID);
                        ModeratorMenuMode.startStageDate = Convert.ToDateTime(startStageDate);
                        ModeratorMenuMode.actionUser = "generate_stage_playoff_from_qualify1";
                    }

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipStage", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipStageListViewModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Nova Fase foi gerada com sucesso.";
                }
                else
                {
                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            if (actionForm == "generate_stage")
                            {

                            }

                            response = GlobalVariables.WebApiClient.GetAsync("ChampionshipStage/" + formHTML["selectedID"]).Result;
                            modelReturnJSON = response.Content.ReadAsAsync<ChampionshipStageListViewModel>().Result;

                            string pathChampionshipLogo = String.Empty;
                            string pathTypeLogo = String.Empty;

                            GlobalFunctions.getPathLogoChampionship(formHTML["championshipName"], formHTML["championshipType"], ref pathChampionshipLogo, ref pathTypeLogo);

                            modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                            modelReturnJSON.pathLogoType = pathTypeLogo;
                            modelReturnJSON.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                            modelReturnJSON.championshipName = formHTML["championshipName"];
                            modelReturnJSON.championshipType = formHTML["championshipType"];

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Gerar Fase Details. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Gerar Fase Details. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Gerar Fase Details: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }



        // GET: Moderator/Draw
        [UserModerator]
        public ActionResult Draw(FormCollection formHTML)
        {

            HttpResponseMessage response = null;
            ChampionshipListViewModel modelReturnJSON = null;
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();

            setViewBagVariables();

            try
            {

                ModeratorMenuMode.actionUser = "getAllActive";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Sorteio. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Sorteio. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Sorteio: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: Moderator/DrawDetails
        [UserModerator]
        public ActionResult DrawDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipDetailsModel modelReturnJSON = new ChampionshipDetailsModel();
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();

            UserTeamViewModel modelReturnJSONUserTeam = new UserTeamViewModel();
            UserTeamViewModel ModeratorUserTeam = new UserTeamViewModel();

            ChampionshipListViewModel modelReturnJSONChampionship = new ChampionshipListViewModel();
            SpoolerViewModel modelReturnJSONSpooler = new SpoolerViewModel();
            SpoolerViewModel ModeratorSpooler = new SpoolerViewModel();

            string actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.inLaunchResult = "1";
            ViewBag.inSmartWizardMenu = "1";

            try
            {
                if (actionForm != "show_draw_details" && actionForm != "add_spooler_warning_of_draw")
                    modelReturnJSON = (ChampionshipDetailsModel)TempData["FullModel"];

                if (actionForm == "draw_automatic_user_team")
                {
                    ModeratorUserTeam.actionUser = "draw_automatic_user_team";
                    ModeratorUserTeam.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Draw", ModeratorUserTeam).Result;
                    modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        ViewBag.inDrawTeamsUsersJustHasBeenDone = "1";
                        TempData["actionSuccessfully"] = "O Sorteio Automático de Técnico & Times foi realizado com sucesso.";
                    }
                }
                else if (actionForm == "cancel_draw_user_team")
                {
                    ModeratorUserTeam.actionUser = "cancel_draw_user_team";
                    ModeratorUserTeam.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Draw", ModeratorUserTeam).Result;
                    modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "O Cancelamento do Sorteio de Técnico & Times foi realizado com sucesso.";
                }
                else if (actionForm == "assume_draw_user_team")
                {
                    ModeratorUserTeam.actionUser = "assume_draw_user_team";
                    ModeratorUserTeam.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Draw", ModeratorUserTeam).Result;
                    modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "A Ação de Assumir Técnico & Times das Ligas foi realizado com sucesso.";
                }
                else if (actionForm == "draw_automatic_match_table")
                {
                    ModeratorUserTeam.actionUser = "draw_automatic_match_table";
                    ModeratorUserTeam.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Draw", ModeratorUserTeam).Result;
                    modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;
                    ViewBag.justDidDrawMatchTable = "1";
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "O Sorteio Automático da Tabela de Jogos foi realizado com sucesso.";
                }
                else if (actionForm == "cancel_draw_match_table")
                {
                    ModeratorUserTeam.actionUser = "cancel_draw_match_table";
                    ModeratorUserTeam.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Draw", ModeratorUserTeam).Result;
                    modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;
                    ViewBag.justDidDrawMatchTable = "1";
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "O Cancelamento do Sorteio da Tabela de Jogos foi realizado com sucesso.";
                }
                else if (actionForm == "draw_automatic_group_table")
                {
                    ModeratorUserTeam.actionUser = "draw_automatic_group_table";
                    ModeratorUserTeam.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Draw", ModeratorUserTeam).Result;
                    modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        ViewBag.justDidDrawGroups = "1";
                        ViewBag.inDrawGroupsJustHasBeenDone = "1";
                        TempData["actionSuccessfully"] = "O Sorteio Automático dos Grupos foi realizado com sucesso.";
                    }
                }
                else if (actionForm == "cancel_draw_group_table")
                {
                    ModeratorUserTeam.actionUser = "cancel_draw_group_table";
                    ModeratorUserTeam.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Draw", ModeratorUserTeam).Result;
                    modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;
                    ViewBag.justDidDrawGroups = "1";
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "O Cancelamento do Sorteio dos Grupos foi realizado com sucesso.";
                }
                else if (actionForm == "add_spooler_warning_of_draw")
                {

                    ModeratorSpooler.actionUser = "add_spooler_draw_warning";
                    ModeratorSpooler.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    ModeratorSpooler.descriptionProcess = "Alerta para realização do sorteio: ";
                    ModeratorSpooler.typeProcess = GlobalVariables.SPOOLER_EMAIL_DRAW_WARNING;
                    ModeratorSpooler.userIDResponsible = Convert.ToInt32(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Spooler", ModeratorSpooler).Result;
                    modelReturnJSONSpooler = response.Content.ReadAsAsync<SpoolerViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONSpooler.returnMessage;

                    modelReturnJSONChampionship = (ChampionshipListViewModel)TempData["FullModel"];

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Spooler de Alerta para o Sorteio do Campeonato foi efetuado. Serão enviados " + modelReturnJSONSpooler.totalSentEmails.ToString() + " e-mails para este processo.";
                }
                else if (actionForm == "add_spooler_draw_done")
                {
                    ModeratorSpooler.actionUser = "add_spooler_draw_done";
                    ModeratorSpooler.championshipID = Convert.ToInt16(formHTML["selectedID"]);
                    ModeratorSpooler.descriptionProcess = "Sorteio Realizado: ";
                    ModeratorSpooler.typeProcess = GlobalVariables.SPOOLER_EMAIL_DRAW_DONE;
                    ModeratorSpooler.userIDResponsible = Convert.ToInt32(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("Spooler", ModeratorSpooler).Result;
                    modelReturnJSONSpooler = response.Content.ReadAsAsync<SpoolerViewModel>().Result;
                    modelReturnJSON.returnMessage = modelReturnJSONSpooler.returnMessage;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Spooler de Realização do Sorteio do Campeonato foi efetuado. Serão enviados " + modelReturnJSONSpooler.totalSentEmails.ToString() + " e-mails para este processo.";
                }
                else
                {
                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "add_spooler_warning_of_draw")
                            {
                                return View("Draw", modelReturnJSONChampionship);
                            }
                            else
                            {
                                if (actionForm == "show_draw_details")
                                {
                                    modelReturnJSON = GlobalFunctions.ShowChampionshipDetails(formHTML["selectedID"]);
                                }

                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if ((!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully"))
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                else
                                {
                                    if (actionForm == "draw_automatic_user_team" || actionForm == "cancel_draw_user_team" || actionForm == "assume_draw_user_team" || actionForm == "show_draw_details")
                                    {
                                        response = GlobalVariables.WebApiClient.GetAsync("UserTeam/" + formHTML["selectedID"]).Result;
                                        modelReturnJSONUserTeam = response.Content.ReadAsAsync<UserTeamViewModel>().Result;

                                        modelReturnJSON.returnMessage = modelReturnJSONUserTeam.returnMessage;

                                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                        {
                                            modelReturnJSON.drawDoneUserTeam = modelReturnJSONUserTeam.drawDone;
                                            modelReturnJSON.listOfUserTeam = modelReturnJSONUserTeam.listOfUserTeam;
                                        }
                                    }

                                    if (actionForm == "draw_automatic_match_table" || actionForm == "cancel_draw_match_table" || actionForm == "cancel_draw_group_table" || actionForm == "cancel_draw_user_team")
                                    {
                                        ChampionshipMatchTableViewModel listOfMatchTable = new ChampionshipMatchTableViewModel();

                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipMatchTable/" + formHTML["selectedID"]).Result;
                                        listOfMatchTable = response.Content.ReadAsAsync<ChampionshipMatchTableViewModel>().Result;
                                        modelReturnJSON.listOfMatch = listOfMatchTable.listOfMatch;
                                        modelReturnJSON.drawDoneMatchTable = 0;
                                        modelReturnJSON.returnMessage = listOfMatchTable.returnMessage;
                                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                            if (modelReturnJSON.listOfMatch.Count > 0) { modelReturnJSON.drawDoneMatchTable = 1; }
                                        listOfMatchTable = null;
                                    }

                                     if (actionForm == "draw_automatic_group_table" || actionForm == "cancel_draw_group_table" || actionForm == "cancel_draw_user_team")
                                    {
                                        ChampionshipTeamTableListViewModel listOfTeamTable = new ChampionshipTeamTableListViewModel();

                                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipTeamTable/" + formHTML["selectedID"]).Result;
                                        listOfTeamTable = response.Content.ReadAsAsync<ChampionshipTeamTableListViewModel>().Result;
                                        modelReturnJSON.listOfTeamTable = listOfTeamTable.listOfTeamTable;
                                        modelReturnJSON.returnMessage = listOfTeamTable.returnMessage;

                                        modelReturnJSON.drawDoneTeamTableGroup = 0;
                                        if (modelReturnJSON.listOfTeamTable.Count > 0)
                                        {
                                            if (modelReturnJSON.listOfTeamTable[0].groupID > 0) { modelReturnJSON.drawDoneTeamTableGroup = 1; }
                                        }


                                        listOfTeamTable = null;
                                    }

                                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    {
                                        if (modelReturnJSON.listOfTeamStage0.Count > 0)
                                            modelReturnJSON.totalMatchesPerRound = (modelReturnJSON.listOfTeamStage0.Count / 2);
                                        if (modelReturnJSON.forGroup == false && modelReturnJSON.twoLegs == false && modelReturnJSON.twoTurns == false)
                                            modelReturnJSON.totalMatchesPerRound = (modelReturnJSON.listOfTeam.Count / 2);
                                        else if (modelReturnJSON.forGroup == true)
                                            modelReturnJSON.totalMatchesPerRound = (modelReturnJSON.listOfTeam.Count / 2);
                                    }
                                }
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            //modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Sorteio Automático. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        //modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu Moderador - Sorteio Automático. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfGroup = new List<StandardDetailsModel>();
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.listOfTeamTable = new List<ChampionshipTeamTableDetailsModel>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu Moderador - Sorteio Automático: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                modelReturnJSONUserTeam = null;
                ModeratorUserTeam = null;
                modelReturnJSONSpooler = null;
                ModeratorSpooler = null;
                modelReturnJSONChampionship = null;
            }
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

        private string getBodyHtml(ChampionshipDetailsModel model, string divisionName)
        {

            StringBuilder strBodyHtml = new StringBuilder();

            try
            {

                strBodyHtml.Append("<p style='font-size:24px'><b>ARENA FIFA</b></p>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("<b>Olá " + model.userName1 + " (" + model.psnID1 + "),</b><br><br>");

                if (model.type=="DIV3" || model.type == "DIV4")
                {
                    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Abriu uma vaga para participar da " + model.seasonName + "  do Arena Fifa.</span>");
				    strBodyHtml.Append("<br>");
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Se aceitar você PODRERÁ treinar o time <b>" + model.teamName1 + " (provavelmente) </b>da " + divisionName + " na " + model.seasonName + "  do Arena Fifa nos campeonatos de H2H (X1).</span>");
                    strBodyHtml.Append("<br><br>");
                    strBodyHtml.Append("<span style='font-size:14px;font-family:Verdana;color:red'><b>Todos eles serão disputados com o " + HttpContext.Application["fifa.codImgCurrent"].ToString() + " e no PS4.</b></span>");
                    strBodyHtml.Append("<br><br>");
                    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Existe um técnico a sua frente, o tempo dele responder está se esgotando, portanto se desejar participar, deverá responder este e-mail dentro de 24 horas, caso contrario estaremos disponibilizando sua vaga para outro técnico.</span>");
                }
                else if (model.type == "DIV1" || model.type == "DIV3")
                {
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Abriu uma vaga para participar da " + divisionName + " na " + model.seasonName + "  do Arena Fifa nos campeonatos de H2H (X1).</span>");
				    strBodyHtml.Append("<br>");
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Se aceitar você PODRERÁ treinar o time <b>" + model.teamName1 + " (provavelmente) </b>da " + divisionName + ".</span>");
				    strBodyHtml.Append("<br><br>");
				    strBodyHtml.Append("<span style='font-size:14px;font-family:Verdana;color:red'><b>Todos eles serão disputados com o " + HttpContext.Application["fifa.codImgCurrent"].ToString() + " e no PS4.</b></span>");
				    strBodyHtml.Append("<br><br>");
				    //strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Você está sendo escolhido por ser o primeiro da lista dos técnicos da " & Request("dsTituloTecnico") & " que NÃO está pontuado negativamente na Lista Negra, portanto se desejar participar, responde este e-mail dentro de 24 horas caso contrário estaremos disponibilizando sua vaga para o técnico seguinte.</span>");
                    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Existe um técnico a sua frente, o tempo dele responder está se esgotando, portanto se desejar participar, deverá responder este e-mail dentro de 24 horas, caso contrario estaremos disponibilizando sua vaga para outro técnico.</span>");
                }
                else if (model.type == "FUT1")
                {
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Abriu uma vaga para participar da " + divisionName + " na " + model.seasonName + "  do Arena Fifa nos campeonatos de FUT (Ultimate Team).</span>");
				    strBodyHtml.Append("<br>");
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Se aceitar você irá treinar o seu mesmo time que já vem jogando: <b>" + model.teamName1 + " </b>.</span>");
				    strBodyHtml.Append("<br><br>");
				    strBodyHtml.Append("<span style='font-size:14px;font-family:Verdana;color:red'><b>Todos eles serão disputados com o " + HttpContext.Application["fifa.codImgCurrent"].ToString() + " e no PS4.</b></span>");
				    strBodyHtml.Append("<br><br>");
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Existe um técnico a sua frente, o tempo dele responder está se esgotando, portanto se desejar participar, deverá responder este e-mail dentro de 24 horas, caso contrário estaremos disponibilizando sua vaga para outro técnico.</span>");
                }
                else if (model.type == "FUT2")
                {
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Abriu uma vaga para participar da " + divisionName + " na " + model.seasonName + "  do Arena Fifa nos campeonatos de FUT (Ultimate Team).</span>");
				    strBodyHtml.Append("<br>");
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Se aceitar você irá treinar o time que fez a inscrição: <b>" + model.teamName1 +  " </b>.</span>");
				    strBodyHtml.Append("<br><br>");
				    strBodyHtml.Append("<span style='font-size:14px;font-family:Verdana;color:red'><b>Todos eles serão disputados com o " + HttpContext.Application["fifa.codImgCurrent"].ToString() + " e no PS4.</b></span>");
				    strBodyHtml.Append("<br><br>");
				    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Existe um técnico a sua frente, o tempo dele responder está se esgotando, portanto se desejar participar, deverá responder este e-mail dentro de 24 horas, caso contrário estaremos disponibilizando sua vaga para outro técnico.</span>");
                }

                strBodyHtml.Append("<br><br><br>");
			    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Atenciosamente,</span>");
			    strBodyHtml.Append("<br>");
			    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'><b>Moderação ARENA FIFA</b></span>");
			    strBodyHtml.Append("<br>");
			    strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Nosso Site: <a style='color:blue' href='http://www.arenafifa.com.br/'>http://www.arenafifa.com.br/</a></span>");
			    strBodyHtml.Append("<br>");
			    strBodyHtml.Append("</span>");

                return strBodyHtml.ToString();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                strBodyHtml = null;
            }

        }

        private string getBodyHtmlSwapManager(ChampionshipDetailsModel model)
        {

            StringBuilder strBodyHtml = new StringBuilder();

            try
            {

                strBodyHtml.Append("<span style='PADDING-RIGHT: 0px;PADDING-LEFT: 0px;FONT-SIZE: 11px;PADDING-BOTTOM: 0px;MARGIN: 0px;COLOR: #333333;PADDING-TOP: 0px;BACKGROUND-REPEAT: repeat-x;FONT-FAMILY: Arial, Helvetica, sans-serif;TEXT-ALIGN: left'>");
                strBodyHtml.Append("<p style='font-size:24px'><b>ARENA FIFA</b></p>");
                strBodyHtml.Append("<br>");
                if (model.type.Substring(0,3) == "DIV")
                    strBodyHtml.Append("Parabéns " + model.userName1 + " <b>(" + model.psnID1 + ")</b>, você estará participando da temporada como o novo técnico do <b>" + model.teamName1 + "</b>.<br><br>");
                else if (model.type.Substring(0, 3) == "FUT")
                    strBodyHtml.Append("Parabéns " + model.userName1 + " <b>(" + model.psnID1 + ")</b>, você estará participando da temporada com o <b>" + model.teamName1 + "</b>.<br><br>");
                else if (model.type.Substring(0, 3) == "PRO")
                    strBodyHtml.Append("Parabéns " + model.userName1 + " <b>(" + model.psnID1 + ")</b>, você estará participando da temporada como manager do <b>" + model.teamName1 + "</b>.<br><br>");

                    if (model.type == "DIV4")
                {
                    strBodyHtml.Append("Irá disputar a Série D do H2H (X1).  Também poderá competir na Liga Europa e na Copa UEFA se ainda o <b>" + model.teamName1  + "</ b> estiver ativo nas competições.<br><br>");
                    strBodyHtml.Append("Boa sorte e seja bem vindo ao site.<br><br>");
                }
                else if (model.type == "DIV3")
                {
                    strBodyHtml.Append("Irá disputar a Série C do H2H (X1).  Também poderá competir na Liga Europa e na Copa UEFA se ainda o <b>" + model.teamName1 + "</ b> estiver ativo nas competições.<br><br>");
                    strBodyHtml.Append("Boa sorte e seja bem vindo ao site.<br><br>");
                }
                else if (model.type == "DIV2")
                {
                    strBodyHtml.Append("Irá disputar a Série B do H2H (X1).  Também poderá competir na Liga dos Campeões e na Copa UEFA se ainda o <b>" + model.teamName1 + "</ b> estiver ativo nas competições.<br><br>");
                    strBodyHtml.Append("Boa sorte em seu novo desafio.<br><br>");
                }
                else if (model.type == "DIV1")
                {
                    strBodyHtml.Append("Irá disputar a Série A do H2H (X1).  Também poderá competir na Liga dos Campeões e na Copa UEFA se ainda o <b>" + model.teamName1 + "</ b> estiver ativo nas competições.<br><br>");
                    strBodyHtml.Append("Boa sorte em seu novo desafio.<br><br>");
                }
                else if (model.type == "FUT1")
                {
                    strBodyHtml.Append("Irá disputar a Série A do FUT (Ultimate Team).  Também poderá competir na Copa FUT (se o time ainda estiver ativo na competição) com o time <b>" + model.teamName1 + "</ b>.<br><br>");
                    strBodyHtml.Append("Seja bem vindo e boa sorte para seu time neste desafio.<br><br>");
                }
                else if (model.type == "PRO1")
                {
                    strBodyHtml.Append("Irá disputar a Série A do PRO CLUB.  Também poderá competir na Copa PRO CLUB (se o clube ainda estiver ativo na competição) com o clube <b>" + model.teamName1 + "</ b>.<br><br>");
                    strBodyHtml.Append("Seja bem vindo e boa sorte para seu clube neste desafio.<br><br>");
                }

                strBodyHtml.Append("<br><br><br>");
                strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Atenciosamente,</span>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'><b>Moderação ARENA FIFA</b></span>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Nosso Site: <a style='color:blue' href='http://www.arenafifa.com.br/'>http://www.arenafifa.com.br/</a></span>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("</span>");

                return strBodyHtml.ToString();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                strBodyHtml = null;
            }

        }

        private string getBodyHtmlSwapManagerPRO(ChampionshipDetailsModel model)
        {

            StringBuilder strBodyHtml = new StringBuilder();

            try
            {

                strBodyHtml.Append("<span style='PADDING-RIGHT: 0px;PADDING-LEFT: 0px;FONT-SIZE: 11px;PADDING-BOTTOM: 0px;MARGIN: 0px;COLOR: #333333;PADDING-TOP: 0px;BACKGROUND-REPEAT: repeat-x;FONT-FAMILY: Arial, Helvetica, sans-serif;TEXT-ALIGN: left'>");
                strBodyHtml.Append("<p style='font-size:24px'><b>ARENA FIFA</b></p>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("Parabéns " + model.userName1 + " <b>(" + model.psnID1 + ")</b>, você será o NOVO manager do club <b>" + model.teamName1 + "</b> no site do ARENA e participará da Série Ae a Copa PRO CLUB (se o clube ainda estiver ativo na competição).<br><br>");
                strBodyHtml.Append("Boa sorte para seu clube neste seu desafio.<br><br>");

                strBodyHtml.Append("<br><br><br>");
                strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Atenciosamente,</span>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'><b>Moderação ARENA FIFA</b></span>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("<span style='font-size:12px;font-family:Verdana;color:black'>Nosso Site: <a style='color:blue' href='http://www.arenafifa.com.br/'>http://www.arenafifa.com.br/</a></span>");
                strBodyHtml.Append("<br>");
                strBodyHtml.Append("</span>");

                return strBodyHtml.ToString();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                strBodyHtml = null;
            }

        }


    }
}