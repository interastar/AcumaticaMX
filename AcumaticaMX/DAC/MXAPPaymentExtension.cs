using PX.Data;
using PX.Objects.AP;
using System;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(APPayment.docType), typeof(APPayment.refNbr), IsOptional = true)]
    public class MXAPPaymentExtension : PXCacheExtension<APPayment>
    {
        //[PXMergeAttributes(Method = MergeMethod.Replace)]
        [ToWordsES(typeof(APPayment.curyOrigDocAmt))]
        public virtual string AmountToWords { get; set; }
    }
}
