using PX.Data;
using PX.Objects.AP;
using System;


namespace AcumaticaMX
{
    [Serializable]
    public class MXAPVendorPayments : IBqlTable
    {
        #region BAccountID
        public abstract class bAccountID : PX.Data.IBqlField
        {
        }
        [PXDBInt(IsKey = true)]
        [PXParent(typeof(Select<VendorR,
            Where<VendorR.bAccountID,
                Equal<Current<bAccountID>>>>))]
        [PXDBDefault(typeof(VendorR.bAccountID))]
        public virtual int? BAccountID { get; set; }
        #endregion

        #region LineNbr
        public abstract class lineNbr : PX.Data.IBqlField
        {
        }
        [PXDBIdentity(IsKey = true)]
        public virtual int? LineNbr { get; set; }
        #endregion LineNbr

        #region MetodoDePago

        public abstract class paymentMethod : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXDefault(AcumaticaMX.Common.PayMethod.Transfer)]
        [PXSelector(typeof(Search<MXFESatPaymentMethodList.satPaymentMethod>),
            typeof(MXFESatPaymentMethodList.description),
            DescriptionField = typeof(MXFESatPaymentMethodList.description),
            SelectorMode = PXSelectorMode.DisplayModeText)]
        [PXUIField(DisplayName = "Forma de Pago")]
        public virtual string PaymentMethod { get; set; }

        #endregion MetodoDePago

        #region Bank

        public abstract class bankCD : IBqlField
        {
        }

        [PXDBString(3, IsUnicode = true)]
        [PXSelector(
            typeof(Search<MXFESatBankList.bankCD>),
            typeof(MXFESatBankList.bankName),
            DescriptionField = typeof(MXFESatBankList.bankName),
            SelectorMode = PXSelectorMode.DisplayMode)]
        [PXUIField(DisplayName = "Banco")]
        public virtual string BankCD { get; set; }

        #endregion Bank

        #region BankName

        public abstract class bankName : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [PXFormula(typeof(Selector<bankCD, MXFESatBankList.bankName>))]
        [PXUIField(DisplayName = "Nombre del banco", Visible = false)] // Este atributo lo mantiene invisible
        public virtual string BankName { get; set; }

        #endregion BankName

        #region Bank Account

        public abstract class bankAccount : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "Numero de cuenta bancario")]
        public virtual string BankAccount { get; set; }

        #endregion Bank Account

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
