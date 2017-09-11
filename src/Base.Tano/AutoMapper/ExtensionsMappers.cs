using System.Collections.Generic;
//using AutoMapper;
//using FTC.Movida.Model.Entity;
//using FTC.Movida.Model.Param;
//using FTC.Movida.Model.Result;
//using FTC.Movida.ViewModel.Param;
//using FTC.Movida.ViewModel.Result;

namespace FTC.Movida.ModelMapper
{
    public static class ExtensionsMappers
    {
        static ExtensionsMappers()
        {
            AutoMapperConfiguration.Configure();
        }

        //#region Default
        //public static DefaultResultViewModel ToViewModel(this DefaultResult model)
        //{
        //    return Mapper.Map<DefaultResult, DefaultResultViewModel>(model);
        //}
        //#endregion

        //#region Auth
        //public static AutenticacaoResultViewModel ToViewModel(this ConsumidorAutenticacaoResult model)
        //{
        //    return Mapper.Map<ConsumidorAutenticacaoResult, AutenticacaoResultViewModel>(model);
        //}
        //#endregion

        //#region Parceiro
        //public static Parceiro ToDomain(this ParceiroViewModel model)
        //{
        //    return Mapper.Map<ParceiroViewModel, Parceiro>(model);
        //}
        //public static ParceiroPesquisaParam ToDomain(this ParceiroPesquisaParamViewModel model)
        //{
        //    return Mapper.Map<ParceiroPesquisaParamViewModel, ParceiroPesquisaParam>(model);
        //}
        //public static ParceiroResultViewModel ToViewModel(this ParceiroResult model)
        //{
        //    return Mapper.Map<ParceiroResult, ParceiroResultViewModel>(model);
        //}
        //public static IEnumerable<ParceiroPesquisaResultViewModel> ToViewModel(this IEnumerable<ParceiroPesquisaResult> model)
        //{
        //    return Mapper.Map<IEnumerable<ParceiroPesquisaResult>, IEnumerable<ParceiroPesquisaResultViewModel>>(model);
        //}
        //#endregion

        //#region GrupoProduto
        //public static GrupoProduto ToDomain(this GrupoProdutoViewModel model)
        //{
        //    return Mapper.Map<GrupoProdutoViewModel, GrupoProduto>(model);
        //}
        //public static GrupoProdutoPesquisaParam ToDomain(this GrupoProdutoPesquisaParamViewModel model)
        //{
        //    return Mapper.Map<GrupoProdutoPesquisaParamViewModel, GrupoProdutoPesquisaParam>(model);
        //}
        //public static GrupoProdutoResultViewModel ToViewModel(this GrupoProdutoResult model)
        //{
        //    return Mapper.Map<GrupoProdutoResult, GrupoProdutoResultViewModel>(model);
        //}
        //public static IEnumerable<GrupoProdutoPesquisaResultViewModel> ToViewModel(this IEnumerable<GrupoProdutoPesquisaResult> model)
        //{
        //    return Mapper.Map<IEnumerable<GrupoProdutoPesquisaResult>, IEnumerable<GrupoProdutoPesquisaResultViewModel>>(model);
        //}
        //#endregion

        //#region Voucher

        //public static VoucherParam ToDomain(this VoucherParamViewModel model)
        //{
        //    return Mapper.Map<VoucherParamViewModel, VoucherParam>(model);
        //}

        //public static IEnumerable<ArquivoVoucherResultViewModel> ToViewModel(this IEnumerable<ArquivoVoucherResult> model)
        //{
        //    return Mapper.Map<IEnumerable<ArquivoVoucherResult>, IEnumerable<ArquivoVoucherResultViewModel>>(model);
        //}

        //public static LotesVoucherParam ToDomain(this LotesVoucherParamViewModel model)
        //{
        //    return Mapper.Map<LotesVoucherParamViewModel, LotesVoucherParam>(model);
        //}

        //public static IEnumerable<LotesVoucherResultViewModel> ToViewModel(this IEnumerable<LotesVoucherResult> model)
        //{
        //    return Mapper.Map<IEnumerable<LotesVoucherResult>, IEnumerable<LotesVoucherResultViewModel>>(model);
        //}

        //#endregion

        //#region ESTOQUE
        //public static ConsultaEstoqueVoucherParam ToDomain(this ConsultaEstoqueVoucherParamViewModel model)
        //{
        //    return Mapper.Map<ConsultaEstoqueVoucherParamViewModel, ConsultaEstoqueVoucherParam>(model);
        //}

