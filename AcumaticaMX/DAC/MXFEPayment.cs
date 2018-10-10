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

        [PXDBString(15, IsKey = true, IsFixed = false)]
        [PXSelector(typeof(Search<MXFEPayment.refNbr>),
            typeof(refNbr),
            typeof(customerID),
            ValidateValue = true,
            IsDirty = true)]
        [PXUIField(DisplayName = "Numero de pago", Visible = true, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr
        //Hacerlo iskey en el futuro
        #region DocType

        public abstract class docType : IBqlField
        {
        }

        [PXDBString(3, IsFixed = true)]
        [PXDefault(typeof(PaymentDocType))]
        [PXUIField(DisplayName = "Tipo de Documento", Enabled = false)]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region DocDate
        public abstract class docDate : IBqlField
        {
        }
        [PXDBDateAndTime(PreserveTime = true)]
        [PXDefault(typeof(AccessInfo.businessDate), PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Fecha", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual DateTime? DocDate{ get;set; }
        #endregion

        #region CustomerID

        public abstract class customerID : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        [PXSelector(typeof(Search<BAccount.bAccountID,
            Where<BAccount.bAccountID,
                Equal<Current<MXFEPayment.customerID>>>>),
            SubstituteKey = typeof(BAccount.acctName))]
        [PXUIField(DisplayName = "Cliente", Enabled = false, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual int? CustomerID { get; set; }

        #endregion CustomerID        
        
        #region UseCfdiCD

        public abstract class useCfdiCD : PX.Data.IBqlField { }
        [PXDBString]
        [PXUIField(DisplayName = Messages.UseCFDI, Enabled = false)]
        public virtual string UseCfdiCD { get; set; }

        #endregion UseCfdiCD

        #region Serie

        public abstract class serie : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Serie", Enabled = false)]
        public virtual string Serie { get; set; }

        #endregion Serie

        #region Folio

        public abstract class folio : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Folio", Enabled = false)]
        public virtual string Folio { get; set; }

        #endregion Folio

        #region CancelDate

        public abstract class cancelDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion CancelDate

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

        #region NoCertificadoSAT

        public abstract class satCertificateNum : IBqlField { }

        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "No. Certificado SAT", Enabled = false)]
        public virtual string SatCertificateNum { get; set; }

        #endregion NoCertificadoSAT

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

        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Folio Fiscal del Complemento de Pago", Enabled = false)]
        [CfdiStatus(typeof(stampStatus), typeof(uuid), typeof(cancelDate))]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region QrCode

        public abstract class qrCode : IBqlField { }

        [PXDBString(95, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Codigo QR", Enabled = false)]
        public virtual string QrCode { get; set; }

        #endregion QrCode

        // -- Campos no persistentes *************

        #region CadenaOriginal

        public abstract class documentString : IBqlField { }

        [PXString(4000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cadena Original", Enabled = false)]
        public virtual string DocumentString { get; set; }

        #endregion CadenaOriginal
        
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
        [PXUIField(DisplayName = "Edo. Timbrado", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true, Enabled = false)]
        [CfdiStatus.List()]
        public virtual string StampStatus { get; set; }

        #endregion Estado

        #region report
        public abstract class report : IBqlField
        {
        }

        [PXString]
        [PXUIField(DisplayName = "Reporte", Visible = true)]
        public virtual string Report { get; set; }
        #endregion report


        //---
        #region Tipo Entrada/Salida

        public abstract class typeP : IBqlField { }

        [PXDBString(1, IsFixed = false, IsUnicode = true)]
        [PXStringList(
            new string[]
            {
                Common.PaymentType.Input,
                Common.PaymentType.Output,
            },
            new string[]
            {
                Common.PaymentType.InputLabel,
                Common.PaymentType.OutputLabel,
            }
            )]
        public virtual string TypeP { get; set; }

        #endregion Tipo Entrada/Salida

        #region Version Cfdi

        public abstract class version : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        public virtual string Version { get; set; }

        #endregion Version Cfdi

        #region Version Complemento de Pago

        public abstract class paymentVersion : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        public virtual string PaymentVersion { get; set; }

        #endregion Version Complemento de Pago

        #region Selected
        public abstract class selected : IBqlField { }
        [PXBool()]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? Selected { get; set; }
        #endregion

        // -- Temporales

        #region Enviado

        public abstract class sended : IBqlField { }

        [PXDBBool()]
        [PXDefault(false)]
        [PXUIField(DisplayName = "Enviado",  Enabled = true)]
        public virtual bool? Sended { get; set; }

        #endregion Enviado

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

    public class PaymentDocType : Constant<String>
    {
        public PaymentDocType() : base("CDP")
        {
        }
    }
}
