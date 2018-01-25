using PX.Data;
using PX.Objects.CA;
using System;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(PaymentMethod.paymentMethodID), IsOptional = true)]
    public class MXPaymentMethodExtension : PXCacheExtension<PaymentMethod>
    {
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