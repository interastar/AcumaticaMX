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
        [PXUIField(DisplayName = Messages.Customs, Enabled = false)]
        public virtual string Customs { get; set; }

        #endregion Customs

        #region ImportDate

        public abstract class importDate : IBqlField
        {
        }

        [PXDBDate()]
        [PXUIField(DisplayName = Messages.ImportDate, Enabled = false)]
        public virtual DateTime? ImportDate { get; set; }

        #endregion ImportDate

        #region RequestNbr

        public abstract class requestNbr : IBqlField
        {
        }

        [PXDBString(40, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.RequestNumber, Enabled = false)]
        //[ValidateFields(Messages.ErrorCustoms, typeof(customs), typeof(importDate))]
        public virtual string RequestNbr { get; set; }

        #endregion RequestNbr

        #region CustomsRequestNbr

        public abstract class customsRequestNbr : IBqlField
        {
        }

        [PXSelector(
            typeof(Search2<MXFESatCustomsRequestNumberList.customsRequestNumberID,
                LeftJoin<MXFESatCustomsList,
                    On<MXFESatCustomsRequestNumberList.customsCD,
                        Equal<MXFESatCustomsList.customsCD>>>>),
            typeof(MXFESatCustomsList.description),
            typeof(MXFESatCustomsRequestNumberList.customsCD),
            typeof(MXFESatCustomsRequestNumberList.patent),
            typeof(MXFESatCustomsRequestNumberList.fiscalExcercise),
            typeof(MXFESatCustomsRequestNumberList.qty),
            DescriptionField = typeof(MXFESatCustomsRequestNumberList.customsCD))]
        [PXDBGuid]
        [PXDefault]
        [PXUIField(DisplayName = Messages.CustomsRequestNbr)]
        public virtual Guid? CustomsRequestNbr { get; set; }

        #endregion CustomsRequestNbr
    }
}
