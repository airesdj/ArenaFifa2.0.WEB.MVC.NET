using ArenaFifa20.NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ArenaFifa20.NET.Controllers
{
    public class RankingController : Controller
    {

        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inRanking = "1";
        }

        // GET: Ranking/Summary
        public ActionResult Summary()
        {

            HttpResponseMessage response = null;
            RankingSummaryViewModel modelReturnJSON = null;
            RankingSummaryViewModel hallOfFameMode = new RankingSummaryViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "summary";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Ranking", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<RankingSummaryViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "RankingSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Ranking. (" + modelReturnJSON.returnMessage + ")";
                            hallOfFameMode.listOfScorersH2H = new List<listScorers>();
                            hallOfFameMode.listOfScorersPRO = new List<listScorers>();
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Ranking. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        hallOfFameMode.listOfScorersH2H = new List<listScorers>();
                        hallOfFameMode.listOfScorersPRO = new List<listScorers>();
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfScorersH2H = new List<listScorers>();
                hallOfFameMode.listOfScorersPRO = new List<listScorers>();
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

    }
}