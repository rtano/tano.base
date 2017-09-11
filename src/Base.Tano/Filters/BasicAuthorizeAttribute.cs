using System;
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
    /// <summary>
    /// 
    /// </summary>
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
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
            var start = DateTime.Now;
            AutenticacaoApplicationService =
                ((BasicAuthorizeAttribute)
                    GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(BasicAuthorizeAttribute)))
                    .AutenticacaoApplicationService;

            if (AutenticacaoApplicationService == null)
                return;

            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null)
            {
                var rawCredentials = authHeader.Parameter;
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));

                var split = credentials.Split(new[] { ':' }, 2);
                var userName = split[0];
                var password = split[1];

                //var consumidorAutenticacao = AutenticacaoApplicationService.Autenticar(new AutenticacaoViewModel { Cpf = userName, Senha = password });
                //if (consumidorAutenticacao != null && !string.IsNullOrWhiteSpace(consumidorAutenticacao.Cpf))
                //{
                //    var principal = new GenericPrincipal(new GenericIdentity(consumidorAutenticacao.Cpf), null);
                //    Thread.CurrentPrincipal = principal;
                //    return;
                //}
            }
            HandleUnauthorized(actionContext, HttpStatusCode.Unauthorized);
        }

        private void HandleUnauthorized(HttpActionContext actionContext, HttpStatusCode httpStatusCode)
        {
            actionContext.Response = actionContext.Request.CreateResponse(httpStatusCode);
        }
    }
}