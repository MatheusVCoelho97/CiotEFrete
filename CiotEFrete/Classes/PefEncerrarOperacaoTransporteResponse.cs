﻿using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    [DFeRoot("EncerrarOperacaoTransporteResponse", Namespace = "http://schemas.ipc.adm.br/efrete/pef")]
    public sealed class PefEncerrarOperacaoTransporteResponse : DFeDocument<PefEncerrarOperacaoTransporteResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("EncerrarOperacaoTransporteResult", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefEncerrarOperacaoTransporteResult Result { get; set; }

        #endregion
    }
}
