using PX.Data;
using PX.Objects.CR;
using PX.Objects.CR.MassProcess;

namespace AcumaticaMX
{
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

        [PXString(50, IsUnicode = true)]
        [AddressPart(typeof(Address.addressLine1), 1, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Calle", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Street { get; set; }

        #endregion Street

        #region ExtNumber

        public abstract class extNumber : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [AddressPart(typeof(Address.addressLine1), 2, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Número Exterior", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string ExtNumber { get; set; }

        #endregion ExtNumber

        #region IntNumber

        public abstract class intNumber : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [AddressPart(typeof(Address.addressLine1), 3, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Número Interior", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string IntNumber { get; set; }

        #endregion IntNumber

        #region Neighborhood

        public abstract class neighborhood : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [AddressPart(typeof(Address.addressLine2), 1, typeof(neighborhood), typeof(municipality), Separator = ",")]
        [PXUIField(DisplayName = "Colonia", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Neighborhood { get; set; }

        #endregion Neighborhood

        #region Municipality

        public abstract class municipality : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [AddressPart(typeof(Address.addressLine2), 2, typeof(neighborhood), typeof(municipality), Separator = ",")]
        [PXUIField(DisplayName = "Municipio/Delegación", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Municipality { get; set; }

        #endregion Municipality

        #region Reference

        public abstract class reference : IBqlField
        {
        }

        [PXString(100, IsUnicode = true)]
        [AddressPart(typeof(Address.addressLine3), 1, typeof(reference))]
        [PXUIField(DisplayName = "Referencia", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Reference { get; set; }

        #endregion Reference
    }
}