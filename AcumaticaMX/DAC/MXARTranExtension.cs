using System;
using PX.Data;
using PX.Objects.AR;
namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(ARTran.tranType),typeof(ARTran.refNbr), typeof(ARTran.lineNbr),IsOptional = true)]
    public class MXARTranExtension : PXCacheExtension<ARTran>
    {
        public abstract class productServiceCD : IBqlField
        {
        }
        [PXDBString]
        [PXSelector(
            typeof(Search<MXFESatProductServiceList.productServiceCD>),
            typeof(MXFESatProductServiceList.description),
            DescriptionField = typeof(MXFESatProductServiceList.description))]
        [PXFormula(typeof(Selector<ARTran.inventoryID, MXINInventoryItemExtension.productServiceCD>))]
        [PXUIField(DisplayName = Messages.ProductService)]
        public virtual string ProductServiceCD { get; set; }

        public abstract class measureCD : IBqlField
        {
        }
        [PXDBString]
        public virtual string MeasureCD { get; set; }

        public abstract class measureName : IBqlField
        {
        }
        [PXDBString]
        //[PXFormula(typeof(Selector<measureCD, MXFESatMeasureList.name>))]
        public virtual string MeasureName { get; set; }
    }
}
