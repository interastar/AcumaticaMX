using PX.Data;
using PX.Objects.CR;

namespace MX.Objects
{
    [PXTable(typeof(BAccount.bAccountID), IsOptional = true)]
    public class SYFEBAccountExt : PXCacheExtension<PX.Objects.CR.BAccount>
    {
        #region RFC

        [PXMergeAttributes(Method = MergeMethod.Merge)]
        [PXUIField(DisplayName = "RFC", Required = true)]
        public string TaxRegistrationID { get; set; }

        #endregion RFC

        #region Regimen

        public abstract class regimen : IBqlField
        {
        }

        [PXDBString(100, IsFixed = false, IsUnicode = true)]
        [PXDefault(MX.Objects.Common.RegimenTypes.JuridicalGeneralLabel, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXStringList(
            new string[]
            {
                MX.Objects.Common.RegimenTypes.NaturalSalaried, MX.Objects.Common.RegimenTypes.NaturalFee,
                MX.Objects.Common.RegimenTypes.NaturalLessor, MX.Objects.Common.RegimenTypes.NaturalBusinessActivity,
                MX.Objects.Common.RegimenTypes.NaturalTaxIncorporated, MX.Objects.Common.RegimenTypes.JuridicalGeneral,
                MX.Objects.Common.RegimenTypes.JuridicalNonProfit
            },
            new string[]
            {
                MX.Objects.Common.RegimenTypes.NaturalSalariedLabel, MX.Objects.Common.RegimenTypes.NaturalFeeLabel,
                MX.Objects.Common.RegimenTypes.NaturalLessorLabel, MX.Objects.Common.RegimenTypes.NaturalBusinessActivityLabel,
                MX.Objects.Common.RegimenTypes.NaturalTaxIncorporatedLabel, MX.Objects.Common.RegimenTypes.JuridicalGeneralLabel,
                MX.Objects.Common.RegimenTypes.JuridicalNonProfitLabel
            })]
        [PXUIField(DisplayName = "Regimen fiscal")]
        public virtual string Regimen { get; set; }

        #endregion Regimen

        #region IsNaturalPerson

        public abstract class isNaturalPerson : IBqlField
        {
        }

        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Persona Física")]
        public virtual bool? IsNaturalPerson { get; set; }

        #endregion IsNaturalPerson

        #region DefaultOriginAccount

        public abstract class defaultOriginAccount : IBqlField
        {
        }

        [PXDBString(30, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cuenta de origen default")]
        public virtual string DefaultOriginAccount { get; set; }

        #endregion DefaultOriginAccount

        #region DefaultPaymentMethod

        public abstract class defaultPaymentMethod : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXDefault(MX.Objects.Common.PayMethod.Transfer, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXStringList(
            new string[]
            {
                MX.Objects.Common.PayMethod.Cash, MX.Objects.Common.PayMethod.Cheque,
                MX.Objects.Common.PayMethod.Transfer, MX.Objects.Common.PayMethod.CreditCard,
                MX.Objects.Common.PayMethod.Wallet, MX.Objects.Common.PayMethod.Electronic,
                MX.Objects.Common.PayMethod.Coupons, MX.Objects.Common.PayMethod.DebitCard,
                MX.Objects.Common.PayMethod.ServiceCard, MX.Objects.Common.PayMethod.Other,
            },
            new string[]
            {
                MX.Objects.Common.PayMethod.CashLabel, MX.Objects.Common.PayMethod.ChequeLabel,
                MX.Objects.Common.PayMethod.TransferLabel, MX.Objects.Common.PayMethod.CreditCardLabel,
                MX.Objects.Common.PayMethod.WalletLabel, MX.Objects.Common.PayMethod.ElectronicLabel,
                MX.Objects.Common.PayMethod.CouponsLabel, MX.Objects.Common.PayMethod.DebitCardLabel,
                MX.Objects.Common.PayMethod.ServiceCardLabel, MX.Objects.Common.PayMethod.OtherLabel,
            }, MultiSelect = true)]
        [PXUIField(DisplayName = "Metodo de Pago Preferido")]
        public virtual string DefaultPaymentMethod { get; set; }

        #endregion DefaultPaymentMethod
    }
}