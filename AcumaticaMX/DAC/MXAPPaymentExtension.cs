using PX.Data;
using PX.Objects.AP;
using System;

namespace AcumaticaMX
{
    [Serializable]
    public class MXAPPaymentExtension : PXCacheExtension<APRegister>
    {
        [ToWordsES]
        public virtual string AmountToWords { get; set; }
    }
}
