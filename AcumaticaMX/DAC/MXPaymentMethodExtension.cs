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
        [PXDefault]
        [PXSelector(
            typeof(Search<MXFESatPaymentMethodList.satPaymentMethod>),
            DescriptionField = typeof(MXFESatPaymentMethodList.description))]
        [PXUIField(DisplayName = Messages.PaymentMethod, Enabled = true)]
        public virtual string SatPaymentMethod { get; set; }

        #endregion SatPaymentMethod
    }
}