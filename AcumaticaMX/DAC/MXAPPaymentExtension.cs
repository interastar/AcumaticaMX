using PX.Data;
using PX.Objects.AP;
using System;

namespace AcumaticaMX
{
    [Serializable]
    public class MXAPPaymentExtension : PXCacheExtension<APPayment>
    {
        [ToWordsES]
        public virtual string AmountToWords { get; set; }
    }
}
