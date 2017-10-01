using PX.Data;
using PX.Objects.IN;
using System;


namespace AcumaticaMX
{
    public class MXFEUnit : IBqlTable
    {

        public abstract class unitCD : IBqlField
        {
        }
        [PXDBString(IsKey = true, IsFixed = true)]
        [PXSelector(
            typeof(Search4<INUnit.fromUnit,
                Where<INUnit.unitType,
                    Equal<GlobalUnit.Constant_3>>,
                Aggregate<
                    GroupBy<INUnit.fromUnit>>>),
            DescriptionField = typeof(INUnit.fromUnit))]
        [PXUIField(DisplayName = Messages.Unit)]
        [PXDefault]
        public virtual string UnitCD { get; set; }

        public abstract class measureCD : IBqlField
        {
        }
        [PXSelector(
            typeof(Search<MXFESatMeasureList.measureCD>),
            typeof(MXFESatMeasureList.name),
            typeof(MXFESatMeasureList.description),
            DescriptionField = typeof(MXFESatMeasureList.name))]
        [PXDBString]
        [PXDefault]
        [PXUIField(DisplayName = Messages.Measure)]
        public virtual string MeasureCD { get; set; }

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

    public class GlobalUnit
    {
        public class Constant_3 : Constant<int>
        {
            public Constant_3()
            : base(3)
            {
            }
        }
    }
}
