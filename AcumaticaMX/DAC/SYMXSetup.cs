using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;
namespace MX.Objects
{

    public class SYMXSetup : IBqlTable
    {
        #region MainBranch

        public abstract class mainBranch : IBqlField { }
        [PXDBInt]
        [PXDBDefault]
        [PXSelector(typeof(PX.Objects.GL.Branch.branchID),
            SubstituteKey = typeof(PX.Objects.GL.Branch.branchCD),
            DescriptionField = typeof(PX.Objects.GL.Branch.acctName)
            )]
        [PXUIField(DisplayName = Messages.MainBranch)]
        public virtual int? MainBranch { get; set; }

        #endregion MainBranch

        #region Credentials

        public abstract class credentials : IBqlField { }
        [PXDBString]
        [PXSelector(typeof(PX.SM.Certificate.name))]
        [PXUIField(DisplayName = Messages.Credentials)]
        public virtual string Credentials { get; set; }

        #endregion Credentials

        #region CertificateNbr

        public abstract class certificateNbr : IBqlField { }
        [PXDBString]
        [PXDBDefault]
        [PXUIField(DisplayName = Messages.CertificateNbr)]
        public virtual string CertificateNbr { get; set; }

        #endregion CertificateNbr

        #region Audit

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

        #endregion Audit

    }
}