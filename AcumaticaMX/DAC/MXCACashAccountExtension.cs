using PX.Data;
using PX.Objects.CA;
using System;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(CashAccount.cashAccountID), IsOptional = true)]
    public class MXCACashAccountExtension : PXCacheExtension<CashAccount>
    {
        #region Bank

        public abstract class bankCD : IBqlField
        {
        }

        [PXDBString(3, IsUnicode = true)]
        [PXSelector(
            typeof(Search<MXFESatBankList.bankCD>),
            DescriptionField = typeof(MXFESatBankList.bankName))]
        [PXUIField(DisplayName = "Banco")]
        public virtual string BankCD { get; set; }

        #endregion Bank

        #region Bank Account

        public abstract class bankAccount : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "Numero de cuenta bancario")]
        public virtual string BankAccount { get; set; }

        #endregion Bank Account
    }
}
