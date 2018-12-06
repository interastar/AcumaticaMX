using System;
using PX.Data;
using PX.Objects.SO;
namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(SOShipment.shipmentNbr), IsOptional = true)]
    public class MXSOShipmentADExtension : PXCacheExtension<SOShipment>
    {

        #region EarlyInvoice

        [PXDBBool]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Factura anticipada", IsReadOnly = true)]
        public bool? EarlyInvoice { get; set; }

        public class earlyInvoice : IBqlField { }

        #endregion EarlyInvoice
    }
}
