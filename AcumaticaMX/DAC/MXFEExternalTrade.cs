using System;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.SO;
namespace AcumaticaMX
{
    [Serializable]
    public class MXFEExternalTrade : IBqlTable
    {
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXParent(typeof(Select<ARRegister,
            Where<ARRegister.refNbr,
                Equal<Current<refNbr>>>>))]
        [PXDBString(15, IsKey = true)]
        [PXDefault(typeof(ARRegister.refNbr))]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region DocType

        public abstract class docType : IBqlField
        {
        }
        [PXDBString(3, IsKey = true)]
        [PXDefault(typeof(ARRegister.docType))]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region Version

        public abstract class version : IBqlField
        {
        }
        [PXDBString(3)]
        public virtual string Version { get; set; }

        #endregion Version

        #region MotivoTraslado

        public abstract class transferReason : IBqlField
        {
        }
        [PXDBString(2)]
        public virtual string TransferReason { get; set; }

        #endregion MotivoTraslado

        #region TipoOperacion

        public abstract class operationType : IBqlField
        {
        }
        [PXDBInt]
        [PXDefault(2)]
        [PXUIField( DisplayName = Messages.OperationType, Enabled = false )]
        public virtual int? OperationType { get; set; }

        #endregion TipoOperacion

        #region ClavePedimento

        public abstract class requestKey : IBqlField
        {
        }
        [PXDBString(2)]
        [PXDefault("A1")]
        [PXUIField(DisplayName = Messages.RequestKey, Enabled = false)]
        public virtual string RequestKey { get; set; }

        #endregion ClavePedimento

        #region CertificadoOrigen

        public abstract class isOriginCertificate : IBqlField
        {
        }
        [PXDBBool]
        public virtual bool? IsOriginCertificate { get; set; }

        #endregion CertificadoOrigen

        #region Numero de Certificado de Origen

        public abstract class originCertificateNbr : IBqlField
        {
        }
        [PXDBString(40)]
        [PXUIField(DisplayName = Messages.OriginCertificateNbr)]
        public virtual string OriginCertificateNbr { get; set; }

        #endregion Numero de Certificado de Origen

        #region Numero de Exportador Confiable

        public abstract class trustworthyExporterNbr : IBqlField
        {
        }
        [PXDBString(50)]
        [PXUIField(DisplayName = Messages.TrustworthyExporterNbr)]
        public virtual string TrustworthyExporterNbr { get; set; }

        #endregion Numero de Exportador Confiable

        #region Incoterm

        public abstract class incoterm : IBqlField
        {
        }
        [PXDBString(3)]
        [PXUIField(DisplayName = Messages.Incoterm, Enabled = false)]
        public virtual string Incoterm { get; set; }

        #endregion Incoterm

        #region Subdivision

        public abstract class hasSubdivision : IBqlField
        {
        }
        [PXDBBool]
        [PXUIField(DisplayName = Messages.Subdivision)]
        public virtual bool? HasSubdivision { get; set; }

        #endregion Subdivision

        #region Observaciones

        public abstract class description : IBqlField
        {
        }
        [PXDBString(300)]
        [PXUIField(DisplayName = Messages.Description)]
        public virtual string Description { get; set; }

        #endregion Observaciones

        #region Tipo de Cambio USD

        public abstract class currencyRateAmt : IBqlField
        {
        }
        [PXDBDecimal(6)]
        public virtual decimal? CurrencyRateAmt { get; set; }

        #endregion Tipo de Cambio USD

        #region Total USD

        public abstract class usdTotal : IBqlField
        {
        }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = Messages.UsdTotal)]
        public virtual decimal? UsdTotal { get; set; }

        #endregion Total USD

        #region Numero de Registro  del Propietario

        public abstract class ownerTaxRegistrationID : IBqlField
        {
        }
        [PXDBString(40)]
        [PXUIField(DisplayName = Messages.UsdTotal)]
        public virtual string OwnerTaxRegistrationID { get; set; }

        #endregion Numero de Registro del Propietario

        #region Residencia Fiscal del Propietario

        public abstract class ownerFiscalAddress : IBqlField
        {
        }
        [PXDBString(3)]
        public virtual string OwnerFiscalAddress { get; set; }
        [PXUIField(DisplayName = Messages.UsdTotal)]
        #endregion Residencia Fiscal del Propietario

        #region Numero de Registro  del Destinatario

        public abstract class receiverTaxRegistrationID : IBqlField
        {
        }
        [PXDBString(40)]
        [PXUIField(DisplayName = Messages.ReceiverTaxRegistrationID)]
        public virtual string ReceiverTaxRegistrationID { get; set; }

        #endregion Numero de Registro del Destinatario

        #region Nombre del Destinatario

        public abstract class receiverName : IBqlField
        {
        }
        [PXDBString(40)]
        [PXUIField(DisplayName = Messages.ReceiverName)]
        public virtual string ReceiverName { get; set; }

        #endregion Nombre del Destinatario

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
