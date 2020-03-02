﻿using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    #region Enums

    public enum TipoPagamento
    {
        TransferenciaBancaria = 0,
        eFRETE = 1
    }

    public enum CategoriaPagamento
    {
        Adiantamento = 0,
        Estadia = 1,
        Quitacao = 2,
        SemCategoria = 3
    }

    #endregion

    public sealed class PefAdicionarOperacaoTransportePagamentos : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "IdPagamentoCliente", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string IdPagamentoCliente { get; set; }

        [DFeIgnore]
        public DateTime DataLiberacao { get; set; }

        [DFeElement(TipoCampo.Str, "DataDeLiberacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string DataLiberacaoProxy
        {
            get => DataLiberacao.ToString("yyyy-MM-dd");
            set => DataLiberacao = DateTime.Parse(value);
        }

        [DFeElement(TipoCampo.De2, "Valor", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public decimal Valor { get; set; }

        [DFeIgnore]
        public TipoPagamento Tipo { get; set; }

        [DFeElement(TipoCampo.Str, "TipoPagamento", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string TipoProxy
        {
            get => this.Tipo == TipoPagamento.TransferenciaBancaria ? "TransferenciaBancaria" : "eFRETE";
            set => this.Tipo = value == "eFRETE" ? TipoPagamento.eFRETE : TipoPagamento.TransferenciaBancaria;
        }
               
        [DFeIgnore]
        public CategoriaPagamento Categoria { get; set; }

        [DFeElement(TipoCampo.Str, "Categoria", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string CategoriaProxy
        {
            get
            {
                switch (Categoria)
                {
                    case CategoriaPagamento.Adiantamento: return "Adiantamento";
                    case CategoriaPagamento.Estadia: return "Estadia";
                    case CategoriaPagamento.Quitacao: return "Quitacao";
                    case CategoriaPagamento.SemCategoria: return "Sem Categoria (Livre)";
                    default: throw new NotImplementedException("Categoria não implementada");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "adiantamento": Categoria = CategoriaPagamento.Adiantamento; break;
                    case "estadia": Categoria = CategoriaPagamento.Estadia; break;
                    case "quitacao": Categoria = CategoriaPagamento.Quitacao; break;
                    case "sem categoria": Categoria = CategoriaPagamento.SemCategoria; break;
                    default: throw new NotImplementedException("Categoria não implementada");
                }
            }
        }

        [DFeElement(TipoCampo.Str, "Documento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string Documento { get; set; }

        [DFeElement("InformacoesBancarias", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public PefAdicionarOperacaoTransporteInformacoesBancarias InformacoesBancarias { get; set; }

        [DFeElement(TipoCampo.Str, "InformacaoAdicional", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public string InformacaoAdicional { get; set; }

        [DFeElement(TipoCampo.Str, "CnpjFilialAbastecimento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 9)]
        public string CnpjFilialAbastecimento { get; set; }

        #endregion
    }
}
