using System;
using PX.Data;
using PX.Objects.AR;
namespace AcumaticaMX
{
    [Serializable]
    public class MXFERelatedDocument : IBqlTable
    {
        #region DocType

        public abstract class docType : IBqlField
        {
        }
        [PXDBString(3, IsKey = true, IsFixed = true)]
        [PXDBDefault(typeof(ARRegister.docType))]
        [PXUIField(DisplayName = "Tipo (Principal)")]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXDBString(15, IsUnicode = true, IsKey = true)]
        [PXDBDefault(typeof(ARRegister.refNbr))]
        [PXParent(typeof(Select<ARRegister,
            Where<ARRegister.docType,
                Equal<Current<docType>>,
                And<ARRegister.refNbr,
                    Equal<Current<refNbr>>>>>))]
        [PXUIField(DisplayName = "No. Referencia (Principal)")]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region RelatedDocType

        public abstract class relatedDocType : IBqlField
        {
        }
        [PXDBString(3, IsKey = true, IsFixed = true)]
        [PXUIField( DisplayName = "Tipo")]
        public virtual string RelatedDocType { get; set; }

        #endregion RelatedDocType

        #region RelatedRefNbr

        public abstract class relatedRefNbr : IBqlField
        {
        }
        [PXDBString(15, IsUnicode = true, IsKey = true)]
        [PXUIField(DisplayName = "No. Referencia")]
        public virtual string RelatedRefNbr { get; set; }

        #endregion RelatedRefNbr

        #region RelationType

        public abstract class relationType : IBqlField
        {
        }
        [PXDBString(2)]
        [PXStringList(
            new string[]
            {
                Common.RelationType.CreditMemo,
                Common.RelationType.DebitMemo,
                Common.RelationType.Refund,
                Common.RelationType.Replace,
                Common.RelationType.Transfers,
                Common.RelationType.InvoiceTransfers,
                Common.RelationType.Advance,
            },
            new string[]
            {
                Common.RelationType.CreditMemoLabel,
                Common.RelationType.DebitMemoLabel,
                Common.RelationType.RefundLabel,
                Common.RelationType.ReplaceLabel,
                Common.RelationType.TransfersLabel,
                Common.RelationType.InvoiceTransfersLabel,
                Common.RelationType.AdvanceLabel,
            }
            )]
        [PXUIField(DisplayName = "Tipo de relación", Enabled = false)]
        public virtual string RelationType { get; set; }

        #endregion RelationType

        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid]
        [PXFormula(typeof(Selector<MXFERelatedDocument.relatedRefNbr, MXARRegisterExtension.uuid>))]
        [PXUIField(DisplayName = "UUID", Enabled = false, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

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
