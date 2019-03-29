using PX.Data;

namespace IS.Objects.DD
{
    public sealed class ARInvoiceISDDExt : PXCacheExtension<PX.Objects.AR.ARInvoice>
    {
        //UsrAddendumInclude
        #region UsrAddendumInclude
        public abstract class usrAddendumInclude : IBqlField { }
        [PXDBBool]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(Visible = true, DisplayName = "Incluye Addenda", IsReadOnly = true)]
        public bool? UsrAddendumInclude { get; set; }
        #endregion UsrAddendumInclude
    }
}
