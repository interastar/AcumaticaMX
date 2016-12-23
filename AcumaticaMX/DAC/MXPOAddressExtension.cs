using PX.Data;
using PX.Objects.PO;

namespace AcumaticaMX
{
    public class MXPOAddressExtension : PXCacheExtension<PX.Objects.PO.POAddress>, IMXAddressExtension
    {
        #region Street

        public abstract class street : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(POAddress.addressLine1), 1, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Calle", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Street { get; set; }

        #endregion Street

        #region ExtNumber

        public abstract class extNumber : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(POAddress.addressLine1), 2, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Número Exterior", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string ExtNumber { get; set; }

        #endregion ExtNumber

        #region IntNumber

        public abstract class intNumber : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(POAddress.addressLine1), 3, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Número Interior", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string IntNumber { get; set; }

        #endregion IntNumber

        #region Neighborhood

        public abstract class neighborhood : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(POAddress.addressLine2), 1, typeof(neighborhood), typeof(municipality), Separator = ",")]
        [PXUIField(DisplayName = "Colonia", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Neighborhood { get; set; }

        #endregion Neighborhood

        #region Municipality

        public abstract class municipality : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(POAddress.addressLine2), 2, typeof(neighborhood), typeof(municipality), Separator = ",")]
        [PXUIField(DisplayName = "Municipio/Delegación", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Municipality { get; set; }

        #endregion Municipality

        #region Reference

        public abstract class reference : IBqlField
        {
        }

        [PXString(100, IsUnicode = true)]
        [MultipartField(typeof(POAddress.addressLine3), 1, typeof(reference))]
        [PXUIField(DisplayName = "Referencia", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Reference { get; set; }

        #endregion Reference
    }
}