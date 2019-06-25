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
    public class CurrentSeasonController : Controller
    {

        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inModeratorCurrentSeason = "1";
            ViewBag.inModeratorMenu = "1";
            ViewBag.inLaunchResult = "0";

        }

        private void setViewBagVariablesMyMatches()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inModeratorMyMatches = "1";
            ViewBag.inModeratorMenu = "1";
            if (Session["user.teamNameH2H"].ToString() == String.Empty)
                ViewBag.inMyMatchesMenuH2H = "0";
            else
                ViewBag.inMyMatchesMenuH2H = "1";

            if (Session["user.teamNameFUT"].ToString() == String.Empty)
                ViewBag.inMyMatchesMenuFUT = "0";
            else
                ViewBag.inMyMatchesMenuFUT = "1";

            if (Session["user.teamNamePRO"].ToString() == String.Empty)
                ViewBag.inMyMatchesMenuPRO = "0";
            else
                ViewBag.inMyMatchesMenuPRO = "1";
            ViewBag.inLaunchResult = "0";
        }

        // GET: CurrentSeason/CommentMatch
        [SessionTimeout]
        [ValidateInput(false)]
        public ActionResult CommentMatch(FormCollection formHTML)
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
            string championshipID = String.Empty;
            string matchID = String.Empty;
            if (formHTML["actionForm"]==null)
                actionForm = "show_championshipmatchtable_details";
            else
                actionForm = formHTML["actionForm"].ToLower();

            if (formHTML["sourceForm"] != null)
                sourceForm = formHTML["sourceForm"];

            if (sourceForm == String.Empty)
                setViewBagVariables();
            else
                setViewBagVariablesMyMatches();

            if (formHTML["selectedID"] != null)
                championshipID = formHTML["selectedID"];

            if (formHTML["matchID"] != null)
                matchID = formHTML["matchID"];

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
                            else
                            {
                                if (actionForm == "show_championshipmatchtable_details")
                                {
                                    ViewBag.inScorerDetails = "1";

                                    modelReturnJSON = GlobalFunctions.getDetailsViewChampionshipMatch(championshipID, matchID);
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
                commentMatchMode = null;
            }
        }





    }
}