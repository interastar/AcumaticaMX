using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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
            public const string One = "PUE";
            public const string Partial = "PPD";

            public const string OneLabel = "Pago en una sola exhibición";
            public const string PartialLabel = "Pago en parcialidades";
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
            public const string NAFE = "NA";
            public const string NACE = "98";
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
            public const string NAFELabel = "NA Facturacion Electrónica";
            public const string NACELabel = "NA Contabilidad Electónica";
            public const string OtherLabel = "Otros";

            public static string Labels
            {
                get
                {
                    return string.Join(",", typeof(PayMethod).GetFields().Where(x => x.Name.Contains("Label")).Select(x => x.GetValue(null)));
                }
            }
        }

        public static class Tax
        {
            public const string ISR = "001";
            public const string IVA = "002";
            public const string IEPS = "003";

            public const string ISRLabel = "ISR";
            public const string IVALabel = "IVA";
            public const string IEPSLabel = "IEPS";
        }

        public static class TaxType
        {
            public const string Holding = "R";
            public const string Transfer = "T";

            public const string HoldingLabel = "Retención";
            public const string TransferLabel = "Traslado";
        }
    }

    public class Convert
    {
        /// <summary>
        /// Options for specifying the desired grammatical gender for the output words
        /// </summary>
        public enum GrammaticalGender
        {
            /// <summary>
            /// Indicates masculine grammatical gender
            /// </summary>
            Masculine,

            /// <summary>
            /// Indicates feminine grammatical gender
            /// </summary>
            Feminine,

            /// <summary>
            /// Indicates neuter grammatical gender
            /// </summary>
            Neuter
        }

        private static readonly string[] UnitsMap = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce",
                                                        "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte", "veintiuno",
                                                        "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve"};

        private const string Feminine1 = "una";
        private const string Feminine21 = "veintiuna";
        private static readonly string[] TensMap = { "cero", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
        private static readonly string[] HundredsMap = { "cero", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
        private static readonly string[] FeminineHundredsMap = { "cero", "ciento", "doscientas", "trescientas", "cuatrocientas", "quinientas", "seiscientas", "setecientas", "ochocientas", "novecientas" };

        private static readonly Dictionary<int, string> Ordinals = new Dictionary<int, string>
        {
            {1, "primero"},
            {2, "segundo"},
            {3, "tercero"},
            {4, "cuarto"},
            {5, "quinto"},
            {6, "sexto"},
            {7, "séptimo"},
            {8, "octavo"},
            {9, "noveno"},
            {10, "décimo"}
        };

        public static string ToWords(decimal? amount, string curyID)
        {
            var graph = new PXGraph();

            PX.Objects.CM.Currency cury = new PXSelectReadonly<PX.Objects.CM.Currency,
                                Where<PX.Objects.CM.Currency.curyID, Equal<Required<PX.Objects.CM.Currency.curyID>>>>(graph).Select(curyID);

            if (cury != null)
            {
                /// Todo: Actualizar
                return CuryToWords(amount, cury.CuryID, cury.Description);
            }

            return "";
        }

        public static string CuryToWords(decimal? value, string currencyID, string currencyDescription)
        {
            if (value == null)
                return "";

            var parts = new List<string>();

            var whole = (int)Math.Truncate((decimal)value);
            var cents = ((decimal)value) - whole;

            parts.Add(FirstLetterToUpper(NumberToWords(whole)));
            parts.Add(currencyDescription.ToLower());
            parts.Add(DecimalsToFraction(cents));
            parts.Add(currencyID);

            return string.Join(" ", parts.ToArray());
        }

        public static string DecimalsToFraction(decimal decimals)
        {
            var cents = Math.Truncate(decimals * 100);

            return string.Format("{0:00}/100", cents);
        }

        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static string NumberToWords(int number, GrammaticalGender gender = GrammaticalGender.Masculine)
        {
            if (number == 0)
                return "cero";

            if (number < 0)
                return string.Format("menos {0}", NumberToWords(Math.Abs(number)));

            var parts = new List<string>();

            if ((number / 1000000000) > 0)
            {
                parts.Add(number / 1000000000 == 1
                    ? "mil millones"
                    : string.Format("{0} mil millones", NumberToWords(number / 1000000000)));

                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(number / 1000000 == 1
                    ? "un millón"
                    : string.Format("{0} millones", NumberToWords(number / 1000000)));

                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(number / 1000 == 1
                    ? "mil"
                    : string.Format("{0} mil", NumberToWords(number / 1000, gender)));

                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(number == 100
                    ? "cien"
                    : gender == GrammaticalGender.Feminine
                        ? FeminineHundredsMap[(number / 100)]
                        : HundredsMap[(number / 100)]);
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 30)
                {
                    if (gender == GrammaticalGender.Feminine && (number == 1 || number == 21))
                    {
                        parts.Add(number == 1 ? Feminine1 : Feminine21);
                    }
                    else
                    {
                        parts.Add(UnitsMap[number]);
                    }
                }
                else
                {
                    var lastPart = TensMap[number / 10];
                    int units = number % 10;
                    if (units == 1 && gender == GrammaticalGender.Feminine)
                    {
                        lastPart += " y una";
                    }
                    else if (units > 0)
                    {
                        lastPart += string.Format(" y {0}", UnitsMap[number % 10]);
                    }

                    parts.Add(lastPart);
                }
            }

            return string.Join(" ", parts.ToArray());
        }
    }
}