using System;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.CR;
namespace AcumaticaMX
{
    [Serializable]
    public class MXFEPayment : IBqlTable
    {
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }

        [PXDBString(15, IsKey = true, InputMask = ">CCCCCCCCCC")]
        [PXSelector(typeof(Search<MXFEPayment.refNbr>),
            typeof(refNbr),
            typeof(customerID))]
        [PXUIField(DisplayName = "Numero de pago", Visible = true, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Folio Fiscal del Complemento de Pago", Enabled = false)]
        [CfdiStatus(typeof(stampStatus), typeof(uuid), typeof(cancelDate))]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region CancelDate

        public abstract class cancelDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion CancelDate

        #region CustomerID

        public abstract class customerID : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        [PXSelector(typeof(Search<BAccount.bAccountID,
            Where<BAccount.bAccountID,
                Equal<Current<ARPayment.customerID>>>>),
            SubstituteKey = typeof(BAccount.acctName))]
        [PXUIField(DisplayName = "Cliente", Enabled = false, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual int? CustomerID { get; set; }

        #endregion CustomerID

        #region SelloSAT

        public abstract class stamp : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello SAT", Enabled = false)]
        public virtual string Stamp { get; set; }

        #endregion SelloSAT

        #region Sello CFD

        public abstract class seal : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello CFD", Enabled = false)]
        public virtual string Seal { get; set; }

        #endregion Sello CFD

        #region CadenaOriginalTFD

        public abstract class stampString : IBqlField { }

        [PXDBString(1000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cadena Original TFD", Enabled = false)]
        public virtual string StampString { get; set; }

        #endregion CadenaOriginalTFD

        #region FechaTimbrado

        public abstract class stampDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
        public virtual DateTime? StampDate { get; set; }

        #endregion FechaTimbrado

        #region Estado

        public abstract class stampStatus : IBqlField { }

        [PXString(1, IsFixed = true)]
        [PXUIField(DisplayName = "Edo. Timbrado", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true, Enabled = false)]
        [CfdiStatus.List()]
        public virtual string StampStatus { get; set; }

        #endregion Estado

        #region QrCode

        public abstract class qrCode : IBqlField { }

        [PXDBString(95, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Codigo QR", Enabled = false)]
        public virtual string QrCode { get; set; }

        #endregion QrCode

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

        #region Version

        public abstract class version : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        public virtual string Version { get; set; }

        #endregion Version

        // Opcionales

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

        #region audit

        #region NoteID

        public abstract class noteID : PX.Data.IBqlField
        {
        }

        /// <summary>
        /// Identifier of the <see cref="PX.Data.Note">Note</see> object, associated with the document.
        /// </summary>
        /// <value>
        /// Corresponds to the <see cref="PX.Data.Note.NoteID">Note.NoteID</see> field.
        /// </value>
        [PXNote(ShowInReferenceSelector = true)]
        public Guid? NoteID { get; set; }

        #endregion NoteID

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
