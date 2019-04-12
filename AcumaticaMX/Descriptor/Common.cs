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
        public const string defaultCfdiVersion = "3.3";
        public const string defaultPaymentMethod = "03";

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
            public const string PartialLabel = "Pago en parcialidades o diferido";
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
            public const string NA = "98";
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
            public const string NALabel = "NA";
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

	    /// <summary>
        /// Catálogo de Unidades
        /// </summary>
        public static class SatUnits
        {
            public const string Kilo = "01";
            public const string Gram = "02";
            public const string LinealMeter = "03";
            public const string SquareMeter = "04";
            public const string CubicMeter = "05";
            public const string Piece = "06";
            public const string Head = "07";
            public const string Liter = "08";
            public const string Pair = "09";
            public const string KiloWatt = "10";
            public const string Thousand = "11";
            public const string Set = "12";
            public const string KiloWatt_Hour = "13";
            public const string Ton = "14";
            public const string Berrel = "15";
            public const string GramNet = "16";
            public const string Ten = "17";
            public const string Hundred = "18";
            public const string Dozen = "19";
            public const string Box = "20";
            public const string Bottle = "21";
            public const string Service = "99";

            public static string Values
            {
                get
                {
                    return string.Join(",", typeof(SatUnits).GetFields().Where(x => !x.Name.Contains("Label")).Select(x => x.GetValue(null)));
                }
            }

            public const string KiloLabel = "Kilo";
            public const string GramLabel = "Gramo";
            public const string LinealMeterLabel = "Metro Lineal";
            public const string SquareMeterLabel = "Metro Cuadrado";
            public const string CubicMeterLabel = "Metro Cubico";
            public const string PieceLabel = "Pieza";
            public const string HeadLabel = "Cabeza";
            public const string LiterLabel = "Litro";
            public const string PairLabel = "Par";
            public const string KiloWattLabel = "KiloWatt";
            public const string ThousandLabel = "Millar";
            public const string SetLabel = "Juego";
            public const string KiloWatt_HourLabel = "KiloWatt/Hora";
            public const string TonLabel = "Tonelada";
            public const string BerrelLabel = "Barril";
            public const string GramNetLabel = "Gramo Neto";
            public const string TenLabel = "Decena";
            public const string HundredLabel = "Cientos";
            public const string DozenLabel = "Docena";
            public const string BoxLabel = "Caja";
            public const string BottleLabel = "Botella";
            public const string ServiceLabel = "Servicio";

            public static string Labels
            {
                get
                {
                    return string.Join(",", typeof(SatUnits).GetFields().Where(x => x.Name.Contains("Label")).Select(x => x.GetValue(null)));
                }
            }
        }
        public static class DocumentType
        {
            public const string Cfdi = "C";
            public const string CfdCbb = "B";
            public const string Foreign = "F";

            public const string CfdiLabel = "CFDI";
            public const string CfdCbbLabel = "CFD/CBB";
            public const string ForeignLabel = "Factura Extranjera";
        }    

        public static class TransferReason
        {
            public const string ReasonOne = "01";
            public const string ReasonTwo = "02";
            public const string ReasonThree = "03";
            public const string ReasonFour = "04";
            public const string ReasonFive = "05";
            public const string ReasonSix = "99";

            public const string ReasonOneLabel = "Envío de mercancias facturadas con anterioridad";
            public const string ReasonTwoLabel = "Reubicación de mercancías propias";
            public const string ReasonThreeLabel = "Envío de mercancías objeto de contrato de consignación";
            public const string ReasonFourLabel = "Envío de mercancías para posterior enajenación";
            public const string ReasonFiveLabel = "Envío de mercancías propiedad de terceros";
            public const string ReasonSixLabel = "Otros";
        }
        
        public static class Incoterm
        {
            public const string CFR = "CFR";
            public const string CIF = "CIF";
            public const string CPT = "CPT";
            public const string CIP = "CIP";
            public const string DAF = "DAF";
            public const string DAP = "DAP";
            public const string DAT = "DAT";
            public const string DES = "DES";
            public const string DEQ = "DEQ";
            public const string DDU = "DDU";
            public const string DDP = "DDP";
            public const string EXW = "EXW";
            public const string FCA = "FCA";
            public const string FAS = "FAS";
            public const string FOB = "FOB";

            public const string CFRLabel = "COSTE Y FLETE (PUERTO DE DESTINO CONVENIDO).";
            public const string CIFLabel = "COSTE, SEGURO Y FLETE (PUERTO DE DESTINO CONVENIDO).";
            public const string CPTLabel = "TRANSPORTE PAGADO HASTA (EL LUGAR DE DESTINO CONVENIDO).";
            public const string CIPLabel = "TRANSPORTE Y SEGURO PAGADOS HASTA (LUGAR DE DESTINO CONVENIDO).";
            public const string DAFLabel = "ENTREGADA EN FRONTERA (LUGAR CONVENIDO).";
            public const string DAPLabel = "ENTREGADA EN LUGAR.";
            public const string DATLabel = "ENTREGADA EN TERMINAL.";
            public const string DESLabel = "ENTREGADA SOBRE BUQUE (PUERTO DE DESTINO CONVENIDO).";
            public const string DEQLabel = "ENTREGADA EN MUELLE (PUERTO DE DESTINO CONVENIDO).";
            public const string DDULabel = "ENTREGADA DERECHOS NO PAGADOS (LUGAR DE DESTINO CONVENIDO).";
            public const string DDPLabel = "ENTREGADA DERECHOS PAGADOS (LUGAR DE DESTINO CONVENIDO).";
            public const string EXWLabel = "EN FABRICA (LUGAR CONVENIDO).";
            public const string FCALabel = "FRANCO TRANSPORTISTA (LUGAR DESIGNADO).";
            public const string FASLabel = "FRANCO AL COSTADO DEL BUQUE (PUERTO DE CARGA CONVENIDO).";
            public const string FOBLabel = "FRANCO A BORDO (PUERTO DE CARGA CONVENIDO).";
        }

        public static class RelationType
        {
            public const string CreditMemo = "01";
            public const string DebitMemo = "02";
            public const string Refund = "03";
            public const string Replace = "04";
            public const string Transfers = "05";
            public const string InvoiceTransfers = "06";
            public const string Advance = "07";

            public const string CreditMemoLabel = "Nota de crédito de los documentos relacionados";
            public const string DebitMemoLabel = "Nota de débito de los documentos relacionados";
            public const string RefundLabel = "Devolución de mercancía sobre facturas o traslados previos";
            public const string ReplaceLabel = "Sustitución de los CFDI previos";
            public const string TransfersLabel = "Traslados de mercancias facturados previamente";
            public const string InvoiceTransfersLabel = "Factura generada por los traslados previos";
            public const string AdvanceLabel = "CFDI por aplicación de anticipo";
        }

        public static class VendorType
        {
            public const string Empty = "";
            public const string National = "Nacional";
            public const string Foreign = "Extranjero";
            public const string Global = "Global";

            public const string EmptyLabel = "";
            public const string NationalLabel = "Nacional";
            public const string ForeignLabel = "Extranjero";
            public const string GlobalLabel = "Global";
        }

        public static class VendorOperationType
        {
            public const string Empty = "";
            public const string Services = "Prestación de servicios profesionales";
            public const string LeasingEstate = "Arrendamiento de inmuebles";
            public const string Others = "Otros";

            public const string EmptyLabel = Empty;
            public const string ServicesLabel = Services;
            public const string LeasingEstateLabel = LeasingEstate;
            public const string OthersLabel = Others;
        }

        public static class TypeOfImport
        {
            public const string Expenses = "E";

            public const string ExpensesLabel = "Gastos";
        }

        public static class PaymentType {
            public const string Input = "E";
            public const string Output = "S";

            public const string InputLabel = "Entrada";
            public const string OutputLabel = "Salida";
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
