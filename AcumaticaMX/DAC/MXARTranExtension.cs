using System;
using PX.Data;
using PX.Objects.AR;
namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(ARTran.tranType),typeof(ARTran.refNbr), typeof(ARTran.lineNbr),IsOptional = true)]
    public class MXARTranExtension : PXCacheExtension<ARTran>
    {
        #region ProductServiceCD
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
        #endregion ProductServiceCD

        #region MeasureCD
        public abstract class measureCD : IBqlField
        {
        }
        [PXDBString]
        public virtual string MeasureCD { get; set; }
        #endregion MeasureCD

        #region MeasureName
        public abstract class measureName : IBqlField
        {
        }
        [PXDBString]
        public virtual string MeasureName { get; set; }
        #endregion MeasureName

        #region DescriptionBackUp
        public abstract class descriptionBackUp : IBqlField
        {
        }
        [PXDBString(1000)]
        public virtual string DescriptionBackUp { get; set; }
        #endregion DescriptionBackUp

        //Esto guarda la referencia al tipo de documento a la que se le esta haciendo el cargo
        //por linea
        #region AppliedDocType
        public abstract class appliedDocType : IBqlField
        {
        }
        [PXDBString(3)]
        public virtual string AppliedDocType { get; set; }
        #endregion AppliedDocType

        //Esto guarda la referencia al documento a la que se le esta haciendo el cargo
        //por linea
        #region AppliedRefNbr
        public abstract class appliedRefNbr : IBqlField
        {
        }
        [PXDBString(15)]
        public virtual string AppliedRefNbr { get; set; }
        #endregion AppliedRefNbr
    }
}
