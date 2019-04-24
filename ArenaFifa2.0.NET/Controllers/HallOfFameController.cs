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
    public class HallOfFameController : Controller
    {

        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inHallOfFame = "1";
            ViewBag.inRenewNextSeason = ConfigurationManager.AppSettings["renew.next.season"].ToString();

        }

        // GET: HallOfFame/Summary
        public ActionResult Summary()
        {

            HttpResponseMessage response = null;
            SummaryViewModel modelReturnJSON = null;
            SummaryViewModel hallOfFameMode = new SummaryViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "summary";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<SummaryViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: HallOfFame/GeneralRegulation
        public ActionResult GeneralRegulation()
        {
            setViewBagVariables();
            return View();
        }


        // GET: HallOfFame/ChampionshipScoringRegulation
        public ActionResult ChampionshipScoringRegulation()
        {

            HttpResponseMessage response = null;
            ChampionshipScoreViewModel modelReturnJSON = null;
            ChampionshipScoreViewModel hallOfFameMode = new ChampionshipScoreViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "championshipScoring";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<ChampionshipScoreViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Pontuação Por Campeonato. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Pontuação Por Campeonato. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Pontuação Por Campeonato: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: HallOfFame/GeneralBlackList
        public ActionResult GeneralBlackList()
        {

            HttpResponseMessage response = null;
            GeneralBlackListViewModel modelReturnJSON = null;
            GeneralBlackListViewModel hallOfFameMode = new GeneralBlackListViewModel();

            setViewBagVariables();

            try
            {

                hallOfFameMode.actionUser = "blackList";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<GeneralBlackListViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Lista Negra. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Lista Negra. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Lista Negra: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: HallOfFame/AchievementsH2H
        public ActionResult AchievementsH2H()
        {

            HttpResponseMessage response = null;
            AchievementViewModel modelReturnJSON = null;
            AchievementViewModel hallOfFameMode = new AchievementViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "achievementH2H";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<AchievementViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Conquistas H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Conquistas H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Conquistas H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: HallOfFame/AchievementsFUT
        public ActionResult AchievementsFUT()
        {

            HttpResponseMessage response = null;
            AchievementViewModel modelReturnJSON = null;
            AchievementViewModel hallOfFameMode = new AchievementViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "achievementFUT";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<AchievementViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Conquistas H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Conquistas H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Conquistas H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: HallOfFame/AchievementsPRO
        public ActionResult AchievementsPRO()
        {

            HttpResponseMessage response = null;
            AchievementViewModel modelReturnJSON = null;
            AchievementViewModel hallOfFameMode = new AchievementViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "achievementPRO";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<AchievementViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Conquistas H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Conquistas H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Conquistas H2H: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
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