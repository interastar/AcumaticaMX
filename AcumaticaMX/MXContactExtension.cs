using System;
using PX.Data;
using PX.Objects;
using PX.Objects.CR;

namespace AcumaticaMX
{
	[PXTable(typeof(Contact.contactID), IsOptional = true)]
	public class MXContactExtension : PXCacheExtension<PX.Objects.CR.Contact>
	{
		#region SecondLastName
		public abstract class secondLastName : IBqlField
		{
		}
		[PXDBString(100, IsUnicode = true)]
		[PXUIField(DisplayName = "Apellido Materno", Visibility = PXUIVisibility.SelectorVisible)]
		public virtual string SecondLastName { get; set; }
		#endregion

		#region PersonalID
		public abstract class personalID : IBqlField
		{
		}
		[PXDBString(100, IsUnicode = true)]
		[PXUIField(DisplayName = "CURP", Visibility = PXUIVisibility.SelectorVisible)]
		public virtual string PersonalID { get; set; }
		#endregion
	}
}
