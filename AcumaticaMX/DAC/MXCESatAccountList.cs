using System;
using PX.Data;

namespace AcumaticaMX
{
    public class MXCESatAccountList : IBqlTable
    {

        #region GroupingCodeCD

        public abstract class groupingCodeCD : PX.Data.IBqlField
        {
        }

        [PXDBString(6, IsKey = true, IsUnicode = true, InputMask = ">CCCCCC")]
        [PXDefault]
        [PXUIField(DisplayName = Messages.GroupingCodeLabel)]
        public virtual string GroupingCodeCD { get; set; }

        #endregion GroupingCodeCD

        #region GroupingCodeID

        public abstract class groupingCodeID : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        public virtual int? GroupingCodeID { get; set; }

        #endregion GroupingCodeID

        #region Level

        public abstract class level : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        [PXUIField(DisplayName = Messages.LevelLabel)]
        public virtual int? Level { get; set; }

        #endregion Level

        #region Description

        public abstract class description : PX.Data.IBqlField
        {
        }

        [PXDBString(250, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.DescriptionLabel)]
        public virtual string Description { get; set; }

        #endregion Description

        #region ParentCD

        public abstract class parentCD : PX.Data.IBqlField
        {
        }

        [PXDBString(6, IsUnicode = true)]
        public virtual string ParentCD { get; set; }

        #endregion ParentCD

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