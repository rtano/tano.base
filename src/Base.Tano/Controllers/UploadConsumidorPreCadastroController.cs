//using System;
//using System.IO;
//using System.Net;
//using System.Net.Http;
//using System.Web;
//using System.Web.Http;
//using FTC.Movida.Admin.Filters;
//using FTC.Movida.ViewModel.Interfaces;
//using FTC.Movida.ViewModel.Param;
//using FTC.Movida.ViewModel.Result;

//namespace FTC.Movida.Admin.Controllers
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [HandleGlobalException]
//    public class UploadConsumidorPreCadastroController : ApiController
//    {
//        private readonly IUploadConsumidorPreCadastroAppService _uploadConsumidorPreCadastroAppService;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="uploadConsumidorPreCadastroAppService"></param>
//        public UploadConsumidorPreCadastroController(IUploadConsumidorPreCadastroAppService uploadConsumidorPreCadastroAppService)
//        {
//            _uploadConsumidorPreCadastroAppService = uploadConsumidorPreCadastroAppService;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        [BasicAuthorizeAdminAttribute]
//        public HttpResponseMessage Post()
//        {
//            var retorno = new DefaultResultViewModel
//            {
//                CodigoErro = 99,
//                MensagemDisplay = "Arquivo não encontrado",
//                MensagemImpressa = "Arquivo não encontrado"
//            };

//            if (HttpContext.Current.Request.Files.Count > 0)
//            {
//                var file = HttpContext.Current.Request.Files[0];
//                var reader = new StreamReader(file.InputStream);

//                var uploadParam = new UploadConsumidorPreParamViewModel { Arquivo = reader };
//                retorno = _uploadConsumidorPreCadastroAppService.ImportarArquivo(uploadParam);
//            }

//            return retorno == null ? Request.CreateResponse(HttpStatusCode.NotAcceptable, retorno) : Request.CreateResponse(HttpStatusCode.OK, retorno);
//        }
//    }
//}