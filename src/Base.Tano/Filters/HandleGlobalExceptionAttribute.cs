using System.Web.Http.Filters;

namespace FTC.Movida.Admin.Filters
{
    /// <summary>
    /// Atributo para criação de log de erro da aplicação
    /// </summary>
    public class HandleGlobalExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var log = log4net.LogManager.GetLogger("MovidaAdminCore");

            if (log.IsErrorEnabled)
                log.Error("Erro", actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
        }
    }
}