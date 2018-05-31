using PX.Data;
using PX.Objects.AP;
using System;

namespace AcumaticaMX
{
    [Serializable]
    public class MXAPPaymentExtension : PXCacheExtension<APRegister>
    {
        [ToWordsES(typeof(Current<APRegister.curyOrigDocAmt>), typeof(Current<APRegister.curyID>))]
        public virtual string AmountToWords { get; set; }
    }
}
