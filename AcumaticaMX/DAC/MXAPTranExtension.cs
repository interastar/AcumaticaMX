using System;
using PX.Data;
using PX.Objects.AP;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(APTran.tranType), typeof(APTran.refNbr), typeof(APTran.lineNbr), IsOptional = true)]
    public class MXAPTranExtension : PXCacheExtension<APTran>
    {
        #region OperationType
        public abstract class operationType : IBqlField { }
        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXStringList(
            new string[]
            {
                Common.VendorOperationType.Empty,
                Common.VendorOperationType.Services,
                Common.VendorOperationType.LeasingEstate,
                Common.VendorOperationType.Others,
            },
            new string[]
            {
                Common.VendorOperationType.EmptyLabel,
                Common.VendorOperationType.ServicesLabel,
                Common.VendorOperationType.LeasingEstateLabel,
                Common.VendorOperationType.OthersLabel,
            }
            )]
        [PXUIField(DisplayName = "Tipo de operación")]
        public virtual string OperationType { get; set; }

        #endregion OperationType
    }
}
