using System;
using PX.Data;
using PX.Objects.CS;
namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(ShipTerms.shipTermsID), IsOptional = true)]
    public class MXCSShipTermsExtension : PXCacheExtension<ShipTerms>
    {
        public abstract class incotermCD : IBqlField
        {
        }
        [PXSelector(typeof(Search<MXFESatIncotermList.incotermCD>),
            typeof(MXFESatIncotermList.description),
            DescriptionField = typeof(MXFESatIncotermList.description))]
        [PXDBString(3, IsUnicode = true, InputMask = ">CCC")]
        [PXUIField(DisplayName = Messages.IncotermCD, Required = true)]
        [PXDefault]
        public virtual string IncotermCD { get; set; }
    }
}
