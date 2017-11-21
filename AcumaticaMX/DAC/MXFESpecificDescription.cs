using System;
using PX.Data;

namespace AcumaticaMX
{
    public class MXFESpecificDescription
    {
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXDBString(15)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region DocType

        public abstract class docType : IBqlField
        {
        }
        [PXDBString(3)]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region InventoryID

        public abstract class inventoryID : IBqlField
        {
        }
        [PXDBInt]
        public virtual int? InventoryID { get; set; }

        #endregion InventoryID

        #region CommodityLineNbr

        public abstract class commodityLineNbr : IBqlField
        {
        }
        [PXDBInt]
        public virtual int? CommodityLineNbr { get; set; }

        #endregion CommodityLineNbr

        #region LineNbr

        public abstract class lineNbr : IBqlField
        {
        }
        [PXDBIdentity]
        public virtual int? LineNbr { get; set; }

        #endregion LineNbr

        #region Marca

        public abstract class brand : IBqlField { }

        [PXDBString(35)]
        //[PXUIField(DisplayName = Messages.Brand)]
        public virtual string Brand { get; set; }

        #endregion Marca

        #region Modelo

        public abstract class model : IBqlField { }
        [PXDBString(80)]
        //[PXUIField(DisplayName = Messages.Model)]
        public virtual string Model { get; set; }

        #endregion Modelo

        #region SubModelo

        public abstract class subModel : IBqlField { }
        [PXDBString(50)]
        //[PXUIField(DisplayName = Messages.Model)]
        public virtual string SubModel { get; set; }

        #endregion SubModelo

        #region Numero de Serie

        public abstract class serieNbr : IBqlField { }
        [PXDBString(50)]
        //[PXUIField(DisplayName = Messages.Model)]
        public virtual string SerieNbr { get; set; }

        #endregion Numero de Serie

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
