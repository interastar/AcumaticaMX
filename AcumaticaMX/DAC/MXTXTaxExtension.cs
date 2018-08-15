using System;
using PX.Data;
using PX.Objects.TX;
namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(Tax.taxID), IsOptional = true)]
    public class MXTXTaxExtension : PXCacheExtension<Tax>
    {
        #region Sat Tax

        public abstract class satTax : IBqlField
        {
        }

        [PXDBString(4, IsUnicode = true)]
        [PXStringList(
            new string[]
            {
                Common.Tax.ISR,
                Common.Tax.IVA,
                Common.Tax.IEPS,
            },
            new string[]
            {
                Common.Tax.ISRLabel,
                Common.Tax.IVALabel,
                Common.Tax.IEPSLabel,
            }
            )]
        [PXUIField(DisplayName = Messages.Tax, Enabled = true)]
        //[PXDefault(Common.Tax.IVA)]
        public virtual string SatTax { get; set; }

        #endregion

        #region Exempt

        public abstract class exempt : PX.Data.IBqlField
        {
        }

        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = Messages.Exempt)]
        public virtual bool? Exempt { get; set; }

        #endregion Exempt
    }
}
