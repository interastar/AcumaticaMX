using System;
using PX.Data;
using PX.Objects.AR;

namespace AcumaticaMX
{
    public class MXARPaymentNotifications : IBqlTable
    {
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXDBString(IsKey = true)]
        [PXParent(typeof(Select<ARPayment,
            Where<ARPayment.refNbr,
                Equal<Current<ARPayment.refNbr>>,
                    And<ARPayment.docType,
                        Equal<ARPayment.docType>>>>))]
        [PXDBDefault(typeof(ARPayment.refNbr))]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region DocType

        public abstract class docType : IBqlField
        {
        }
        [PXDBString(IsKey = true)]
        [PXDBDefault(typeof(ARPayment.docType))]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region LineNbr
        public abstract class lineNbr : PX.Data.IBqlField
        {
        }
        [PXDBIdentity(IsKey = true)]
        public virtual int? LineNbr { get; set; }
        #endregion LineNbr

        #region Send

        public abstract class send : IBqlField { }

        [PXDBBool]
        [PXDefault(true)]
        [PXUIField(DisplayName = "Enviar por correo", Visibility = PXUIVisibility.SelectorVisible, Enabled = true)]
        public virtual bool? Send { get; set; }

        #endregion Send

        #region StampedUuid

        public abstract class stampedUuid : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Uuid")]
        public virtual Guid? StampedUuid { get; set; }

        #endregion StampedUuid

        #region AttachedUuid

        public abstract class attachedUuid : IBqlField { }

        [PXDBGuid]
        public virtual Guid? AttachedUuid { get; set; }

        #endregion AttachedUuid

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
