using System;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.IN;
namespace AcumaticaMX
{
    [Serializable]
    public class MXFECommodity : IBqlTable
    {
        #region DocType

        public abstract class docType : IBqlField
        {
        }

        [PXDBString(3, IsKey = true, IsFixed = true)]
        [PXDBDefault(typeof(ARTran.tranType))]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }

        [PXDBString(15, IsKey = true, IsUnicode = true)]
        [PXDBDefault(typeof(ARTran.refNbr))]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region LineNbr

        public abstract class lineNbr : IBqlField
        {
        }

        [PXDBInt(IsKey = true)]
        [PXParent(typeof(Select<ARTran,
            Where<ARTran.refNbr,
                Equal<Current<refNbr>>,
                And<ARTran.tranType,
                    Equal<Current<docType>>,
                    And<ARTran.lineNbr,
                        Equal<Current<lineNbr>>>>>>))]
        [PXDBDefault(typeof(ARTran.lineNbr))]
        public virtual int? LineNbr { get; set; }

        #endregion LineNbr


        #region InventoryID

        public abstract class inventoryID : IBqlField
        {
        }
        [PXDBInt]
        [PXSelector(typeof(Search<InventoryItem.inventoryID>))]
        public virtual int? InventoryID { get; set; }

        #endregion InventoryID

        #region Numero de identificacion

        public abstract class identificationCD : IBqlField
        {
        }
        [PXDBString(100)]
        [PXFormula(typeof(Selector<inventoryID, InventoryItem.inventoryCD>))]
        [PXUIField(DisplayName = Messages.NumberID, Enabled = false)]
        public virtual string IdentificationCD { get; set; }

        #endregion Numero de identificacion

        #region Fracción Arancelaria

        public abstract class tariffFraction : IBqlField
        {
        }
        [PXDBString(100)]
        [PXUIField(DisplayName = Messages.TarrifFraction, Enabled = true)]
        public virtual string TariffFraction { get; set; }

        #endregion Fracción Arancelaria

        #region Cantidad Aduana

        public abstract class customsQty : IBqlField
        {
        }
        [PXDBDecimal]
        public virtual decimal? CustomsQty { get; set; }

        #endregion Cantidad Aduana

        #region Unidad Aduana

        public abstract class customsUnit : IBqlField
        {
        }
        [PXDBString(3)]
        [PXSelector(typeof(Search<MXFESatMeasureList.measureCD>),
            SubstituteKey = typeof(MXFESatMeasureList.name),
            SelectorMode = PXSelectorMode.TextMode)]
        [PXUIField(DisplayName = Messages.CustomsUnit, Enabled = false)]
        public virtual string CustomsUnit { get; set; }

        #endregion Unidad Aduana

        #region Valor Unitario de Aduana

        public abstract class customsUnitAmt : IBqlField
        {
        }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = Messages.CustomsUnitAmt, Enabled = true)]
        public virtual decimal? CustomsUnitAmt { get; set; }

        #endregion Valor Unitario de Aduana

        #region Valor en Dolares

        public abstract class usdAmt : IBqlField
        {
        }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = Messages.UsdAmt, Enabled = false)]
        [PXFormula(typeof(Mult<customsQty, customsUnitAmt>))]
        public virtual decimal? UsdAmt { get; set; }

        #endregion Valor en Dolares

        #region LineCntr

        public abstract class lineCntr : IBqlField
        {
        }
        [PXDBInt]
        [PXDefault(0)]
        public virtual int? LineCntr { get; set; }

        #endregion LineCntr

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
