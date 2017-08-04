using System;
using PX.Data;
using PX.Objects;
using PX.Objects.IN;
namespace AcumaticaMX
{
    public class MXINItemLotSerial : IBqlTable
    {

        #region RefNbr
        public abstract class refNbr : IBqlField
        {
        }
        [PXDBString(15, IsUnicode = true)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region InventoryID

        public abstract class inventoryID : IBqlField
        {
        }
        [PXDefault]
        [PXDBInt(IsKey = true)]
        public virtual int? InventoryID { get; set; }

        #endregion InventoryID

        #region LotSerialNbr

        public abstract class lotSerialNbr : IBqlField
        {
        }
        [PXDefault]
        [PXDBString(50, IsUnicode = true, IsKey = true)]
        [PXParent(typeof(Select<PX.Objects.IN.INItemLotSerial,
            Where<PX.Objects.IN.INItemLotSerial.lotSerialNbr,
                Equal<Current<lotSerialNbr>>>>))]
        public virtual string LotSerialNbr { get; set; }

        #endregion LotSerialNbr

        #region Customs

        public abstract class customs : IBqlField
        {
        }

        [PXDBString(40, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.Customs)]
        public virtual string Customs { get; set; }

        #endregion Customs

        #region ImportDate

        public abstract class importDate : IBqlField
        {
        }

        [PXDBDate()]
        [PXUIField(DisplayName = Messages.ImportDate)]
        public virtual DateTime? ImportDate { get; set; }

        #endregion ImportDate

        #region RequestNbr

        public abstract class requestNbr : IBqlField
        {
        }

        [PXDBString(40, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.RequestNumber)]
        [ValidateFields(Messages.ErrorCustoms, typeof(customs), typeof(importDate))]
        public virtual string RequestNbr { get; set; }

        #endregion RequestNbr

        #region LineNbr

        public abstract class lineNbr : IBqlField
        {
        }
        [PXDefault]
        [PXDBInt(IsKey = true)]
        public virtual int? LineNbr { get; set; }

        #endregion LineNbr

        #region ItemSold

        public abstract class itemSold : PX.Data.IBqlField
        {
        }

        [PXDBBool()]
        [PXDefault(false)]
        public virtual bool? ItemSold { get; set; }

        #endregion ItemSold

        #region BatchSold

        public abstract class batchSold : PX.Data.IBqlField
        {
        }

        [PXDBBool()]
        [PXDefault(false)]
        public virtual bool? BatchSold { get; set; }

        #endregion BatchSold

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
    }
}
