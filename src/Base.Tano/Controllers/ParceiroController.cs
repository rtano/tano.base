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
//    /// Métodos referentes ao gerenciamento de Parceiro
//    /// </summary>
//    [HandleGlobalException]
//    public class ParceiroController : ApiController
//    {
//        private readonly IParceiroAppService _parceiroAppService;

//        /// <summary>
//        /// Método Construtor
//        /// </summary>
//        /// <param name="parceiroAppService">Interface Application Service</param>
//        public ParceiroController(IParceiroAppService parceiroAppService)
//        {
//            _parceiroAppService = parceiroAppService;
//        }

//        /// <summary>
//        /// Cadastro de Parceiro
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        [BasicAuthorizeAdminAttribute]
//        public HttpResponseMessage Post([FromBody] ParceiroViewModel model)
//        {
//            var retorno = _parceiroAppService.Cadastrar(model);
//            return (retorno == null || retorno.CodigoErro == 0) ? Request.CreateResponse(HttpStatusCode.OK, retorno) : Request.CreateResponse(HttpStatusCode.NotAcceptable, retorno);
//        }

//        /// <summary>
//        /// Atualização de Parceiro
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        [BasicAuthorizeAdminAttribute]
//        public HttpResponseMessage Put([FromBody] ParceiroViewModel model)
//        {
//            var retorno = _parceiroAppService.Atualizar(model);
//            return (retorno == null || retorno.CodigoErro == 0) ? Request.CreateResponse(HttpStatusCode.OK, retorno) : Request.CreateResponse(HttpStatusCode.NotAcceptable, retorno);
//        }

//        /// <summary>
//        /// Pesquisa filtrado de Parceiros
//        /// </summary>
//        /// <param name="model">Parâmetros para filtro de pesquisa</param>
//        /// <returns>Lista de parceiros</returns>
//        [BasicAuthorizeAdminAttribute]
//        public HttpResponseMessage Get([FromUri] ParceiroPesquisaParamViewModel model)
//        {
//            var retorno = _parceiroAppService.PesquisarParceiros(model);
            
//            if (retorno == null)
//            {
//                var log = log4net.LogManager.GetLogger("MovidaAdminCore");
//                log.Info("Info", new Exception("[PARCEIRO] Pesquisa de parceiros retornando null"));
//            }

//            return retorno == null ? Request.CreateResponse(HttpStatusCode.NotAcceptable, retorno) : Request.CreateResponse(HttpStatusCode.OK, retorno);
//        }
//    }
//}