        //public static IEnumerable<ConsultaEstoqueVoucherResultViewModel> ToViewModel(this IEnumerable<ConsultaEstoqueVoucherResult> model)
        //{
        //    return Mapper.Map<IEnumerable<ConsultaEstoqueVoucherResult>, IEnumerable<ConsultaEstoqueVoucherResultViewModel>>(model);
        //}
        //#endregion

        //#region Produto

        //public static IEnumerable<ProdutoResultViewModel> ToViewModel(this IEnumerable<ProdutoResult> model)
        //{
        //    return Mapper.Map<IEnumerable<ProdutoResult>, IEnumerable<ProdutoResultViewModel>>(model);
        //}

        //#endregion

        //#region ResgatePrivado
        //public static ResgatePrivadoParam ToDomain(this ResgatePrivadoParamViewModel model)
        //{
        //    return Mapper.Map<ResgatePrivadoParamViewModel, ResgatePrivadoParam>(model);
        //}
        //public static IEnumerable<ResgatePrivadoResultViewModel> ToViewModel(this IEnumerable<ResgatePrivadoResult> model)
        //{
        //    return Mapper.Map<IEnumerable<ResgatePrivadoResult>, IEnumerable<ResgatePrivadoResultViewModel>>(model);
        //}
        //public static ResgatePrivadoEstornoParam ToDomain(this ResgatePrivadoEstornoParamViewModel model)
        //{
        //    return Mapper.Map<ResgatePrivadoEstornoParamViewModel, ResgatePrivadoEstornoParam>(model);
        //}
        //public static IEnumerable<ResgatePrivadoTratadoResultViewModel> ToViewModel(this IEnumerable<ResgatePrivadoTratadoResult> model)
        //{
        //    return Mapper.Map<IEnumerable<ResgatePrivadoTratadoResult>, IEnumerable<ResgatePrivadoTratadoResultViewModel>>(model);
        //}
        //public static IEnumerable<VoucherResgatePrivadoResultViewModel> ToViewModel(this IEnumerable<VoucherResgatePrivadoResult> model)
        //{
        //    return Mapper.Map<IEnumerable<VoucherResgatePrivadoResult>, IEnumerable<VoucherResgatePrivadoResultViewModel>>(model);
        //}
        //#endregion

        //#region EmailComunicacao Parceiro
        //public static EmailComunicacaoParceiroParam ToDomain(this EmailComunicacaoParceiroParamViewModel model)
        //{
        //    return Mapper.Map<EmailComunicacaoParceiroParamViewModel, EmailComunicacaoParceiroParam>(model);
        //}
        //public static EmailComunicacaoParceiroPesquisaParam ToDomain(this EmailComunicacaoParceiroPesquisaParamViewModel model)
        //{
        //    return Mapper.Map<EmailComunicacaoParceiroPesquisaParamViewModel, EmailComunicacaoParceiroPesquisaParam>(model);
        //}
        //public static IEnumerable<EmailComunicacaoParceiroPesquisaResultViewModel> ToViewModel(this IEnumerable<EmailComunicacaoParceiroPesquisaResult> model)
        //{
        //    return Mapper.Map<IEnumerable<EmailComunicacaoParceiroPesquisaResult>, IEnumerable<EmailComunicacaoParceiroPesquisaResultViewModel>>(model);
        //}
        //#endregion

        //#region LoteVoucher Desativação
        //public static LoteVoucherPesquisaParam ToDomain(this LoteVoucherPesquisaParamViewModel model)
        //{
        //    return Mapper.Map<LoteVoucherPesquisaParamViewModel, LoteVoucherPesquisaParam>(model);
        //}
        //public static IEnumerable<LoteVoucherContainerPesquisaResultViewModel> ToViewModel(this IEnumerable<LoteVoucherContainerPesquisaResult> model)
        //{
        //    return Mapper.Map<IEnumerable<LoteVoucherContainerPesquisaResult>, IEnumerable<LoteVoucherContainerPesquisaResultViewModel>>(model);
        //}
        //public static IEnumerable<LoteVoucherPesquisaResultViewModel> ToViewModel(this IEnumerable<LoteVoucherPesquisaResult> model)
        //{
        //    return Mapper.Map<IEnumerable<LoteVoucherPesquisaResult>, IEnumerable<LoteVoucherPesquisaResultViewModel>>(model);
        //}

        //public static LoteVoucherDesativarParam ToDomain(this LoteVoucherDesativarParamViewModel model)
        //{
        //    return Mapper.Map<LoteVoucherDesativarParamViewModel, LoteVoucherDesativarParam>(model);
        //}
        //#endregion

    }
}
