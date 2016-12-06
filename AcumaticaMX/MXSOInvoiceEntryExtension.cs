using PX.Data;
using PX.Objects;
using PX.Objects.AR;
using PX.Objects.CM;
using PX.Objects.CS;
using PX.Objects.SO;
using PX.SM;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AcumaticaMX
{
    public class MXSOInvoiceEntryExtension : PXGraphExtension<SOInvoiceEntry>
    {
        #region Method Overrides

        protected void SOInvoice_BillAddressID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            //InvokeBaseHandler?.Invoke(sender, e);

            //var invoice = e.Row as SOInvoice;

            //var address = new ARAddress();
            //address.AddressID = invoice?.BillAddressID;
            //address = this.Base.Billing_Address.Locate(address);

            //if (address != null && address?.IsDefaultBillAddress == true)
            //{
            //    MXAddressExtensionTools.CopyExtendedFields<ARAddress, SOBillingAddress, SOBillingAddress.addressID, MXARAddressExtension, MXSOAddressExtension>(this.Base.Billing_Address.Cache, address, this.Base.SODocument.Current.BillAddressID);
            //}
        }

        //protected void ARAddress_RowInserted(PXCache sender, PXRowInsertedEventArgs e, PXRowInserted InvokeBaseHandler)
        //{
        //    InvokeBaseHandler?.Invoke(sender, e);

        //    var address = e.Row as ARAddress;

        //    if (address?.IsDefaultBillAddress == true)
        //    {
        //        MXAddressExtensionTools.CopyExtendedFields<ARAddress, PX.Objects.CR.Address, PX.Objects.CR.Address.addressID, MXARAddressExtension, MXAddressExtension>(sender, address, address.CustomerAddressID);
        //    }
        //    else
        //    {
        //        MXAddressExtensionTools.CopyExtendedFields<ARAddress, SOBillingAddress, SOBillingAddress.addressID, MXARAddressExtension, MXSOAddressExtension>(this.Base.Billing_Address.Cache, address, this.Base.SODocument.Current.BillAddressID);
        //    }
        //}

        #endregion Method Overrides
    }
}