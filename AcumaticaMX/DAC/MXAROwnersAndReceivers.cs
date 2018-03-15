using PX.Data;
using System;
using PX.Objects.AR;

namespace AcumaticaMX
{
    public class MXAROwnersAndReceivers : IBqlTable
    {
        #region DocType
        public abstract class docType : PX.Data.IBqlField
        {
        }

        [PXDBString(IsKey = true)]
        [PXDBDefault(typeof(ARRegister.docType))]
        [PXParent(typeof(Select<ARRegister,
            Where<ARRegister.docType,
                Equal<Current<docType>>>>))]
        public virtual string DocType { get; set; }

        #endregion DocType

        #region RefNbr

        public abstract class refNbr : PX.Data.IBqlField
        {
        }

        [PXDBString(IsKey = true)]
        [PXDBDefault(typeof(ARRegister.refNbr))]
        [PXParent(typeof(Select<ARRegister,
            Where<ARRegister.refNbr,
                Equal<Current<refNbr>>>>))]
        public virtual string RefNbr { get; set; }

        #endregion RefNbr

        #region BAccountID

        public abstract class bAccountID : PX.Data.IBqlField
        {
        }

        [PXDBInt(IsKey = true)]
        public virtual string BAccountID { get; set; }

        #endregion BAccountID

        #region BAccountType

        public abstract class bAccountType : PX.Data.IBqlField
        {
        }

        [PXDBString]
        [PXUIField(DisplayName = "Tipo de cuenta")]
        public virtual string BAccountType { get; set; }

        #endregion BAccountType

        #region ARAddressID

        public abstract class addressID : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        public virtual int? AddressID { get; set; }

        #endregion ARAddressID

        #region RevisionID

        public abstract class revisionID : PX.Data.IBqlField
        {
        }

        [PXDBInt]
        public virtual int? RevisionID { get; set; }

        #endregion RevisionID


    }
}
