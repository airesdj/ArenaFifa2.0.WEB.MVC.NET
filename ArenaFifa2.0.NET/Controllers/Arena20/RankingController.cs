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

        private void setViewBagVariablesGlobal()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inRanking = "1";
        }

        private void setViewBagVariablesForChampionship()
        {
            ViewBag.inAccessCurrentSeasonRegular = ConfigurationManager.AppSettings["access.current.season.regular"].ToString();
            ViewBag.inAccessCurrentSeasonAccess = ConfigurationManager.AppSettings["access.current.season.access"].ToString();
            ViewBag.inAccessCurrentSeasonAccessDirect = ConfigurationManager.AppSettings["access.current.season.access.direct"].ToString();
            ViewBag.inAccessCurrentSeasonInvite = ConfigurationManager.AppSettings["access.current.season.invite"].ToString();
            ViewBag.inAccessCurrentSeasonExchange = ConfigurationManager.AppSettings["access.current.season.exchange"].ToString();
        }


        // GET: Ranking/Summary
        public ActionResult Summary()
        {

            HttpResponseMessage response = null;
            RankingSummaryViewModel modelReturnJSON = null;
            RankingSummaryViewModel hallOfFameMode = new RankingSummaryViewModel();

            setViewBagVariablesGlobal();

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

        private RankingViewModel executeAPIRanking(RankingViewModel modelReturnJSON, RankingViewModel hallOfFameMode, string descryptionMode)
        {
            HttpResponseMessage response = null;

            response = GlobalVariables.WebApiClient.PostAsJsonAsync("Ranking", hallOfFameMode).Result;
            modelReturnJSON = response.Content.ReadAsAsync<RankingViewModel>().Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.Created:
                    if (modelReturnJSON.returnMessage == "RankingSuccessfully")
                    {

                        TempData["loggedUserID"] = Session["user.id"].ToString();
                        return modelReturnJSON;
                    }
                    else
                    {
                        //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do " + descryptionMode + ". (" + modelReturnJSON.returnMessage + ")";
                        modelReturnJSON.listOfRanking = new List<listRanking>();
                        return modelReturnJSON;
                    }
                default:
                    TempData["returnMessage"] = "Ocorreu algum erro na exibição do "+ descryptionMode + ". (" + response.StatusCode + ")";
                    ModelState.AddModelError("", "application error.");
                    modelReturnJSON.listOfRanking = new List<listRanking>();
                    return modelReturnJSON;
            }

        }

        // GET: Ranking/GeneralH2H
        public ActionResult GeneralH2H()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();

            try
            {
                hallOfFameMode.actionUser = "rankingGeneral";
                hallOfFameMode.typeMode = "H2H";
                hallOfFameMode.totalRecordsRanking = Convert.ToInt16(ConfigurationManager.AppSettings["ranking.total.shown"].ToString());

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Geral H2H");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Geral H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: Ranking/GeneralFUT
        public ActionResult GeneralFUT()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();

            try
            {
                hallOfFameMode.actionUser = "rankingGeneral";
                hallOfFameMode.typeMode = "FUT";
                hallOfFameMode.totalRecordsRanking = Convert.ToInt16(ConfigurationManager.AppSettings["ranking.total.shown"].ToString());


                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Geral FUT");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Geral FUT: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: Ranking/GeneralPRO
        public ActionResult GeneralPRO()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();

            try
            {
                hallOfFameMode.actionUser = "rankingGeneral";
                hallOfFameMode.typeMode = "PRO";
                hallOfFameMode.totalRecordsRanking = Convert.ToInt16(ConfigurationManager.AppSettings["ranking.total.shown"].ToString());


                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Geral PRO CLUB");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Geral PRO CLUB: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: Ranking/CurrentH2H
        public ActionResult CurrentH2H()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();

            try
            {
                hallOfFameMode.actionUser = "rankingCurrent";
                hallOfFameMode.typeMode = "H2H";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Atual H2H");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Atual H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: Ranking/CurrentFUT
        public ActionResult CurrentFUT()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();

            try
            {
                hallOfFameMode.actionUser = "rankingCurrent";
                hallOfFameMode.typeMode = "FUT";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Atual FUT");

                return View(modelReturnJSON);
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Atual FUT: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: Ranking/CurrentPRO
        public ActionResult CurrentPRO()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();

            try
            {
                hallOfFameMode.actionUser = "rankingCurrent";
                hallOfFameMode.typeMode = "PRO";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Atual PRO CLUB");

                return View(modelReturnJSON);
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Atual PRO CLUB: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: Ranking/SerieAH2H
        public ActionResult SerieAH2H()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();
            setViewBagVariablesForChampionship();

            try
            {
                hallOfFameMode.actionUser = "rankingByDivision";
                hallOfFameMode.typeMode = "H2H";
                hallOfFameMode.typeChampionship = "DIV1";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Série A H2H");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Série A H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: Ranking/SerieBH2H
        public ActionResult SerieBH2H()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();
            setViewBagVariablesForChampionship();

            try
            {
                hallOfFameMode.actionUser = "rankingByDivision";
                hallOfFameMode.typeMode = "H2H";
                hallOfFameMode.typeChampionship = "DIV2";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Série B H2H");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Série B H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: Ranking/SerieCH2H
        public ActionResult SerieCH2H()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();
            setViewBagVariablesForChampionship();

            try
            {
                hallOfFameMode.actionUser = "rankingByDivision";
                hallOfFameMode.typeMode = "H2H";
                hallOfFameMode.typeChampionship = "DIV3";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Série C H2H");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Série C H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: Ranking/SerieAFUT
        public ActionResult SerieAFUT()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();
            setViewBagVariablesForChampionship();

            try
            {
                hallOfFameMode.actionUser = "rankingByDivision";
                hallOfFameMode.typeMode = "FUT";
                hallOfFameMode.typeChampionship = "FUT1";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Série A FUT");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Série A FUT: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: Ranking/SerieAPRO
        public ActionResult SerieAPRO()
        {

            RankingViewModel modelReturnJSON = null;
            RankingViewModel hallOfFameMode = new RankingViewModel();

            setViewBagVariablesGlobal();
            setViewBagVariablesForChampionship();

            try
            {
                hallOfFameMode.actionUser = "rankingByDivision";
                hallOfFameMode.typeMode = "PRO";
                hallOfFameMode.typeChampionship = "PRO1";

                modelReturnJSON = executeAPIRanking(modelReturnJSON, hallOfFameMode, "Ranking Série A PRO CLUB");

                return View(modelReturnJSON);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Ranking Série A PRO CLUB: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                hallOfFameMode.listOfRanking = new List<listRanking>();
                return View(hallOfFameMode);

            }
            finally
            {
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

    }
}