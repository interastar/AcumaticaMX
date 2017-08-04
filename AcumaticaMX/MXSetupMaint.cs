using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;


namespace MX.Objects
{
    public class MXSetupMaint : PXGraph<MXSetupMaint>
    {
        public PXSelect<SYMXSetup> Setup;
        public PXSave<SYMXSetup> Save;
        public PXCancel<SYMXSetup> Cancel;
    }
}