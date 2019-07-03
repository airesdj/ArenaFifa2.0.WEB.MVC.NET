using ArenaFifa20.NET.Models;
using SYSEmail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ArenaFifa20.NET
{
    public static class GlobalFunctions
    {

        public static string getBodyHtmlSendComment(ChampionshipMatchTableDetailsModel model, string comment, string dsMatch)
        {

            StringBuilder strBodyHtml = new StringBuilder();
            string dsLinkIdMatch = "acao=JogoComent&parametros=" + model.championshipID.ToString() + "|" + model.matchID.ToString() +
                                  "|" + model.userIDAction.ToString() + "|050559055-094-5-4-0545-429548249843453454";
            try
            {

                strBodyHtml.Append("<span style='padding-right: 0px;padding-left: 0px;font-size: 11px;padding-bottom: 0px;margin: 0px;color: #333333;padding-top: 0px;background-repeat: repeat-x;font-family: arial, helvetica, sans-serif;text-align: left;'>");
                strBodyHtml.Append("<table cellspacing='0' cellpadding='10' border='0'>");
                strBodyHtml.Append("<tr><td width='10px' valign='top'></td><td width='595px' valign='top' style='color:black;white-space:nowrap'>Comente:  <a style='font-size:10px;font-family:Verdana;color:blue;' href='http://www.arenafifa.com.br?" + dsLinkIdMatch + "' target='_blank'>" + dsMatch + "</a></td><tr>");

                strBodyHtml.Append("<tr><td width='10px' valign='top'></td><td width='595px' valign='top' style='color:black'><b>&nbsp;" + HttpContext.Current.Session["user.psnID"].ToString() + " - " + HttpContext.Current.Session["user.currentTeam"].ToString() + "</b>   " + DateTime.Now.ToString("dd-MM") + " às " + DateTime.Now.ToString("HH.mm.ss") + "<br>");

                strBodyHtml.Append("<fieldset style='padding-left:10px;padding-right:10px;text-align:left;border:1px solid;background-color:#fffff;font-size:11px;color:black;font-family:Arial;font-weight:normal'>");

                strBodyHtml.Append("<p style='text-aign:Justify;font-weight:normal'>" + comment.Replace("/", "-").Replace(":", "."));
                strBodyHtml.Append("</p></fieldset></td><tr>");

                strBodyHtml.Append("<tr><td width='10px' valign='top'></td><td width='595px' valign='top' style='font-size:9px;font-family:Verdana;color:black;'>Esta mensagem foi dirigida a voce, pois voce pediu para ser notificado sobre novos comentarios.</td><tr>");
                strBodyHtml.Append("</table>");
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

        public static IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
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

        public static string getPathLogoTeam(string teamName)
        {
            string realPathTeamLogo = String.Empty;


            string logoPath = ConfigurationManager.AppSettings["team.path.image"].ToString() + "/" + teamName + ".jpg";

            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(logoPath)))
            { realPathTeamLogo = logoPath; }
            else { realPathTeamLogo = ConfigurationManager.AppSettings["team.path.image.default"].ToString(); }


            return realPathTeamLogo;
        }

        internal static void getPathLogoChampionship(string championshipName, string modeType, ref string realPathChampionshipLogo, ref string realPathModeLogo)
        {
            string logoPath = ConfigurationManager.AppSettings["championship.path.image"].ToString() + "/" + championshipName.Replace(" ", "_") + ".jpg";
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(logoPath)))
            { realPathChampionshipLogo = logoPath; }
            else { realPathChampionshipLogo = String.Empty; }

            logoPath = "/images/logo-" + getChampionshipModeType(modeType) + "-white.jpg";
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(logoPath)))
            { realPathModeLogo = logoPath; }
            else { realPathModeLogo = String.Empty; }
        }

        private static string getChampionshipModeType(string championshipType)
        {
            string getRreturn = string.Empty;

            if (championshipType.Length==3) { getRreturn = championshipType; }
            else if (championshipType.Length > 3)
            {
                if (championshipType.IndexOf("PRO") > -1) { getRreturn = "PRO"; }
                else if (championshipType.IndexOf("FUT") > -1) { getRreturn = "FUT"; }
                else { getRreturn = "H2H"; }
            }

            return getRreturn;
        }

        public static void getLists(ref List<UserDetailsModel> listUsers, ref List<StandardDetailsModel> listTypes, HttpResponseMessage response)
        {

            TeamDetailsModel modelReturnJSON3 = new TeamDetailsModel();

            response = GlobalVariables.WebApiClient.GetAsync("HomeUser").Result;
            modelReturnJSON3 = response.Content.ReadAsAsync<TeamDetailsModel>().Result;

            listUsers = modelReturnJSON3.listOfUser;

            response = GlobalVariables.WebApiClient.GetAsync("TeamType").Result;
            modelReturnJSON3 = response.Content.ReadAsAsync<TeamDetailsModel>().Result;

            listTypes = modelReturnJSON3.listOfType;

            modelReturnJSON3 = null;
        }

        public static void getListModerator(ref List<ChampionshipUserDetailsModel> listUsers, HttpResponseMessage response)
        {
            ChampionshipUserListViewModel modelReturnJSON3 = new ChampionshipUserListViewModel();
            ChampionshipUserDetailsModel userModel = new ChampionshipUserDetailsModel();

            userModel.id = 0;
            userModel.actionUser = "getListModerator";

            response = GlobalVariables.WebApiClient.PostAsJsonAsync("User", userModel).Result;
            modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipUserListViewModel>().Result;

            listUsers = modelReturnJSON3.listOfUser;

            modelReturnJSON3 = null;
            userModel = null;
        }

        public static ChampionshipDetailsModel ShowChampionshipDetails(string championshipID, ChampionshipDetailsModel detailModel = null, 
                                                                       Boolean isCurrentSeason = false, int userIDSession = 0)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipDetailsModel modelReturnJSON = new ChampionshipDetailsModel();

            try
            {
                if (detailModel == null)
                {
                    response = GlobalVariables.WebApiClient.GetAsync("Championship/" + championshipID).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;
                }
                else
                    modelReturnJSON = detailModel;

                ChampionshipTeamTableListViewModel listOfTeamTable = new ChampionshipTeamTableListViewModel();
                ChampionshipMatchTableViewModel listOfMatchTable = new ChampionshipMatchTableViewModel();
                ChampionshipGroupListViewModel listOfGroup = new ChampionshipGroupListViewModel();
                string pathChampionshipLogo = String.Empty;
                string pathTypeLogo = String.Empty;
                string pathTeamLogo = String.Empty;

                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipGroup/" + championshipID).Result;
                listOfGroup = response.Content.ReadAsAsync<ChampionshipGroupListViewModel>().Result;
                modelReturnJSON.listOfGroup = listOfGroup.listOfGroup;
                modelReturnJSON.returnMessage = listOfGroup.returnMessage;

                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                {
                    response = GlobalVariables.WebApiClient.GetAsync("ChampionshipTeamTable/" + championshipID).Result;
                    listOfTeamTable = response.Content.ReadAsAsync<ChampionshipTeamTableListViewModel>().Result;
                    modelReturnJSON.listOfTeamTable = listOfTeamTable.listOfTeamTable;
                    modelReturnJSON.returnMessage = listOfTeamTable.returnMessage;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipMatchTable/" + championshipID).Result;
                        listOfMatchTable = response.Content.ReadAsAsync<ChampionshipMatchTableViewModel>().Result;
                        modelReturnJSON.listOfMatch = listOfMatchTable.listOfMatch;
                        modelReturnJSON.returnMessage = listOfMatchTable.returnMessage;

                        if (isCurrentSeason==false)
                        {
                            if (modelReturnJSON.returnMessage == "ModeratorSuccessfully" && modelReturnJSON.listOfTeamTable.Count > 0)
                            {
                                for (int i = 0; i < modelReturnJSON.listOfTeamTable.Count; i++)
                                {
                                    modelReturnJSON.listOfTeamTable[i].pathTeamLogo = getPathLogoTeam(modelReturnJSON.listOfTeamTable[i].teamName);
                                }
                                if (modelReturnJSON.listOfTeamTable[0].groupID > 0)
                                    modelReturnJSON.drawDoneTeamTableGroup = 1;
                                else
                                    modelReturnJSON.drawDoneTeamTableGroup = 0;
                            }
                            else if (modelReturnJSON.returnMessage == "ModeratorSuccessfully" && modelReturnJSON.listOfTeam.Count > 0)
                            {
                                for (int i = 0; i < modelReturnJSON.listOfTeam.Count; i++)
                                {
                                    modelReturnJSON.listOfTeam[i].pathImg = getPathLogoTeam(modelReturnJSON.listOfTeam[i].name);
                                }
                            }
                        }
                    }

                }
                getPathLogoChampionship(modelReturnJSON.name, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                modelReturnJSON.pathLogoType = pathTypeLogo;

                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                {
                    if (modelReturnJSON.listOfMatch.Count > 0) { modelReturnJSON.drawDoneMatchTable = 1; } else { modelReturnJSON.drawDoneMatchTable = 0; }

                    if (isCurrentSeason==true)
                    {
                        ChampionshipMatchTableDetailsModel model = new ChampionshipMatchTableDetailsModel();
                        ChampionshipMatchTableClashesListViewModel modelReturnJSONClashes = new ChampionshipMatchTableClashesListViewModel();

                        modelReturnJSON.listOfClashes = new List<ChampionshipMatchTableClashesByTeamModel>();

                        model.actionUser = "get_clashes_by_team";
                        model.championshipID = Convert.ToInt16(championshipID);
                        model.userIDAction = userIDSession;
                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", model).Result;
                        modelReturnJSONClashes = response.Content.ReadAsAsync<ChampionshipMatchTableClashesListViewModel>().Result;

                        if (modelReturnJSONClashes != null)
                        {
                            if (modelReturnJSONClashes.returnMessage == "ModeratorSuccessfully")
                                modelReturnJSON.listOfClashes = modelReturnJSONClashes.listOfClashes;
                        }
                        modelReturnJSONClashes = null;
                        model = null;
                    }
                }

                listOfTeamTable = null;
                listOfMatchTable = null;
                listOfGroup = null;

                return modelReturnJSON;
            }
            catch (Exception ex)
            {
                modelReturnJSON.listOfChampionship = new List<ChampionshipDetailsModel>();
                modelReturnJSON.returnMessage = "Ocorreu algum erro na exibição do Menu Moderador - Exibir Detalhes do Campeonato. (" + ex.Message + ")";
                return modelReturnJSON;
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }

        }

        public static void SendEmailCommentAllUsersByGame(ChampionshipMatchTableDetailsModel modelReturnJSON, string comment, string matchID)
        {
            systemEmail objEmail = new systemEmail();
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipCommentMatchUsersListViewModel modelReturnJSON3 = new ChampionshipCommentMatchUsersListViewModel();
            ChampionshipCommentMatchDetailsModel commentMatchMode = new ChampionshipCommentMatchDetailsModel();
            ChampionshipCommentMatchDetailsModel modelReturnJSON4 = new ChampionshipCommentMatchDetailsModel();

            try
            {
                string dsMatch = modelReturnJSON.championshipName.Replace("  ", " ") + " - " + modelReturnJSON.teamNameHome + " " + modelReturnJSON.totalGoalsHome +
                                 " vs " + modelReturnJSON.totalGoalsAway + " " + modelReturnJSON.teamNameAway + " " + modelReturnJSON.stageName;

                if (!String.IsNullOrEmpty(modelReturnJSON.groupName)) { dsMatch = dsMatch + " - " + modelReturnJSON.groupName; }

                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentUsers/" + matchID).Result;
                modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipCommentMatchUsersListViewModel>().Result;

                modelReturnJSON.returnMessage = modelReturnJSON3.returnMessage;

                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                {
                    for (var i = 0; i < modelReturnJSON3.listOfUsersCommentMatch.Count; i++)
                    {
                        if (commentMatchMode.userID != modelReturnJSON3.listOfUsersCommentMatch[i].userID)
                        {
                            objEmail.SendEmail(getBodyHtmlSendComment(modelReturnJSON, comment, dsMatch),
                                               modelReturnJSON3.listOfUsersCommentMatch[i].email, "CONTACT-US", "Comentario da Fase - " + dsMatch);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                objEmail = null;
                response = null;
                commentMatchMode = null;
                modelReturnJSON3 = null;
                modelReturnJSON4 = null;
            }
        }

        public static ChampionshipMatchTableDetailsModel getDetailsCommentMatch(string actionForm, string txtComment, string sessionUserID, 
                                                                                string championshipID, string matchID, ChampionshipMatchTableDetailsModel modelForm)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipCommentMatchListViewModel modelReturnJSON2 = new ChampionshipCommentMatchListViewModel();
            ChampionshipCommentMatchUsersListViewModel modelReturnJSON3 = new ChampionshipCommentMatchUsersListViewModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            ChampionshipCommentMatchDetailsModel commentMatchMode = new ChampionshipCommentMatchDetailsModel();
            ChampionshipCommentMatchDetailsModel modelReturnJSON4 = new ChampionshipCommentMatchDetailsModel();

            try
            {

                if (actionForm == "save_comment")
                {
                    commentMatchMode.matchID = Convert.ToInt32(matchID);
                    commentMatchMode.comment = txtComment;
                    commentMatchMode.actionUser = "save_comment";
                    commentMatchMode.userID = Convert.ToUInt16(sessionUserID);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentMatch", commentMatchMode).Result;
                    modelReturnJSON4 = response.Content.ReadAsAsync<ChampionshipCommentMatchDetailsModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON4.returnMessage;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        modelReturnJSON = modelForm;

                        SendEmailCommentAllUsersByGame(modelReturnJSON, commentMatchMode.comment, matchID);
                    }
                }
                else if (actionForm.IndexOf("save_user_comment") > -1)
                {
                    commentMatchMode.matchID = Convert.ToInt32(matchID);
                    commentMatchMode.championshipID = Convert.ToInt16(championshipID);
                    commentMatchMode.actionUser = actionForm.Replace("_my_matches", string.Empty);
                    commentMatchMode.userID = Convert.ToInt32(sessionUserID);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentUsers", commentMatchMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        modelReturnJSON = new ChampionshipMatchTableDetailsModel();
                        modelReturnJSON = modelForm;
                    }
                    response.StatusCode = HttpStatusCode.Created;
                }
                else if (actionForm.IndexOf("cancel_user_comment") > -1)
                {
                    commentMatchMode.matchID = Convert.ToInt32(matchID);
                    commentMatchMode.championshipID = Convert.ToInt16(championshipID);
                    commentMatchMode.actionUser = actionForm.Replace("_my_matches", string.Empty);
                    commentMatchMode.userID = Convert.ToInt32(sessionUserID);

                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipCommentUsers", commentMatchMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;
                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        modelReturnJSON = new ChampionshipMatchTableDetailsModel();
                        modelReturnJSON = modelForm;
                    }
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

                            if (actionForm == "save_comment")
                            {
                                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentMatch/" + matchID).Result;
                                modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipCommentMatchListViewModel>().Result;

                                modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                {
                                    modelReturnJSON.listOfCommentMatch = modelReturnJSON2.listOfCommentMatch;
                                }
                            }
                            else if (actionForm.IndexOf("save_user_comment") > -1 || actionForm.IndexOf("cancel_user_comment") > -1)
                            {
                                modelReturnJSON = modelForm;
                                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentUsers/" + matchID).Result;
                                modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipCommentMatchUsersListViewModel>().Result;

                                modelReturnJSON.returnMessage = modelReturnJSON3.returnMessage;

                                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                                    modelReturnJSON.listOfUsersCommentMatch = modelReturnJSON3.listOfUsersCommentMatch;

                            }
                            else
                            {
                                if (actionForm == "show_championshipmatchtable_details")
                                {
                                    modelReturnJSON = getDetailsViewChampionshipMatch(championshipID, matchID);
                                }
                                modelReturnJSON.actionUser = actionForm.ToUpper();
                            }
                            return modelReturnJSON;
                        }
                        else
                        {
                            modelReturnJSON.returnMessage = "Ocorreu algum erro na exibição do Menu Moderador - Decretar Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return modelReturnJSON;
                        }
                    default:
                        modelReturnJSON.returnMessage = "Ocorreu algum erro na exibição do Menu Moderador - Decretar Resultado. (" + response.StatusCode + ")";
                        return modelReturnJSON;
                }
            }
            catch (Exception ex)
            {
                modelReturnJSON.returnMessage = "Erro interno - Exibindo Menu Moderador - Decretar Resultado: (" + ex.InnerException.Message + ")";
                return modelReturnJSON;
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


        public static ChampionshipMatchTableDetailsModel getDetailsLaunchResult(string actionForm, string sessionUserID, string championshipID, string matchID,
                                                                                string goalsTeamHome, string goalsTeamAway, string scorersTeamHome, string scorersTeamAway, 
                                                                                string sessionPsnID, ChampionshipMatchTableDetailsModel modelForm,
                                                                                out string returnMessage)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            var objFunctions = new Commons.functions();

            string loadScorers = String.Empty;
            string loadGoals = String.Empty;
            returnMessage = string.Empty;

            try
            {

                if (actionForm.IndexOf("save_simple_result") > -1)
                {
                    ModeratorMenuMode.matchID = Convert.ToInt32(matchID);
                    ModeratorMenuMode.championshipID = Convert.ToInt32(championshipID);

                    ModeratorMenuMode.totalGoalsHome = goalsTeamHome;
                    ModeratorMenuMode.totalGoalsAway = goalsTeamAway;

                    ModeratorMenuMode.userIDAction = Convert.ToUInt16(sessionUserID);
                    ModeratorMenuMode.psnIDAction = sessionPsnID;

                    ModeratorMenuMode.actionUser = actionForm;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", ModeratorMenuMode).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully" && modelForm.modeType != "FUT" && (ModeratorMenuMode.totalGoalsHome != "0" || ModeratorMenuMode.totalGoalsAway != "0"))
                    {
                        ScorerMatchViewModel scorerMatchModel = new ScorerMatchViewModel();
                        ScorerMatchViewModel modelReturnJSON2 = new ScorerMatchViewModel();

                        scorerMatchModel.matchID = Convert.ToInt32(matchID);
                        scorerMatchModel.championshipID = Convert.ToInt32(championshipID);

                        if (scorersTeamHome.Trim() != String.Empty)
                        {
                            objFunctions.sortOutScorersGoalsByMatch(scorersTeamHome, ref loadScorers, ref loadGoals);
                            scorerMatchModel.loadScorersIDHome = loadScorers;
                            scorerMatchModel.loadScorersGoalsHome = loadGoals;
                        }

                        if (scorersTeamAway.Trim() != String.Empty)
                        {
                            objFunctions.sortOutScorersGoalsByMatch(scorersTeamAway, ref loadScorers, ref loadGoals);
                            scorerMatchModel.loadScorersIDAway = loadScorers;
                            scorerMatchModel.loadScorersGoalsAway = loadGoals;
                        }

                        scorerMatchModel.actionUser = "save_all_by_match";

                        response = GlobalVariables.WebApiClient.PostAsJsonAsync("ScorerMatch", scorerMatchModel).Result;
                        modelReturnJSON2 = response.Content.ReadAsAsync<ScorerMatchViewModel>().Result;

                        modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                            returnMessage = "Resultado e Artilharia atualizados com sucesso.";

                        scorerMatchModel = null;
                        modelReturnJSON2 = null;
                    }
                    else if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        returnMessage = "Resultado atualizado com sucesso.";
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
                            if (actionForm.IndexOf("show_launch_simple_result_details") > -1)
                            {
                                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipMatchTable/" + (championshipID + ";" + matchID)).Result;
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

                                            response = GlobalVariables.WebApiClient.GetAsync("ScorerMatch/" + (championshipID + "|" + matchID)).Result;
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

                                    getPathLogoChampionship(modelReturnJSON.championshipName, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                                    modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                                    modelReturnJSON.pathLogoType = pathTypeLogo.Replace("white", "beige");
                                    modelReturnJSON.pathLogoTeamHome = getPathLogoTeam(modelReturnJSON.teamNameHome);
                                    modelReturnJSON.pathLogoTeamAway = getPathLogoTeam(modelReturnJSON.teamNameAway);
                                }

                                scorersTeamHomeModel = null;
                                scorersTeamAwayModel = null;
                                scorersDetailsModel = null;
                                scorersMatcModel = null;
                            }
                            modelReturnJSON.actionUser = actionForm.ToUpper();
                            return modelReturnJSON;
                        }
                        else
                        {
                            modelReturnJSON.returnMessage = "Ocorreu algum erro na exibição do Lançar Simples Resultado. (" + modelReturnJSON.returnMessage + ")";
                            return modelReturnJSON;
                        }
                    default:
                        modelReturnJSON.returnMessage = "Ocorreu algum erro na exibição do Lançar Simples Resultado. (" + response.StatusCode + ")";
                        return modelReturnJSON;
                }
            }
            catch (Exception ex)
            {
                modelReturnJSON.returnMessage = "Erro interno - Exibindo Lançar Simples Resultado: (" + ex.InnerException.Message + ")";
                return modelReturnJSON;
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
                objFunctions = null;
            }
        }



        public static ChampionshipMatchTableDetailsModel getDetailsViewChampionshipMatch(string championshipID, string matchID)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipMatchTableDetailsModel modelReturnJSON = new ChampionshipMatchTableDetailsModel();
            ChampionshipCommentMatchListViewModel modelReturnJSON2 = new ChampionshipCommentMatchListViewModel();
            ChampionshipCommentMatchUsersListViewModel modelReturnJSON3 = new ChampionshipCommentMatchUsersListViewModel();
            ScorerMatchViewModel scorersMatcModel = new ScorerMatchViewModel();
            ChampionshipDetailsModel championshipModel = new ChampionshipDetailsModel();
            ChampionshipMatchTableViewModel listOfMatchTable = new ChampionshipMatchTableViewModel();

            try
            {

                response = GlobalVariables.WebApiClient.GetAsync("ChampionshipMatchTable/" + (championshipID + ";" + matchID)).Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipMatchTableDetailsModel>().Result;

                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                {
                    modelReturnJSON.pathLogoTeamHome = getPathLogoTeam(modelReturnJSON.teamNameHome);
                    modelReturnJSON.pathLogoTeamAway = getPathLogoTeam(modelReturnJSON.teamNameAway);
                    string pathChampionshipLogo = string.Empty;
                    string pathTypeLogo = string.Empty;

                    getPathLogoChampionship(modelReturnJSON.championshipName, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                    modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                    modelReturnJSON.pathLogoType = pathTypeLogo;

                    response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentMatch/" + matchID).Result;
                    modelReturnJSON2 = response.Content.ReadAsAsync<ChampionshipCommentMatchListViewModel>().Result;

                    modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;

                    if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                    {
                        modelReturnJSON.listOfCommentMatch = modelReturnJSON2.listOfCommentMatch;

                        response = GlobalVariables.WebApiClient.GetAsync("ChampionshipCommentUsers/" + matchID).Result;
                        modelReturnJSON3 = response.Content.ReadAsAsync<ChampionshipCommentMatchUsersListViewModel>().Result;

                        modelReturnJSON.returnMessage = modelReturnJSON3.returnMessage;

                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {
                            modelReturnJSON.listOfUsersCommentMatch = modelReturnJSON3.listOfUsersCommentMatch;

                            response = GlobalVariables.WebApiClient.GetAsync("ScorerMatch/" + (championshipID + "|" + matchID)).Result;
                            scorersMatcModel = response.Content.ReadAsAsync<ScorerMatchViewModel>().Result;

                            modelReturnJSON.returnMessage = scorersMatcModel.returnMessage;

                            if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                            {
                                if (scorersMatcModel.listOfScorerMatch != null)
                                    modelReturnJSON.listOfScorerMatch = scorersMatcModel.listOfScorerMatch;
                                else
                                    modelReturnJSON.listOfScorerMatch = new List<ScorerMatchDetails>();

                                response = GlobalVariables.WebApiClient.GetAsync("Championship/" + championshipID).Result;
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
                                        if (listOfMatchTable.listOfMatch != null)
                                            modelReturnJSON.listOfMatch = listOfMatchTable.listOfMatch;
                                        else
                                            modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();
                                    }
                                    else
                                        modelReturnJSON.listOfMatch = new List<ChampionshipMatchTableDetailsModel>();

                                }

                            }

                        }
                    }


                }
                return modelReturnJSON;
            }
            catch (Exception ex)
            {
                modelReturnJSON.returnMessage = "Ocorreu algum erro na exibição do Menu Moderador - Exibir Detalhes do Campeonato. (" + ex.Message + ")";
                return modelReturnJSON;
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                modelReturnJSON2 = null;
                modelReturnJSON3 = null;
                scorersMatcModel = null;
                championshipModel = null;
                listOfMatchTable = null;
            }


        }

        public static void saveFileUploadLogo(HttpPostedFileBase file, string clubLogoName, 
                                              string fullPathClubLogoName, string fullDefaultPath)
        {
            try
            {
                if (System.IO.File.Exists(fullPathClubLogoName.Replace(clubLogoName, clubLogoName + "-old")))
                    System.IO.File.Delete(fullPathClubLogoName.Replace(clubLogoName, clubLogoName + "-old"));

                if (System.IO.File.Exists(fullPathClubLogoName))
                {
                    System.IO.File.Copy(fullPathClubLogoName, fullPathClubLogoName.Replace(clubLogoName, clubLogoName + "-old"));
                    System.IO.File.Delete(fullPathClubLogoName);
                }

                string pic = System.IO.Path.GetFileName(clubLogoName + ".jpg");
                string path = System.IO.Path.Combine(fullDefaultPath, pic);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Copy(path, path.Replace(file.FileName.Split(Convert.ToChar("."))[0], file.FileName.Split(Convert.ToChar("."))[0] + "-old"));
                    System.IO.File.Delete(path);
                }
                file.SaveAs(path);

            }
            catch (Exception ex)
            {
                throw new SystemException("ERROR, ao tentar gravar logo do seu clube/time: " + ex.Message);
            }
        }

        public static MyNextMatchesViewModel updateMobileManagerPRO(string actionUser, int userID, string fullMobileNumber,
                                                                    MyNextMatchesViewModel fullModel, out string returnMessage)
        {
            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();
            try
            {
                ModeratorMenuMode.actionUser = actionUser;
                ModeratorMenuMode.userID = userID;
                ModeratorMenuMode.codeMobileNumber = stripCodeMobileFullNumber(fullMobileNumber);
                ModeratorMenuMode.mobileNumber = stripNumberMobileFullNumber(fullMobileNumber);
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;
                if (modelReturnJSON.returnMessage == "MyMatchesSuccessfully")
                    returnMessage = "Os dados do Celular do Manager foram alterados com sucesso";
                else
                    returnMessage = modelReturnJSON.returnMessage;

                modelReturnJSON = fullModel;
                //modelReturnJSON.returnMessage = "MyMatchesSuccessfully";
                modelReturnJSON.codeMobileNumber = ModeratorMenuMode.codeMobileNumber;
                modelReturnJSON.mobileNumber = ModeratorMenuMode.mobileNumber;

                return modelReturnJSON;
            }
            catch (Exception ex)
            {
                returnMessage = "Erro interno - Exibindo Tela de Upload Logo Team PRO: (" + ex.Message + ")";
                return fullModel;
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                ModeratorMenuMode = null;
            }
        }


        public static MyNextMatchesViewModel maintenanceSquadPRO(string actionUser, int clubID, string psnID, int playerID, int userID,
                                                                 MyNextMatchesViewModel fullModel, out string returnMessage)
        {
            HttpResponseMessage response = null;
            MyNextMatchesViewModel modelReturnJSON = new MyNextMatchesViewModel();
            MyNextMatchesViewModel ModeratorMenuMode = new MyNextMatchesViewModel();
            MyMatchesSummaryViewModel modelReturnJSON2 = new MyMatchesSummaryViewModel();
            MyMatchesSummaryViewModel ModeratorMenuMode2 = new MyMatchesSummaryViewModel();
            List<squadListModel> listOfSquad = new List<squadListModel>();
            try
            {

                if (actionUser.IndexOf("Add") > -1)
                {
                    ModeratorMenuMode2.actionUser = actionUser;
                    ModeratorMenuMode2.teamID = clubID;
                    ModeratorMenuMode2.psnID = psnID;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode2).Result;
                    modelReturnJSON2 = response.Content.ReadAsAsync<MyMatchesSummaryViewModel>().Result;
                    returnMessage = string.Empty;
                    if (modelReturnJSON2.returnMessage == "MyMatchesSuccessfully")
                        returnMessage = "O jogador foi adicionado com sucesso em seu elenco";
                    else if (modelReturnJSON2.returnMessage == "PsnNotFound")
                        returnMessage = "ATENÇÃO MANAGER: Ação NÃO efetuada. PSN informada (" + ModeratorMenuMode2.psnID + ") não foi encontrada";
                    else if (modelReturnJSON2.returnMessage == "PlayerIsInYourClub")
                        returnMessage = "ATENÇÃO MANAGER: Ação NÃO efetuada. O Jogador já ESTÁ no seu elenco";
                    else if (modelReturnJSON2.returnMessage == "PlayerIsInAnotherClub")
                        returnMessage = "ATENÇÃO MANAGER: Ação NÃO efetuada. O Jogador já se encontra em OUTRO elenco";

                }
                else
                {
                    ModeratorMenuMode.actionUser = actionUser;
                    ModeratorMenuMode.userID = playerID;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                    modelReturnJSON2 = response.Content.ReadAsAsync<MyMatchesSummaryViewModel>().Result;

                    returnMessage = "O jogador foi excluído com sucesso do seu elenco";
                }

                ModeratorMenuMode.actionUser = "uploadLogoTeamPROListOfSquad";
                ModeratorMenuMode.userID = userID;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("MyMatches", ModeratorMenuMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<MyNextMatchesViewModel>().Result;

                listOfSquad = modelReturnJSON.listOfSquad;

                modelReturnJSON = fullModel;
                modelReturnJSON.returnMessage = "MyMatchesSuccessfully";
                modelReturnJSON.listOfSquad = listOfSquad;
                if (modelReturnJSON2.returnMessage != "MyMatchesSuccessfully")
                {
                    modelReturnJSON.psnIDForm = psnID;
                    if (("PsnNotFound,'PlayerIsInYourClub',PlayerIsInAnotherClub").IndexOf(modelReturnJSON2.returnMessage) == -1)
                        modelReturnJSON.returnMessage = modelReturnJSON2.returnMessage;
                }

                return modelReturnJSON;
            }
            catch (Exception ex)
            {
                returnMessage = "Erro interno - Exibindo Tela de Manutenção Elenco PRO: (" + ex.Message + ")";
                return fullModel;
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

        public static string stripCodeMobileFullNumber(string mobilieFullNumber)
        {
            string codeMobileNumber = String.Empty;

            if (mobilieFullNumber.IndexOf("(") > -1 && mobilieFullNumber.IndexOf(")") > -1)
            {
                codeMobileNumber = mobilieFullNumber.Substring(mobilieFullNumber.IndexOf("(")+1, 2);
            }

            return codeMobileNumber;
        }

        public static string stripNumberMobileFullNumber(string mobilieFullNumber)
        {
            string codeMobileNumber = String.Empty;

            if (mobilieFullNumber.IndexOf(")") > -1)
            {
                codeMobileNumber = mobilieFullNumber.Split(Convert.ToChar(")"))[1];
            }

            return codeMobileNumber;
        }

        public static void getHistoryClashesTeamAndCoach(ref ChampionshipMatchTableDetailsModel modelReturnJSON)
        {
            ChampionshipMatchTableClashesHistoryTotalswModel modelReturnJSON5 = new ChampionshipMatchTableClashesHistoryTotalswModel();
            ChampionshipMatchTableClashesHistoryTotalsByTeamswModel modelReturnJSON6 = new ChampionshipMatchTableClashesHistoryTotalsByTeamswModel();
            ChampionshipMatchTableDetailsModel ModeratorMenuMode = new ChampionshipMatchTableDetailsModel();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                ModeratorMenuMode.actionUser = "clashes_historic_by_coaches";
                ModeratorMenuMode.userIDAction = modelReturnJSON.userHomeID;
                ModeratorMenuMode.psnIDAction = modelReturnJSON.psnIDHome;
                ModeratorMenuMode.psnIDSearch = modelReturnJSON.psnIDAway;
                ModeratorMenuMode.modeType = modelReturnJSON.modeType;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", ModeratorMenuMode).Result;
                modelReturnJSON5 = response.Content.ReadAsAsync<ChampionshipMatchTableClashesHistoryTotalswModel>().Result;

                if (modelReturnJSON5.returnMessage != "ModeratorSuccessfully")
                {
                    modelReturnJSON.historyCoachClash.listOfMatchDraw = new List<ChampionshipMatchTableDetailsModel>();
                    modelReturnJSON.historyCoachClash.listOfMatchWinUsuLogged = new List<ChampionshipMatchTableDetailsModel>();
                    modelReturnJSON.historyCoachClash.listOfMatchWinUsuSearch = new List<ChampionshipMatchTableDetailsModel>();
                }
                else
                {
                    modelReturnJSON.historyCoachClash = modelReturnJSON5;

                    ModeratorMenuMode.actionUser = "clashes_historic_by_teams";
                    ModeratorMenuMode.teamHomeID = modelReturnJSON.teamHomeID;
                    ModeratorMenuMode.teamAwayID = modelReturnJSON.teamAwayID;
                    ModeratorMenuMode.modeType = modelReturnJSON.modeType;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("ChampionshipMatchTable", ModeratorMenuMode).Result;
                    modelReturnJSON6 = response.Content.ReadAsAsync<ChampionshipMatchTableClashesHistoryTotalsByTeamswModel>().Result;

                    if (modelReturnJSON6.returnMessage != "ModeratorSuccessfully")
                    {
                        modelReturnJSON.historyTeamClash.listOfMatchDraw = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.historyTeamClash.listOfMatchWinTeamHome = new List<ChampionshipMatchTableDetailsModel>();
                        modelReturnJSON.historyTeamClash.listOfMatchWinTeamAway = new List<ChampionshipMatchTableDetailsModel>();
                    }
                    else
                        modelReturnJSON.historyTeamClash = modelReturnJSON6;
                }
            }
            catch
            {

            }
            finally
            {
                modelReturnJSON5 = null;
                modelReturnJSON6 = null;
                ModeratorMenuMode = null;
                response = null;
            }
        }
    }
}