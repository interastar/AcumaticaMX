using System;
using PX.Data;
using PX.Objects.CS;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(State.countryID), typeof(State.stateID), IsOptional = true)]
    public class MXCSStateExtension : PXCacheExtension<State>
    {
        #region State

        public abstract class stateCD : IBqlField
        {
        }
        [PXDBString(3, IsUnicode = true)]
        [PXSelector(
            typeof(Search<MXFESatStateList.stateCD,
                Where<MXFESatStateList.countryCD,
                    Equal<Current<MXCSCountryExtension.countryCD>>>>),
            typeof(MXFESatStateList.countryCD),
            typeof(MXFESatStateList.name))]
        [PXUIField(DisplayName = Messages.State)]
        public virtual string StateCD { get; set; }

        #endregion State
    }
}
