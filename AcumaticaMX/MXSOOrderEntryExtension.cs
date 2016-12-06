using PX.Data;
using PX.Objects;
using PX.Objects.SO;
using System;

namespace AcumaticaMX
{
    public class MXSOOrderEntryExtension : PXGraphExtension<SOOrderEntry>
    {
        #region Event Handlers

        public virtual void SOOrder_CustomerID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            InvokeBaseHandler?.Invoke(sender, e);

            var address = this.Base.Billing_Address.Current ?? this.Base.Billing_Address.Select();

            MXAddressExtensionTools.CopyExtendedFields<SOBillingAddress, PX.Objects.CR.Address, PX.Objects.CR.Address.addressID, MXSOAddressExtension, MXAddressExtension>(sender, address, address.CustomerAddressID);
        }

        #endregion Event Handlers
    }
}