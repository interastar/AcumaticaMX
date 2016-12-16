namespace AcumaticaMX
{
    /// <summary>
    /// Librería de mensajes y etiquetas centralizada
    /// </summary>
    public static class Messages
    {
        // Textos y Etiquetas de campos

        #region Nombres

        //public const string Etiqueta = "Valor";

        #endregion Nombres

        public const string CleanCfdi = "Nuevo";
        public const string StampedCfdi = "Timbrado";
        public const string CanceledCfdi = "Cancelado";
        public const string BlockedCfdi = "Bloqueado";

        //*** SYFEPaymentMethodExtension
        public const string PaymentMethod = "Clave Método de Pago en SAT";

        //*** BAccount
        public const string TaxRegistrationIDInvalid = "La clave del RFC (México) debe tener entre 12 y 13 caracteres y seguir la forma XXXXaammddHHH con números y mayúsculas.";
    }
}