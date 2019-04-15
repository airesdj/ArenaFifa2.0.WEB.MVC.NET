using System;
//using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ArenaFifa20.NET.Models;
using ArenaFifa20.NET.Controllers;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

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
                return View(model);
            }

            model.actionUser = "Signin";

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("HomeUser", model).Result;

            returnJSON_UserLoginModel modelReturnJSON = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.Created:
                    if (modelReturnJSON.returnMessage == "loginSuccessfully")
                    {
                        return RedirectToLocal("Index");
                    }
                    else { 
                        if (modelReturnJSON.returnMessage == "loginFailed") { 
                            TempData["returnMessage"] = "Senha inválida! Favor tentar novamente.";
                            ModelState.AddModelError("", "Invalid login attempt.");
                        }
                        else if (modelReturnJSON.returnMessage == "UserNotFound") { 
                            TempData["returnMessage"] = "Usuário não cadastrado ou não está ativo. Favor tentar novamente.";
                            ModelState.AddModelError("", "User not found.");
                        }
                        else if (modelReturnJSON.returnMessage.Substring(0,6) == "error_") { 
                            TempData["returnMessage"] = "Ocorreu algum erro na validação do login. Favor tentar novamente.";
                            ModelState.AddModelError("", "application error.");
                        }
                        return View(model);
                    }
                case HttpStatusCode.NotAcceptable:
                    TempData["returnMessage"] = "Ocorreu algum erro na validação do login. Favor tentar novamente.";
                    ModelState.AddModelError("", "application error.");
                    return View(model);
                default:
                    TempData["returnMessage"] = "Ocorreu algum erro na validação do login. Favor tentar novamente.";
                    ModelState.AddModelError("", "application error.");
                    return View(model);
            }

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
        public ActionResult Register()
        {
            var typeHowFindUs = GetAllTypeHowFindUs();
            var states = GetAllStates();
            var teams = GetAllTeams();
            var model = new RegisterViewModel();
            model.listWhatHowFindUs = GetSelectListItems(typeHowFindUs);
            model.listStates = GetSelectListItems(states);
            model.listTeams = GetSelectListItems(teams);
            return View(model);
            //return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                //var result = await UserManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                  //  return RedirectToAction("Index", "Home");
                //}
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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


        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = await UserManager.FindByNameAsync(model.Email);
                //if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                //{
                    // Don't reveal that the user does not exist or is not confirmed
                 //   return View("ForgotPasswordConfirmation");
               // }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var user = await UserManager.FindByNameAsync(model.Email);
            //if (user == null)
            //{
                // Don't reveal that the user does not exist
            //    return RedirectToAction("ResetPasswordConfirmation", "Account");
            //}
            //var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            //if (result.Succeeded)
            //{
            //    return RedirectToAction("ResetPasswordConfirmation", "Account");
            //}
            //AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
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