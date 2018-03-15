using System;
using PX.Data;
using PX.Objects;
using PX.Objects.IN;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(INUnit.recordID), IsOptional = true)]
    public class MXINUnitExtension: PXCacheExtension<INUnit>
    {
        #region SatUnits

        public abstract class satUnits : IBqlField
        {
        }

        [PXDBString(2, IsUnicode = true)]
        [PXStringList(
            new string[]
            {
                        AcumaticaMX.Common.SatUnits.Kilo, AcumaticaMX.Common.SatUnits.Gram,
                        AcumaticaMX.Common.SatUnits.LinealMeter, AcumaticaMX.Common.SatUnits.SquareMeter,
                        AcumaticaMX.Common.SatUnits.CubicMeter, AcumaticaMX.Common.SatUnits.Piece,
                        AcumaticaMX.Common.SatUnits.Head, AcumaticaMX.Common.SatUnits.Liter,
                        AcumaticaMX.Common.SatUnits.Pair, AcumaticaMX.Common.SatUnits.KiloWatt,
                        AcumaticaMX.Common.SatUnits.Thousand,AcumaticaMX.Common.SatUnits.Set,
                        AcumaticaMX.Common.SatUnits.KiloWatt_Hour, AcumaticaMX.Common.SatUnits.Ton,
                        AcumaticaMX.Common.SatUnits.Berrel, AcumaticaMX.Common.SatUnits.GramNet,
                        AcumaticaMX.Common.SatUnits.Ten, AcumaticaMX.Common.SatUnits.Hundred,
                        AcumaticaMX.Common.SatUnits.Dozen, AcumaticaMX.Common.SatUnits.Box,
                        AcumaticaMX.Common.SatUnits.Bottle, AcumaticaMX.Common.SatUnits.Service,
            },
            new string[]
            {
                        AcumaticaMX.Common.SatUnits.KiloLabel, AcumaticaMX.Common.SatUnits.GramLabel,
                        AcumaticaMX.Common.SatUnits.LinealMeterLabel, AcumaticaMX.Common.SatUnits.SquareMeterLabel,
                        AcumaticaMX.Common.SatUnits.CubicMeterLabel, AcumaticaMX.Common.SatUnits.PieceLabel,
                        AcumaticaMX.Common.SatUnits.HeadLabel, AcumaticaMX.Common.SatUnits.LiterLabel,
                        AcumaticaMX.Common.SatUnits.PairLabel, AcumaticaMX.Common.SatUnits.KiloWattLabel,
                        AcumaticaMX.Common.SatUnits.ThousandLabel,AcumaticaMX.Common.SatUnits.SetLabel,
                        AcumaticaMX.Common.SatUnits.KiloWatt_HourLabel, AcumaticaMX.Common.SatUnits.TonLabel,
                        AcumaticaMX.Common.SatUnits.BerrelLabel, AcumaticaMX.Common.SatUnits.GramNetLabel,
                        AcumaticaMX.Common.SatUnits.TenLabel, AcumaticaMX.Common.SatUnits.HundredLabel,
                        AcumaticaMX.Common.SatUnits.DozenLabel, AcumaticaMX.Common.SatUnits.BoxLabel,
                        AcumaticaMX.Common.SatUnits.BottleLabel, AcumaticaMX.Common.SatUnits.ServiceLabel,
            })]
        [PXUIField(DisplayName = "Unidades Sat")]
        public virtual string SatUnits { get; set; }

        #endregion SatUnits
    }
}
