using PX.Data;
using PX.Objects.AR;
using System;

namespace AcumaticaMX
{
    /// <summary>
    /// Extensión de ARRegister para asociar información de CFDIs
    /// </summary>
    [PXTable(typeof(ARRegister.docType), typeof(ARRegister.refNbr), IsOptional = true)]
    public class MXARRegisterExtension : PXCacheExtension<PX.Objects.AR.ARRegister>
    {
        // Campos persistentes (en BD) *************

        // - Datos del comprobante fiscal

        #region Version

        public abstract class version : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        public virtual string Version { get; set; }

        #endregion Version

        #region Serie

        public abstract class series : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Serie", Enabled = false)]
        public virtual string Series { get; set; }

        #endregion Serie

        #region FormaDePago

        public abstract class paymentForm : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXDefault(AcumaticaMX.Common.PayForm.One)]
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
        [PXUIField(DisplayName = "Metodo de Pago")]
        public virtual string PaymentForm { get; set; }

        #endregion FormaDePago

        #region MetodoDePago

        public abstract class paymentMethod : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXDefault(AcumaticaMX.Common.PayMethod.Transfer)]
        [PXSelector(typeof(Search<MXFESatPaymentMethodList.satPaymentMethod>),
            typeof(MXFESatPaymentMethodList.description),
            DescriptionField = typeof(MXFESatPaymentMethodList.description))]
        [PXUIField(DisplayName = "Forma de Pago")]
        public virtual string PaymentMethod { get; set; }

        #endregion MetodoDePago

        #region NumCtaPago

        public abstract class originAccount : IBqlField { }

        [PXDBString(20, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cuenta de Pago", Enabled = false)]
        public virtual string OriginAccount { get; set; }

        #endregion NumCtaPago

        #region condicionesDePago

        public abstract class paymentTerms : IBqlField { }

        [PXDBString(100, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Condiciones de Pago")]
        public virtual string PaymentTerms { get; set; }

        #endregion condicionesDePago

        #region MotivoDeDescuento

        public abstract class discountReason : IBqlField { }

        [PXDBString(250, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Motivo de Descuento")]
        public virtual string DiscountReason { get; set; }

        #endregion MotivoDeDescuento

        #region TipoCambio

        public abstract class currencyRate : IBqlField { }

        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Tipo de Cambio actual")]
        public virtual decimal? CurrencyRate { get; set; }

        #endregion TipoCambio

        //  -- Datos de sello del comprobante

        #region noCertificado

        public abstract class certificateNum : IBqlField { }

        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "Certificado del Emisor", Enabled = false)]
        public virtual string CertificateNum { get; set; }

        #endregion noCertificado

        #region certificado

        public abstract class certificate : IBqlField { }

        [PXDBString(2500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Certificado", Enabled = false)]
        public virtual string Certificate { get; set; }

        #endregion certificado

        #region SealDate

        public abstract class sealDate : IBqlField { }

        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Emisión", Enabled = false)]
        public virtual DateTime? SealDate { get; set; }

        #endregion SealDate

        // --- Sello del comprobante

        #region Sello

        public abstract class seal : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello CFD", Enabled = false)]
        public virtual string Seal { get; set; }

        #endregion Sello

        // -- Datos del timbrado del comprobante

        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid()]
        [PXUIField(DisplayName = "UUID", Enabled = false, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region NoCertificadoSAT

        public abstract class satCertificateNum : IBqlField { }

        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "No. Certificado SAT", Enabled = false)]
        public virtual string SatCertificateNum { get; set; }

        #endregion NoCertificadoSAT

        #region FechaTimbrado

        public abstract class stampDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
        public virtual DateTime? StampDate { get; set; }

        #endregion FechaTimbrado

        #region FechaCancelacion

        public abstract class cancelDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Cancelación", Enabled = false)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion FechaCancelacion

        // --- Sello del SAT

        #region SelloSAT

        public abstract class stamp : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello SAT", Enabled = false)]
        public virtual string Stamp { get; set; }

        #endregion SelloSAT

        //  -- Campos de addenda

        #region QrCode

        public abstract class qrCode : IBqlField { }

        [PXDBString(95, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Codigo QR", Enabled = false)]
        public virtual string QrCode { get; set; }

        #endregion QrCode

        #region CadenaOriginalTFD

        public abstract class stampString : IBqlField { }

        [PXDBString(1000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cadena Original TFD", Enabled = false)]
        public virtual string StampString { get; set; }

        #endregion CadenaOriginalTFD

        // Campos no persistentes *************

        #region CadenaOriginal

        public abstract class documentString : IBqlField { }

        [PXString(4000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cadena Original", Enabled = false)]
        public virtual string DocumentString { get; set; }

        #endregion CadenaOriginal

        #region CantidadEnLetra

        public abstract class amountInWords : IBqlField { }

        [PXString(4000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Monto en Letra", IsReadOnly = true, Enabled = false)]
        public virtual string AmountInWords
        {
            [PXDependsOnFields(typeof(ARRegister.curyOrigDocAmt), typeof(ARRegister.curyID))]
            get
            {
                return Convert.ToWords(this.Base.CuryOrigDocAmt, this.Base.CuryID);
            }
            set
            {
            }
        }

        #endregion CantidadEnLetra

        #region QrCodeImg

        public abstract class qrCodeImg : PX.Data.IBqlField
        {
        }

        /// <summary>
        /// Propiedad disponible para calcular y mostrar la imagen del código QR.
        /// </summary>
        /// <value>
        /// Debe regresar un Data URL con el contenido de la imagen del código.
        /// </value>
        [PXString(IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Código QR", IsReadOnly = true)]
        public virtual string QrCodeImg { get; set; }

        #endregion QrCodeImg

        #region Estado

        public abstract class stampStatus : IBqlField { }

        [PXString(1, IsFixed = true)]
        [PXDefault(CfdiStatus.Clean)]
        [PXUnboundDefault(CfdiStatus.Clean)]
        [PXUIField(DisplayName = "Edo. Timbrado", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true, Enabled = false)]
        [CfdiStatus.List()]
        [SetCfdiStatus()]
        public virtual string StampStatus { get; set; }

        #endregion Estado

        #region Timbrable

        public abstract class notStampable : IBqlField { }

        [PXBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "No Timbrar", Visibility = PXUIVisibility.SelectorVisible, Enabled = true)]
        [StampableStatus()]
        public virtual bool? NotStampable { get; set; }

        #endregion Timbrable

        #region DocDateTime
        public abstract class docDateTime : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? DocDateTime { get; set; }
        #endregion DocDateTime

        #region UseCfdiCD
        public abstract class useCfdiCD : PX.Data.IBqlField
        {
        }
        [PXDBString]
        [PXUIField(DisplayName = Messages.UseCFDI)]
        public virtual string UseCfdiCD { get; set; }
        #endregion UseCfdiCD

        #region PaymentDocDateTime
        public abstract class paymentDocDateTime : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = Messages.PaymentDocDateTime)]
        public virtual DateTime? PaymentDocDateTime { get; set; }
        #endregion PaymentDocDateTime
    }
}