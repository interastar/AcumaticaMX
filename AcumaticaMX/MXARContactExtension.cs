using System;
using PX.Data;
using PX.Objects;
using PX.Objects.AR;

namespace AcumaticaMX
{
	[PXTable(typeof(ARContact.contactID), IsOptional = true)]
	public class MXARContactExtension : PXCacheExtension<PX.Objects.AR.ARContact>
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
