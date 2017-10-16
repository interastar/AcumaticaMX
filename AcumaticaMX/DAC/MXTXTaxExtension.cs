using System;
using PX.Data;
using PX.Objects.TX;
namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(Tax.taxID), IsOptional = true)]
    public class MXTXTaxExtension : PXCacheExtension<Tax>
    {
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
        [PXDefault(Common.Tax.IVA)]
        public virtual string SatTax { get; set; }

        public abstract class satTaxType : IBqlField
        {
        }

        [PXDBString(4, IsUnicode = true)]
        [PXStringList(
            new string[]
            {
                Common.TaxType.Holding,
                Common.TaxType.Transfer,
            },
            new string[]
            {
                Common.TaxType.HoldingLabel,
                Common.TaxType.TransferLabel,
            }
            )]
        [PXUIField(DisplayName = Messages.TaxType, Enabled = true)]
        [PXDefault(Common.TaxType.Holding)]
        public virtual string SatTaxType { get; set; }
    }
}
