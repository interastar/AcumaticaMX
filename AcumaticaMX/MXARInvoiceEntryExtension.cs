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

        //protected void ARInvoice_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        //{
        //    InvokeBaseHandler?.Invoke(sender, e);

        //    var document = e.Row as ARInvoice;
        //    var documentExt = document?.GetExtension<MXARRegisterExtension>();

        //    if (documentExt == null) return;

        //    //PXUIFieldAttribute.SetEnabled<MXARRegisterExtension.stampStatus>(sender, document, false);

        //    if (documentExt.Uuid.HasValue && documentExt.Uuid != Guid.Empty)
        //    {
        //        PXUIFieldAttribute.SetEnabled<MXARRegisterExtension.notStampable>(sender, document, false);
        //    }
        //}

        #endregion Event Handlers
    }
}