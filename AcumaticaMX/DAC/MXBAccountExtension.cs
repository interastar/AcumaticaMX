using PX.Data;
using PX.Objects.CR;

namespace AcumaticaMX
{
    [PXTable(typeof(BAccount.bAccountID), IsOptional = true)]
    public class MXBAccountExtension : PXCacheExtension<BAccount>
    {
        #region RFC

        [PXMergeAttributes(Method = MergeMethod.Merge)]
        //[PXDBString(13, IsUnicode = true)]
        [PXUIField(DisplayName = "RFC", Required = true)]
        public string TaxRegistrationID { get; set; }

        #endregion RFC

        #region TaxRegimeID
        public abstract class taxRegimeID : PX.Data.IBqlField
        {
        }
        [PXDBInt]
        [PXSelector(
            typeof(Search<MXFESatTaxRegimeList.taxRegimeID>),
            typeof(MXFESatTaxRegimeList.description),
            typeof(MXFESatTaxRegimeList.applyMoralPerson),
            typeof(MXFESatTaxRegimeList.applyNaturalPerson),
            SubstituteKey = typeof(MXFESatTaxRegimeList.description))]
        [PXUIField(DisplayName = "Regimen fiscal")]
        public virtual int? TaxRegimeID { get; set; }

        #endregion TaxRegimeID

        #region Regimen
        public abstract class regimen : IBqlField
        {

        }
        [PXDBString(100, IsFixed = false, IsUnicode = true)]
        [PXDefault(AcumaticaMX.Common.RegimenTypes.JuridicalGeneralLabel, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXStringList(
            new string[]
            {
                AcumaticaMX.Common.RegimenTypes.NaturalSalaried, AcumaticaMX.Common.RegimenTypes.NaturalFee,
                AcumaticaMX.Common.RegimenTypes.NaturalLessor, AcumaticaMX.Common.RegimenTypes.NaturalBusinessActivity,
                AcumaticaMX.Common.RegimenTypes.NaturalTaxIncorporated,
                AcumaticaMX.Common.RegimenTypes.JuridicalGeneral, AcumaticaMX.Common.RegimenTypes.JuridicalNonProfit
            },
            new string[]
            {
                AcumaticaMX.Common.RegimenTypes.NaturalSalariedLabel, AcumaticaMX.Common.RegimenTypes.NaturalFeeLabel,
                AcumaticaMX.Common.RegimenTypes.NaturalLessorLabel, AcumaticaMX.Common.RegimenTypes.NaturalBusinessActivityLabel,
                AcumaticaMX.Common.RegimenTypes.NaturalTaxIncorporatedLabel,
                AcumaticaMX.Common.RegimenTypes.JuridicalGeneralLabel, AcumaticaMX.Common.RegimenTypes.JuridicalNonProfitLabel
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

        #region UseCFDI
        public abstract class useCfdiCD : PX.Data.IBqlField
        {
        }
        [PXDBString]
        [PXSelector(
            typeof(Search<MXFESatUseCFDIList.useCfdiCD,
                Where<MXFESatUseCFDIList.applyNaturalPerson,
                    Equal<Current<isNaturalPerson>>,
                    Or<MXFESatUseCFDIList.applyMoralPerson,
                        NotEqual<Current<isNaturalPerson>>>>>),
            typeof(MXFESatUseCFDIList.description),
            typeof(MXFESatUseCFDIList.applyMoralPerson),
            typeof(MXFESatUseCFDIList.applyNaturalPerson),
            DescriptionField = typeof(MXFESatUseCFDIList.description)
            )]
        [PXUIField(DisplayName = "Uso de Cfdi")]
        public virtual string UseCfdiCD { get; set; }
        #endregion UseCFDI

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
        [PXDefault(AcumaticaMX.Common.PayMethod.Transfer, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXStringList(
            new string[]
            {
                AcumaticaMX.Common.PayMethod.Cash, AcumaticaMX.Common.PayMethod.Cheque,
                AcumaticaMX.Common.PayMethod.Transfer, AcumaticaMX.Common.PayMethod.CreditCard,
                AcumaticaMX.Common.PayMethod.Wallet, AcumaticaMX.Common.PayMethod.Electronic,
                AcumaticaMX.Common.PayMethod.Coupons, AcumaticaMX.Common.PayMethod.DebitCard,
                AcumaticaMX.Common.PayMethod.ServiceCard, AcumaticaMX.Common.PayMethod.Other,
            },
            new string[]
            {
                AcumaticaMX.Common.PayMethod.CashLabel, AcumaticaMX.Common.PayMethod.ChequeLabel,
                AcumaticaMX.Common.PayMethod.TransferLabel, AcumaticaMX.Common.PayMethod.CreditCardLabel,
                AcumaticaMX.Common.PayMethod.WalletLabel, AcumaticaMX.Common.PayMethod.ElectronicLabel,
                AcumaticaMX.Common.PayMethod.CouponsLabel, AcumaticaMX.Common.PayMethod.DebitCardLabel,
                AcumaticaMX.Common.PayMethod.ServiceCardLabel, AcumaticaMX.Common.PayMethod.OtherLabel,
            }, MultiSelect = true)]
        [PXUIField(DisplayName = "Metodo de Pago Preferido")]
        public virtual string DefaultPaymentMethod { get; set; }

        #endregion DefaultPaymentMethod

        #region FormaDePago

        public abstract class paymentForm : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Metodo de Pago")]
        public virtual string PaymentForm { get; set; }

        #endregion FormaDePago
    }
}