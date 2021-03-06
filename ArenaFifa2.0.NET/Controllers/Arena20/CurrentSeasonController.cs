﻿using ArenaFifa20.NET.Models;
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
    public class CurrentSeasonController : Controller
    {

        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inCurrentSeason = "1";
            ViewBag.inModeratorMenu = "1";
            ViewBag.inLaunchResult = "0";
            ViewBag.inLineUpPlayOffGames = "0";
            ViewBag.inMyPaginateMatches = "0";
            ViewBag.inCurrentSeasonName = String.Empty;
            ViewBag.inCurrentChampionshipNameName = String.Empty;
            ViewBag.inCurrentChampionshipForGroup = String.Empty;
            ViewBag.inCurrentSeasonType = String.Empty;
            ViewBag.listOfActiveChampionship = new List<ChampionshipDetailsModel>();
            ViewBag.listOfActiveOtherModeType = new List<OtherModeTypeOfCurrentSeason>();
            ViewBag.inUserHasTeamFUT = String.Empty;
            ViewBag.inUserHasTeamPRO = String.Empty;
            ViewBag.psnIDLogged = String.Empty;
            ViewBag.inCalculateHistoryMatches = "0";
        }

        private void setViewBagVariablesList(CurrentSeasonMenuViewModel modelReturnJSON)
        {
            List<OtherModeTypeOfCurrentSeason> ListOfOthetMenuMode = new List<OtherModeTypeOfCurrentSeason>();
            OtherModeTypeOfCurrentSeason OthetMenuMode = new OtherModeTypeOfCurrentSeason();

            string[] modesType = { "H2H", "FUT", "PRO" };

            try
            {
                ViewBag.inCurrentSeasonType = modelReturnJSON.modeType;
                ViewBag.inCurrentSeasonName = modelReturnJSON.currentSeasonName +
                                              " " + ViewBag.inCurrentSeasonType;
                ViewBag.inCurrentChampionshipNameName = modelReturnJSON.currentChampionshipName;
                ViewBag.inCurrentChampionshipForGroup = modelReturnJSON.currentChampionshipForGroup.ToString();
                ViewBag.listOfActiveChampionship = modelReturnJSON.listOActiveChampionship;
                ViewBag.inUserHasTeamFUT = modelReturnJSON.userHasTeamFUT.ToString();
                ViewBag.inUserHasTeamPRO = modelReturnJSON.userHasTeamPRO.ToString();

                for (int i = 0; i<modesType.Length;i++)
                {
                    if (modesType[i] != modelReturnJSON.modeType)
                    {
                        OthetMenuMode = new OtherModeTypeOfCurrentSeason();
                        OthetMenuMode.modeType = modesType[i];
                        OthetMenuMode.name = modelReturnJSON.currentSeasonName + " " + modesType[i];
                        OthetMenuMode.url = "/CurrentSeason/Summary";
                        ListOfOthetMenuMode.Add(OthetMenuMode);
                    }
                }
                ViewBag.listOfActiveOtherModeType = ListOfOthetMenuMode;

            }
            catch
            {

            }
            finally
            {
                ListOfOthetMenuMode = null;
                OthetMenuMode = null;
            }


        }

        private string getPathAvatar(string psnID)
        {
            string dsAvatar = "/images/member-avatar/";
            switch (psnID.ToLower())
            {
                case "airesdias":
                    return dsAvatar + "aires.png";
                case "nvscst":
                    return dsAvatar + "fernando.png";
                case "fonseca_rj":
                    return dsAvatar + "fonfon.png";
                case "juniorverde":
                    return dsAvatar + "junior.png";
                case "ibra_bimonti":
                    return dsAvatar + "bimonti.png";
                case "santossfelipe93":
                    return dsAvatar + "felipe.png";
                case "hugosiqueira94":
                    return dsAvatar + "hugo.png";
                case "rick_simoes":
                    return dsAvatar + "ricardo.png";
                case "saydsangelll":
                    return dsAvatar + "sayds.png";
                default:
                    return dsAvatar + "avatar.jpg";
            }
        }

        // GET: CurrentSeason/Summary
        [SessionTimeout]
        public ActionResult Summary(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            CurrentSeasonSummaryViewModel modelReturnJSON = new CurrentSeasonSummaryViewModel();
            CurrentSeasonSummaryViewModel ModeratorMenuMode = new CurrentSeasonSummaryViewModel();
            string modeType = "H2H";

            setViewBagVariables();

            if (formHTML["currentModeTypeSeason"] != null)
                modeType = formHTML["currentModeTypeSeason"].ToUpper();

            try
            {
                if (Session["user.current.season.menu"]==null)
                {
                    ModeratorMenuMode.actionUser = "summary";
                    ModeratorMenuMode.modeType = modeType;
                    ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("CurrentSeason", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<CurrentSeasonSummaryViewModel>().Result;
                }
                else
                {
                    modelReturnJSON = (CurrentSeasonSummaryViewModel)Session["user.current.season.summary"];
                    if (modeType != modelReturnJSON.modeType)
                    {
                        ModeratorMenuMode.actionUser = "summary";
                        ModeratorMenuMode.modeType = modeType;
                        ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("CurrentSeason", ModeratorMenuMode).Result;
                        modelReturnJSON = response.Content.ReadAsAsync<CurrentSeasonSummaryViewModel>().Result;
                        Session["user.current.season.menu"] = null;
                        Session["user.current.season.summary"] = null;
                    }
                    modelReturnJSON.returnMessage = "CurrentSeasonSuccessfully";
                    response.StatusCode = HttpStatusCode.Created;
                }


                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            if (Session["user.current.season.menu"] == null)
                            {
                                modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.pathAvatar1 = getPathAvatar(modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.psnID1);
                                modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.pathAvatar2 = getPathAvatar(modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.psnID2);
                                Session["user.current.season.menu"] = modelReturnJSON.menuCurrentSeason;
                                Session["user.current.season.summary"] = modelReturnJSON;
                            }

                            setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da Current Season - " + modeType + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(ModeratorMenuMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da Current Season - " + modeType + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(ModeratorMenuMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Current Season - " + modeType + ": (" + ex.InnerException.Message + ")";
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

        // GET: CurrentSeason/ClashTable
        [SessionTimeout]
        public ActionResult ClashTable(FormCollection formHTML)
        {

            ChampionshipDetailsModel modelReturnJSON = new ChampionshipDetailsModel();
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();
            CurrentSeasonSummaryViewModel summaryModel = new CurrentSeasonSummaryViewModel();
            HttpResponseMessage response = new HttpResponseMessage();
            CurrentSeasonSummaryViewModel ModeratorMenuMode2 = new CurrentSeasonSummaryViewModel();

            string actionForm = "show_championship_details";

            if (formHTML["actionForm"] != null)
                actionForm = formHTML["actionForm"].ToLower();
            if (actionForm=="voltar_current_season") { actionForm = "show_championship_details"; }
            setViewBagVariables();
            ViewBag.inLaunchResult = "1";
            ViewBag.inMyPaginateMatches = "1";

            try
            {

                summaryModel = (CurrentSeasonSummaryViewModel)Session["user.current.season.summary"];
                setViewBagVariablesList(summaryModel.menuCurrentSeason);

                modelReturnJSON.listOfStage = new List<StandardDetailsModel>();
                modelReturnJSON.listOfGroup = new List<StandardDetailsModel>();
                modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                modelReturnJSON.listOfTeamTable = new List<ChampionshipTeamTableDetailsModel>();
                modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();

                if (actionForm == "show_championship_details")
                {
                    modelReturnJSON = GlobalFunctions.ShowChampionshipDetails(summaryModel.menuCurrentSeason.currentChampionshipID.ToString(), 
                                                                              summaryModel.menuCurrentSeason.currentChampionshipDetails, true,
                                                                               Convert.ToInt32(Session["user.id"].ToString()));
                }
                else if (actionForm == "swap_of_championship")
                {
                    //ModeratorMenuMode2.menuCurrentSeason = summaryModel.menuCurrentSeason;
                    ModeratorMenuMode2.actionUser = "summary_update_team";
                    ModeratorMenuMode2.modeType = summaryModel.modeType;
                    ModeratorMenuMode2.championshipID = Convert.ToInt16(formHTML["championshipID"]);
                    ModeratorMenuMode2.userID = Convert.ToInt16(Session["user.id"].ToString());
                    //ModeratorMenuMode2.menuCurrentSeason.currentChampionshipDetails = summaryModel.menuCurrentSeason.currentChampionshipDetails;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("CurrentSeason", ModeratorMenuMode2).Result;
                    ModeratorMenuMode2 = response.Content.ReadAsAsync<CurrentSeasonSummaryViewModel>().Result;

                    modelReturnJSON = GlobalFunctions.ShowChampionshipDetails(formHTML["championshipID"], null, true,
                                                                               Convert.ToInt32(Session["user.id"].ToString()));

                    modelReturnJSON.menuCurrentSeason = ModeratorMenuMode2.menuCurrentSeason;

                    modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.pathAvatar1 = getPathAvatar(modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.psnID1);
                    modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.pathAvatar2 = getPathAvatar(modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.psnID2);
                    Session["user.current.season.menu"] = modelReturnJSON.menuCurrentSeason;
                    Session["user.current.season.summary"] = ModeratorMenuMode2;

                    setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);
                }
                else if (actionForm == "swap_group_id_selected")
                {
                    modelReturnJSON = (ChampionshipDetailsModel)TempData["FullModel"];
                    modelReturnJSON.groupIDSelected = Convert.ToInt16(formHTML["cmbGroup"]);
                }

                modelReturnJSON.actionUser = actionForm.ToUpper();
                modelReturnJSON.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];

                if ((!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully"))
                {
                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                    return View(modelReturnJSON);
                }
                else if (modelReturnJSON.drawDoneMatchTable == 0)
                {
                    ViewBag.inLaunchResult = "0";
                    ViewBag.inMyPaginateMatches = "0";
                    TempData["returnMessage"] = "A Funcionalidade não está disponível. O Sorteio, deste campeonato, ainda não foi gerado.";
                    return View("Summary", summaryModel);
                }
                else
                {
                    if (modelReturnJSON.forGroup == true && modelReturnJSON.groupIDSelected == 0)
                    {
                        modelReturnJSON.groupIDSelected = GlobalFunctions.getGroupIDUserLogged(modelReturnJSON.listOfTeamTable,
                                                                                                Convert.ToInt32(Session["user.id"].ToString()));
                    }
                    else if (modelReturnJSON.forGroup == false)
                        modelReturnJSON.groupIDSelected = 0;

                    return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Current Season - Clash Table: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                summaryModel = null;
                ModeratorMenuMode2 = null;
                response = null;
            }
        }

        // GET: CurrentSeason/CommentMatchCurrent
        [SessionTimeout]
        [ValidateInput(false)]
        public ActionResult CommentMatchCurrent(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipCommentMatchListViewModel modelReturnJSON2 = new ChampionshipCommentMatchListViewModel();
            ChampionshipCommentMatchUsersListViewModel modelReturnJSON3 = new ChampionshipCommentMatchUsersListViewModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            ChampionshipCommentMatchDetailsModel commentMatchMode = new ChampionshipCommentMatchDetailsModel();
            ChampionshipCommentMatchDetailsModel modelReturnJSON4 = new ChampionshipCommentMatchDetailsModel();

            string actionForm = String.Empty;
            string sourceForm = String.Empty;
            string championshipID = "0";
            string matchID = "0";

            if (formHTML["actionForm"]==null)
                actionForm = "show_championshipmatchtable_details";
            else
                actionForm = formHTML["actionForm"].ToLower();

            if (formHTML["sourceForm"] != null)
                sourceForm = formHTML["sourceForm"];

            if (formHTML["selectedID"] != null)
                championshipID = formHTML["selectedID"];

            if (formHTML["matchID"] != null)
                matchID = formHTML["matchID"];

            setViewBagVariables();
            ViewBag.inLaunchResult = "1";
            ViewBag.inScorerDetails = "1";
            ViewBag.inCalculateHistoryMatches = "1";

            try
            {
                setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);

                if (actionForm.IndexOf("save_comment") > -1)
                {
                    commentMatchMode.matchID = Convert.ToInt32(matchID);
                    commentMatchMode.comment = Server.HtmlDecode(formHTML["txtComment"]);
                    commentMatchMode.actionUser = "save_comment";
                    commentMatchMode.userID = Convert.ToUInt16(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentMatch", commentMatchMode).Result;
                    modelReturnJSON4 = response.Content.ReadAsAsync<ChampionshipCommentMatchDetailsModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON4.returnMessage;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                        GlobalFunctions.SendEmailCommentAllUsersByGame(modelReturnJSON, commentMatchMode.comment, matchID);

                        TempData["actionSuccessfully"] = "Comentário efetuado com sucesso";
                    }
                }
                else if (actionForm.IndexOf("save_user_comment") > -1)
                {
                    commentMatchMode.matchID = Convert.ToInt32(matchID);
                    commentMatchMode.championshipID = Convert.ToInt16(championshipID);
                    commentMatchMode.actionUser = actionForm.Replace("_current_season", String.Empty);
                    commentMatchMode.userID = Convert.ToInt32(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentUsers", commentMatchMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Ação efetuada com sucesso. Você agora estará recebendo os comentários desta partida";
                }
                else if (actionForm.IndexOf("cancel_user_comment") > -1)
                {
                    commentMatchMode.matchID = Convert.ToInt32(matchID);
                    commentMatchMode.championshipID = Convert.ToInt16(championshipID);
                    commentMatchMode.actionUser = actionForm.Replace("_current_season", String.Empty);
                    commentMatchMode.userID = Convert.ToInt32(Session["user.id"].ToString());

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentUsers", commentMatchMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        TempData["actionSuccessfully"] = "Ação efetuada com sucesso. Você NÃO receberá mais os comentários desta partida";
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
                            if (actionForm.IndexOf("save_comment") > -1)
                            {
                                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentMatch/" + matchID).Result;
                                modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipCommentMatchListViewModel>().Result;

                                modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                {
                                    modelReturnJSON.listOfCommentMatch = modelReturnJSON2.listOfCommentMatch;

                                }
                                return View(modelReturnJSON);
                            }
                            else if (actionForm.IndexOf("save_user_comment") > -1 || actionForm.IndexOf("cancel_user_comment") > -1)
                            {
                                modelReturnJSON = (ChampionshipMatchTableDetailsModel)TempData["FullModel"];

                                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentUsers/" + matchID).Result;
                                modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipCommentMatchUsersListViewModel>().Result;

                                modelReturnJSON.returnMessage = modelReturnJSON3.returnMessage;

                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    modelReturnJSON.listOfUsersCommentMatch = modelReturnJSON3.listOfUsersCommentMatch;

                                return View(modelReturnJSON);
                            }
                            else
                            {
                                if (actionForm == "show_championshipmatchtable_details")
                                {
                                    modelReturnJSON = GlobalFunctions.getDetailsViewChampionshipMatch(championshipID, matchID);

                                    GlobalFunctions.getHistoryClashesTeamAndCoach(ref modelReturnJSON);
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                modelReturnJSON.sourceForm = "ClashTable";
                                return View(modelReturnJSON);
                            }
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição Current Season - Informar Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição Current Season - Informar Resultado. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(TempData["FullModel"]);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Current Season - Informar Resultado: (" + ex.InnerException.Message + ")";
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
                commentMatchMode = null;
            }
        }



        // POST: MyMatches/LaunchSimpleResultCurrent
        [SessionTimeout]
        [HttpPost]
        public ActionResult LaunchSimpleResultCurrent(FormCollection formHTML)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipDetailsModel modelReturnJSON2 = new ChampionshipDetailsModel();
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();
            CurrentSeasonSummaryViewModel summaryModel = new CurrentSeasonSummaryViewModel();

            string actionForm = String.Empty;
            string sourceForm = String.Empty;
            string championshipID = "0";
            string matchID = "0";
            string returnMessage = String.Empty;


            if (formHTML["actionForm"] == null)
                actionForm = "show_launch_simple_result_details_current_season";
            else
                actionForm = formHTML["actionForm"].ToLower();

            if (formHTML["sourceForm"] != null)
                sourceForm = formHTML["sourceForm"];

            if (formHTML["selectedID"] != null)
                championshipID = formHTML["selectedID"];

            if (formHTML["matchID"] != null)
                matchID = formHTML["matchID"];

            try
            {
                setViewBagVariables();
                ViewBag.inLaunchResult = "1";

                setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);

                if (actionForm == "save_simple_result")
                {
                    modelReturnJSON = GlobalFunctions.getDetailsLaunchResult(actionForm, Session["user.id"].ToString(), championshipID,
                                                                             matchID, formHTML["goalsTeamHome"], formHTML["goalsTeamAway"],
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
                                ViewBag.inMyPaginateMatches = "1";

                                summaryModel = (CurrentSeasonSummaryViewModel)Session["user.current.season.summary"];
                                setViewBagVariablesList(summaryModel.menuCurrentSeason);

                                modelReturnJSON2.listOfStage = new List<StandardDetailsModel>();
                                modelReturnJSON2.listOfGroup = new List<StandardDetailsModel>();
                                modelReturnJSON2.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                                modelReturnJSON2.listOfTeamTable = new List<ChampionshipTeamTableDetailsModel>();
                                modelReturnJSON2.listOfChampionship = new List<ChampionshipDetailsModel>();

                                modelReturnJSON2 = GlobalFunctions.ShowChampionshipDetails(summaryModel.menuCurrentSeason.currentChampionshipID.ToString(),
                                                                                            summaryModel.menuCurrentSeason.currentChampionshipDetails, true,
                                                                                            Convert.ToInt32(Session["user.id"].ToString()), true);

                                modelReturnJSON2.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];

                                modelReturnJSON.actionUser = actionForm.ToUpper();

                                if ((!String.IsNullOrEmpty(modelReturnJSON2.returnMessage) && modelReturnJSON2.returnMessage != "ModeratorSuccessfully"))
                                {
                                    TempData["returnMessage"] = modelReturnJSON2.returnMessage + " - " + actionForm + ". (" + modelReturnJSON2.returnMessage + ")";
                                    return View(modelReturnJSON2);
                                }
                                else
                                {
                                    if (modelReturnJSON2.forGroup == true && modelReturnJSON2.groupIDSelected == 0)
                                    {
                                        modelReturnJSON2.groupIDSelected = GlobalFunctions.getGroupIDUserLogged(modelReturnJSON2.listOfTeamTable,
                                                                                                                Convert.ToInt32(Session["user.id"].ToString()));
                                    }
                                    else if (modelReturnJSON2.forGroup == false)
                                        modelReturnJSON2.groupIDSelected = 0;

                                    return View("ClashTable", modelReturnJSON2);
                                }
                            }
                            else
                            {
                                ViewBag.inCalculateScore = "1";
                                modelReturnJSON = GlobalFunctions.getDetailsLaunchResult(actionForm, Session["user.id"].ToString(), championshipID,
                                                                                            matchID, formHTML["goalsTeamHome"], formHTML["goalsTeamAway"],
                                                                                            formHTML["scorersTeamHome"], formHTML["scorersTeamAway"], Session["user.psnID"].ToString(),
                                                                                            null, out returnMessage);
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                                modelReturnJSON.sourceForm = "ClashTable";
                                if (!String.IsNullOrEmpty(modelReturnJSON.returnMessage) && modelReturnJSON.returnMessage != "ModeratorSuccessfully")
                                {
                                    TempData["returnMessage"] = modelReturnJSON.returnMessage + " - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                                    modelReturnJSON.listOfScorerTeamHome = new List<ScorerDetails>();
                                    modelReturnJSON.listOfScorerTeamAway = new List<ScorerDetails>();
                                    modelReturnJSON.championshipID = Convert.ToInt16(championshipID);
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
                summaryModel = null;
            }
        }



        // POST: CurrentSeason/UploadLogo
        [SessionTimeout]
        [HttpPost]
        public ActionResult UploadLogo(FormCollection formHTML)
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
                setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);

                HttpPostedFileBase file = Request.Files[0];
                if (file == null)
                    TempData["returnMessage"] = "ATENÇÃO " + userTypeNameResponsible + ": Ação NÃO efetuada. Nenhuma imagem foi enviada";
                else
                {
                    string defaultPath = ConfigurationManager.AppSettings["team.path.image"].ToString();
                    string currentPathImage = defaultPath + "/" + formHTML["clubLogoName"] + ".jpg";

                    GlobalFunctions.saveFileUploadLogo(file, formHTML["clubLogoName"], Server.MapPath(currentPathImage),
                                                       Server.MapPath(defaultPath));


                    TempData["actionSuccessfully"] = "A logo do seu clube foi alterada com sucesso";
                }
                modelReturnJSON.sourceForm = "CurrentSeason";
                return View(viewNameReturn, modelReturnJSON);

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "PRO";
                modelReturnJSON.sourceForm = "CurrentSeason";
                TempData["returnMessage"] = "Erro interno - Exibindo Current Season - Upload Logo Team: (" + ex.Message + ")";
                return View(viewNameReturn, modelReturnJSON);

            }
            finally
            {
                modelReturnJSON = null;
            }
        }

        // GET: CurrentSeason/UploadLogoTeamPRO
        [SessionTimeout]
        public ActionResult UploadLogoTeamPRO(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();
            string actionForm = String.Empty;
            string returnMessage = String.Empty;
            if (!String.IsNullOrEmpty(formHTML["actionForm"]))
                actionForm = formHTML["actionForm"].ToLower();

            try
            {
                setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);

                if (actionForm == "update-mobile-manager")
                {
                    modelReturnJSON = GlobalFunctions.updateMobileManagerPRO("updateMobileManagerPRO", Convert.ToInt32(formHTML["selectedID"]),
                                                                             formHTML["mobileNumber"], (MyNextMatchesViewModel)TempData["FullModel"],
                                                                             out returnMessage);
                    if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        TempData["actionSuccessfully"] = returnMessage;

                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }
                else if (actionForm == "add-player")
                {
                    modelReturnJSON = GlobalFunctions.maintenanceSquadPRO("spAddPlayerSquadPro", Convert.ToInt32(formHTML["clubID"]), formHTML["txtPsn"],
                                                                          0, Convert.ToInt32(Session["user.id"].ToString()),
                                                                          (MyNextMatchesViewModel)TempData["FullModel"], out returnMessage);
                    TempData["returnMessage"] = string.Empty;
                    TempData["actionSuccessfully"] = string.Empty;
                    if (returnMessage.IndexOf("ATENÇÃO MANAGER") == -1)
                    {
                        TempData["actionSuccessfully"] = returnMessage;
                        modelReturnJSON.psnIDForm = String.Empty;
                    }
                    else
                        TempData["returnMessage"] = returnMessage;

                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }
                else if (actionForm == "delete-player")
                {
                    modelReturnJSON = GlobalFunctions.maintenanceSquadPRO("spDeletePlayerSquadPro", 0, formHTML["txtPsn"],
                                                                          Convert.ToInt32(formHTML["playerID"]), Convert.ToInt32(Session["user.id"].ToString()),
                                                                          (MyNextMatchesViewModel)TempData["FullModel"], out returnMessage);
                    TempData["returnMessage"] = string.Empty;
                    TempData["actionSuccessfully"] = string.Empty;
                    if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        TempData["actionSuccessfully"] = returnMessage;
                    else
                        TempData["returnMessage"] = returnMessage;

                    modelReturnJSON.psnIDForm = String.Empty;
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
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
                            modelReturnJSON.sourceForm = "CurrentSeason";
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "PRO";
                            modelReturnJSON.sourceForm = "CurrentSeason";
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Upload Logo Team PRO. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.typeMode = "PRO";
                        modelReturnJSON.sourceForm = "CurrentSeason";
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Upload Logo Team PRO. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "PRO";
                modelReturnJSON.sourceForm = "CurrentSeason";
                TempData["returnMessage"] = "Erro interno - Exibindo Menu da tela Current Season - Upload Logo Team PRO: (" + ex.Message + ")";
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

        // GET: CurrentSeason/UploadLogoTeamFUT
        [SessionTimeout]
        public ActionResult UploadLogoTeamFUT()
        {

            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();

            setViewBagVariables();

            try
            {
                setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);

                ModeratorMenuMode.actionUser = "uploadLogoTeamFUTDetails";
                ModeratorMenuMode.userID = Convert.ToInt32(Session["user.id"].ToString());
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                        {
                            modelReturnJSON.sourceForm = "CurrentSeason";
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            modelReturnJSON.typeMode = "FUT";
                            modelReturnJSON.sourceForm = "CurrentSeason";
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Upload Logo Team FUT. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        modelReturnJSON.typeMode = "FUT";
                        modelReturnJSON.sourceForm = "CurrentSeason";
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Upload Logo Team FUT. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                modelReturnJSON.typeMode = "FUT";
                modelReturnJSON.sourceForm = "CurrentSeason";
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Upload Logo Team FUT: (" + ex.Message + ")";
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


        // GET: CurrentSeason/Scorer
        [SessionTimeout]
        public ActionResult Scorer()
        {

            HttpResponseMessage response = null;
            CurrentSeasonSummaryViewModel modelReturnJSON = new CurrentSeasonSummaryViewModel();
            CurrentSeasonSummaryViewModel modelReturnJSON2 = new CurrentSeasonSummaryViewModel();
            ScorerDetails ModeratorMenuMode = new ScorerDetails();

            setViewBagVariables();

            try
            {
                modelReturnJSON.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                setViewBagVariablesList(modelReturnJSON.menuCurrentSeason);

                ModeratorMenuMode.actionUser = "getListOfScorerByChampionship";
                ModeratorMenuMode.id = modelReturnJSON.menuCurrentSeason.currentChampionshipID;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Scorer", ModeratorMenuMode).Result;
                modelReturnJSON2 = response.Content.ReadAsAsync<CurrentSeasonSummaryViewModel>().Result;
                modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            modelReturnJSON.listOfScorers = modelReturnJSON2.listOfScorers;
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - List Of Scorers. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - List Of Scorers. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - List Of Scorers: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: CurrentSeason/Moderator
        [SessionTimeout]
        public ActionResult Moderator()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            CurrentSeasonSummaryViewModel modelReturnJSON = new CurrentSeasonSummaryViewModel();

            setViewBagVariables();

            try
            {
                modelReturnJSON.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                setViewBagVariablesList(modelReturnJSON.menuCurrentSeason);

                modelReturnJSON.returnMessage = "CurrentSeasonSuccessfully";
                response.StatusCode = HttpStatusCode.Created;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Moderator. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Moderator. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Moderator: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }

        // GET: CurrentSeason/Group
        [SessionTimeout]
        public ActionResult Group()
        {
            HttpResponseMessage response = null;
            CurrentSeasonSummaryViewModel modelReturnJSON = new CurrentSeasonSummaryViewModel();
            ChampionshipGroupListViewModel modelReturnJSON2 = new ChampionshipGroupListViewModel();
            ChampionshipTeamTableListViewModel modelReturnJSON3 = new ChampionshipTeamTableListViewModel();

            setViewBagVariables();

            try
            {
                modelReturnJSON.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                setViewBagVariablesList(modelReturnJSON.menuCurrentSeason);

                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipGroup/" + modelReturnJSON.menuCurrentSeason.currentChampionshipID.ToString()).Result;
                modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipGroupListViewModel>().Result;

                modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                {
                    modelReturnJSON.listOfGroup = modelReturnJSON2.listOfGroup;

                    response = GlobalVariables.WebApiClient.GetAsync("ChampionshipTeamTable/" + modelReturnJSON.menuCurrentSeason.currentChampionshipID.ToString()).Result;
                    modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipTeamTableListViewModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON3.returnMessage;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        modelReturnJSON.returnMessage = "CurrentSeasonSuccessfully";
                        modelReturnJSON.listOfTeamTable = modelReturnJSON3.listOfTeamTable;
                    }

                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            ViewBag.psnIDLogged = Session["user.psnID"].ToString();
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Group. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Group. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Group: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                modelReturnJSON3 = null;
            }
        }


        // GET: CurrentSeason/TeamCoach
        [SessionTimeout]
        public ActionResult TeamCoach()
        {
            HttpResponseMessage response = null;
            CurrentSeasonSummaryViewModel modelReturnJSON = new CurrentSeasonSummaryViewModel();
            ChampionshipTeamListViewModel modelReturnJSON2 = new ChampionshipTeamListViewModel();

            setViewBagVariables();

            try
            {
                modelReturnJSON.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                setViewBagVariablesList(modelReturnJSON.menuCurrentSeason);

                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipTeam/" + modelReturnJSON.menuCurrentSeason.currentChampionshipID.ToString()).Result;
                modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipTeamListViewModel>().Result;

                modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                {
                    modelReturnJSON.listOfTeam = modelReturnJSON2.listOfTeam;
                    modelReturnJSON.returnMessage = "CurrentSeasonSuccessfully";
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Team & Coach. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Team & Coach. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Team & Coach: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
            }
        }


        // GET: CurrentSeason/Regulation
        [SessionTimeout]
        public ActionResult Regulation()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            CurrentSeasonSummaryViewModel modelReturnJSON = new CurrentSeasonSummaryViewModel();

            setViewBagVariables();

            try
            {
                modelReturnJSON.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                setViewBagVariablesList(modelReturnJSON.menuCurrentSeason);

                modelReturnJSON.returnMessage = "CurrentSeasonSuccessfully";
                response.StatusCode = HttpStatusCode.Created;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Regulation. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Regulation. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Regulation: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }


        // GET: CurrentSeason/ForecastPlayoffGame
        [SessionTimeout]
        public ActionResult ForecastPlayoffGame()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            CurrentSeasonSummaryViewModel modelReturnJSON = new CurrentSeasonSummaryViewModel();
            CurrentSeasonSummaryViewModel modelReturnJSON2 = new CurrentSeasonSummaryViewModel();
            CurrentSeasonSummaryViewModel ModeratorMenuMode = new CurrentSeasonSummaryViewModel();

            setViewBagVariables();

            try
            {
                setViewBagVariablesList((CurrentSeasonMenuViewModel)Session["user.current.season.menu"]);
                modelReturnJSON.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];


                ModeratorMenuMode.actionUser = "getAllForecastSecondStage";
                ModeratorMenuMode.championshipID = modelReturnJSON.menuCurrentSeason.currentChampionshipID;
                ModeratorMenuMode.totalGroupPerChampionship = modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.totalGroup;
                ModeratorMenuMode.totalQualifiedPerGroup = modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.totalQualify;
                ModeratorMenuMode.placeQualifiedPerGroup = modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.sourcePlaceFromChampionshipSource;
                ModeratorMenuMode.anotherChampionshipID = modelReturnJSON.menuCurrentSeason.currentChampionshipDetails.ChampionshipIDSource;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("CurrentSeason", ModeratorMenuMode).Result;
                modelReturnJSON2 = response.Content.ReadAsAsync<CurrentSeasonSummaryViewModel>().Result;
                modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            modelReturnJSON.listOfForecastTeamQualified = modelReturnJSON2.listOfForecastTeamQualified;
                            modelReturnJSON.listOfForecastTeamQualifiedThirdPlace = modelReturnJSON2.listOfForecastTeamQualifiedThirdPlace;
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Forecast Playoff Game. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Forecast Playoff Game. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Forecast Playoff Game: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                ModeratorMenuMode = null;
            }
        }


        // GET: CurrentSeason/ClashesHistory
        [SessionTimeout]
        public ActionResult ClashesHistory(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableClashesHistoryTotalswModel modelReturnJSON = new ChampionshipMatchTableClashesHistoryTotalswModel();
            ChampionshipMatchTableClashesHistoryTotalswModel modelReturnJSON2 = new ChampionshipMatchTableClashesHistoryTotalswModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            CurrentSeasonMenuViewModel menuCurrentModel = new CurrentSeasonMenuViewModel();

            setViewBagVariables();

            string actionForm = String.Empty;
            if (formHTML["actionForm"] != null)
                actionForm = formHTML["actionForm"].ToUpper();

            try
            {
                ViewBag.inCalculateHistoryMatches = "1";
                menuCurrentModel = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                modelReturnJSON2.menuCurrentSeason = menuCurrentModel;
                setViewBagVariablesList(menuCurrentModel);

                if (actionForm != "SEARCH_HISTORY")
                {
                    modelReturnJSON.actionUser = "VIEW";
                    modelReturnJSON.menuCurrentSeason = modelReturnJSON2.menuCurrentSeason;
                    modelReturnJSON.listOfMatchDraw = new List<ChampionshipMatchTableDetailsModel>();
                    modelReturnJSON.listOfMatchWinUsuLogged = new List<ChampionshipMatchTableDetailsModel>();
                    modelReturnJSON.listOfMatchWinUsuSearch = new List<ChampionshipMatchTableDetailsModel>();
                }
                else
                {
                    ModeratorMenuMode.actionUser = "clashes_historic_by_coaches";
                    ModeratorMenuMode.userIDAction = Convert.ToUInt16(Session["user.id"].ToString());
                    ModeratorMenuMode.psnIDAction = Session["user.psnID"].ToString();
                    ModeratorMenuMode.psnIDSearch = formHTML["txtPsnID"];
                    ModeratorMenuMode.modeType = menuCurrentModel.modeType;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableClashesHistoryTotalswModel>().Result;

                    modelReturnJSON.actionUser = "VIEW";

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        modelReturnJSON.actionUser = actionForm.ToUpper();
                    else
                    {
                        modelReturnJSON.listOfMatchDraw = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.listOfMatchWinUsuLogged = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.listOfMatchWinUsuSearch = new List<ChampionshipMatchTableDetailsModel>();

                        if (modelReturnJSON.returnMessage == "ErrorExecuteProcedure")
                            TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Clashes History: (Erro na frecuperação do histórico de confrontos)";
                        else if (modelReturnJSON.returnMessage == "PsnIDSearchNotFound")
                            TempData["returnMessage"] = "Erro na pesquisa do histórico: PSN Informada não foi encontrada";
                    }
                    modelReturnJSON.menuCurrentSeason = menuCurrentModel;
                }
                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                modelReturnJSON2.actionUser = "VIEW";
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Clashes History: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON2);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                modelReturnJSON2 = null;
            }
        }

        // GET: CurrentSeason/Calendar
        [SessionTimeout]
        public ActionResult Calendar(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipCalendarListViewModel modelReturnJSON = new ChampionshipCalendarListViewModel();
            ChampionshipCalendarListViewModel modelReturnJSON2 = new ChampionshipCalendarListViewModel();
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();

            string actionType = String.Empty;

            setViewBagVariables();

            try
            {
                modelReturnJSON2.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                setViewBagVariablesList(modelReturnJSON2.menuCurrentSeason);
                actionType = modelReturnJSON2.menuCurrentSeason.modeType;
                ModeratorMenuMode.actionUser = "calendarAllActiveByType";
                ModeratorMenuMode.modeType = actionType;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipCalendarListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            modelReturnJSON.menuCurrentSeason = modelReturnJSON2.menuCurrentSeason;
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Calendar - " + actionType + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON2);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Calendar - " + actionType + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON2);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Calendar - " + actionType + ": (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON2);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                ModeratorMenuMode = null;
            }
        }

        // GET: CurrentSeason/LineUpOfPlayoffGames
        [SessionTimeout]
        public ActionResult LineUpOfPlayoffGames()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipLineUpListViewModel modelReturnJSON = new ChampionshipLineUpListViewModel();
            ChampionshipLineUpListViewModel modelReturnJSON2 = new ChampionshipLineUpListViewModel();
            ChampionshipDetailsModel ModeratorMenuMode = new ChampionshipDetailsModel();

            setViewBagVariables();
            ViewBag.inLineUpPlayOffGames = "1";

            try
            {
                modelReturnJSON2.menuCurrentSeason = (CurrentSeasonMenuViewModel)Session["user.current.season.menu"];
                modelReturnJSON2.listOfStage2 = new List<ChampionshipLineUpDetailsModel>();
                modelReturnJSON2.listOfRound16 = new List<ChampionshipLineUpDetailsModel>();
                modelReturnJSON2.listOfQuarter = new List<ChampionshipLineUpDetailsModel>();
                modelReturnJSON2.listOfSemi = new List<ChampionshipLineUpDetailsModel>();
                modelReturnJSON2.listOfGrandFinal = new List<ChampionshipLineUpDetailsModel>();
                setViewBagVariablesList(modelReturnJSON2.menuCurrentSeason);

                ModeratorMenuMode.actionUser = "lineUpByID";
                ModeratorMenuMode.id = modelReturnJSON2.menuCurrentSeason.currentChampionshipID;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Championship", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipLineUpListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "CurrentSeasonSuccessfully")
                        {
                            modelReturnJSON.menuCurrentSeason = modelReturnJSON2.menuCurrentSeason;
                            modelReturnJSON.stageIDStage2 = Convert.ToInt16(GlobalVariables.STAGE_SECOND_STAGE);
                            modelReturnJSON.stageIDRound16 = Convert.ToInt16(GlobalVariables.STAGE_ROUND_16);
                            modelReturnJSON.stageIDQuarter = Convert.ToInt16(GlobalVariables.STAGE_QUARTER_FINAL);
                            modelReturnJSON.stageIDSemi = Convert.ToInt16(GlobalVariables.STAGE_SEMI_FINAL);
                            modelReturnJSON.stageIDFinal = Convert.ToInt16(GlobalVariables.STAGE_FINAL);
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Line Up Playoff Games. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON2);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição da tela Current Season - Line Up Playoff Games. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON2);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo tela Current Season - Line Up Playoff Games: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON2);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                ModeratorMenuMode = null;
            }
        }

    }
}