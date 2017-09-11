using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tano.EntityFramework
{
    public class PageResult<T>
    {
        public PageResult()
        {
            Items = new List<T>();
        }
        public IList<T> Items { get; set; }
        public int Count { get; set; }
    }

    public class Parceiro 
    {
        public int? Id { get; set; }
        public int? IdParceiroWordpress { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool? Ativo { get; set; }
    }

    public class DefaultPesquisaParam
    {
        public int? Skip { get; set; }
        public int? Top { get; set; }
        public string Ordenacao { get; set; }
        public string Order { get; set; }
    }
    public class ParceiroPesquisaParam : DefaultPesquisaParam
    {
        public int? IdParceiro { get; set; }
        public int? IdParceiroWordpress { get; set; }
        public string Context { get; set; }
        public bool? Ativo { get; set; }
    }

    public class DefaultResult
    {
        public string MensagemDisplay { get; set; }
        public string MensagemImpressa { get; set; }
        public int? CodigoErro { get; set; }
    }
    public class ParceiroResult : DefaultResult
    {
        public int? Id { get; set; }
    }
    public class ParceiroPesquisaResult
    {
        public int? Id { get; set; }
        public int? IdParceiroWordpress { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool? Ativo { get; set; }
        public int TotalRegistro { get; set; }
    }



    public interface IParceiroRepository : IBaseRepository<Parceiro>
    {
        ParceiroResult Cadastrar(Parceiro param);
        DefaultResult AtualizarParceiro(Parceiro param);
        PageResult<ParceiroPesquisaResult> PesquisarParceiros(ParceiroPesquisaParam param);

        //DefaultResult AlterarInserirEmailComunicacao(EmailComunicacaoParceiroParam param);
        //DefaultResult DesativarEmailComunicacao(EmailComunicacaoParceiroParam param);
        //IEnumerable<EmailComunicacaoParceiroPesquisaResult> PesquisarEmailComunicacao(EmailComunicacaoParceiroPesquisaParam param);
    }

    public class ParceiroRepository : BaseRepositorio<Parceiro>, IParceiroRepository
    {
        public ParceiroRepository()
        {
            Initialize();
        }

        public ParceiroResult Cadastrar(Parceiro param)
        {
            var parametros = new Dictionary<object, object>
            {
                {"@Descricao", string.IsNullOrEmpty(param.Descricao) ? (object) DBNull.Value : param.Descricao},
                {"@IdParceiroWordpress", param.IdParceiroWordpress ?? (object) DBNull.Value},
            };

            return ExecuteProcedureWithoutType<ParceiroResult>(new RepositoryParam
            {
                Params = parametros,
                ProcedureName = "Inserir_Parceiro"
            }).FirstOrDefault();
        }

        public DefaultResult AtualizarParceiro(Parceiro param)
        {
            var parametros = new Dictionary<object, object>
            {
                {"@IdParceiro", param.Id},
                {"@IdParceiroWordpress", param.IdParceiroWordpress ?? (object) DBNull.Value},
                {"@Descricao", string.IsNullOrEmpty(param.Descricao) ? (object) DBNull.Value : param.Descricao},
                {"@Ativo", param.Ativo ?? (object) DBNull.Value}
            };

            return ExecuteProcedureWithoutType<DefaultResult>(new RepositoryParam
            {
                Params = parametros,
                ProcedureName = "Alterar_Parceiro"
            }).FirstOrDefault();
        }

        public PageResult<ParceiroPesquisaResult> PesquisarParceiros(ParceiroPesquisaParam param)
        {
            var parametros = new Dictionary<object, object>
            {
                {"@IdParceiro", param.IdParceiro ?? (object) DBNull.Value},
                {"@IdParceiroWordpress", param.IdParceiroWordpress ?? (object) DBNull.Value},
                {"@Context", string.IsNullOrEmpty(param.Context) ? (object) DBNull.Value : param.Context},
                {"@Ativo", param.Ativo ?? (object) DBNull.Value},
                {"@Skip", param.Skip ?? (object) "0"},
                {"@Top", param.Top ?? (object) "99"},
                {"@Ordenacao", string.IsNullOrEmpty(param.Ordenacao) ? "Parceiro" : param.Ordenacao},
                {"@Order", string.IsNullOrEmpty(param.Order) ? "ASC" : param.Order}
            };

            var parceiros = ExecuteProcedureWithoutType<ParceiroPesquisaResult>(new RepositoryParam
            {
                Params = parametros,
                ProcedureName = "Consultar_Parceiro"
            });

            var parceirosResult = parceiros as IList<ParceiroPesquisaResult> ?? parceiros.ToList();

            var resultPage = new PageResult<ParceiroPesquisaResult>();

            if (parceirosResult.Any())
            {
                var parceiroPesquisaResult = parceirosResult.FirstOrDefault();
                if (parceiroPesquisaResult != null)
                    resultPage.Count = parceiroPesquisaResult.TotalRegistro;
                resultPage.Items = parceirosResult.ToList();
            }

            return resultPage;
        }



        //public DefaultResult AlterarInserirEmailComunicacao(EmailComunicacaoParceiroParam param)
        //{
        //    var parametros = new Dictionary<object, object>
        //    {
        //        {"@IdParceiro", param.IdParceiro},
        //        {"@Emails", string.IsNullOrEmpty(param.Emails) ? (object) DBNull.Value : param.Emails},
        //        {"@Descricao", string.IsNullOrEmpty(param.Descricao) ? (object) DBNull.Value : param.Descricao}

        //    };

        //    return ExecuteProcedureWithoutType<DefaultResult>(new RepositoryParam
        //    {
        //        Params = parametros,
        //        ProcedureName = "Alterar_Inserir_Email_ComunicacaoParceiro"
        //    }).FirstOrDefault();
        //}

        //public DefaultResult DesativarEmailComunicacao(EmailComunicacaoParceiroParam param)
        //{
        //    var parametros = new Dictionary<object, object>
        //    {
        //        {"@IdParceiro", param.IdParceiro},
        //        {"@Emails", string.IsNullOrEmpty(param.Emails) ? (object) DBNull.Value : param.Emails}
        //    };

        //    return ExecuteProcedureWithoutType<DefaultResult>(new RepositoryParam
        //    {
        //        Params = parametros,
        //        ProcedureName = "Deletar_Email_ComunicacaoParceiro"
        //    }).FirstOrDefault();
        //}

        //public IEnumerable<EmailComunicacaoParceiroPesquisaResult> PesquisarEmailComunicacao(
        //    EmailComunicacaoParceiroPesquisaParam param)
        //{
        //    var parametros = new Dictionary<object, object>
        //    {
        //        {"@IdParceiro", param.IdParceiro ?? (object) DBNull.Value},
        //        {"@Ativo", param.Ativo ?? (object) DBNull.Value}
        //    };

        //    var emails = ExecuteProcedureWithoutType<EmailComunicacaoParceiroPesquisaResult>(new RepositoryParam
        //    {
        //        Params = parametros,
        //        ProcedureName = "Consultar_Emails_ComunicacaoParceiro"
        //    });

        //    return emails;
        //}
    }
}