using System;
using PX.Data;
using PX.Objects.IN;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(INTran.docType), typeof(INTran.refNbr), typeof(INTran.lineNbr), IsOptional = true)]
    public class MXINTranExtension: PXCacheExtension<INTran>
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
        [PXUIField(DisplayName = Messages.RequestNumber)]
        [ValidateFields(Messages.ErrorCustoms, typeof(customs), typeof(importDate))]
        public virtual string RequestNbr { get; set; }

        #endregion RequestNbr
    }
}
