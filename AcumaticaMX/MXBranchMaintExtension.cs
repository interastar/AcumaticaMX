using System;
using PX.Data;
using PX.Objects;

namespace AcumaticaMX
{
    using PX.Objects.CS;
    using PX.Objects.CR;

    public class MXBranchMaintExtension : PXGraphExtension<BranchMaint>
    {
        #region Event Handlers
        protected virtual void LocationExtAddress_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            LocationExtAddress address = e.Row as LocationExtAddress;

            if (address == null) return;

            if (address.IsAddressSameAsMain != null)
            {
                bool enabled = !(address.IsAddressSameAsMain ?? false);

                PXUIFieldAttribute.SetEnabled<MXAddressExtension.street>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<MXAddressExtension.extNumber>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<MXAddressExtension.intNumber>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<MXAddressExtension.neighborhood>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<MXAddressExtension.municipality>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<MXAddressExtension.reference>(sender, address, enabled);
            }
        }

        protected virtual void Address_Street_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Address address = e.Row as Address;

            if (address == null) return;

            MXAddressExtension addressExt = address.GetExtension<MXAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<Address.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void Address_ExtNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Address address = e.Row as Address;

            if (address == null) return;

            MXAddressExtension addressExt = address.GetExtension<MXAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<Address.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void Address_IntNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Address address = e.Row as Address;

            if (address == null) return;

            MXAddressExtension addressExt = address.GetExtension<MXAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<Address.addressLine2>(address, addressExt.IntNumber);
        }
        #endregion
    }
}
