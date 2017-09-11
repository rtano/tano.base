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
//    /// 
//    /// </summary>
//    [HandleGlobalException]
//    public class TesteChamadaApiController : ApiController
//    {
//        private readonly ITesteChamadaApiAppService _testeChamadaApiAppService;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="testeChamadaApiAppService"></param>
//        public TesteChamadaApiController(ITesteChamadaApiAppService testeChamadaApiAppService)
//        {
//            _testeChamadaApiAppService = testeChamadaApiAppService;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        [BasicAuthorizeAdminAttribute]
//        public HttpResponseMessage Get()
//        {
//            var retorno = _testeChamadaApiAppService.Get();

//            if (retorno == null)
//            {
//                var log = log4net.LogManager.GetLogger("MovidaAdminCore");
//                log.Info("Info", new Exception("[TesteChamadaApi] retorno null"));
//            }

//            return retorno == null ? Request.CreateResponse(HttpStatusCode.NotAcceptable, retorno) : Request.CreateResponse(HttpStatusCode.OK, retorno);
//        }
//    }
//}