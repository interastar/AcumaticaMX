using System;
using PX.Data;
using PX.Objects.IN;

namespace AcumaticaMX
{
    [Serializable]
    public class MXFEAgreementItem : IBqlTable
    {
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXParent(typeof(Select<MXFEAgreement,
            Where<MXFEAgreement.refNbr,
                Equal<Current<refNbr>>>>))]
        [PXDBDefault(typeof(MXFEAgreement.refNbr))]
        [PXDBString(15, IsKey = true, IsUnicode = true)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region AgreementNbr

        public abstract class agreementNbr : IBqlField
        {
        }
        [PXDBString(50, IsKey = true)]
        [PXDefault(typeof(MXFEAgreement.agreementNbr))]
        public virtual string AgreementNbr { get; set; }

        #endregion AgreementNbr

        #region LineNbr

        public abstract class lineNbr : IBqlField
        {
        }
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(MXFEAgreement.lineCntr))]
        public virtual int? LineNbr { get; set; }

        #endregion LineNbr

        #region InventoryItem

        public abstract class inventoryID : IBqlField
        {
        }
        [PXDBInt(IsKey = true)]
        [PXSelector(typeof(Search<InventoryItem.inventoryID>),
            SubstituteKey = typeof(InventoryItem.inventoryCD))]
        [PXDefault]
        [PXUIField(DisplayName = Messages.InventoryItem, Required = true)]
        public virtual int? InventoryID { get; set; }

        #endregion InventoryItem

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
