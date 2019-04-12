using System;
using AcumaticaMX;
using PX.Data;

namespace IS.Objects.MX
{
    public class ISMXVoucher : IBqlTable
    {
        //   Llave

        #region VoucherID

        public abstract class voucherID : IBqlField { }
        
        [PXUIField(DisplayName = "Id", Enabled = false)]
        public virtual int? VoucherID { get; set; }

        #endregion VoucherID

        //  -- Datos generales del cfdi

        #region Version

        public abstract class version : IBqlField { }
        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        [PXDefault(Common.defaultCfdiVersion, PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual string Version { get; set; }

        #endregion Version

        #region DocType

        public abstract class docType : IBqlField { }

        [PXDBString(1, IsFixed = true)]
        [PXUIField(DisplayName = "Tipo de Comprobante", Enabled = false)]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region Serie

        public abstract class serie : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Serie", Enabled = false)]
        public virtual string Serie { get; set; }

        #endregion Serie

        #region Folio

        public abstract class folio : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        public virtual string Folio { get; set; }
        
        #endregion Folio

        #region DocDateTime

        public abstract class docDateTime : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? DocDateTime { get; set; }

        #endregion DocDateTime

        #region FormaDePago

        public abstract class paymentForm : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXDefault(Common.PayForm.Partial)]
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
        [PXDefault(Common.defaultPaymentMethod, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXSelector(typeof(Search<MXPaymentMethodExtension.satPaymentMethod>),
            typeof(MXFESatPaymentMethodList.description),
            DescriptionField = typeof(MXFESatPaymentMethodList.description))]
        [PXUIField(DisplayName = "Forma de Pago")]
        public virtual string PaymentMethod { get; set; }

        #endregion MetodoDePago

        #region PaymentTerms

        public abstract class paymentTerms : IBqlField { }

        [PXDBString(1000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Condiciones de Pago")]
        public virtual string PaymentTerms { get; set; }
        
        #endregion PaymentTerms

        #region ZipCode

        public abstract class zipCode : IBqlField { }

        [PXDBString(5, IsUnicode = true, InputMask = ">CCCCC")]
        [PXUIField(DisplayName = "Lugar de Expedicion")]
        public virtual string ZipCode { get; set; }

        #endregion ZipCode

        #region CuryID

        public abstract class curyID : IBqlField { }
        [PXDBString(3, IsUnicode = true, InputMask = ">LLL")]
        [PXUIField(DisplayName = "Moneda")]
        public virtual string CuryID { get; set; }

        #endregion CuryID

        #region CurrencyRate

        public abstract class curyRate : IBqlField { }
        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Tipo de Cambio")]
        public virtual decimal? CuryRate { get; set; }

        #endregion CurrencyRate

        #region Disccount
        public abstract class disccountAmt : IBqlField { }
        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Descuento", Enabled = false)]
        public virtual decimal? DisccountAmt { get; set; }
        #endregion Disccount

        #region VoucherSubTotal
        public abstract class voucherSubTotal : IBqlField { }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Subtotal", Enabled = false)]
        public virtual decimal? VoucherSubTotal { get; set; }
        #endregion VoucherSubTotal

        #region VoucherTotal
        public abstract class voucherTotal : IBqlField { }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Total", Enabled = false)]
        public virtual decimal? VoucherTotal { get; set; }
        #endregion VoucherTotal

        #region PacConfirmation

        public abstract class pacConfirmation : IBqlField { }

        [PXDBString(5, IsUnicode = true, InputMask = ">CCCCC")]
        [PXUIField(DisplayName = "Confirmacion")]
        public virtual string PacConfirmation { get; set; }

        #endregion PacConfirmation

        //  -- Datos de sello del comprobante

        #region CertificateNbr

        public abstract class certificateNbr : IBqlField { }

        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "Certificado del Emisor", Enabled = false)]
        public virtual string CertificateNbr { get; set; }

        #endregion CertificateNbr

        #region Certificate

        public abstract class certificate : IBqlField { }

        [PXDBString(2500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Certificado", Enabled = false)]
        public virtual string Certificate { get; set; }

        #endregion Certificate

        #region SealDate

        public abstract class sealDate : IBqlField { }

        [PXDBDate()]
        [PXUIField(DisplayName = "Fecha de Emisión", Enabled = false)]
        public virtual DateTime? SealDate { get; set; }

        #endregion SealDate

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

        #region SatCertificateNbr

        public abstract class satCertificateNbr : IBqlField { }

        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "No. Certificado SAT", Enabled = false)]
        public virtual string SatCertificateNbr { get; set; }

        #endregion SatCertificateNbr

        #region StampDate

        public abstract class stampDate : IBqlField { }

        [PXDBDate()]
        [PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
        public virtual DateTime? StampDate { get; set; }

        #endregion StampDate

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

        //  -- Campos de status

        #region Estado de Cancelacion
        public abstract class cancelStatus : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Edo. Cancelacion", Enabled = false)]
        public virtual string CancelStatus { get; set; }
        #endregion Estado de Cancelacion

        #region FechaCancelacion

        public abstract class cancelDate : IBqlField { }

        [PXDBDate()]
        [PXUIField(DisplayName = "Fecha de Cancelación", Enabled = false)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion FechaCancelacion

        //  -- Datos unicos por Cfdi

        #region IssuerTaxRegistrationID

        public abstract class issuerTaxRegistrationID : IBqlField { }
        [PXDefault]
        [PXDBString(13)]
        [PXUIField(DisplayName = "Rfc Emisor")]
        public virtual string IssuerTaxRegistrationID { get; set; }

        #endregion IssuerTaxRegistrationID

        #region Issuer

        public abstract class issuer : IBqlField { }
        [PXDefault]
        [PXDBString(254)]
        [PXUIField(DisplayName = "Nombre del Emisor")]
        public virtual string Issuer { get; set; }

        #endregion Issuer

        #region ReceiverTaxRegistrationID

        public abstract class receiverTaxRegistrationID : IBqlField { }
        [PXDefault]
        [PXDBString(13)]
        [PXUIField(DisplayName = "Rfc Receptor")]
        public virtual string ReceiverTaxRegistrationID { get; set; }

        #endregion ReceiverTaxRegistrationID

        #region Receiver

        public abstract class receiver : IBqlField { }
        [PXDefault]
        [PXDBString(254)]
        [PXUIField(DisplayName = "Nombre del Receptor")]
        public virtual string Receiver { get; set; }
        
        #endregion Receiver

        #region UseCfdiCD

        public abstract class useCfdiCD : IBqlField { }
        [PXDBString(3)]
        [PXUIField(DisplayName = Messages.UseCFDI)]
        [PXDefault]
        public virtual string UseCfdiCD { get; set; }

        #endregion UseCfdiCD

        #region TaxTransferredTotal
        public abstract class taxTransferredTotal : IBqlField { }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Total de Impuestos transferidos", Enabled = false)]
        public virtual decimal? TaxTransferredTotal { get; set; }
        #endregion TaxTransferredTotal

        #region TaxHoldingTotal
        public abstract class taxHoldingTotal : IBqlField { }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Total de Impuestos retenidos", Enabled = false)]
        public virtual decimal? TaxHoldingTotal { get; set; }
        #endregion TaxHoldingTotal

        //   Helpers

        #region DocRef
        public abstract class docRef : IBqlField { }
        [PXDBGuid(IsKey = true)]
        [PXDefault(PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Referencia", Enabled = false,
            Visibility = PXUIVisibility.SelectorVisible)]
        public virtual Guid? DocRef { get; set; }

        #endregion DocRef

        #region Module
        public abstract class module : IBqlField { }
        [PXDBString(2, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Modulo", Enabled = false)]
        public virtual string Module { get; set; }
        #endregion Module

        // -- Campos no persistentes

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
            [PXDependsOnFields(typeof(voucherTotal), typeof(curyID))]
            get
            {
                return AcumaticaMX.Convert.ToWords(VoucherTotal, CuryID);
            }
            set
            {
            }
        }

        #endregion CantidadEnLetra

        #region QrCodeImg

        /// <summary>
        /// Propiedad disponible para calcular y mostrar la imagen del código QR.
        /// </summary>
        /// <value>
        /// Debe regresar un Data URL con el contenido de la imagen del código.
        /// </value>
        public abstract class qrCodeImg : IBqlField { }
        [PXString(IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Código QR", IsReadOnly = true)]
        public virtual string QrCodeImg { get; set; }

        #endregion QrCodeImg

        //  -- Complementos

        #region External Trade

        public abstract class hasExternalTrade : IBqlField { }

        [PXDBBool]
        [PXUIField(DisplayName = "Comercio Exterior", Enabled = true)]
        public virtual bool? HasExternalTrade { get; set; }

        #endregion External Trade

        //  -- Auditoria

        #region audit

        #region tstamp

        public abstract class Tstamp : PX.Data.IBqlField
        {
        }

        protected byte[] _tstamp;

        [PXDBTimestamp()]
        public virtual byte[] tstamp
        {
            get
            {
                return this._tstamp;
            }
            set
            {
                this._tstamp = value;
            }
        }

        #endregion tstamp

        #region CreatedByID

        public abstract class createdByID : PX.Data.IBqlField
        {
        }

        protected Guid? _CreatedByID;

        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID
        {
            get
            {
                return this._CreatedByID;
            }
            set
            {
                this._CreatedByID = value;
            }
        }

        #endregion CreatedByID

        #region CreatedByScreenID

        public abstract class createdByScreenID : PX.Data.IBqlField
        {
        }

        protected string _CreatedByScreenID;

        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID
        {
            get
            {
                return this._CreatedByScreenID;
            }
            set
            {
                this._CreatedByScreenID = value;
            }
        }

        #endregion CreatedByScreenID

        #region CreatedDateTime

        public abstract class createdDateTime : PX.Data.IBqlField
        {
        }

        protected DateTime? _CreatedDateTime;

        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime
        {
            get
            {
                return this._CreatedDateTime;
            }
            set
            {
                this._CreatedDateTime = value;
            }
        }

        #endregion CreatedDateTime

        #region LastModifiedByID

        public abstract class lastModifiedByID : PX.Data.IBqlField
        {
        }

        protected Guid? _LastModifiedByID;

        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID
        {
            get
            {
                return this._LastModifiedByID;
            }
            set
            {
                this._LastModifiedByID = value;
            }
        }

        #endregion LastModifiedByID

        #region LastModifiedByScreenID

        public abstract class lastModifiedByScreenID : PX.Data.IBqlField
        {
        }

        protected string _LastModifiedByScreenID;

        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID
        {
            get
            {
                return this._LastModifiedByScreenID;
            }
            set
            {
                this._LastModifiedByScreenID = value;
            }
        }

        #endregion LastModifiedByScreenID

        #region LastModifiedDateTime

        public abstract class lastModifiedDateTime : PX.Data.IBqlField
        {
        }

        protected DateTime? _LastModifiedDateTime;

        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime
        {
            get
            {
                return this._LastModifiedDateTime;
            }
            set
            {
                this._LastModifiedDateTime = value;
            }
        }

        #endregion LastModifiedDateTime

        #endregion audit
    }
}
