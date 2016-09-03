using System;
using PX.Data;
using PX.Objects;

namespace AcumaticaMX
{

    using PX.Objects.CR;
    using PX.Objects.AR;

    public class MXARInvoiceEntryExtension : PXGraphExtension<ARInvoiceEntry>
    {
        #region Event Handlers

        protected void ARInvoice_CustomerID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);

            var document = e.Row as ARInvoice;

            ARAddress_Update(this.Base.Billing_Address.Cache, document);
        }

        protected void ARInvoice_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);
            ARRegister invoice =  (ARRegister) e.Row;
            var document = e.Row as ARInvoice;
            PXUIFieldAttribute.SetEnabled<MXARRegisterExtension.stampStatus>(sender,invoice, false);
            ARAddress_Update(this.Base.Billing_Address.Cache, document);
        }

        protected virtual void ARAddress_Update(PXCache addressCache, ARInvoice document)
        {
            ARAddress address = this.Base.Billing_Address.Select();

            if (address == null) return;
            var addressExt = address.GetExtension<MXARAddressExtension>();

            // Si hay dirección pero los campos extendidos están en blanco
            if (!string.IsNullOrEmpty(address.AddressLine1) && string.IsNullOrEmpty(addressExt.Street))
            {
                Address defaultAddress = PXSelectJoin<Address,
                                    InnerJoin<Customer,
                                        On<Address.addressID, Equal<Customer.defBillAddressID>,
                                        And<Address.bAccountID, Equal<Customer.bAccountID>>>>,
                                    Where<Customer.bAccountID, Equal<Required<Customer.bAccountID>>>>.Select(this.Base, document.CustomerID);

                if (defaultAddress == null) return;
                var defaultAddressExt = defaultAddress.GetExtension<MXAddressExtension>();

                addressCache.SetValueExt<MXARAddressExtension.street>(address, defaultAddressExt.Street);
                addressCache.SetValueExt<MXARAddressExtension.extNumber>(address, defaultAddressExt.ExtNumber);
                addressCache.SetValueExt<MXARAddressExtension.intNumber>(address, defaultAddressExt.IntNumber);
                addressCache.SetValueExt<MXARAddressExtension.municipality>(address, defaultAddressExt.Municipality);
                addressCache.SetValueExt<MXARAddressExtension.neighborhood>(address, defaultAddressExt.Neighborhood);
                addressCache.SetValueExt<MXARAddressExtension.reference>(address, defaultAddressExt.Reference);

                //bool? o = address.OverrideAddress;
                addressCache.Update(address);
                //address.OverrideAddress = o;
            }
        }

        protected virtual void ARAddress_Street_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as ARAddress;

            if (address == null) return;

            var addressExt = address.GetExtension<MXARAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<ARAddress.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void ARAddress_ExtNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as ARAddress;

            if (address == null) return;

            var addressExt = address.GetExtension<MXARAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<ARAddress.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void ARAddress_IntNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as ARAddress;

            if (address == null) return;

            var addressExt = address.GetExtension<MXARAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<ARAddress.addressLine2>(address, addressExt.IntNumber);
        }
        #endregion
    }
}