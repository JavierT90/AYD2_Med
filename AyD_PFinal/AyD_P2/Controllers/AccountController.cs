using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AyD_P2.Models;

namespace AyD_P2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        PROYECTOEntities db = new PROYECTOEntities();
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (Session["codigo_usuario"] != null)
            {
                    Session.Abandon();
            }
           
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel modelo)
        {
            using (PROYECTOEntities db = new PROYECTOEntities())
            {
                
                if (!existeUsuario(modelo.Usuario, modelo.Password) )
                {
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View();
                }else
                {
                    var usuario = db.USUARIO.Where(x => x.usuario1 == modelo.Usuario && x.pass == modelo.Password).FirstOrDefault();

                    Session["codigo_usuario"] = usuario.id_usuario;
                    Session["usuario"] = usuario.usuario1;
                    Session["tipo_usuario"] = usuario.tipo;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                    
                }
            }
        }

        public bool existeUsuario(string us, string pass)
        {
            var usuario = db.USUARIO.Where(x => x.usuario1 == us && x.pass == pass).FirstOrDefault();

            if (usuario != null)
            {
                return true;
            }
            return false;
        }


        //------------------------------------------------------------------------------
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (Session["codigo_usuario"] != null)
            {
                Session.Abandon();
            }
            return View();
        }
        
        //------------------------------------------------------------------------------
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel modelo)
        {
            using (PROYECTOEntities db = new PROYECTOEntities())
            {
                
                if (usuarioNoDuplicado(modelo.Usuario, modelo.Tipo)) //usuario no duplicado
                {
                    if(creaUsuario(modelo.Usuario, modelo.Password, modelo.Tipo)) {
                        ModelState.AddModelError("", "Usuario creado");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Usuario ya existe");
                }
                        
            }
                    
            
            return View();
        }

        public bool usuarioNoDuplicado(string us, int stipo)
        {
            var usuario = db.USUARIO.Where(x => x.usuario1 == us && x.tipo == stipo).FirstOrDefault();
            if(usuario == null)
            {
                return true;
            }

            return false;
        }

        public bool creaUsuario(string usuario, string password, int stipo)
        {
            db.USUARIO.Add(new USUARIO
            {
                usuario1 = usuario,
                pass = password,
                tipo = stipo
            });
            db.SaveChanges();

            return true;
        }



        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
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

        [AllowAnonymous]
        public ActionResult Logout(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            /*if (Session["codigo_usuario"] != null)
            {
                Session.Abandon();
            }*/

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            if (sesionActiva(Session["codigo_usuario"]))
            {
                Session.Abandon();
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public bool sesionActiva(object v)
        {
            if (v != null)
            {
                return true;

            }
            else
                return false;
        }
        #endregion
    }
}