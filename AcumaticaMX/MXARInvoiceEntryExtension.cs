using PX.Data;
using PX.Objects;
using PX.Objects.AR;
using System;

namespace AcumaticaMX
{
    public class MXARInvoiceEntryExtension : PXGraphExtension<ARInvoiceEntry>
    {
        #region Event Handlers

        protected bool _UpdatingAddress = false;

        protected void ARInvoice_CustomerID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = this.Base.Billing_Address.Current ?? this.Base.Billing_Address.Select();
            CheckExtendedFields(sender, address);
        }

        protected void ARAddress_OverrideAddress_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as ARAddress;
            CheckExtendedFields(sender, address);
        }

        protected void CheckExtendedFields(PXCache sender, ARAddress address)
        {
            if (_UpdatingAddress) return;
            _UpdatingAddress = true;

            try
            {
                // Si el id de dirección es default, parece que no se copian bien los campos extendidos.
                // así que lo hacemos manualmente
                //if (this.Base.customer.Current.DefAddressID == this.Base.customer.Current.DefBillAddressID)
                if (address == null || address?.CustomerAddressID == null) return;

                var addressExtension = address.GetExtension<MXARAddressExtension>();
                if (addressExtension == null || (
                    addressExtension?.Street == null &&
                    addressExtension?.ExtNumber == null &&
                    addressExtension?.IntNumber == null &&
                    addressExtension?.Neighborhood == null &&
                    addressExtension?.Municipality == null &&
                    addressExtension?.Reference == null
                    )) MXAddressExtension.CopyExtendedFields(sender, address, address.CustomerAddressID);
            }
            catch (PXFieldValueProcessingException ex)
            {
                ex.ErrorValue = address?.CustomerAddressID;
                throw;
            }
            finally
            {
                _UpdatingAddress = false;
            }
        }

        protected void ARInvoice_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);

            var document = e.Row as ARInvoice;
            var documentExt = document.GetExtension<MXARRegisterExtension>();

            PXUIFieldAttribute.SetEnabled<MXARRegisterExtension.stampStatus>(sender, document, false);

            this.Base.Billing_Address.Cache.AllowUpdate = !(document.Printed == true || document.Emailed == true || documentExt.StampStatus != CfdiStatus.Clean);
        }

        #endregion Event Handlers
    }
}