﻿using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ArenaFifa20.NET.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Configuration;
using SYSEmail;
using static ArenaFifa20.NET.App_Start.CheckSessionTimeOut;

namespace ArenaFifa20.NET.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Signin
        [AllowAnonymous]
        public ActionResult Signin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Signin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signin(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModeState is invalid";
                return View(model);
            }

            HttpResponseMessage response = null;
            returnJSON_UserLoginModel modelReturnJSON = null;

            try
            {

                model.actionUser = "Signin";

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HomeUser", model).Result;

                modelReturnJSON = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "loginSuccessfully")
                        {
                            Session["session.active"] = true;
                            Session["user.id"] = modelReturnJSON.id.ToString();
                            Session["user.name"] = modelReturnJSON.name.ToString();
                            Session["user.psnID"] = modelReturnJSON.psnID.ToString();
                            Session["user.isModerator"] = modelReturnJSON.userModerator;
                            Session["user.dtLastAccess"] = modelReturnJSON.lastAccess.ToString();
                            Session["user.dsEmail"] = modelReturnJSON.email.ToString();
                            Session["user.currentTeam"] = modelReturnJSON.currentTeam.ToString();
                            Session["user.totalTitlesWon"] = modelReturnJSON.totalTitlesWon.ToString();
                            Session["user.totalVices"] = modelReturnJSON.totalVices.ToString();

                            Session["user.pathAvatar"] = ConfigurationManager.AppSettings["avatar.path.default"].ToString();

                            string new_path_atavar = ConfigurationManager.AppSettings["avatar.path.coach"].ToString() + "/" +
                                                     modelReturnJSON.id.ToString() + ".jpg";

                            if (System.IO.File.Exists(HttpContext.Server.MapPath(new_path_atavar))) { Session["user.pathAvatar"] = new_path_atavar; }

                            return RedirectToLocal("Index");
                        }
                        else
                        {
                            if (modelReturnJSON.returnMessage == "loginFailed")
                            {
                                TempData["returnMessage"] = "Senha inválida! Favor tentar novamente.";
                                ModelState.AddModelError("", "Invalid login attempt.");
                            }
                            else if (modelReturnJSON.returnMessage == "UserNotFound")
                            {
                                TempData["returnMessage"] = "Usuário não cadastrado ou não está ativo. Favor tentar novamente.";
                                ModelState.AddModelError("", "User not found.");
                            }
                            else if (modelReturnJSON.returnMessage.Substring(0, 6) == "error_")
                            {
                                TempData["returnMessage"] = "Ocorreu algum erro na validação do login. Favor tentar novamente.";
                                ModelState.AddModelError("", "application error.");
                            }
                            return View(model);
                        }
                    case HttpStatusCode.NotAcceptable:
                        TempData["returnMessage"] = "Ocorreu algum erro não aceitável na validação do login. Favor tentar novamente.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na validação do login. Favor tentar novamente.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - validando login do usuário: ("+ex.InnerException.Message+")";
                ModelState.AddModelError("", "application error.");
                return View(model);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }

        }

        //
        // GET: /Account/Signout
        [AllowAnonymous]
        public ActionResult Signout(string returnUrl)
        {
            Session.Abandon();
            ViewBag.ReturnUrl = returnUrl;
            return RedirectToLocal("Index");
        }

        //
        // GET: /Account/ChangePassword
        [AllowAnonymous]
        [SessionTimeout]
        public ActionResult ChangePassword(string returnUrl)
        {
            //model.id = Session["user.id"].ToString();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [SessionTimeout]
        public async Task<ActionResult> ChangePassword(ChangePassWDViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModeState is invalid";
                return View(model);
            }

            HttpResponseMessage response = null;
            returnJSON_UserLoginModel modelReturnJSON = null;

            try
            {

                TempData["serverValidation"] = "0";
                TempData["current_password"] = model.current_password;
                TempData["password"] = model.password;
                TempData["confirm_password"] = model.confirm_password;

                if (!string.IsNullOrEmpty(model.current_password) && !string.IsNullOrEmpty(model.password) && model.current_password == model.password)
                {
                    ModelState.AddModelError("current_password", "Os campos Senha Atual e Nova Senha são iguais.");
                    TempData["serverValidation"] = "1";
                    return View(model);
                }
                else {

                    TempData["serverValidation"] = "0";
                    model.id = Session["user.id"].ToString();
                    model.actionUser = "ChangePassword";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("HomeUser", model).Result;

                    modelReturnJSON = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Created:
                            if (modelReturnJSON.returnMessage == "changedSuccessfully")
                            {
                                return RedirectToAction("ChangePasswordConfirmation", "Account");
                            }
                            else if (modelReturnJSON.returnMessage == "loginFailed")
                            {
                                ModelState.AddModelError("current_password", "Senha Atual inválida! Favor tentar novamente.");
                                TempData["serverValidation"] = "1";
                                return View(model);
                            }
                            else
                            {
                                //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                                TempData["returnMessage"] = "Ocorreu algum erro na alteração da senha. ("+modelReturnJSON.returnMessage+")";
                                return View(model);
                            }
                        case HttpStatusCode.NotAcceptable:
                            TempData["returnMessage"] = "Ocorreu algum erro não aceitável na alteração da senha. Favor tentar novamente.";
                            ModelState.AddModelError("", "application error.");
                            return View(model);
                        default:
                            TempData["returnMessage"] = "Ocorreu algum erro na alteração da senha. (" + response.StatusCode + ")";
                            ModelState.AddModelError("", "application error.");
                            return View(model);
                    }

                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - alterando a senha do usuário: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }

        }


        //
        // GET: /Account/ChangePasswordConfirmation
        [AllowAnonymous]
        public ActionResult ChangePasswordConfirmation()
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            Session["session.active"] = false;
            return View();
        }

        //
        // GET: /Account/UpdateConfirmation
        [AllowAnonymous]
        public ActionResult UpdateConfirmation()
        {
            return View();
        }

        private IEnumerable<string> GetAllModes()
        {
            return new List<string>
            {
                "H2H E/OU FUT","APENAS PRO CLUB"
            };
        }

        private IEnumerable<string> GetAllTypeHowFindUs()
        {
            return new List<string>
            {
                "INTERNET","AMIGOS","BANNER","SITE DE BUSCA","FACEBOOK","OUTROS"
            };
        }

        private IEnumerable<string> GetAllStates()
        {
            return new List<string>
            {
                "Acre","Alagoas","Amapá","Amazonas","Bahia","Ceará","Distrito Federal","Espírito Santo","Goiás","Maranhão","Mato Grosso do Sul","Minas Gerais","Pará","Paraíba","Paraná","Pernambuco","Piauí","Rio de Janeiro","Rio Grande do Norte","Rio Grande do Sul","Rondônia","Roraima","Santa Catarina","São Paulo","Sergipe","Tocantins"
            };
        }

        private IEnumerable<string> GetAllTeams()
        {
            return new List<string>
            {
                "ABC-RN","Adap-PR","Alagoinhas-AL","Alecrim-RN","América-MG","América-RJ","Americano-RJ","América De Natal-RN","ASA-AL","Atlético-GO","Atlético-MG","Atlético-PR","Avaí-SC","Bahia-BA","Bangu-RJ","Baraúnas-RN","Baré-RR","Boa Vista-RJ","Botafogo-PB","Botafogo-RJ","Bragantino-SP","Brasiliense-DF","Cabofriense-RJ","Cajazeiras-PB","Camaçari-BA","Campinense-PB","Cascavel-PR","Caxias-RS","Ceará-CE","Ceilândia-DF","Central-PE","Chapecoense-SC","Colo Colo-BA","Corinthians-AL","Corinthians-SP","Coritiba-PR","CRAC-GO","Criciúma-SC","Cruzeiro-MG","Duque De Caxias-RJ","Esportivo-RS","Figueirense-SC","Flamengo-PI","Flamengo-RJ","Fluminense-BA","Fluminense-RJ","Fortaleza-CE","Gama-DF","Goiás-GO","Grêmio-AC","Grêmio-MT","Grêmio-RS","Grêmio Prudente-SP","Guarani-SP","Internacional-RS","Ipatinga-MG","Iraty-PR","Itapipoca-CE","Ituiutaba-MG","J. Maluceli-PR","Ji Paraná-PR","Joinville-SC","Juazeiro-BA","Juventude-RS","Juventus-SP","Linhares-SE","Londrina-PR","Luverdense-MT","Macaé-RJ","Madureira-RJ","Marília-SP","Moto Clube-SE","Nacional-AM","Náutico-PE","Nova Iguaçu-RJ","Palmas-TO","Palmeiras-SP","Paraná-PR","Payssandú-PA","Ponte Preta-SP","Portuguesa-SP","Poções-BA","Porto-PE","Rio Branco-AC","Rio Claro-SP","Roraima-RO","Salgueiro-PE","Santo André-SP","Santos-SP","São_Caetano","São José-RS","São Paulo-SP","São Raimundo-PA","Serra-ES","Serrano-PE","Sertãozinho-SP","Sport-PE","Tigres do Brasil-RJ","Tocantinópolis-TO","Treze-PB","Tupi-MG","Ulbra-RS","União Rondonópolis-RO","União-MT","Vasco-RJ","Veranópolis-RS","Vila Nova-GO","Vila_Nova-MG","Vitória-BA","Volta Redonda-RJ"
            };
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
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

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            RegisterViewModel model = new RegisterViewModel();
            ViewBag.ReturnUrl = returnUrl;
            CreateListsToFormRegister(model);
            return View(model);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModeState is invalid";
                return View(model);
            }

            CreateListsToFormRegister(model);

            HttpResponseMessage response = null;
            returnJSON_UserLoginModel modelReturnJSON = null;
            systemEmail objEmail = new systemEmail();

            try
            {
                model.actionUser = "Register";
                model.userActive = true;
                model.userModerator = false;

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HomeUser", model).Result;

                modelReturnJSON = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "registerSuccessfully")
                        {
                            objEmail.SendEmail(getBodyHtmlRegister(model), model.Email, "CONTACT-US", "Cadastro Efetuado");

                            return RedirectToAction("RegisterConfirmation", "Account");
                        }
                        else if (modelReturnJSON.returnMessage == "PsnFound")
                        {
                            ModelState.AddModelError("psnID", "Já existe um outro usuário com a mesma PSN informada.");
                            return View(model);
                        }
                        else if (modelReturnJSON.returnMessage == "NameFound")
                        {
                            ModelState.AddModelError("name", "Já existe um outro usuário com o mesmo NOME informado.");
                            return View(model);
                        }
                        else if (modelReturnJSON.returnMessage == "EmailFound")
                        {
                            ModelState.AddModelError("Email", "Já existe um outro usuário com o mesmo E-MAIL informado.");
                            return View(model);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na geração de un novo cacdastro. (" + modelReturnJSON.returnMessage + ")";
                            return View(model);
                        }
                    case HttpStatusCode.NotAcceptable:
                        TempData["returnMessage"] = "Ocorreu algum erro não aceitável na geração de un novo cacdastro. Favor tentar novamente.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na geração de un novo cacdastro. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - geração de un novo cacdastro: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                objEmail = null;

            }

        }

        // GET: /Account/Update
        [AllowAnonymous]
        [SessionTimeout]
        public ActionResult Update(string returnUrl)
        {
            RegisterViewModel model = new RegisterViewModel();
            HttpResponseMessage response = null;
            returnJSON_UserLoginModel modelReturnJSON = null;
            ViewBag.ReturnUrl = returnUrl;


            try
            {
                CreateListsToFormRegister(model);

                response = GlobalVariables.WebApiClient.GetAsync("HomeUser/"+Session["user.id"].ToString()).Result;
                modelReturnJSON = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

                model.id = modelReturnJSON.id;
                model.name = modelReturnJSON.name;
                model.psnID = modelReturnJSON.psnID;
                model.birthday = modelReturnJSON.birthday;
                model.Email = modelReturnJSON.email;
                model.howfindus = modelReturnJSON.howfindus;
                model.whathowfindus = modelReturnJSON.whatkindofmedia;
                model.team = modelReturnJSON.team;
                model.state = modelReturnJSON.state;
                model.inEmailWarning = Convert.ToBoolean(modelReturnJSON.receiveWarningEachRound);
                model.inEmailTeamTable = Convert.ToBoolean(modelReturnJSON.receiveTeamTable);
                model.inParticipate = Convert.ToBoolean(modelReturnJSON.wishParticipate);
                model.userModerator = modelReturnJSON.userModerator;
                return View(model);

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - exibição da tela de alteração de dados de cacdastro: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);

            }
            finally
            {
                model = null;
                response = null;
                modelReturnJSON = null;

            }

        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [SessionTimeout]
        public async Task<ActionResult> Update(RegisterViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Message = "ModeState is invalid";
            //    return View(model);
            //}

            CreateListsToFormRegister(model);

            HttpResponseMessage response = null;
            RegisterViewModel modelReturnJSON = null;
            systemEmail objEmail = new systemEmail();

            try
            {
                model.actionUser = "Update";
                model.userActive = true;
                model.idUserOperation = Convert.ToUInt16(Session["user.id"]);
                model.psnOperation = Session["user.psnID"].ToString();
                model.psnRegister = Session["user.psnID"].ToString();

                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HomeUser", model).Result;

                modelReturnJSON = response.Content.ReadAsAsync<RegisterViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "updateSuccessfully")
                        {
                            return RedirectToAction("UpdateConfirmation", "Account");
                        }
                        else if (modelReturnJSON.returnMessage == "PsnFound")
                        {
                            ModelState.AddModelError("psnID", "Já existe um outro usuário com a mesma PSN informada.");
                            return View(model);
                        }
                        else if (modelReturnJSON.returnMessage == "NameFound")
                        {
                            ModelState.AddModelError("name", "Já existe um outro usuário com o mesmo NOME informado.");
                            return View(model);
                        }
                        else if (modelReturnJSON.returnMessage == "EmailFound")
                        {
                            ModelState.AddModelError("Email", "Já existe um outro usuário com o mesmo E-MAIL informado.");
                            return View(model);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Ocorreu algum erro na alteração de dados de cacdastro. (" + modelReturnJSON.returnMessage + ")";
                            return View(model);
                        }
                    case HttpStatusCode.NotAcceptable:
                        TempData["returnMessage"] = "Ocorreu algum erro não aceitável na alteração de dados de cacdastro. Favor tentar novamente.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro naalteração de dados de cacdastro. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - alteração de dados de cacdastro: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                objEmail = null;

            }

        }

        private void CreateListsToFormRegister(RegisterViewModel model)
        {
            model.listWhatHowFindUs = GetSelectListItems(GetAllTypeHowFindUs());
            model.listStates = GetSelectListItems(GetAllStates());
            model.listTeams = GetSelectListItems(GetAllTeams());
            model.listModes = GetSelectListItems(GetAllModes());
        }

        private string getBodyHtmlRegister(RegisterViewModel model)
        {

            string strBodyHtml = string.Empty;


            strBodyHtml = strBodyHtml + "<span style='PADDING-RIGHT: 0px;PADDING-LEFT: 0px;FONT-SIZE: 11px;PADDING-BOTTOM: 0px;MARGIN: 0px;COLOR: #333333;PADDING-TOP: 0px;BACKGROUND-REPEAT: repeat-x;FONT-FAMILY: Arial, Helvetica, sans-serif;TEXT-ALIGN: left'>";
            strBodyHtml = strBodyHtml + "<p>Olá " + model.name + ",<br><br></p>";
            strBodyHtml = strBodyHtml + "<span style='font-size:16px;font-family:Verdana;color:red'><b>O Sistema acaba de efetuar seu cadastro no site Arena Fifa.</b></span>";
            strBodyHtml = strBodyHtml + "<br><br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:12px;font-family:Verdana;color:blue'><b>Dados Cadastrais:</b></span>";
            strBodyHtml = strBodyHtml + "<br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>PSN ID:</b>&nbsp;&nbsp;" + model.psnID + "</span>";
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>E-mail:</b>&nbsp;&nbsp;" + model.Email + "</span>";
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Data de Nascimento:</b>&nbsp;&nbsp;" + model.birthday.ToString("dd/MM/yyyy") + "</span>";
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>E-mail:</b>&nbsp;&nbsp;" + model.state + "</span>";
            strBodyHtml = strBodyHtml + "<br>";
            if (model.inEmailWarning)
            {
                strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Deseja receber e-mails de alerta de fechamento da rodada.</b></span>";
            }
            else
            {
                strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>NÃO Deseja receber e-mails de alerta de fechamento da rodada.</b></span>";
            }
            strBodyHtml = strBodyHtml + "<br>";
            if (model.inEmailTeamTable)
            {
                strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Deseja receber e-mails de informe sobre a classificação dos participantes após a última rodada.</b></span>";

            }
            else
            {
                strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>NÃO Deseja receber e-mails de informe sobre a classificação dos participantes após a última rodada.</b></span>";
            }
            strBodyHtml = strBodyHtml + "<br>";
            if (model.inParticipate)
            {
                strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Deseja participar dos campeonatos disponíveis.</b></span>";
            }
            else
            {
                strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>NÃO Deseja receber e-mails de informe sobre a classificação dos participantes após a última rodada.</b></span>";
            }
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Como ficou sabendo do Arena Fifa?</b>&nbsp;&nbsp;" + model.howfindus + "</span>";
            if (model.whathowfindus != string.Empty)
            {
                strBodyHtml = strBodyHtml + "<br>";
                strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Qual?</b>&nbsp;&nbsp;" + model.whathowfindus + "</span>";
            }
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Time Escolhido:</b>&nbsp;&nbsp;" + model.team + "</span>";
            strBodyHtml = strBodyHtml + "<br><br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:12px;font-family:Verdana;color:blue'><b>Como participar dos campeonatos ?</b></span>";
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Nosso site tem como objetivo despertar o interesse competir com diversas pessoas e que todos possam se divertir de forma sadia.</b></span>";
            strBodyHtml = strBodyHtml + "<br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>A participação é totalmente gratuita</b></span>";
            strBodyHtml = strBodyHtml + "<br><br>";
            strBodyHtml = strBodyHtml + "<center>";
            strBodyHtml = strBodyHtml + "<br><br><br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:black'><b>Para acessar, entre em </b>&nbsp;&nbsp;<a href='http://www.arenafifa.com.br/'>http://www.arenafifa.com.br/</a></span>";
            strBodyHtml = strBodyHtml + "<br><br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:10px;font-family:Verdana;color:blue'><b>O Regulamento do Site e dos Campeonatos se encontram em nosso portal, visite e conheça um pouco mais dos campeonatos que estamos disponibilizando.</b></span>";
            strBodyHtml = strBodyHtml + "<br><br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:16px;font-family:Verdana;color:red'><b>Obrigado e Boa Sorte!!!</b></span>";
            strBodyHtml = strBodyHtml + "<br><br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:12px;font-family:Verdana;color:black'>Atenciosamente,</span>";
            strBodyHtml = strBodyHtml + "<br><br>";
            strBodyHtml = strBodyHtml + "<span style='font-size:12px;font-family:Verdana;color:black'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SAC ARENA FIFA</span>";
            strBodyHtml = strBodyHtml + "<br><br>";
            strBodyHtml = strBodyHtml + "</center>";
            strBodyHtml = strBodyHtml + "</span>";

            return strBodyHtml;

        }
        //
        // GET: /Account/RegisterConfirmation
        [AllowAnonymous]
        public ActionResult RegisterConfirmation()
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            Session["session.active"] = false;
            return View();
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            //var result = await UserManager.ConfirmEmailAsync(userId, code);
            //return View(result.Succeeded ? "ConfirmEmail" : "Error");
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (_userManager != null)
                //{
                //    _userManager.Dispose();
                //    _userManager = null;
                //}

                //if (_signInManager != null)
                //{
                //    _signInManager.Dispose();
                //    _signInManager = null;
                //}
            }

            base.Dispose(disposing);
        }



        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}