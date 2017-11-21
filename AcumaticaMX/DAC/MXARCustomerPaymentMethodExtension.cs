using PX.Data;
using PX.Objects.AR;
using System;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(CustomerPaymentMethod.pMInstanceID), IsOptional = true)]
    public class MXARCustomerPaymentMethodExtension : PXCacheExtension<CustomerPaymentMethod>
    {
        #region Bank

        public abstract class bankCD : IBqlField
        {
        }

        [PXDBString(3, IsUnicode = true)]
        [PXSelector(
            typeof(Search<MXFESatBankList.bankCD>),
            typeof(MXFESatBankList.bankName),
            DescriptionField = typeof(MXFESatBankList.bankName),
            SelectorMode = PXSelectorMode.DisplayMode)]
        [PXUIField(DisplayName = "Banco")]
        public virtual string BankCD { get; set; }

        #endregion Bank

        #region BankName

        public abstract class bankName : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [PXFormula(typeof(Selector<bankCD, MXFESatBankList.bankName>))]
        [PXUIField(DisplayName = "Nombre del banco", Visible = false)] // Este atributo lo mantiene invisible
        public virtual string BankName { get; set; }

        #endregion BankName
    }
}
