using PX.Data;
using PX.Objects.AR;
using System;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(ARRegister.docType), typeof(ARRegister.refNbr), IsOptional = true)]
    public class MXARRegisterADExtension : PXCacheExtension<ARRegister>
    {
        #region SalesOrder

        [PXDBString(2, IsFixed = true, InputMask = ">aa")]
        [PXDefault(PX.Objects.SO.SOOrderTypeConstants.SalesOrder, typeof(PX.Objects.SO.SOSetup.defaultOrderType))]
        [PXUIField(DisplayName = "SO Order Type", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true)]
        public string OrderTypeSO { get; set; }

        public class orderTypeSO : IBqlField { }

        #endregion SalesOrder

        #region OrderNbrSO

        [PXDBString(15, IsUnicode = true, IsFixed = true, InputMask = ">CCCCCCCCCCCCCCC")]
        [PXUIField(DisplayName = "SO Order Nbr.", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true)]
        public string OrderNbrSO { get; set; }

        public class orderNbrSO : IBqlField { }

        #endregion OrderNbrSO

        #region CreditMemoCheck

        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Nota de Crédito Aplicada", IsReadOnly = true)]
        public bool? CreditMemoCheck { get; set; }

        public class creditMemoCheck : IBqlField { }

        #endregion CreditMemoCheck

        #region EarlyInvoice

        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Factura anticipada", IsReadOnly = true)]
        public bool? EarlyInvoice { get; set; }

        public class earlyInvoice : IBqlField { }

        #endregion EarlyInvoice
    }
}
