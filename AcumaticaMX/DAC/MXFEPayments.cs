﻿using System;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.CR;
namespace AcumaticaMX
{
    [Serializable]
    public class MXFEPayments : IBqlTable
    {
        #region PaymentRefNbr

        public abstract class paymentRefNbr : IBqlField
        {
        }

        [PXDBString(15, IsKey = true, InputMask = ">CCCCCCCCCC")]
        [PXSelector(typeof(Search<MXFEPayments.paymentRefNbr>),
            typeof(paymentRefNbr),
            typeof(customerID))]
        [PXUIField(DisplayName = "Numero de pago", Visible = true, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string PaymentRefNbr { get; set; }

        #endregion PaymentRefNbr

        #region StampedUuid

        public abstract class stampedUuid : IBqlField { }

        [PXDBGuid]
        [PXUIField(DisplayName = "Folio Fiscal del Complemento de Pago", Enabled = false, Visibility = PXUIVisibility.SelectorVisible)]
        [CfdiStatus(typeof(stampStatus), typeof(stampedUuid), typeof(cancelDate))]
        public virtual Guid? StampedUuid { get; set; }

        #endregion StampedUuid

        #region CancelDate

        public abstract class cancelDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion CancelDate

        #region CustomerID

        public abstract class customerID : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        [PXSelector(typeof(Search<BAccount.bAccountID,
            Where<BAccount.bAccountID,
                Equal<Current<ARPayment.customerID>>>>),
            SubstituteKey = typeof(BAccount.acctName))]
        [PXUIField(DisplayName = "Cliente", Enabled = false, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual int? CustomerID { get; set; }

        #endregion CustomerID

        #region SelloSAT

        public abstract class stamp : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello SAT", Enabled = false)]
        public virtual string Stamp { get; set; }

        #endregion SelloSAT

        #region Sello CFD

        public abstract class cFDSeal : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello CFD", Enabled = false)]
        public virtual string CFDSeal { get; set; }

        #endregion Sello CFD

        #region CadenaOriginalTFD

        public abstract class stampString : IBqlField { }

        [PXDBString(1000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cadena Original TFD", Enabled = false)]
        public virtual string StampString { get; set; }

        #endregion CadenaOriginalTFD

        #region FechaTimbrado

        public abstract class stampDate : IBqlField { }
        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
        public virtual DateTime? StampDate { get; set; }

        #endregion FechaTimbrado

        #region AttachedUuid

        public abstract class attachedUuid : IBqlField { }

        [PXDBGuid]
        public virtual Guid? AttachedUuid { get; set; }

        #endregion AttachedUuid

        #region Estado

        public abstract class stampStatus : IBqlField { }

        [PXString(1, IsFixed = true)]
        [PXUIField(DisplayName = "Edo. Timbrado", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true, Enabled = false)]
        [CfdiStatus.List()]
        public virtual string StampStatus { get; set; }

        #endregion Estado

        #region QrCode

        public abstract class qrCode : IBqlField { }

        [PXDBString(95, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Codigo QR", Enabled = false)]
        public virtual string QrCode { get; set; }

        #endregion QrCode

        #region QrCodeImg

        public abstract class qrCodeImg : PX.Data.IBqlField
        {
        }

        /// <summary>
        /// Propiedad disponible para calcular y mostrar la imagen del código QR.
        /// </summary>
        /// <value>
        /// Debe regresar un Data URL con el contenido de la imagen del código.
        /// </value>
        [PXString(IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Código QR", IsReadOnly = true)]
        public virtual string QrCodeImg { get; set; }

        #endregion QrCodeImg

        #region Version

        public abstract class version : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        public virtual string Version { get; set; }

        #endregion Version

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
