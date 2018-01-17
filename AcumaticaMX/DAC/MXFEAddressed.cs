using System;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.CR;

namespace AcumaticaMX
{
    [Serializable]
    public class MXFEAddressed : IBqlTable
    {
        #region RefNbr

        public abstract class refNbr : IBqlField
        {
        }
        [PXParent(typeof(Select<ARRegister,
            Where<ARRegister.refNbr,
                Equal<Current<refNbr>>>>))]
        [PXDBString(15, IsKey = true)]
        [PXDefault(typeof(ARRegister.refNbr))]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region DocType

        public abstract class docType : IBqlField
        {
        }
        [PXDBString(3, IsKey = true)]
        [PXDefault(typeof(ARRegister.docType))]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region HasAddressed

        public abstract class hasAddressed : IBqlField
        {
        }
        [PXDBBool]
        [PXUIField(DisplayName = Messages.HasAddressed)]
        public virtual bool? HasAddressed { get; set; }

        #endregion HasAddressed

        #region Numero de Registro  del Destinatario

        public abstract class receiverTaxRegistrationID : IBqlField
        {
        }
        [PXDBString(40)]
        [PXUIField(DisplayName = Messages.ReceiverTaxRegistrationID)]
        public virtual string ReceiverTaxRegistrationID { get; set; }

        #endregion Numero de Registro del Destinatario

        #region Nombre del Destinatario

        public abstract class receiverName : IBqlField
        {
        }
        [PXDBString(300)]
        [PXUIField(DisplayName = Messages.ReceiverName)]
        public virtual string ReceiverName { get; set; }

        #endregion Nombre del Destinatario

        #region Street

        public abstract class street : IBqlField
        {
        }
        [PXDBString(100)]
        [PXUIField(DisplayName = Messages.Street)]
        public virtual string Street { get; set; }

        #endregion Street

        #region OutdoorNumber

        public abstract class outdoorNumber : IBqlField
        {
        }
        [PXDBString(55)]
        [PXUIField(DisplayName = Messages.OutdoorNumber)]
        public virtual string OutdoorNumber { get; set; }

        #endregion OutdoorNumber

        #region IndoorNumber

        public abstract class indoorNumber : IBqlField
        {
        }
        [PXDBString(55)]
        [PXUIField(DisplayName = Messages.IndoorNumber)]
        public virtual string IndoorNumber { get; set; }

        #endregion IndoorNumber

        #region Neighborhood

        public abstract class neighborhood : IBqlField
        {
        }
        [PXDBString(120)]
        [PXUIField(DisplayName = Messages.NeighborhoodCD)]
        public virtual string Neighborhood { get; set; }

        #endregion Neighborhood

        #region Location

        public abstract class location : IBqlField
        {
        }
        [PXDBString(120)]
        [PXUIField(DisplayName = Messages.Town)]
        public virtual string Location { get; set; }

        #endregion Location

        #region Municipality

        public abstract class municipality : IBqlField
        {
        }
        [PXDBString(120)]
        [PXUIField(DisplayName = Messages.Municipality)]
        public virtual string Municipality { get; set; }

        #endregion Municipality

        #region State

        public abstract class state : IBqlField
        {
        }
        [PXDBString(30)]
        [PXUIField(DisplayName = Messages.State)]
        public virtual string State { get; set; }

        #endregion State

        #region Country

        public abstract class country : IBqlField
        {
        }
        [PXDBString(3)]
        [PXSelector(typeof(Search<MXFESatCountryList.countryCD>),
            typeof(MXFESatCountryList.name),
            DescriptionField = typeof(MXFESatCountryList.name))]
        [PXUIField(DisplayName = Messages.Country)]
        public virtual string Country { get; set; }

        #endregion Country

        #region ZipCode

        public abstract class zipCode : IBqlField
        {
        }
        [PXDBString(12)]
        [PXUIField(DisplayName = Messages.ZipCodeCD)]
        public virtual string ZipCode { get; set; }

        #endregion ZipCode

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
