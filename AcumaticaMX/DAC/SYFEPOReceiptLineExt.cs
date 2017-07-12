using System;
using PX.Data;
using PX.Objects;
using PX.Objects.PO;

namespace MX.Objects
{
    [PXTable(typeof(POReceiptLine.receiptNbr), typeof(POReceiptLine.lineNbr), IsOptional = true)]
    public class SYFEPOReceiptLineExt : PXCacheExtension<POReceiptLine>
    {
        #region Customs

        public abstract class customs : IBqlField
        {
        }

        [PXDBString(40, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.Customs)]
        public virtual string Customs { get; set; }

        #endregion Customs

        #region ImportDate

        public abstract class importDate : IBqlField
        {
        }

        [PXDBDate()]
        [PXUIField(DisplayName = Messages.ImportDate)]
        public virtual DateTime? ImportDate { get; set; }

        #endregion ImportDate

        #region RequestNbr

        public abstract class requestNbr : IBqlField
        {
        }

        [PXDBString(40, IsUnicode = true)]
        [ValidateFields(Messages.ErrorCustoms, typeof(customs), typeof(importDate))]
        [PXUIField(DisplayName = Messages.RequestNumber)]
        public virtual string RequestNbr { get; set; }

        #endregion RequestNbr

    }
}
