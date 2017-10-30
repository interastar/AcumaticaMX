using System;
using PX.Data;
using PX.Objects.AR;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(ARAdjust.adjgDocType), typeof(ARAdjust.adjgRefNbr), typeof(ARAdjust.adjNbr), 
        typeof(ARAdjust.adjdDocType), typeof(ARAdjust.adjdRefNbr), IsOptional = true)]
    public class MXARAdjustExtension : PXCacheExtension<ARAdjust>
    {
        #region Send

        public abstract class send : IBqlField { }

        [PXDBBool]
        [PXDefault(true)]
        [PXUIField(DisplayName = "Enviar por correo", Visibility = PXUIVisibility.SelectorVisible, Enabled = true)]
        public virtual bool? Send { get; set; }

        #endregion Send

        #region DocumentID

        public abstract class documentID : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Folio Fiscal de la factura relacionada")]
        public virtual Guid? DocumentID { get; set; }

        #endregion DocumentID

        #region Partiality

        public abstract class partiality : IBqlField { }

        [PXDBInt]
        [PXUIField(DisplayName = "Parcialidad")]
        public virtual int? Partiality { get; set; }

        #endregion Partiality

        #region DebtAmt

        public abstract class debtAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Saldo insoluto anterior")]
        public virtual decimal? DebtAmt { get; set; }

        #endregion DebtAmt

        #region PaymentAmt

        public abstract class paymentAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Importe")]
        public virtual decimal? PaymentAmt { get; set; }

        #endregion PaymentAmt

        #region NewDebtAmt

        public abstract class newDebtAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Nuevo Saldo Insoluto")]
        public virtual decimal? NewDebtAmt { get; set; }

        #endregion NewDebtAmt

        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Uuid")]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region CancelDate

        public abstract class cancelDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion CancelDate

        ///*** Campos calculados
        ///

        #region Estado

        public abstract class stampStatus : IBqlField { }

        [PXString(1, IsFixed = true)]
        [PXDefault(CfdiStatus.Clean)]
        [PXUnboundDefault(CfdiStatus.Clean)]
        [PXUIField(DisplayName = "Edo. Timbrado", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true, Enabled = false)]
        public virtual string StampStatus { get; set; }

        #endregion Estado
    }
}
