using PX.Data;
using PX.Objects;
using System;

namespace AcumaticaMX
{
    using PX.Objects.CR;
    using PX.Objects.CS;

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

        #endregion Event Handlers
    }
}