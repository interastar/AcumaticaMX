using System;
using PX.Data;
using PX.Objects.AR;
namespace AcumaticaMX
{
    [PXTable(typeof(ARTran.tranType), typeof(ARTran.lineNbr), typeof(ARTran.refNbr), IsOptional = true)]
    public class MXARTranExtension : PXCacheExtension<ARTran>
    {
        #region CustomsInformation

        public abstract class customsInformation : IBqlField
        {

        }
        [PXDBString]
        public virtual string CustomsInformation{ get;set; }

        #endregion CustomsInformation
    }
}
