using System;
using PX.Data;

namespace AcumaticaMX
{
   
    public class MXFEPaymentTran : IBqlTable
    {
        //Pagos
        //Hacerlo iskey en el futuro
        #region DocType

        public abstract class docType : IBqlField
        {
        }

        [PXDBString(3, IsFixed = true)]
        [PXDefault(typeof(MXFEPayment.docType))]
        [PXUIField(DisplayName = "Tipo de Documento", Enabled = false)]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region RefNbr

        public abstract class refNbr : IBqlField{}

        [PXDBString(15, IsKey = true, InputMask = ">CCCCCCCCCC")]
        [PXParent(typeof(Select<MXFEPayment, 
            Where<MXFEPayment.docType, 
                Equal<Current<MXFEPaymentTran.docType>>, 
                And<MXFEPayment.refNbr, 
                    Equal<Current<MXFEPaymentTran.refNbr>>>>>))]
        [PXDefault(typeof(MXFEPayment.refNbr))]
        [PXUIField(DisplayName = "Numero de pago", Visible = true, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        //Ajustes

        //Documento de Pago
        #region AdjgDocType
        public abstract class adjgDocType : IBqlField{}
        [PXDBString(3, IsKey = true, IsFixed = true, InputMask = "")]
        public virtual String AdjgDocType
        {
            set;get;
        }
        #endregion


        #region AdjgRefNbr
        public abstract class adjgRefNbr : IBqlField{}
        [PXDBString(15, IsUnicode = true, IsKey = true)]
        public virtual String AdjgRefNbr
        {
            set;get;
        }
        #endregion

        //Factura Aplicada

        #region AdjdDocType
        public abstract class adjdDocType : IBqlField{ }
        [PXDBString(3, IsKey = true, IsFixed = true, InputMask = "")]
        public virtual string AdjdDocType
        {
            get;
            set;
        }
        #endregion

        public abstract class adjdRefNbr : IBqlField{}
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = ">CCCCCCCCCCCCCCC")]
        public virtual string AdjdRefNbr
        {
            set; get;
        }

        //Linea
        #region AdjNbr
        public abstract class adjNbr : IBqlField{}
        [PXDBInt(IsKey = true)]
        public virtual Int32? AdjNbr
        {
            set;get;
        }
        #endregion


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
