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
            ViewBag.inRenewNextSeason = ConfigurationManager.AppSettings["renewal.next.season"].ToString();
        }

        // GET: HallOfFame/Summary
        public ActionResult Summary()
        {

            HttpResponseMessage response = null;
            HallOfFameSummaryViewModel modelReturnJSON = null;
            HallOfFameSummaryViewModel hallOfFameMode = new HallOfFameSummaryViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "summary";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<HallOfFameSummaryViewModel>().Result;

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

        // GET: HallOfFame/RenewalH2H
        public ActionResult RenewalH2H()
        {

            HttpResponseMessage response = null;
            RenewalViewModel modelReturnJSON = null;
            RenewalViewModel hallOfFameMode = new RenewalViewModel();

            setViewBagVariables();
            ViewBag.inRenewalWorldCup = ConfigurationManager.AppSettings["renewal.h2h.worldcup"].ToString();
            ViewBag.inRenewalUefaEuro = ConfigurationManager.AppSettings["renewal.h2h.uefaeuro"].ToString();
            ViewBag.limitBanWorldCupUefaEuro = ConfigurationManager.AppSettings["renewal.total.limit.ban.worldcup"].ToString();


            try
            {
                hallOfFameMode.actionUser = "renewal";
                hallOfFameMode.seasonID = 0;
                hallOfFameMode.renewalMode = "H2H";
                hallOfFameMode.championshipIDRenewal = ConfigurationManager.AppSettings["renewal.h2h.id"].ToString();
                hallOfFameMode.championshipIDBenchRenewal = ConfigurationManager.AppSettings["renewal.h2h.id.bench"].ToString();
                if (ViewBag.inRenewalWorldCup=="1" || ViewBag.inRenewalUefaEuro == "1")
                    hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = ConfigurationManager.AppSettings["renewal.h2h.id.worldcup.uefaeuro"].ToString();
                else
                    hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = String.Empty;
                hallOfFameMode.totalLimitBlackList = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.total.limit.blackList"].ToString());
                hallOfFameMode.totalLimitBanWorldCupUefaEuro = Convert.ToInt16(ViewBag.limitBanWorldCupUefaEuro);
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<RenewalViewModel>().Result;

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
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações H2H. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações H2H. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Renovações H2H: (" + ex.InnerException.Message + ")";
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


        // GET: HallOfFame/RenewalFUT
        public ActionResult RenewalFUT()
        {

            HttpResponseMessage response = null;
            RenewalViewModel modelReturnJSON = null;
            RenewalViewModel hallOfFameMode = new RenewalViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "renewal";
                hallOfFameMode.seasonID = 0;
                hallOfFameMode.renewalMode = "FUT";
                hallOfFameMode.championshipIDRenewal = ConfigurationManager.AppSettings["renewal.fut.id"].ToString();
                hallOfFameMode.championshipIDBenchRenewal = ConfigurationManager.AppSettings["renewal.fut.id.bench"].ToString();
                hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = String.Empty;
                hallOfFameMode.totalLimitBlackList = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.total.limit.blackList"].ToString());
                hallOfFameMode.totalLimitBanWorldCupUefaEuro = 0;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<RenewalViewModel>().Result;

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
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações FUT. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações FUT. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Renovações FUT: (" + ex.InnerException.Message + ")";
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

        // GET: HallOfFame/RenewalPRO
        public ActionResult RenewalPRO()
        {

            HttpResponseMessage response = null;
            RenewalViewModel modelReturnJSON = null;
            RenewalViewModel hallOfFameMode = new RenewalViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "renewal";
                hallOfFameMode.seasonID = 0;
                hallOfFameMode.renewalMode = "PRO";
                hallOfFameMode.championshipIDRenewal = ConfigurationManager.AppSettings["renewal.pro.id"].ToString();
                hallOfFameMode.championshipIDBenchRenewal = ConfigurationManager.AppSettings["renewal.pro.id.bench"].ToString();
                hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = String.Empty;
                hallOfFameMode.totalLimitBlackList = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.total.limit.blackList"].ToString());
                hallOfFameMode.totalLimitBanWorldCupUefaEuro = 0;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<RenewalViewModel>().Result;

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
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações PRO. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações PRO. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Renovações PRO: (" + ex.InnerException.Message + ")";
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


        // GET: HallOfFame/RenewalPROSquad
        public ActionResult RenewalPROSquad(FormCollection formHTML)
        {

            HttpResponseMessage response = null;
            RenewalPROCLUBSquadViewModel modelReturnJSON = null;
            RenewalPROCLUBSquadViewModel hallOfFameMode = new RenewalPROCLUBSquadViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "renewalSquad";
                hallOfFameMode.managerID = Convert.ToInt16(formHTML["userID"]); ;
                hallOfFameMode.seasonID = Convert.ToInt16(formHTML["seasonID"]); ;
                hallOfFameMode.clubName = formHTML["clubName"]; ;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;

                modelReturnJSON = response.Content.ReadAsAsync<RenewalPROCLUBSquadViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            string pathImg = "/images/team-logo/"+ modelReturnJSON.clubName + ".jpg";
                            if (System.IO.File.Exists(HttpContext.Server.MapPath(pathImg)))
                                { modelReturnJSON.pathImageClub = pathImg; }
                            else
                                { modelReturnJSON.pathImageClub = ConfigurationManager.AppSettings["path.image.default"].ToString(); }


                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações PRO Squad. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na exibição do Hall da Fama - Renovações PRO Squad. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - Exibindo Hall da Fama - Renovações PRO Squad: (" + ex.InnerException.Message + ")";
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