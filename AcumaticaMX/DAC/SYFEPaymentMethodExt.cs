using PX.Data;
using PX.Objects.CA;
using System;

namespace MX.Objects
{
    [Serializable]
    [PXTable(typeof(PaymentMethod.paymentMethodID), IsOptional = true)]
    public class SYFEPaymentMethodExt : PXCacheExtension<PaymentMethod>
    {
        #region PaymentMethodID

        public abstract class paymentMethodID : PX.Data.IBqlField
        {
        }

        [PXDBString(10, IsUnicode = true, IsKey = true)]
        [PXDefault()]
        [PXSelector(typeof(Search<PaymentMethod.paymentMethodID>))]
        public virtual string PaymentMethodID { set; get; }

        #endregion PaymentMethodID

        #region SatPaymentMethod

        public abstract class satPaymentMethod : IBqlField
        {
        }

        [PXDBString(40, IsUnicode = true)]
        [PXDefault(MX.Objects.Common.PayMethod.Cash)]
        [PXStringList(
            new string[]
            {
                        MX.Objects.Common.PayMethod.Cash, MX.Objects.Common.PayMethod.Cheque,
                        MX.Objects.Common.PayMethod.Transfer, MX.Objects.Common.PayMethod.CreditCard,
                        MX.Objects.Common.PayMethod.Wallet, MX.Objects.Common.PayMethod.Electronic,
                        MX.Objects.Common.PayMethod.Coupons, MX.Objects.Common.PayMethod.DebitCard,
                        MX.Objects.Common.PayMethod.ServiceCard, MX.Objects.Common.PayMethod.Other,
                        MX.Objects.Common.PayMethod.NAFE, MX.Objects.Common.PayMethod.NACE,
            },
            new string[]
            {
                        MX.Objects.Common.PayMethod.CashLabel, MX.Objects.Common.PayMethod.ChequeLabel,
                        MX.Objects.Common.PayMethod.TransferLabel, MX.Objects.Common.PayMethod.CreditCardLabel,
                        MX.Objects.Common.PayMethod.WalletLabel, MX.Objects.Common.PayMethod.ElectronicLabel,
                        MX.Objects.Common.PayMethod.CouponsLabel, MX.Objects.Common.PayMethod.DebitCardLabel,
                        MX.Objects.Common.PayMethod.ServiceCardLabel, MX.Objects.Common.PayMethod.OtherLabel,
                        MX.Objects.Common.PayMethod.NAFELabel, MX.Objects.Common.PayMethod.NACELabel,
            }, MultiSelect = false)]
        [PXUIField(DisplayName = Messages.PaymentMethod, Enabled = true)]
        public virtual string SatPaymentMethod { get; set; }

        #endregion SatPaymentMethod
    }
}