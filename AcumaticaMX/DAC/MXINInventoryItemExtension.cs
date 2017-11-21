using System;
using PX.Data;
using PX.Objects.IN;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(InventoryItem.inventoryID), IsOptional = true)]
    public class MXINInventoryItemExtension : PXCacheExtension<InventoryItem>
    {
        public abstract class productServiceCD : IBqlField
        {
        }
        [PXDBString]
        [PXSelector(
            typeof(Search<MXFESatProductServiceList.productServiceCD>),
            typeof(MXFESatProductServiceList.description),
            DescriptionField = typeof(MXFESatProductServiceList.description))]
        [PXDefault]
        [PXUIField(DisplayName = Messages.ProductService)]
        public virtual string ProductServiceCD { get; set; }
    }
}
