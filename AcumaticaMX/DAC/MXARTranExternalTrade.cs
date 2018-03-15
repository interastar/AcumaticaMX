using System;
using PX.Data;
using PX.Objects;
using PX.Objects.AR;

namespace AcumaticaMX
{
    public class MXARTranExternalTrade : IBqlTable
    {

        #region DocType
        public abstract class docType : PX.Data.IBqlField
        {
        }

        [PXDBString(IsKey = true)]
        [PXDBDefault(typeof(ARTran.tranType))]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region RefNbr

        public abstract class refNbr : PX.Data.IBqlField
        {
        }

        [PXDBString(IsKey = true)]
        [PXDBDefault(typeof(ARTran.refNbr))]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region LineNbr

        public abstract class lineNbr : IBqlField
        {
        }

        [PXDBInt(IsKey = true)]
        [PXDBDefault(typeof(ARTran.lineNbr))]
        [PXParent(typeof(Select<ARTran,
            Where<ARTran.tranType, Equal<Current<docType>>, 
            And<ARTran.refNbr, Equal<Current<refNbr>>,
            And<ARTran.lineNbr, Equal<Current<lineNbr>>>>>>))]
        public virtual int? LineNbr { get; set; }

        #endregion LineNbr

        #region Qyt

        public abstract class qty : IBqlField
        {
        }

        [PXDecimal]
        [PXFormula(typeof(Parent<ARTran.qty>))]
        [PXUIField(DisplayName = "Cantidad")]
        public virtual Decimal? Qty { get; set; }

        #endregion Qyt

        #region TariffUnit

        public abstract class tariffUnit : IBqlField
        {
        }

        [PXDBString(2, IsUnicode = true)]
        [PXUIField(DisplayName = "Unidad Aduana")]
        public virtual string TariffUnit { get; set; }

        #endregion TariffUnit

        #region TariffFraction

        public abstract class tariffFraction : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "Fracción Arancelaría")]
        public virtual string TariffFraction { get; set; }

        #endregion TariffFraction

        #region TariffUnitValue

        public abstract class tariffUnitValue : IBqlField
        {
        }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Valor Unitario Aduanal")]
        public virtual decimal? TariffUnitValue { get; set; }

        #endregion TariffUnitValue

        #region TariffTotalValue

        public abstract class tariffTotalValue : IBqlField
        {
        }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Valor Total Aduanal")]
        public virtual decimal? TariffTotalValue { get; set; }

        #endregion TariffTotalValue

        #region Brand

        public abstract class brand : IBqlField
        {
        }

        [PXDBString(35)]
        [PXUIField(DisplayName = "Marca")]
        public virtual string Brand { get; set; }

        #endregion Brand

        #region Model

        public abstract class model : IBqlField
        {
        }

        [PXDBString(35)]
        [PXUIField(DisplayName = "Modelo")]
        public virtual string Model { get; set; }

        #endregion Model

        #region SubModel

        public abstract class subModel : IBqlField
        {
        }

        [PXDBString(35)]
        [PXUIField(DisplayName = "SubModelo")]
        public virtual string SubModel { get; set; }

        #endregion SubModel

        #region SerieNumber

        public abstract class serieNumber : IBqlField
        {
        }

        [PXDBString(35)]
        [PXUIField(DisplayName = "Numero de Serie")]
        public virtual string SerieNumber { get; set; }

        #endregion SerieNumber

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
