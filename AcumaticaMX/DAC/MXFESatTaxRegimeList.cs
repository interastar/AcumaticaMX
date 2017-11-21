using System;
using PX.Data;

namespace AcumaticaMX
{
    public class MXFESatTaxRegimeList : IBqlTable
    {

        public abstract class taxRegimeID : IBqlField
        {
        }
        [PXDBInt(IsKey = true)]
        [PXDefault]
        [PXUIField(DisplayName = Messages.TaxRegimCD)]
        public virtual int? TaxRegimeID { get; set; }

        public abstract class description : IBqlField
        {
        }
        [PXDBString]
        [PXDefault]
        [PXUIField(DisplayName = Messages.DescriptionLabel)]
        public virtual string Description { get; set; }

        public abstract class applyNaturalPerson : IBqlField
        {
        }
        [PXDBBool]
        [PXDefault]
        [PXUIField(DisplayName = Messages.ApplyNaturalPerson)]
        public virtual bool? ApplyNaturalPerson { get; set; }

        public abstract class applyMoralPerson : IBqlField
        {
        }
        [PXDBBool]
        [PXDefault]
        [PXUIField(DisplayName = Messages.ApplyMoralPerson)]
        public virtual bool? ApplyMoralPerson { get; set; }

        public abstract class validityStartDate : IBqlField
        {
        }
        [PXDBDate]
        [PXDefault]
        [PXUIField(DisplayName = Messages.ValidityStartDate)]
        public virtual System.DateTime? ValidityStartDate { get; set; }

        public abstract class validityEndDate : IBqlField
        {
        }
        [PXDBDate]
        [PXUIField(DisplayName = Messages.ValidityEndDate)]
        public virtual System.DateTime? ValidityEndDate { get; set; }

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
