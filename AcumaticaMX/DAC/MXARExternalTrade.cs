using PX.Data;
using System;
using PX.Objects.AR;
using PX.Objects.CS;
namespace AcumaticaMX
{
    [Serializable]
    public class MXARExternalTrade: IBqlTable
    {

        #region DocType
        public abstract class docType : PX.Data.IBqlField
        {
        }

        [PXDBString(IsKey = true)]
        [PXDBDefault(typeof(ARRegister.docType))]
        [PXParent(typeof(Select<ARRegister,
            Where<ARRegister.docType,
                Equal<Current<docType>>>>))]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region RefNbr

        public abstract class refNbr : PX.Data.IBqlField
        {
        }

        [PXDBString(IsKey = true)]
        [PXDBDefault(typeof(ARRegister.refNbr))]
        [PXParent(typeof(Select<ARRegister,
            Where<ARRegister.refNbr,
                Equal<Current<refNbr>>>>))]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region TransferReason

        public abstract class transferReason : PX.Data.IBqlField
        {
        }

        [PXDBString]
        [PXStringList(
            new string[]
            {
                "01","02","03","04","05","99"
            },
            new string[]
            {
                "Envío de mercancias facturadas con anterioridad",
                "Reubicación de mercancias propias",
                "Envío de mercancias objeto de contrato de consignación",
                "Envío de mercancias para posterior enajenación",
                "Envío de mercancias propiedad de terceros",
                "Otros"
            })]
        [PXUIField(DisplayName = "Motivo de Traslado")]
        public virtual string TransferReason { get; set; }

        #endregion TransferReason

        #region OperationType

        public abstract class operationType : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        [PXDefault(2,PersistingCheck = PXPersistingCheck.Nothing)] // catalogo
        [PXUIField(DisplayName = "Tipo de Operación", IsReadOnly = true)]
        public virtual int? OperationType { get; set; }

        #endregion OperationType

        #region RequestKey

        public abstract class requestKey : PX.Data.IBqlField
        {
        }

        [PXDBString]
        [PXStringList(
            new string[]
            {
                "A1"
            },
            new string[]
            {
                "Importación y Exportacion definitiva"
            })]
        [PXUIField(DisplayName = "Clave de Pedimento")]
        public virtual string RequestKey { get; set; }

        #endregion RequestKey

        #region OriginCertified

        public abstract class originCertified : PX.Data.IBqlField
        {
        }

        [PXDBBool]
        [PXUIField(DisplayName = "Funge como certificado de origen")]
        public virtual bool? OriginCertified { get; set; }

        #endregion OriginCertified

        #region OriginCertifiedNumber

        public abstract class originCertifiedNumber : PX.Data.IBqlField
        {
        }

        [PXDBString]
        [PXUIField(DisplayName = "Numero de Certificado de Origen")]
        public virtual string OriginCertifiedNumber { get; set; }

        #endregion OriginCertifiedNumber

        #region Incoterm

        public abstract class incoterm : PX.Data.IBqlField
        {
        }

        [PXDBString]
        [PXSelector(typeof(ShipTerms.shipTermsID))]
        [PXUIField(DisplayName = "Incoterm")]
        public virtual string Incoterm { get; set; }

        #endregion Incoterm

        #region Subdivision

        public abstract class subdivision : PX.Data.IBqlField
        {
        }

        [PXDBBool]
        [PXUIField(DisplayName = "Division de Factura")]
        public virtual bool? Subdivision { get; set; }

        #endregion Subdivision

        #region ExchangeRate

        public abstract class exchangeRate : PX.Data.IBqlField
        {
        }

        [PXDBString]
        [PXUIField(DisplayName = "Tipo de Cambio en Dolares")]
        public virtual string ExchangeRate { get; set; }

        #endregion ExchangeRate

        #region Observations

        public abstract class observations : PX.Data.IBqlField
        {
        }

        [PXDBString]
        [PXUIField(DisplayName = "Observaciones")]
        public virtual string Observations { get; set; }

        #endregion Observations

        // Audit
        
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

    }
}
