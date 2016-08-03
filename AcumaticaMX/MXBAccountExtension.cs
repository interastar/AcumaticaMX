using System;
using PX.Data;
using PX.Objects;

namespace AcumaticaMX
{
	using PX.Objects.CR;

    [PXTable(typeof(BAccount.bAccountID), IsOptional = true)]
	public class MXBAccountExtension : PXCacheExtension<PX.Objects.CR.BAccount>
	{
		#region Regimen
		public abstract class regimen : IBqlField
		{
		}
		[PXDBString(100, IsFixed = false, IsUnicode = true)]
		[PXDefault(AcumaticaMX.Common.RegimenTypes.JuridicalGeneralLabel)]
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
        #endregion

        #region IsNaturalPerson
        public abstract class isNaturalPerson : IBqlField
        {
        }
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Persona Física")]
        public virtual bool? IsNaturalPerson { get; set; }
        #endregion

        #region DefaultOriginAccount
        public abstract class defaultOriginAccount : IBqlField
		{
		}
		[PXDBString(30, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Cuenta de origen default")]
		public virtual string DefaultOriginAccount { get; set; }
        #endregion
    }
}
