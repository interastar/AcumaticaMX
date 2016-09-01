using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcumaticaMX
{
    /// <summary>
    /// Esta clase contiene todos los catálogos de campos que tienen opciones predefinidas por el SAT
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Catálogo de regimenes fiscales
        /// </summary>
        public static class RegimenTypes
        {
            // Valores
            public const string NaturalSalaried = "Asalariados";
            public const string NaturalFee = "Honorarios";
            public const string NaturalLessor = "Arrendamiento de Inmuebles";
            public const string NaturalBusinessActivity = "Actividades Empresariales";
            public const string NaturalTaxIncorporated = "Incorporación Fiscal";

            public const string JuridicalGeneral = "Personas Morales del Régimen General";
            public const string JuridicalNonProfit = "Personas Morales con Fines no Lucrativos";

            public static string Values
            {
                get
                {
                    return string.Join(",", typeof(PayMethod).GetFields().Where(x => !x.Name.Contains("Label")).Select(x => x.GetValue(null)));
                }
            }

            /// Etiquetas
            public const string NaturalSalariedLabel = "Persona Física - Asalariados";
            public const string NaturalFeeLabel = "Persona Física - Honorarios";
            public const string NaturalLessorLabel = "Persona Física - Arrendamiento de Inmuebles";
            public const string NaturalBusinessActivityLabel = "Persona Física - Actividades Empresariales";
            public const string NaturalTaxIncorporatedLabel = "Persona Física - Incorporación Fiscal";

            public const string JuridicalGeneralLabel = "Personas Morales - Régimen General";
            public const string JuridicalNonProfitLabel = "Personas Morales - Fines no Lucrativos";

            public static string Labels
            {
                get
                {
                    return string.Join(",", typeof(PayMethod).GetFields().Where(x => x.Name.Contains("Label")).Select(x => x.GetValue(null)));
                }
            }
        }

        /// <summary>
        /// Catálogo de formas de pago
        /// </summary>
        public static class PayForm
        {
            public const string One = "Pago en una sola exhibición";
            public const string Partial = "Pago en parcialidades";

            public const string OneLabel = "Pago en una sola exhibición";
            public const string PartialLabel = "Pago en parcialidades";

            public const string Values = "Pago en una sola exhibición,Pago en parcialidades";
        }

        /// <summary>
        /// Catálogo de métodos de pago
        /// </summary>
        public static class PayMethod
        {
            public const string Cash = "01";
            public const string Cheque = "02";
            public const string Transfer = "03";
            public const string CreditCard = "04";
            public const string Wallet = "05";
            public const string Electronic = "06";
            public const string Coupons = "08";
            public const string DebitCard = "28";
            public const string ServiceCard = "29";
            public const string Other = "99";

            public static string Values
            {
                get
                {
                    return string.Join(",", typeof(PayMethod).GetFields().Where(x => !x.Name.Contains("Label")).Select(x => x.GetValue(null)));
                }
            }

            public const string CashLabel = "Efectivo";
            public const string ChequeLabel = "Cheque nominativo";
            public const string TransferLabel = "Transferencia electrónica de fondos";
            public const string CreditCardLabel = "Tarjetas de Crédito";
            public const string WalletLabel = "Monedero Electrónico";
            public const string ElectronicLabel = "Dinero electrónico";
            public const string CouponsLabel = "Vales de despensa";
            public const string DebitCardLabel = "Tarjeta de Débito";
            public const string ServiceCardLabel = "Tarjeta de Servicio";
            public const string OtherLabel = "Otros";

            public static string Labels
            {
                get
                {
                    return string.Join(",", typeof(PayMethod).GetFields().Where(x => x.Name.Contains("Label")).Select(x => x.GetValue(null)));
                }
            }
        }
    }
}