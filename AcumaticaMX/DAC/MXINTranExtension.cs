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

        [PXDBString(21, IsUnicode = true, IsFixed = true ,InputMask = "00  00  0000  0000000")]
        [PXUIField(DisplayName = Messages.RequestNumber, Enabled = true)]
        [RequestNumber("Es necesario asignar el numero de pedimento", typeof(requestNbr))]
        public virtual string RequestNbr { get; set; }

        #endregion RequestNbr
    }
}
