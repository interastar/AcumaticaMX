using PX.Data;
using PX.Objects.AP;
using System;

namespace MX.Objects
{
    /// <summary>
    /// Extensión de ARRegister para asociar información de CFDIs
    /// </summary>
    [PXTable(typeof(APRegister.docType), typeof(APRegister.refNbr), IsOptional = true)]
    public class PXFEAPRegisterExt : PXCacheExtension<APRegister>
    {
        // Campos persistentes (en BD) *************

        // - Datos del comprobante fiscal

        #region Serie

        public abstract class series : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Serie", Enabled = false)]
        public virtual string Series { get; set; }

        #endregion Serie

        #region FormaDePago

        public abstract class paymentForm : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Forma de Pago")]
        public virtual string PaymentForm { get; set; }

        #endregion FormaDePago

        #region MetodoDePago

        public abstract class paymentMethod : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Metodo de Pago")]
        public virtual string PaymentMethod { get; set; }

        #endregion MetodoDePago

        #region NumCtaPago

        public abstract class originAccount : IBqlField { }

        [PXDBString(20, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Cuenta de Pago", Enabled = false)]
        public virtual string OriginAccount { get; set; }

        #endregion NumCtaPago

        #region condicionesDePago

        public abstract class paymentTerms : IBqlField { }

        [PXDBString(100, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Condiciones de Pago")]
        public virtual string PaymentTerms { get; set; }

        #endregion condicionesDePago

        //  -- Datos de sello del comprobante

        #region noCertificado

        public abstract class certificateNum : IBqlField { }

        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "Certificado del Emisor", Enabled = false)]
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

        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Emisión", Enabled = false)]
        public virtual DateTime? SealDate { get; set; }

        #endregion SealDate

        // --- Sello del comprobante

        #region Sello

        public abstract class seal : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello CFD", Enabled = false)]
        public virtual string Seal { get; set; }

        #endregion Sello

        // -- Datos del timbrado del comprobante

        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid()]
        [PXUIField(DisplayName = "UUID", Enabled = false, Visibility = PXUIVisibility.SelectorVisible)]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region NoCertificadoSAT

        public abstract class satCertificateNum : IBqlField { }

        [PXDBString(20, IsFixed = true, IsUnicode = false)]
        [PXUIField(DisplayName = "No. Certificado SAT", Enabled = false)]
        public virtual string SatCertificateNum { get; set; }

        #endregion NoCertificadoSAT

        #region FechaTimbrado

        public abstract class stampDate : IBqlField { }

        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
        public virtual DateTime? StampDate { get; set; }

        #endregion FechaTimbrado

        #region FechaCancelacion

        public abstract class cancelDate : IBqlField { }

        [PXDBDateAndTime(PreserveTime = true)]
        [PXUIField(DisplayName = "Fecha de Cancelación", Enabled = false)]
        public virtual DateTime? CancelDate { get; set; }

        #endregion FechaCancelacion

        // --- Sello del SAT

        #region SelloSAT

        public abstract class stamp : IBqlField { }

        [PXDBString(500, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Sello SAT", Enabled = false)]
        public virtual string Stamp { get; set; }

        #endregion SelloSAT

        // -- Datos de importación del documento

        #region IsImport
        public abstract class isImport : IBqlField { }
        [PXDBBool]
        [PXUIField(DisplayName = "Importación", Enabled = false)]
        public virtual bool? IsImport { get; set; }
        #endregion IsImport

        #region Provider
        public abstract class provider : IBqlField { }
        [PXDBString(13, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "RFC del Proveedor", Enabled = false)]
        public virtual string Provider { get; set; }
        #endregion Provider

        #region TaxesTotal
        public abstract class taxesTotal : IBqlField { }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Total de Impuestos", Enabled = false)]
        public virtual decimal? TaxesTotal { get; set; }
        #endregion TaxesTotal

        #region AmountTotal
        public abstract class amountTotal : IBqlField { }
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Monto total", Enabled = false)]
        public virtual decimal? AmountTotal { get; set; }
        #endregion AmountTotal
    }
}