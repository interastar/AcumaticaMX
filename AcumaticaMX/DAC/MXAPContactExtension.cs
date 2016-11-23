using PX.Data;
using PX.Objects.AP;

namespace AcumaticaMX
{
    [PXTable(typeof(APContact.contactID), IsOptional = true)]
    public class MXAPContactExtension : PXCacheExtension<PX.Objects.AP.APContact>
    {
        #region SecondLastName

        public abstract class secondLastName : IBqlField
        {
        }

        [PXDBString(100, IsUnicode = true)]
        [PXUIField(DisplayName = "Apellido Materno", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string SecondLastName { get; set; }

        #endregion SecondLastName

        #region PersonalID

        public abstract class personalID : IBqlField
        {
        }

        [PXDBString(100, IsUnicode = true)]
        [PXUIField(DisplayName = "CURP", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string PersonalID { get; set; }

        #endregion PersonalID
    }
}