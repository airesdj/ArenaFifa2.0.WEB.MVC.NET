using ArenaFifa20.NET.Models;
using SYSEmail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static ArenaFifa20.NET.App_Start.CheckSessionTimeOut;

namespace ArenaFifa20.NET.Controllers
{
    public class MyMatchesController : Controller
    {

        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inModeratorMyMatches = "1";
            ViewBag.inModeratorMenu = "1";
            if (Session["user.teamNameH2H"].ToString()==String.Empty)
                ViewBag.inMyMatchesMenuH2H = "0";
            else
                ViewBag.inMyMatchesMenuH2H = "1";

            if (Session["user.teamNameFUT"].ToString()==String.Empty)
                ViewBag.inMyMatchesMenuFUT = "0";
            else
                ViewBag.inMyMatchesMenuFUT = "1";

            if (Session["user.teamNamePRO"].ToString() == String.Empty)
                ViewBag.inMyMatchesMenuPRO = "0";
            else
                ViewBag.inMyMatchesMenuPRO = "1";
            ViewBag.inLaunchResult = "0";
            ViewBag.inScorerDetails = "0";
            ViewBag.inCalculateScore = "0";
        }

        // GET: MyMatches/Summary
        [SessionTimeout]
        public ActionResult Summary()
        {

            HttpResponseMessage response = null;
            MyMatchesSummaryViewModel modelReturnJSON = new MyMatchesSummaryViewModel();
            MyMatchesSummaryViewModel ModeratorMenuMode = new MyMatchesSummaryViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "summary";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyMatchesSummaryViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            Session["user.teamNameH2H"] = modelReturnJSON.teamNameH2H;
                            Session["user.teamNameFUT"] = modelReturnJSON.teamNameFUT;
                            Session["user.teamNamePRO"] = modelReturnJSON.teamNamePRO;

                            setViewBagVariables();

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.listOfScorersH2H = new List<listScorers>();
                            modelReturnJSON.listOfScorersPRO = new List<listScorers>();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos. (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.listOfScorersH2H = new List<listScorers>();
                        modelReturnJSON.listOfScorersPRO = new List<listScorers>();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos: (" + ex.InnerException.Message + ")";
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


        // GET: MyMatches/NextMatchH2H
        [SessionTimeout]
        public ActionResult NextMatchH2H()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myNextMatchesH2H";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("NextMatch", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "H2H";
                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Próximos Jogos H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View("NextMatch", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "H2H";
                        modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Próximos Jogos H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("NextMatch", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "H2H";
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Próximos Jogos H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("NextMatch", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: MyMatches/MatchPlayedH2H
        [SessionTimeout]
        public ActionResult MatchPlayedH2H()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myMatchesDoneH2H";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("MatchPlayed", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "H2H";
                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Jogos Realizados H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View("MatchPlayed", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "H2H";
                        modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Jogos Realizados H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("MatchPlayed", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "H2H";
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Jogos Realizados H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("MatchPlayed", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: MyMatches/ScorerH2H
        [SessionTimeout]
        public ActionResult ScorerH2H()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myListOfScorersH2H";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("Scorer", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "H2H";
                            modelReturnJSON.listOfScorers = new List<listScorers>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Lista de Artilheiros H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View("Scorer", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "H2H";
                        modelReturnJSON.listOfScorers = new List<listScorers>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Lista de Artilheiros H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("Scorer", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "H2H";
                modelReturnJSON.listOfScorers = new List<listScorers>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Lista de Artilheiros H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("Scorer", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: MyMatches/NextMatchFUT
        [SessionTimeout]
        public ActionResult NextMatchFUT()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myNextMatchesFUT";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("NextMatch", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "FUT";
                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Próximos Jogos FUT. (" + modelReturnJSON.returnMessage + ")";
                            return View("NextMatch", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "FUT";
                        modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Próximos Jogos FUT. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("NextMatch", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "FUT";
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Próximos Jogos FUT: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("NextMatch", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }

        // GET: MyMatches/MatchPlayedFUT
        [SessionTimeout]
        public ActionResult MatchPlayedFUT()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myMatchesDoneFUT";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("MatchPlayed", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "FUT";
                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Jogos Realizados FUT. (" + modelReturnJSON.returnMessage + ")";
                            return View("MatchPlayed", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "FUT";
                        modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Jogos Realizados FUT. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("MatchPlayed", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "FUT";
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Jogos Realizados FUT: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("MatchPlayed", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: MyMatches/UploadLogoTeamFUT
        [SessionTimeout]
        public ActionResult UploadLogoTeamFUT()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "uploadLogoTeamFUTDetails";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "FUT";
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Upload Logo Team FUT. (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "FUT";
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Upload Logo Team FUT. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "FUT";
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Upload Logo Team FUT: (" + ex.InnerException.Message + ")";
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


        // GET: MyMatches/NextMatchPRO
        [SessionTimeout]
        public ActionResult NextMatchPRO()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myNextMatchesPRO";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("NextMatch", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "PRO";
                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Próximos Jogos PRO. (" + modelReturnJSON.returnMessage + ")";
                            return View("NextMatch", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "PRO";
                        modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Próximos Jogos PRO. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("NextMatch", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "PRO";
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Próximos Jogos PRO: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("NextMatch", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }

        // GET: MyMatches/MatchPlayedPRO
        [SessionTimeout]
        public ActionResult MatchPlayedPRO()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myMatchesDonePRO";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("MatchPlayed", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "PRO";
                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Jogos Realizados PRO. (" + modelReturnJSON.returnMessage + ")";
                            return View("MatchPlayed", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "PRO";
                        modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Jogos Realizados PRO. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("MatchPlayed", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "PRO";
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Jogos Realizados PRO: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("MatchPlayed", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }

        // GET: MyMatches/ScorerPRO
        [SessionTimeout]
        public ActionResult ScorerPRO()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                ModeratorMenuMode.actionUser = "myListOfScorersPRO";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View("Scorer", modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "PRO";
                            modelReturnJSON.listOfScorers = new List<listScorers>();
                            modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Lista de Artilheiros PRO. (" + modelReturnJSON.returnMessage + ")";
                            return View("Scorer", ModeratorMenuMode);
                        }
                    default:
                        modelReturnJSON.typeMode = "PRO";
                        modelReturnJSON.listOfScorers = new List<listScorers>();
                        modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Lista de Artilheiros PRO. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("Scorer", ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "PRO";
                modelReturnJSON.listOfScorers = new List<listScorers>();
                modelReturnJSON.totalsMyMatches = new MyMatchesTotalModel();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Lista de Artilheiros PRO: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("Scorer", ModeratorMenuMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }

        // GET: MyMatches/UploadLogoTeamPRO
        [SessionTimeout]
        public ActionResult UploadLogoTeamPRO(FormCollection formHTML)
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();
            MyMatchesSummaryViewModel modelReturnJSON2 = new MyMatchesSummaryViewModel();
            MyMatchesSummaryViewModel ModeratorMenuMode2 = new MyMatchesSummaryViewModel();
            List<squadListModel> listOfSquad = new List<squadListModel>();

            setViewBagVariables();
            string actionForm = String.Empty;
            string returnMessage = String.Empty;
            if (!String.IsNullOrEmpty(formHTML["actionForm"]))
                actionForm = formHTML["actionForm"].ToLower();

            try
            {
                if (actionForm=="update-mobile-manager")
                {
                    ModeratorMenuMode.actionUser = "updateMobileManagerPRO";
                    ModeratorMenuMode.userID = Convert.ToInt32(formHTML["selectedID"]);
                    ModeratorMenuMode.codeMobileNumber = GlobalFunctions.stripCodeMobileFullNumber(formHTML["mobileNumber"]);
                    ModeratorMenuMode.mobileNumber = GlobalFunctions.stripNumberMobileFullNumber(formHTML["mobileNumber"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;
                    returnMessage = modelReturnJSON.returnMessage;
                    if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        TempData["actionSuccessfully"] = "Os dados do Celular do Manager foram alterados com sucesso";

                    modelReturnJSON = (MyNextMatchesViewModel)TempData["FullModel"];
                    modelReturnJSON.returnMessage = returnMessage;
                    modelReturnJSON.codeMobileNumber = ModeratorMenuMode.codeMobileNumber;
                    modelReturnJSON.mobileNumber = ModeratorMenuMode.mobileNumber;
                }
                else if (actionForm == "add-player")
                {
                    ModeratorMenuMode2.actionUser = "spAddPlayerSquadPro";
                    ModeratorMenuMode2.teamID = Convert.ToInt32(formHTML["clubID"]);
                    ModeratorMenuMode2.psnID = formHTML["txtPsn"];
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode2).Result;
                    modelReturnJSON2 = response.Content.ReadAsAsync<MyMatchesSummaryViewModel>().Result;
                    TempData["returnMessage"] = string.Empty;
                    if (modelReturnJSON2.returnMessage == "MyMatchesSuccessfully")
                        TempData["actionSuccessfully"] = "O jogador foi adicionado com sucesso em seu elenco";
                    else if(modelReturnJSON2.returnMessage == "PsnNotFound")
                        TempData["returnMessage"] = "ATENÇÃO MANAGER: Ação NÃO efetuada. PSN informada (" + ModeratorMenuMode2.psnID + ") não foi encontrada";
                    else if (modelReturnJSON2.returnMessage == "PlayerIsInYourClub")
                        TempData["returnMessage"] = "ATENÇÃO MANAGER: Ação NÃO efetuada. O Jogador já ESTÁ no seu elenco";
                    else if (modelReturnJSON2.returnMessage == "PlayerIsInAnotherClub")
                        TempData["returnMessage"] = "ATENÇÃO MANAGER: Ação NÃO efetuada. O Jogador já se encontra em OUTRO elenco";

                    ModeratorMenuMode.actionUser = "uploadLogoTeamPROListOfSquad";
                    ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                    listOfSquad = modelReturnJSON.listOfSquad;

                    modelReturnJSON = (MyNextMatchesViewModel)TempData["FullModel"];
                    modelReturnJSON.returnMessage = "MyMatchesSuccessfully";
                    modelReturnJSON.listOfSquad = listOfSquad;
                    if (modelReturnJSON2.returnMessage != "MyMatchesSuccessfully")
                    {
                        modelReturnJSON.psnIDForm = formHTML["txtPsn"];
                        if (("PsnNotFound,'PlayerIsInYourClub',PlayerIsInAnotherClub").IndexOf(modelReturnJSON2.returnMessage) == -1)
                            modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;
                    }
                }
                else if (actionForm == "delete-player")
                {
                    ModeratorMenuMode.actionUser = "spDeletePlayerSquadPro";
                    ModeratorMenuMode.userID = Convert.ToInt32(formHTML["playerID"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                    modelReturnJSON2 = response.Content.ReadAsAsync<MyMatchesSummaryViewModel>().Result;

                    ModeratorMenuMode.actionUser = "uploadLogoTeamPROListOfSquad";
                    ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                    listOfSquad = modelReturnJSON.listOfSquad;

                    modelReturnJSON = (MyNextMatchesViewModel)TempData["FullModel"];
                    modelReturnJSON.returnMessage = "MyMatchesSuccessfully";
                    modelReturnJSON.listOfSquad = listOfSquad;
                    TempData["actionSuccessfully"] = "O jogador foi excluído com sucesso do seu elenco";
                }
                else
                {
                    ModeratorMenuMode.actionUser = "uploadLogoTeamPRODetails";
                    ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;
                }
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "PRO";
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Upload Logo Team PRO. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.typeMode = "PRO";
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Menu de Meus Jogos - Upload Logo Team PRO. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "PRO";
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Upload Logo Team PRO: (" + ex.InnerException.Message + ")";
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
                listOfSquad = null;
            }
        }


        // POST: MyMatches/UploadLogo
        [SessionTimeout]
        [HttpPost]
        public ActionResult UploadLogo(FormCollection formHTML, HttpPostedFileBase fileForm)
        {

            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();

            setViewBagVariables();
            string viewNameReturn = "UploadLogoTeamPRO";
            string userTypeNameResponsible = "MANAGER";
            modelReturnJSON = (MyNextMatchesViewModel)TempData["FullModel"];
            modelReturnJSON.returnMessage = "MyMatchesSuccessfully";
            if (formHTML["actionForm"] == "UPLOAD-LOGO-FUT") { viewNameReturn = "UploadLogoTeamFUT"; userTypeNameResponsible = "TÉCNICO"; }
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file == null)
                    TempData["returnMessage"] = "ATENÇÃO " + userTypeNameResponsible + ": Ação NÃO efetuada. Nenhuma imagem foi enviada";
                else
                {
                    string defaultPath = ConfigurationManager.AppSettings["team.path.image"].ToString();
                    string currentPathImage = defaultPath + "/" + formHTML["clubLogoName"] + ".jpg";

                    if (System.IO.File.Exists(Server.MapPath(currentPathImage.Replace(formHTML["clubLogoName"], formHTML["clubLogoName"] + "-old"))))
                        System.IO.File.Delete(Server.MapPath(currentPathImage).Replace(formHTML["clubLogoName"], formHTML["clubLogoName"] + "-old"));

                    if (System.IO.File.Exists(Server.MapPath(currentPathImage)))
                    {
                        System.IO.File.Copy(Server.MapPath(currentPathImage), Server.MapPath(currentPathImage.Replace(formHTML["clubLogoName"], formHTML["clubLogoName"] + "-old")));
                        System.IO.File.Delete(Server.MapPath(currentPathImage));
                    }

                    string pic = System.IO.Path.GetFileName(formHTML["clubLogoName"] + ".jpg");
                    string path = System.IO.Path.Combine(Server.MapPath(defaultPath), pic);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Copy(path, path.Replace(file.FileName.Split(Convert.ToChar("."))[0], file.FileName.Split(Convert.ToChar("."))[0] + "-old"));
                        System.IO.File.Delete(path);
                    }
                    file.SaveAs(path);
                    TempData["actionSuccessfully"] = "A logo do seu clube foi alterada com sucesso";
                }
                return View(viewNameReturn, modelReturnJSON);

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "PRO";
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Upload Logo Team PRO: (" + ex.Message + ")";
                return View(viewNameReturn, modelReturnJSON);

            }
            finally
            {
                modelReturnJSON = null;
            }
        }



        // POST: MyMatches/CommentMatchCurrent
        [SessionTimeout]
        [HttpPost]
        public ActionResult CommentMatchCurrent(FormCollection formHTML)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();

            try
            {
                string championshipID = formHTML["selectedID"];
                string matchID = formHTML["matchID"];
                string sourceForm = formHTML["sourceForm"];
                string actionForm = formHTML["actionForm"].ToLower();

                setViewBagVariables();
                ViewBag.inLaunchResult = "1";
                ViewBag.inScorerDetails = "1";

                if (actionForm == "save_comment")
                {
                    modelReturnJSON = GlobalFunctions.getDetailsCommentMatch(actionForm, Server.HtmlDecode(formHTML["txtComment"]), Session["user.id"].ToString(),
                                                                             championshipID, matchID, (ChampionshipMatchTableDetailsModel)TempData["FullModel"]);

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        TempData["actionSuccessfully"] = "Comentário efetuado com sucesso";
                    }
                    response.StatusCode = HttpStatusCode.Created;
                }
                else if (actionForm == "save_user_comment_my_matches")
                {
                    modelReturnJSON = GlobalFunctions.getDetailsCommentMatch(actionForm, String.Empty, Session["user.id"].ToString(),
                                                                             championshipID, matchID, (ChampionshipMatchTableDetailsModel)TempData["FullModel"]);
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Ação efetuada com sucesso. Você agora estará recebendo os comentários desta partida";
                    response.StatusCode = HttpStatusCode.Created;
                }
                else if (actionForm == "cancel_user_comment_my_matches")
                {
                    modelReturnJSON = GlobalFunctions.getDetailsCommentMatch(actionForm, String.Empty, Session["user.id"].ToString(),
                                                                             championshipID, matchID, (ChampionshipMatchTableDetailsModel)TempData["FullModel"]);
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Ação efetuada com sucesso. Você NÃO receberá mais os comentários desta partida";
                    response.StatusCode = HttpStatusCode.Created;
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

                            if (actionForm == "save_comment" || actionForm == "save_user_comment_my_matches" || actionForm == "cancel_user_comment_my_matches")
                            {
                                modelReturnJSON.sourceForm = sourceForm;
                                return View(modelReturnJSON);
                            }
                            else
                            {
                                if (actionForm == "show_championshipmatchtable_details")
                                {
                                    modelReturnJSON = GlobalFunctions.getDetailsViewChampionshipMatch(championshipID, matchID);
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";

                                modelReturnJSON.sourceForm = sourceForm;
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Meus Jogos - Comentar Partida. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Meus Jogos - Comentar Partida. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(TempData["FullModel"]);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Comentar Partida: (" + ex.Message + ")";
                return View(modelReturnJSON);

            }
            finally
            {
                modelReturnJSON = null;
                response = null;
            }
        }


        // POST: MyMatches/LaunchSimpleResultCurrent
        [SessionTimeout]
        [HttpPost]
        public ActionResult LaunchSimpleResultCurrent(FormCollection formHTML)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            MyNextMatchesViewModel modelReturnJSON2 = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            try
            {
                string sourceForm = formHTML["sourceForm"];
                string actionForm = formHTML["actionForm"].ToLower();
                string returnMessage = String.Empty;

                setViewBagVariables();
                ViewBag.inLaunchResult = "1";

                if (actionForm == "save_simple_result")
                {
                    modelReturnJSON = GlobalFunctions.getDetailsLaunchResult(actionForm, Session["user.id"].ToString(), formHTML["selectedID"],
                                                                             formHTML["matchID"], formHTML["goalsTeamHome"], formHTML["goalsTeamAway"],
                                                                             formHTML["scorersTeamHome"], formHTML["scorersTeamAway"], Session["user.psnID"].ToString(),
                                                                             (ChampionshipMatchTableDetailsModel)TempData["FullModel"], out returnMessage);

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully" && returnMessage != String.Empty)
                        TempData["actionSuccessfully"] = returnMessage;
                    response.StatusCode = HttpStatusCode.Created;
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
                                ModeratorMenuMode.actionUser = "my" + sourceForm.Replace("Match", "Matches");
                                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                                modelReturnJSON2 = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                                modelReturnJSON2.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON2.returnMessage) && modelReturnJSON2.returnMessage != "MyMatchesSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON2.returnMessage + " - " + actionForm + ". (" + modelReturnJSON2.returnMessage + ")";

                                return View("NextMatch", modelReturnJSON2);
                            }
                            else
                            {
                                ViewBag.inCalculateScore = "1";
                                modelReturnJSON = GlobalFunctions.getDetailsLaunchResult(actionForm, Session["user.id"].ToString(), formHTML["selectedID"],
                                                                                            formHTML["matchID"], formHTML["goalsTeamHome"], formHTML["goalsTeamAway"],
                                                                                            formHTML["scorersTeamHome"], formHTML["scorersTeamAway"], Session["user.psnID"].ToString(),
                                                                                            null, out returnMessage);
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                modelReturnJSON.sourceForm = sourceForm;
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                {
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
                            modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Meus Jogos - Lançar Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Meus Jogos - Lançar Resultado. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(TempData["FullModel"]);
                }
            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfScorerTeamHome = new List<ScorerDetails>();
                modelReturnJSON.listOfScorerTeamAway = new List<ScorerDetails>();
                TempData["returnMessage"] = "Erro interno - Exibindo Menu de Meus Jogos - Lançar Resultado: (" + ex.Message + ")";
                return View(modelReturnJSON);

            }
            finally
            {
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                ModeratorMenuMode = null;
                response = null;
            }
        }


    }
}