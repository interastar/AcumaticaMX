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

        public const string CleanCfdi = "Nuevo";
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
    }
}