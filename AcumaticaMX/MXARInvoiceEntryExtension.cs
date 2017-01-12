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

            this.Base.Billing_Address.Cache.AllowUpdate = (documentExt.StampStatus == CfdiStatus.Clean);
        }

        #endregion Event Handlers
    }
}