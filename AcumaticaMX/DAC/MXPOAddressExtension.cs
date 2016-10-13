using PX.Data;
using PX.Objects.PO;

namespace AcumaticaMX
{
    [PXTable(typeof(POAddress.addressID), IsOptional = true)]
    public class MXPOAddressExtension : PXCacheExtension<PX.Objects.PO.POAddress>
    {
        #region Street

        public abstract class street : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "Calle", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Street { get; set; }

        #endregion Street

        #region ExtNumber

        public abstract class extNumber : IBqlField
        {
        }

        [PXDBString(10, IsUnicode = true)]
        [PXUIField(DisplayName = "Número Exterior", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string ExtNumber { get; set; }

        #endregion ExtNumber

        #region IntNumber

        public abstract class intNumber : IBqlField
        {
        }

        [PXDBString(10, IsUnicode = true)]
        [PXUIField(DisplayName = "Número Interior", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string IntNumber { get; set; }

        #endregion IntNumber

        #region Neighborhood

        public abstract class neighborhood : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "Colonia", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Neighborhood { get; set; }

        #endregion Neighborhood

        #region Municipality

        public abstract class municipality : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "Municipio/Delegación", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Municipality { get; set; }

        #endregion Municipality

        #region Reference

        public abstract class reference : IBqlField
        {
        }

        [PXDBString(100, IsUnicode = true)]
        [PXUIField(DisplayName = "Referencia", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Reference { get; set; }

        #endregion Reference
    }
}