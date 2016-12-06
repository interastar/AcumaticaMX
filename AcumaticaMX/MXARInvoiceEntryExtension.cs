using PX.Data;
using PX.Objects;
using PX.Objects.AR;
using PX.Objects.SO;
using System;

namespace AcumaticaMX
{
    public class MXARInvoiceEntryExtension : PXGraphExtension<ARInvoiceEntry>
    {
        #region Event Handlers

        protected void ARInvoice_CustomerID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);

            var invoice = e.Row as ARInvoice;

            //var address = new ARAddress();
            //address.AddressID = invoice?.BillAddressID;
            //address = this.Base.Billing_Address.Locate(address);

            var address = this.Base.Billing_Address.Current ?? this.Base.Billing_Address.Select();

            //PXTrace.WriteInformation("ARInvoice_CustomerID_FieldUpdated. address.CustomerAddressID:" + address?.CustomerAddressID + " address.IsDefaultBillAddress:" + address?.IsDefaultBillAddress + " address.IsDefaultAddress:" + address?.IsDefaultAddress);

            if (address != null)
            {
                MXAddressExtensionTools.CopyExtendedFields<ARAddress, PX.Objects.CR.Address, PX.Objects.CR.Address.addressID, MXARAddressExtension, MXAddressExtension>(sender, address, address.CustomerAddressID);
            }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(string message)
        {
            PXTrace.WriteInformation(message);
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