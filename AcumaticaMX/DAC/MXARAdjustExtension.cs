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
        //-- Documento Relacionado
        #region DocumentID

        public abstract class documentID : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Folio Fiscal de la factura relacionada", Enabled = false)]
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
        [PXUIField(DisplayName = "Parcialidad", Enabled = false)]
        public virtual int? Partiality { get; set; }

        #endregion Partiality

        /// <summary>
        /// Saldo antes del pago
        /// </summary>
        #region DebtAmt

        public abstract class debtAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Saldo Insoluto Anterior", Enabled = false)]
        public virtual decimal? DebtAmt { get; set; }

        #endregion DebtAmt

        /// <summary>
        /// Saldo despues del pago
        /// </summary>
        #region NewDebtAmt

        public abstract class newDebtAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Nuevo Saldo Insoluto", Enabled = false)]
        public virtual decimal? NewDebtAmt { get; set; }

        #endregion NewDebtAmt

        /// <summary>
        /// UUid del cfdi timbrado
        /// </summary>
        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Uuid")]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region Moneda de la Factura

        public abstract class curyIDDR : IBqlField { }

        [PXDBString]
        public virtual string CuryIDDR { get; set; }
        #endregion Moneda de la Factura

        #region Tipo de cambio del Pago
        public abstract class currencyRateDR : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Tipo de CambioR", Enabled = false)]
        public virtual decimal? CurrencyRateDR { get; set; }

        #endregion Tipo de cambio del Pago

        //-- Datos Generales del Pago

        #region Fecha de Pago
        public abstract class paymentDate : IBqlField
        {
        }
        [PXDBDate]
        [PXUIField(DisplayName = "Fecha de Pago", Enabled = false)]
        public virtual DateTime? PaymentDate { get; set; }
        #endregion Fecha de Pago

        /// <summary>
        /// Monto del pago
        /// </summary>
        #region Monto del Pago

        public abstract class paymentAmt : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Monto del Pago", Enabled = false)]
        public virtual decimal? PaymentAmt { get; set; }

        #endregion Monto del Pago

        #region Moneda del Pago

        public abstract class curyIDP : IBqlField { }

        [PXDBString]
        [PXUIField(DisplayName = "MonedaP", Enabled = false)]
        public virtual string CuryIDP { get; set; }

        #endregion Moneda del Pago

        #region Forma de pago del Pago

        public abstract class paymentMethodP : IBqlField { }

        [PXDBString]
        [PXUIField(DisplayName = "Forma de PagoP", Enabled = false)]
        public virtual string PaymentMethodP { get; set; }

        #endregion Forma de pago del Pago

        #region Tipo de cambio del Pago

        public abstract class currencyRateP : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Tipo de CambioP", Enabled = false)]
        public virtual decimal? CurrencyRateP { get; set; }

        #endregion Tipo de cambio del Pago

        // Opcionales

        #region Opcionales

        #region Numero de Operacion
        public abstract class operationNbr : IBqlField { }
        [PXDBString(100, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.OperationNbr)]
        public virtual string OperationNbr { get; set; }
        #endregion Numero de Operacion

        #region Rfc Emisor de la Cuenta Ordenante
        public abstract class rfcEmisorCtaOrd : IBqlField { }
        [PXDBString(13, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.RfcEmisorCtaOrd)]
        public virtual string RfcEmisorCtaOrd { get; set; }
        #endregion Rfc Emisor de la Cuenta Ordenante

        #region Nombre del Banco Ordenante Extranjero
        public abstract class nomBancoOrdExt : IBqlField { }
        [PXDBString(300, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.NomBancoOrdExt)]
        public virtual string NomBancoOrdExt { get; set; }
        #endregion Nombre del Banco Ordenante Extranjero

        #region Cuenta Ordenante
        public abstract class ctaOrdenante : IBqlField { }
        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.CtaOrdenante)]
        public virtual string CtaOrdenante { get; set; }
        #endregion Cuenta Ordenante

        #region Rfc Emisor de la Cuenta Beneficiaria
        public abstract class rfcEmisorCtaBen : IBqlField { }
        [PXDBString(13, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.RfcEmisorCtaBen)]
        public virtual string RfcEmisorCtaBen { get; set; }
        #endregion Rfc Emisor de la Cuenta Beneficiaria

        #region Cuenta Beneficiaria
        public abstract class ctaBeneficiario : IBqlField { }
        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.CtaBeneficiario)]
        public virtual string CtaBeneficiario { get; set; }
        #endregion Cuenta Beneficiaria

        #region Tipo de Cadena de Pago
        public abstract class tipoCadPago : IBqlField { }
        [PXDBString(2, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.TipoCadPago)]
        public virtual string TipoCadPago { get; set; }
        #endregion Tipo de Cadena de Pago

        #region Certificado de Pago
        public abstract class certPago : IBqlField { }
        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.CertPago)]
        public virtual string CertPago { get; set; }
        #endregion Certificado de Pago

        #region Cadena Original de Pago
        public abstract class cadPago : IBqlField { }
        [PXDBString(8192, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.CadPago)]
        public virtual string CadPago { get; set; }
        #endregion Cadena Original de Pago

        #region Sello Pago
        public abstract class selloPago : IBqlField { }
        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.SelloPago)]
        public virtual string SelloPago { get; set; }
        #endregion Sello Pago

        #endregion Opcionales

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


        #region PaymentExpirationDate

        public abstract class paymentExpirationDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? PaymentExpirationDate { get; set; }

        #endregion PaymentExpirationDate
    }
}
