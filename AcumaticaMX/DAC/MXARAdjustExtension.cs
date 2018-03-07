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
        #region DocumentID

        public abstract class documentID : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Folio Fiscal de la factura relacionada")]
        public virtual Guid? DocumentID { get; set; }

        #endregion DocumentID

        #region FormaDePago

        public abstract class paymentForm : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        [PXStringList(
            new string[]
            {
                Common.PayForm.One,
                Common.PayForm.Partial,
            },
            new string[]
            {
                Common.PayForm.OneLabel,
                Common.PayForm.PartialLabel,
            }
            )]
        [PXUIField(DisplayName = "Forma de pago", Enabled = false)]
        public virtual string PaymentForm { get; set; }

        #endregion FormaDePago

        /// <summary>
        /// Numero de parcialidad
        /// </summary>
        #region Partiality

        public abstract class partiality : IBqlField { }

        [PXDBInt]
        [PXUIField(DisplayName = "Parcialidad")]
        public virtual int? Partiality { get; set; }

        #endregion Partiality

        /// <summary>
        /// Saldo antes del pago
        /// </summary>
        #region DebtAmt

        public abstract class debtAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Saldo Insoluto Anterior")]
        public virtual decimal? DebtAmt { get; set; }

        #endregion DebtAmt

        /// <summary>
        /// Saldo despues del pago
        /// </summary>
        #region NewDebtAmt

        public abstract class newDebtAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Nuevo Saldo Insoluto")]
        public virtual decimal? NewDebtAmt { get; set; }

        #endregion NewDebtAmt

        /// <summary>
        /// UUid del cfdi timbrado
        /// </summary>
        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid]
        [CfdiStatus(typeof(stampStatus), typeof(uuid), typeof(cancelDate))]
        [PXUIField(DisplayName = "Uuid")]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region CancelDate

        public abstract class cancelDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion CancelDate

        #region PaymentRefNbr

        public abstract class paymentRefNbr : IBqlField
        {
        }
        [PXDBString]
        [PXUIField(DisplayName = Messages.PaymentRefNbr, Enabled = false)]
        public virtual string PaymentRefNbr { get; set; }

        #endregion PaymentRefNbr

        #region CuryID

        public abstract class curyID : IBqlField
        {
        }
        [PXDBString]
        public virtual string CuryID { get; set; }

        #endregion CuryID

        ///*** Campos calculados

        #region Estado

        public abstract class stampStatus : IBqlField { }

        [PXString(1, IsFixed = true)]
        [PXUIField(DisplayName = "Edo. Timbrado", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true, Enabled = false)]
        [CfdiStatus.List()]
        public virtual string StampStatus { get; set; }

        #endregion Estado
    }
}
