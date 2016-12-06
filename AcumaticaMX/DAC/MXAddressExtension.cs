using PX.Data;
using PX.Objects.CR;

namespace AcumaticaMX
{
    [PXTable(typeof(Address.addressID), IsOptional = true)]
    public class MXAddressExtension : PXCacheExtension<PX.Objects.CR.Address>, IMXAddressExtension
    {
        // Todo Cambiar campos por virtuales (calculados)
        // Extender tamaño de AddressLine
        // Crear atributo que expanda AddressLine1,2 y 3 en estos campos y que
        // los combine en ellos de nuevo:

        // AddressLine1 = Street + ExtNumber + IntNumber
        // AddressLine2 = Neighborhood + Municipality
        // AddressLine3 = Reference

        #region Street

        public abstract class street : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [CompositeField(typeof(Address.addressLine1), typeof(street), typeof(extNumber))]
        [PXUIField(DisplayName = "Calle", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Street { get; set; }

        #endregion Street

        #region ExtNumber

        public abstract class extNumber : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [CompositeField(typeof(Address.addressLine1), typeof(street), typeof(extNumber))]
        [PXUIField(DisplayName = "Número Exterior", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string ExtNumber { get; set; }

        #endregion ExtNumber

        #region IntNumber

        public abstract class intNumber : IBqlField
        {
        }

        [PXDBString(50, IsUnicode = true)]
        [CompositeField(typeof(Address.addressLine2), typeof(intNumber))]
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
        [CompositeField(typeof(Address.addressLine3), typeof(municipality))]
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