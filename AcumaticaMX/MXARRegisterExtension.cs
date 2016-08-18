using System;
using PX.Data;
using PX.Objects;
using PX.Objects.AR;

namespace AcumaticaMX
{
    /// <summary>
    /// Extensión de ARRegister para asociar información de CFDIs
    /// </summary>
    [PXTable(typeof(ARRegister.docType), typeof(ARRegister.refNbr), IsOptional = true)]
    public class MXARRegisterExtension : PXCacheExtension<PX.Objects.AR.ARRegister>
    {

        // Campos persistentes (en BD) *************

        // - Datos del comprobante fiscal
        #region serie
        public abstract class series : IBqlField { }
        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Serie")]
        public virtual string Series { get; set; }
        #endregion serie

        #region formaDePago
        public abstract class paymentForm : IBqlField { }
        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXDefault(AcumaticaMX.Common.PayForm.One)]
        [PXStringList(AcumaticaMX.Common.PayForm.Values)]
        [PXUIField(DisplayName = "Forma de Pago")]
        public virtual string PaymentForm { get; set; }
        #endregion formaDePago

        #region MetodoDePago
        public abstract class paymentMethod : IBqlField { }
        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXDefault(AcumaticaMX.Common.PayMethod.Transfer)]
        [PXStringList(
            new string[]
            {
                AcumaticaMX.Common.PayMethod.Cash, AcumaticaMX.Common.PayMethod.Cheque,
                AcumaticaMX.Common.PayMethod.Transfer, AcumaticaMX.Common.PayMethod.CreditCard,
                AcumaticaMX.Common.PayMethod.Wallet, AcumaticaMX.Common.PayMethod.Electronic,
                AcumaticaMX.Common.PayMethod.Coupons, AcumaticaMX.Common.PayMethod.DebitCard,
                AcumaticaMX.Common.PayMethod.ServiceCard, AcumaticaMX.Common.PayMethod.Other,
            },
            new string[]
            {
                AcumaticaMX.Common.PayMethod.CashLabel, AcumaticaMX.Common.PayMethod.ChequeLabel,
                AcumaticaMX.Common.PayMethod.TransferLabel, AcumaticaMX.Common.PayMethod.CreditCardLabel,
                AcumaticaMX.Common.PayMethod.WalletLabel, AcumaticaMX.Common.PayMethod.ElectronicLabel,
                AcumaticaMX.Common.PayMethod.CouponsLabel, AcumaticaMX.Common.PayMethod.DebitCardLabel,
                AcumaticaMX.Common.PayMethod.ServiceCardLabel, AcumaticaMX.Common.PayMethod.OtherLabel,
            }, MultiSelect = true)]
        [PXUIField(DisplayName = "Metodo de Pago")]
        public virtual string PaymentMethod { get; set; }
        #endregion MetodoDePago

        #region NumCtaPago
        public abstract class originAccount : IBqlField { }
        [PXDBString(4, IsFixed = true, IsUnicode = true)]
        [PXUIField(DisplayName = "Cuenta de Pago", Enabled = false)]
        public virtual string OriginAccount { get; set; }
        #endregion NumCtaPago

        #region condicionesDePago
        public abstract class paymentConditions : IBqlField { }
        [PXDBString(100, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Condiciones de Pago")]
        public virtual string PaymentConditions { get; set; }
        #endregion condicionesDePago

        //  -- Datos de sello del comprobante
        #region noCertificado
        public abstract class certificateNum : IBqlField { }
        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "No. Certificado SAT", Enabled = false)]
        public virtual string CertificateNum { get; set; }
        #endregion noCertificado

        #region certificado
        public abstract class certificate : IBqlField { }
        [PXDBString(2500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Certificado", Enabled = false)]
        public virtual string Certificate { get; set; }
        #endregion certificado

        #region SealDate
        public abstract class sealDate : IBqlField { }
        [PXDBDate()]
        [PXUIField(DisplayName = "Fecha de Emisión", Enabled = false)]
        public virtual DateTime? SealDate { get; set; }
        #endregion SealDate

        // --- Sello del comprobante
        #region sello
        public abstract class seal : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello CFD", Enabled = false)]
        public virtual string Seal { get; set; }
        #endregion sello

        // -- Datos del timbrado del comprobante
        #region Uuid
        public abstract class uuid : IBqlField { }
        [PXDBGuid()]
        [PXUIField(DisplayName = "UUID", Enabled = false)]
        public virtual Guid? Uuid { get; set; }
        #endregion Uuid

        #region noCertificadoSAT
        public abstract class satCertificateNum : IBqlField { }
        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "No. Certificado SAT", Enabled = false)]
        public virtual string SatCertificateNum { get; set; }
        #endregion noCertificadoSAT

        #region FechaTimbrado
        public abstract class stampDate : IBqlField { }
        [PXDBDate()]
        [PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
        public virtual DateTime? StampDate { get; set; }
        #endregion FechaTimbrado

        // --- Sello del SAT
        #region selloSAT
        public abstract class stamp : IBqlField { }
        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello SAT", Enabled = false)]
        public virtual string Stamp { get; set; }
        #endregion selloSAT

        //  -- Campos de addenda
        #region QrCode
        public abstract class qrCode : IBqlField { }
        [PXDBString(95, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Codigo QR", Enabled = false)]
        public virtual string QrCode { get; set; }
        #endregion QrCode

        #region cadenaOriginalTFD
        public abstract class stampString : IBqlField { }
        [PXDBString(1000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cadena Original TFD", Enabled = false)]
        public virtual string StampString { get; set; }
        #endregion cadenaOriginalTFD

        // Campos no persistentes *************
        #region cadenaOriginal
        public abstract class documentString : IBqlField { }
        [PXString(4000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cadena Original", Enabled = false)]
        public virtual string DocumentString { get; set; }
        #endregion cadenaOriginal

        #region CantidadEnLetra
        public abstract class amountInWords : IBqlField { }
        [PXString(4000, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Monto en Letra", Enabled = false)]
        public virtual string AmountInWords { get; set; }
        #endregion CantidadEnLetra  
    }
}

