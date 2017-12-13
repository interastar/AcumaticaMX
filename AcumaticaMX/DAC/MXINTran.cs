using System;
using PX.Data;
using PX.Objects.IN;

namespace AcumaticaMX
{
    [Serializable]
    public class MXINTran : IBqlTable
    {
        //KEYS
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXDBString(15, IsKey = true)]
        [PXUIField(DisplayName = Messages.LineNbr, Enabled = false)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region DocType

        public abstract class docType : IBqlField
        {
        }
        [PXDBString(3, IsKey = true)]
        [PXUIField(DisplayName = Messages.LineNbr, Enabled = false)]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region LineNbr

        public abstract class lineNbr : IBqlField
        {
        }
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = Messages.LineNbr, Enabled = true)]
        public virtual int? LineNbr { get; set; }

        #endregion LineNbr

        #region InventoryID

        public abstract class inventoryID : IBqlField
        {
        }
        [PXDBInt]
        [PXUIField(DisplayName = "InventoryID", Enabled = false)]
        public virtual int? InventoryID { get; set; }

        #endregion InventoryID

        //DATA
        #region Customs

        public abstract class customs : IBqlField
        {
        }

        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.Customs, Enabled = false)]
        public virtual string Customs { get; set; }

        #endregion Customs

        #region ImportDate

        public abstract class importDate : IBqlField
        {
        }

        [PXDBDate()]
        [PXUIField(DisplayName = Messages.ImportDate, Enabled = true)]
        public virtual DateTime? ImportDate { get; set; }

        #endregion ImportDate

        #region RequestNbr

        public abstract class requestNbr : IBqlField
        {
        }

        [PXDBString(21, IsUnicode = true, IsFixed = true, InputMask = "00  00  0000  0000000")]
        [PXUIField(DisplayName = Messages.RequestNumber, Enabled = true)]
        [RequestNumber("Es necesario asignar el numero de pedimento", typeof(requestNbr))]
        public virtual string RequestNbr { get; set; }

        #endregion RequestNbr

        //

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
