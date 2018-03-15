using System;
using PX.Data;
using PX.Objects.CS;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(Country.countryID), IsOptional = true)]
    public class MXCSCountryExtension : PXCacheExtension<Country>
    {
        #region Country

        public abstract class countryCD : IBqlField
        {
        }
        [PXSelector(typeof(Search<MXFESatCountryList.countryCD>),
            DescriptionField = typeof(MXFESatCountryList.name))]
        [PXDBString(3, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.Country)]
        public virtual string CountryCD { get; set; }

        #endregion Country
    }
}
