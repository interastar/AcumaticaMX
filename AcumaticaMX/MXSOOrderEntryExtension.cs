using PX.Data;
using PX.Objects;
using PX.Objects.SO;
using System;

namespace AcumaticaMX
{
    public class MXSOOrderEntryExtension : PXGraphExtension<SOOrderEntry>
    {
        protected bool _UpdatingAddress = false;

        #region Event Handlers

        protected virtual void SOOrder_CustomerID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);

            var address = this.Base.Billing_Address.Current ?? (SOBillingAddress)this.Base.Billing_Address.Select();
            CheckExtendedFields(sender, address);
        }

        protected void SOBillingAddress_OverrideAddress_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            var address = e.Row as SOBillingAddress;
            CheckExtendedFields(sender, address);
        }

        protected void CheckExtendedFields(PXCache sender, SOBillingAddress address)
        {
            if (_UpdatingAddress) return;
            _UpdatingAddress = true;

            try
            {
                // Si el id de dirección es default, parece que no se copian bien los campos extendidos.
                // así que lo hacemos manualmente
                //if (this.Base.customer.Current.DefAddressID == this.Base.customer.Current.DefBillAddressID)
                if (address == null || address?.CustomerAddressID == null) return;

                var addressExtension = ((SOAddress)address).GetExtension<MXSOAddressExtension>();
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

        #endregion Event Handlers
    }
}