using PX.Data;
using PX.Objects.AP;
using System;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(APPayment.docType), typeof(APPayment.refNbr), IsOptional = true)]
    public class MXAPPaymentExtension : PXCacheExtension<APPayment>
    {
        [PXMergeAttributes(Method = MergeMethod.Replace)]

        public string AmountToWords {
            [PXDependsOnFields(typeof(APPayment.curyOrigDocAmt), typeof(APPayment.curyID))]
            get
            {
                return Convert.ToWords(this.Base.CuryOrigDocAmt, this.Base.CuryID);
            }
            set
            {
            }
        }
    }
}
