using PX.Data;
using PX.Objects.CR;

namespace AcumaticaMX
{
    public class MXContactExtension : PXCacheExtension<PX.Objects.CR.Contact>
    {
        #region Lastname

        [PXMergeAttributes(Method = MergeMethod.Merge)]
        [PXDBString(200, IsUnicode = true)]
        public string LastName { get; set; }

        #endregion Lastname

        #region FirstLastName

        public abstract class firstLastName : IBqlField
        {
        }

        [PXString(100, IsUnicode = true)]
        [MultipartField(typeof(Contact.lastName), 1, typeof(firstLastName), typeof(secondLastName))]
        [PXUIField(DisplayName = "Apellido Paterno")]
        public virtual string FirstLastName { get; set; }

        #endregion FirstLastName

        #region SecondLastName

        public abstract class secondLastName : IBqlField
        {
        }

        [PXString(100, IsUnicode = true)]
        [MultipartField(typeof(Contact.lastName), 2, typeof(firstLastName), typeof(secondLastName))]
        [PXUIField(DisplayName = "Apellido Materno")]
        public virtual string SecondLastName { get; set; }

        #endregion SecondLastName

        #region PersonalID

        public abstract class personalID : IBqlField
        {
        }

        [PXString(18, IsUnicode = true)]
        [MultipartField(typeof(Contact.extRefNbr), 1, typeof(personalID))]
        [PXUIField(DisplayName = "CURP", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string PersonalID { get; set; }

        #endregion PersonalID
    }
}