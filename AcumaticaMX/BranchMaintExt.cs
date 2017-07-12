using PX.Data;
using PX.Objects;
using System;

namespace MX.Objects
{
    using PX.Objects.CR;
    using PX.Objects.CS;

    public class BranchMaintExt : PXGraphExtension<BranchMaint>
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

                PXUIFieldAttribute.SetEnabled<SYFEAddressExt.street>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<SYFEAddressExt.extNumber>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<SYFEAddressExt.intNumber>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<SYFEAddressExt.neighborhood>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<SYFEAddressExt.municipality>(sender, address, enabled);
                PXUIFieldAttribute.SetEnabled<SYFEAddressExt.reference>(sender, address, enabled);
            }
        }

        #endregion Event Handlers
    }
}