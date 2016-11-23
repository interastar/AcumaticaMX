using PX.Data;
using PX.Objects.CR;

namespace AcumaticaMX
{
    [PXTable(typeof(Address.addressID), IsOptional = true)]
    public class MXAddressExtension : PXCacheExtension<PX.Objects.CR.Address>
    {
        public static object CopyExtendedFields(PXCache sender, object address, int? baseAddressID)
        {
            var addressCache = sender.Graph.Caches[address.GetType()];

            if (baseAddressID == null) return address;

            Address defaultAddress = PXSelect<Address,
                Where<Address.addressID, Equal<Required<Address.addressID>>>>.Select(sender.Graph, baseAddressID);

            if (defaultAddress == null) return address;
            var defaultAddressExt = defaultAddress.GetExtension<MXAddressExtension>();
            if (defaultAddressExt == null) return address;

            var updated = false;

            if (!string.IsNullOrEmpty(defaultAddressExt.Street))
            {
                addressCache.SetValueExt(address, "Street", defaultAddressExt.Street);
                updated = true;
            }

            if (!string.IsNullOrEmpty(defaultAddressExt.ExtNumber))
            {
                addressCache.SetValueExt(address, "ExtNumber", defaultAddressExt.ExtNumber);
                updated = true;
            }

            if (!string.IsNullOrEmpty(defaultAddressExt.IntNumber))
            {
                addressCache.SetValueExt(address, "IntNumber", defaultAddressExt.IntNumber);
                updated = true;
            }

            if (!string.IsNullOrEmpty(defaultAddressExt.Municipality))
            {
                addressCache.SetValueExt(address, "Municipality", defaultAddressExt.Municipality);
                updated = true;
            }

            if (!string.IsNullOrEmpty(defaultAddressExt.Neighborhood))
            {
                addressCache.SetValueExt(address, "Neighborhood", defaultAddressExt.Neighborhood);
                updated = true;
            }

            if (!string.IsNullOrEmpty(defaultAddressExt.Reference))
            {
                addressCache.SetValueExt(address, "Reference", defaultAddressExt.Reference);
                updated = true;
            }

            if (updated)
            {
                addressCache.Update(address);
                addressCache.SetStatus(address, PXEntryStatus.Updated);
                addressCache.IsDirty = true;
            }

            return address;
        }

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