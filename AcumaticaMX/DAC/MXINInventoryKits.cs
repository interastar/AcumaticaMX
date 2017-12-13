using System;
using PX.Data;
namespace AcumaticaMX
{
    [Serializable]
    public class MXINInventoryKits : IBqlTable
    {
        #region RefNbr
        public abstract class refNbr : IBqlField
        {
        }
        [PXDBString(15, IsUnicode = true)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region DocType
        public abstract class docType : IBqlField
        {
        }
        [PXDBString(3, IsUnicode = true)]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region InventoryID

        public abstract class inventoryID : IBqlField
        {
        }
        [PXDBInt(IsKey = true)]
        public virtual int? InventoryID { get; set; }

        #endregion InventoryID

        #region LotSerialNbr

        public abstract class lotSerialNbr : IBqlField
        {
        }
        [PXDefault]
        [PXDBString(50, IsUnicode = true, IsKey = true)]
        public virtual string LotSerialNbr { get; set; }

        #endregion LotSerialNbr        
        
        #region KitNbr

        public abstract class kitNbr : IBqlField
        {
        }
        [PXDBInt(IsKey = true)]
        public virtual int? KitNbr { get; set; }

        #endregion KitNbr

        #region ItemSold

        public abstract class itemSold : PX.Data.IBqlField
        {
        }

        [PXDBBool()]
        [PXDefault(false)]
        public virtual bool? ItemSold { get; set; }

        #endregion ItemSold

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
