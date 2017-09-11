//using System;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using FTC.Movida.Admin.Filters;
//using FTC.Movida.ViewModel.Interfaces;
//using FTC.Movida.ViewModel.Param;

//namespace FTC.Movida.Admin.Controllers
//{
//    /// <summary>
//    /// Métodos referentes ao gerenciamento de Resgate Privado
//    /// </summary>
//    [HandleGlobalException]
//    public class ResgatePrivadoController : ApiController
//    {
//        private readonly IResgatePrivadoAppService _resgatePrivadoAppService;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="resgatePrivadoAppService"></param>
//        public ResgatePrivadoController(IResgatePrivadoAppService resgatePrivadoAppService)
//        {
//            _resgatePrivadoAppService = resgatePrivadoAppService;
//        }

//        /// <summary>
//        /// Pesquisa filtrado de Resgate Privado
//        /// </summary>
//        /// <param name="model">Parâmetros para filtro de pesquisa</param>
//        /// <returns>Lista de resgates de Produtos</returns>
//        [BasicAuthorizeAdminWithCpfAttribute]
//        public HttpResponseMessage Get([FromUri] ResgatePrivadoParamViewModel model)
//        {
//            var retorno = _resgatePrivadoAppService.PesquisarVouchersPrivados(model);

//            if (retorno == null)
//            {
//                var log = log4net.LogManager.GetLogger("MovidaAdminCore");
//                log.Info("Info", new Exception("[Resgate Privado] Pesquisa de Vouchers Privados retornando null"));
//            }

//            return retorno == null ? Request.CreateResponse(HttpStatusCode.NotAcceptable, retorno) : Request.CreateResponse(HttpStatusCode.OK, retorno);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        [BasicAuthorizeAdminWithCpfAttribute]
//        [ValidateModel]
//        public HttpResponseMessage Delete([FromBody]ResgatePrivadoEstornoParamViewModel model)
//        {
//            //model.IsPrivate = true;

//            var retorno = _resgatePrivadoAppService.EstornarResgate(model);

//            if (retorno == null || retorno.CodigoErro != 0)
//            {
//                var log = log4net.LogManager.GetLogger("MovidaCore");

//                if (retorno == null)
//                {
//                    log.Error("Error", new Exception("Problema ao deletar voucher"));
//                }
//                else
//                {
//                    log.Error("Error", new Exception(string.Concat(retorno.CodigoErro, " - ", retorno.MensagemDisplay)));
//                }
//            }
//            return retorno == null || retorno.CodigoErro != 0 ? Request.CreateResponse(HttpStatusCode.NotModified, retorno) : Request.CreateResponse(HttpStatusCode.OK, retorno);
//        }
//    }
//}