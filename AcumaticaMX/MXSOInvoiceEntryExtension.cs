using PX.Data;
using PX.Objects;
using PX.Objects.AR;
using PX.Objects.CR;
using PX.Objects.SO;
using System;

namespace AcumaticaMX
{
    public class MXSOInvoiceEntryExtension : PXGraphExtension<SOInvoiceEntry>
    {
        #region Event Handlers

        protected void SOInvoice_CustomerID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);

            var document = e.Row as SOInvoice;

            //SOAddress_Update(this.Base.Billing_Address.Cache, document);
        }

        protected void SOInvoice_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);
            ARRegister invoice = (ARRegister)e.Row;
            var document = e.Row as SOInvoice;
            PXUIFieldAttribute.SetEnabled<MXARRegisterExtension.stampStatus>(sender, invoice, false);
            //SOAddress_Update(this.Base.Billing_Address.Cache, document);
        }

        protected virtual void SOAddress_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            SOAddress_Update(sender, (SOAddress)e.Row);
        }

        protected virtual void SOAddress_Update(PXCache sender, SOAddress address)
        {
            //SOAddress address = this.Base.Billing_Address.Select();

            if (address == null) return;
            var addressExt = address.GetExtension<MXSOAddressExtension>();

            // Si hay dirección pero los campos extendidos están en blanco
            if (!string.IsNullOrEmpty(address.AddressLine1) && string.IsNullOrEmpty(addressExt.Street))
            {
                //Address defaultAddress = PXSelectJoin<Address,
                //                    InnerJoin<Customer,
                //                        On<Address.addressID, Equal<Customer.defBillAddressID>,
                //                        And<Address.bAccountID, Equal<Customer.bAccountID>>>>,
                //                    Where<Customer.bAccountID, Equal<Required<Customer.bAccountID>>>>.Select(this.Base, document.CustomerID);

                Address defaultAddress = PXSelectJoin<Address,
                    InnerJoin<Customer,
                        On<Address.addressID, Equal<Customer.defBillAddressID>,
                        And<Address.bAccountID, Equal<Customer.bAccountID>>>>,
                    Where<Address.addressID, Equal<Required<SOAddress.customerAddressID>>>>.Select(this.Base, address.CustomerAddressID);

                if (defaultAddress == null) return;
                var defaultAddressExt = defaultAddress.GetExtension<MXAddressExtension>();

                sender.SetValueExt<MXSOAddressExtension.street>(address, defaultAddressExt.Street);
                sender.SetValueExt<MXSOAddressExtension.extNumber>(address, defaultAddressExt.ExtNumber);
                sender.SetValueExt<MXSOAddressExtension.intNumber>(address, defaultAddressExt.IntNumber);
                sender.SetValueExt<MXSOAddressExtension.municipality>(address, defaultAddressExt.Municipality);
                sender.SetValueExt<MXSOAddressExtension.neighborhood>(address, defaultAddressExt.Neighborhood);
                sender.SetValueExt<MXSOAddressExtension.reference>(address, defaultAddressExt.Reference);

                sender.Update(address);
            }
        }

        protected virtual void SOAddress_Street_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as SOAddress;

            if (address == null) return;

            var addressExt = address.GetExtension<MXSOAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<SOAddress.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void SOAddress_ExtNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as SOAddress;

            if (address == null) return;

            var addressExt = address.GetExtension<MXSOAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<SOAddress.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void SOAddress_IntNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as SOAddress;

            if (address == null) return;

            var addressExt = address.GetExtension<MXSOAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<SOAddress.addressLine2>(address, addressExt.IntNumber);
        }

        #endregion Event Handlers
    }
}