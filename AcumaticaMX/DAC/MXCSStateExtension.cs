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
        [PXSelector(typeof(Search2<MXFESatStateList.stateCD,
            InnerJoin<Country,
                On<Country.countryID,
                    Equal<State.countryID>>>,
            Where<MXCSCountryExtension.countryCD,
                Equal<MXFESatStateList.countryCD>>>),
            DescriptionField = typeof(MXFESatStateList.name))]
        [PXDBString(3, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.State)]
        public virtual string StateCD { get; set; }

        #endregion State
    }
}
