using System;
using PX.Data;

namespace AcumaticaMX
{
    public class MXFESatStatesList : IBqlTable
    {
        public abstract class currencyCD : IBqlField
        {
        }
        [PXDBString(3, IsKey = true, IsUnicode = true, InputMask = ">CCC")]
        [PXUIField(DisplayName = Messages.CurrencyCD)]
        public virtual string CurrencyCD { get; set; }

        public abstract class description : IBqlField
        {
        }
        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = Messages.DescriptionLabel)]
        public virtual string Description { get; set; }

        public abstract class precision : IBqlField
        {
        }
        [PXDBInt]
        [PXUIField(DisplayName = Messages.Precision)]
        public virtual int? Precision { get; set; }

        public abstract class variation : IBqlField
        {
        }
        [PXDBString]
        [PXUIField(DisplayName = Messages.Variation)]
        public virtual string Variation { get; set; }
    }
}
