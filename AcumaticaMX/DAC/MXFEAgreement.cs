using System;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.CR;
namespace AcumaticaMX
{
    [Serializable]
    public class MXFEAgreement : IBqlTable
    {
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXDBString(15, IsKey = true, IsUnicode = true)]
        [PXSelector(typeof(Search<MXFEAgreement.refNbr>))]
        [PXUIField(DisplayName = Messages.RefNbr)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region AgreementName

        public abstract class agreementName : IBqlField
        {
        }
        [PXDBString(50, IsUnicode = true)]
        [PXDefault]
        [PXUIField(DisplayName = Messages.AgreemenName, Required = true)]
        public virtual string AgreementName { get; set; }

        #endregion AgreementName

        #region AgreementNbr

        public abstract class agreementNbr : IBqlField
        {
        }

        [PXDBString(50)]
        [PXDefault]
        [PXUIField(DisplayName = Messages.AgreemenNbr, Required = true)]
        public virtual string AgreementNbr { get; set; }

        #endregion AgreementNbr

        #region CustomerID

        public abstract class customerID : IBqlField
        {
        }
        [PXDBInt]
        [PXSelector(typeof(Search<Customer.bAccountID,
            Where<Customer.status, IsNull,
                        Or<Customer.status, Equal<BAccount.status.active>,
                        Or<Customer.status, Equal<BAccount.status.oneTime>>>>>),
            typeof(Customer.acctCD),
            typeof(Customer.acctName),
            SubstituteKey = typeof(Customer.acctName))]
        [PXDefault]
        [PXUIField(DisplayName = Messages.Customer, Required = true)]
        public virtual int? CustomerID { get; set; }

        #endregion CustomerID

        #region StartDate

        public abstract class startDate : IBqlField
        {
        }
        [PXDBDateAndTime]
        [PXDefault]
        [PXUIField(DisplayName = Messages.ValidityStartDate, Required = true)]
        public virtual DateTime? StartDate { get; set; }

        #endregion StartDate

        #region EndDate

        public abstract class endDate : IBqlField
        {
        }
        [PXDBDateAndTime]
        [PXDefault]
        [PXUIField(DisplayName = Messages.ValidityEndDate, Required = true)]
        public virtual DateTime? EndDate { get; set; }

        #endregion EndDate

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
