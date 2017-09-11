using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
//using FTC.Movida.ViewModel.Interfaces;
//using FTC.Movida.ViewModel.Param;
using Microsoft.Practices.Unity;

namespace FTC.Movida.Admin.Filters
{
    public interface IAutenticacaoAppService
    {
        //AutenticacaoResultViewModel Autenticar(AutenticacaoViewModel param);
        //AutenticacaoResultViewModel AutenticarJuridico(AutenticacaoJuridicoViewModel param);
    }

    /// <summary>
    /// 
    /// </summary>
    public class BasicAuthorizeAdminAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        [Dependency]
        public IAutenticacaoAppService AutenticacaoApplicationService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AutenticacaoApplicationService =
                ((BasicAuthorizeAdminAttribute)
                    GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(BasicAuthorizeAdminAttribute)))
                    .AutenticacaoApplicationService;


            var cookies = actionContext.Request.Headers.GetCookies().Any() ? actionContext.Request.Headers.GetValues("Cookie") : null;

            if (cookies != null)
            {
                string basic = "";
                foreach (var item in cookies)
                {
                    if (item.IndexOf("relatorio=", System.StringComparison.Ordinal) >= 0)
                    {
                        basic = basic + item.Substring(item.IndexOf("relatorio=", System.StringComparison.Ordinal) + 10);
                        basic = basic.Substring(0, basic.IndexOf(";") >= 0 ? basic.IndexOf(";") : basic.Length);
                        var rawCredentials = basic;
                        var encoding = Encoding.GetEncoding("iso-8859-1");
                        var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));

                        var split = credentials.Split(new[] { ':' }, 2);
                        var userName = split[0];
                        var password = split[1];
                        //var consumidorAutenticacao =
                        //    AutenticacaoApplicationService.AutenticarJuridico(
                        //        new AutenticacaoJuridicoViewModel { Cnpj = userName, Senha = password });
                        //if (consumidorAutenticacao != null && !string.IsNullOrWhiteSpace(consumidorAutenticacao.Cpf))
                        //{
                        //    var principal = new GenericPrincipal(new GenericIdentity(consumidorAutenticacao.Cpf), null);
                        //    Thread.CurrentPrincipal = principal;
                        //    return;
                        //}
                        HandleUnauthorized(actionContext, HttpStatusCode.Unauthorized);
                        break;
                    }
                }
            }
            HandleUnauthorized(actionContext, HttpStatusCode.Unauthorized);
        }

        private void HandleUnauthorized(HttpActionContext actionContext, HttpStatusCode httpStatusCode)
        {
            actionContext.Response = actionContext.Request.CreateResponse(httpStatusCode);
        }
    }
}