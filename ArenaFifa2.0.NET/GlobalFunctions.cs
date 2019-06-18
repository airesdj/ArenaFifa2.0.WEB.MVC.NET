using ArenaFifa20.NET.Models;
using SYSEmail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

        public static ChampionshipDetailsModel ShowChampionshipDetails(string championshipID)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ChampionshipDetailsModel modelReturnJSON = new ChampionshipDetailsModel();

            try
            {

                response = GlobalVariables.WebApiClient.GetAsync("Championship/" + championshipID).Result;
                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipDetailsModel>().Result;

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
                getPathLogoChampionship(modelReturnJSON.name, modelReturnJSON.modeType, ref pathChampionshipLogo, ref pathTypeLogo);

                modelReturnJSON.pathLogoChampionship = pathChampionshipLogo;
                modelReturnJSON.pathLogoType = pathTypeLogo;

                if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                {
                    if (modelReturnJSON.listOfMatch.Count > 0) { modelReturnJSON.drawDoneMatchTable = 1; } else { modelReturnJSON.drawDoneMatchTable = 0; }
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

    }
}