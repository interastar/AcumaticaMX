using PX.Common;

namespace AcumaticaMX
{
    /// <summary>
    /// Librería de mensajes y etiquetas centralizada
    /// </summary>
    [PXLocalizable()]
    public static class Messages
    {
        // Textos y Etiquetas de campos

        #region Nombres

        //public const string Etiqueta = "Valor";
        //public const string Etiqueta = "Valor";
        //public const string Etiqueta = "Valor";
        public const string Municipality = "Municipio / Delegación";

        #endregion Nombres

        // Estados de factura

        #region Estados

        public const string CleanCfdi = "No Timbrado";
        public const string StampedCfdi = "Timbrado";
        public const string CanceledCfdi = "Cancelado";
        public const string BlockedCfdi = "Bloqueado";

        #endregion Estados

        // Mensajes de error

        #region Mensaje

        public const string NaturalContactInfoRequired = "Los campos nombre, apellido paterno y apellido materno son obligatorios para personas físicas";
        public const string LegalContactInfoRequired = "El campo nombre de compañía es obligatorio para personas morales";
        public const string AddressInfoRequired = "Los campos calle, número exterior, colonia, municipio, ciudad, país, estado y código postal son obligatorios para facturar";

        public const string TaxRegistrationIDRequired = "El RFC es necesario para facturar en México";
        public const string TaxRegistrationIDInvalid = "La clave del RFC (México) debe tener entre 12 y 13 caracteres y seguir la forma XXXXaammddHHH con números y mayúsculas.";

        #endregion Mensaje

        //*** SYFEPaymentMethodExtension
        public const string PaymentMethod = "Clave Método de Pago en SAT";

        //*** MXPOReceipLineExt
        public const string Customs = "Aduana";
        public const string ImportDate = "Fecha de importación";
        public const string RequestNumber = "Numero de Pedimento";
        public const string CustomsRequestNbr = "Información aduanera";
        public const string ErrorCustoms = "Si ingresa Número de pedimento, debe ingresar nombre de aduana y la fecha de importación.";
        public const string ErrorImportDate = "El campo Fecha de Importacion no puede estar vacio";
        public const string LineNbr = "LineNbr";

        #region Catalogo de Cuentas

        //*** MXCESatAccountList
        public const string GroupingCodeLabel = "Código Agrupador";
        public const string GroupingCodeIDLabel = "GroupingCodeID";
        public const string LevelLabel = "Nivel";
        public const string DescriptionLabel = "Descripción";
        public const string ParentCD = "Código agrupador Padre";
        public const string ParentIDLabel = "Padre";

        #endregion Catalogo de Cuentas

        #region Catalogo de Códigos Postales

        //*** ZipCodeList
        public const string ZipCodeCD = "Código Postal";
        public const string State = "Estado";
        public const string Town = "Localidad";

        #endregion Catalogo de Códigos Postales

        #region Catalogo de Productos y Sevicios
        public const string ProdServCode = "Clave Producto Servicio";
        public const string ProdServIVA = "Incluir IVA trasladado";
        public const string ProdServIEPS = "Incluir IEPS trasladado";
        public const string ProdServComplement = "Incluir Complemento";
        #endregion Catalogo de Productos y Servicios

        #region Catalogo de Regimen Fiscal
        public const string TaxRegimCD = "Clave Regimen Fiscal";
        public const string ApplyNaturalPerson = "Aplica persona fisica";
        public const string ApplyMoralPerson = "Aplica persona Moral";
        #endregion Catalogo de Regimen Fiscal

        #region Catalogo de Numero de pedimento de Aduana
        public const string Patent = "Patente";
        public const string FiscalExcercise = "Ejercicio Fiscal";
        #endregion Catalogo de Numero de pedimento de Aduana

        #region Catalogo de uso de CFDI
        public const string useCFDI = "Clave Uso";
        #endregion

        #region Catalogo de Bancos
        public const string BankCD = "Clave del Banco";
        public const string BankName = "Nombre del Banco";
        public const string BankRFC = "RFC del Banco";
        #endregion

        #region Catalogo Unidades de Medida
        public const string MeasureCD = "Clave Unidad de Medida";
        #endregion

        #region Catalogo Unidades de Medida
        public const string CurrencyCD = "Moneda";
        public const string Precision = "Decimales";
        public const string Variation = "Variacion";
        #endregion

        #region Common
        public const string ValidityStartDate = "Inicio Vigencia";
        public const string ValidityEndDate = "Fin Vigencia";
        public const string Qty = "Cantidad";
        public const string UseCFDI = "Uso de Cfdi";
        public const string ProductService = "SAT Producto o Servicio";
        public const string Name = "Nombre";
        public const string Measure = "Sat Unidad de Medida";
        public const string Unit = "Unidad";
        public const string PaymentDocDateTime = "Fecha de Deposito";
        #endregion

        #region Catalogo de Monedas

        //*** MXCESatMoneyList
        public const string MoneyCodeLabel = "Código de Monedas";
        public const string MoneyNameLabel = "Nombre de la moneda";
        #endregion Catalogo de Monedas

        #region Impuestos
        public const string Tax = "Sat Tipo de Impuesto";
        #endregion

        #region Complemento de Pagos
        public const string PaymentRefNbr = "No. Referencia de Complemento de Pago";
        #endregion Complemento de Pagos

    }
}
