using PX.Data;
using PX.Objects.CA;
using System;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(PaymentMethod.paymentMethodID), IsOptional = true)]
    public class MXPaymentMethodExtension : PXCacheExtension<PaymentMethod>
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
        [PXDefault(AcumaticaMX.Common.PayMethod.Cash)]
        [PXStringList(
            new string[]
            {
                        AcumaticaMX.Common.PayMethod.Cash, AcumaticaMX.Common.PayMethod.Cheque,
                        AcumaticaMX.Common.PayMethod.Transfer, AcumaticaMX.Common.PayMethod.CreditCard,
                        AcumaticaMX.Common.PayMethod.Wallet, AcumaticaMX.Common.PayMethod.Electronic,
                        AcumaticaMX.Common.PayMethod.Coupons, AcumaticaMX.Common.PayMethod.DebitCard,
                        AcumaticaMX.Common.PayMethod.ServiceCard, AcumaticaMX.Common.PayMethod.Other,
                        AcumaticaMX.Common.PayMethod.NAFE, AcumaticaMX.Common.PayMethod.NACE,
            },
            new string[]
            {
                        AcumaticaMX.Common.PayMethod.CashLabel, AcumaticaMX.Common.PayMethod.ChequeLabel,
                        AcumaticaMX.Common.PayMethod.TransferLabel, AcumaticaMX.Common.PayMethod.CreditCardLabel,
                        AcumaticaMX.Common.PayMethod.WalletLabel, AcumaticaMX.Common.PayMethod.ElectronicLabel,
                        AcumaticaMX.Common.PayMethod.CouponsLabel, AcumaticaMX.Common.PayMethod.DebitCardLabel,
                        AcumaticaMX.Common.PayMethod.ServiceCardLabel, AcumaticaMX.Common.PayMethod.OtherLabel,
                        AcumaticaMX.Common.PayMethod.NAFELabel,AcumaticaMX.Common.PayMethod.NACELabel,
            }, MultiSelect = false)]
        [PXUIField(DisplayName = Messages.PaymentMethod, Enabled = true)]
        public virtual string SatPaymentMethod { get; set; }

        #endregion SatPaymentMethod
    }
}