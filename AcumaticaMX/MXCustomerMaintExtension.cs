using System;
using PX.Data;
using PX.Objects;

namespace AcumaticaMX
{

    using PX.Objects.CR;
    using PX.Objects.AR;

    public class MXCustomerMaintExtension : PXGraphExtension<CustomerMaint>
    {
        #region Event Handlers
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