using PX.Data;
using PX.Objects.AP;
using System;

namespace AcumaticaMX
{
    /// <summary>
    /// Extensión de ARRegister para asociar información de CFDIs
    /// </summary>
    [Serializable]
    [PXTable(typeof(APRegister.docType), typeof(APRegister.refNbr), IsOptional = true)]
    public class MXAPRegisterExtension : PXCacheExtension<APRegister>
    {
        // Campos persistentes (en BD) *************

        // - Datos del comprobante fiscal

        #region Version

        public abstract class version : IBqlField { }

        [PXDBString(3, IsFixed = false, IsUnicode = true)]
        public virtual string Version { get; set; }

        #endregion Version

        #region Serie

        public abstract class series : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Serie", Enabled = false)]
        public virtual string Series { get; set; }

        #endregion Serie

        #region FormaDePago

        public abstract class paymentForm : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        //[PXDefault(AcumaticaMX.Common.PayForm.One)]
        [PXStringList(
            new string[]
            {
                Common.PayForm.One,
                Common.PayForm.Partial,
            },
            new string[]
            {
                Common.PayForm.OneLabel,
                Common.PayForm.PartialLabel,
            }
            )]
        [PXUIField(DisplayName = "Metodo de Pago")]
        public virtual string PaymentForm { get; set; }

        #endregion FormaDePago

        #region MetodoDePago

        public abstract class paymentMethod : IBqlField { }

        [PXDBString(50, IsFixed = false, IsUnicode = true)]
        //[PXDefault(AcumaticaMX.Common.PayMethod.Transfer)]
        [PXSelector(typeof(Search<MXFESatPaymentMethodList.satPaymentMethod>),
            typeof(MXFESatPaymentMethodList.description),
            DescriptionField = typeof(MXFESatPaymentMethodList.description))]
        [PXUIField(DisplayName = "Forma de Pago")]
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

        [PXDBDate()]
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

        [PXDBDate()]
        [PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
        public virtual DateTime? StampDate { get; set; }

        #endregion FechaTimbrado

        #region FechaCancelacion

        public abstract class cancelDate : IBqlField { }

        [PXDBDate()]
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

        // -- Campos no persistentes

        #region Estado

        public abstract class stampStatus : IBqlField { }

        [PXString(1, IsFixed = true)]
        //[PXDefault(CfdiStatus.Clean)]
        //[PXUnboundDefault(CfdiStatus.Clean)]
        [PXUIField(DisplayName = "Edo. Timbrado", Visibility = PXUIVisibility.SelectorVisible, IsReadOnly = true, Enabled = false)]
        [CfdiStatus.List()]
        [SetCfdiStatus()]
        public virtual string StampStatus { get; set; }

        #endregion Estado

        #region Timbrable

        public abstract class notStampable : IBqlField { }

        [PXBool()]
        //[PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "No Timbrar", Visibility = PXUIVisibility.SelectorVisible, Enabled = true)]
        [StampableStatus(typeof(notStampable), typeof(stampStatus), typeof(uuid))]
        public virtual bool? NotStampable { get; set; }

        #endregion Timbrable

        // -- Datos de importación del documento

        #region Folio

        public abstract class folio : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        public virtual string Folio { get; set; }
        #endregion Folio

        #region Import
        public abstract class import : IBqlField { }
        [PXDBBool]
        [PXUIField(DisplayName = "Importación", Enabled = false)]
        public virtual bool? Import { get; set; }
        #endregion Import

        #region Provider
        public abstract class provider : IBqlField { }
        [PXDBString(13, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "RFC del Proveedor", Enabled = false)]
        public virtual string Provider { get; set; }
        #endregion Provider

        #region TotalTaxes
        public abstract class totalTaxes : IBqlField { }
        [PXDBDecimal]
        [PXUIField(DisplayName = "Total de Impuestos", Enabled = false)]
        public virtual decimal? TotalTaxes { get; set; }
        #endregion TotalTaxes

        #region TotalAmount
        public abstract class totalAmount : IBqlField { }
        [PXDBDecimal]
        [PXUIField(DisplayName = "Monto total", Enabled = false)]
        public virtual decimal? TotalAmount { get; set; }
        #endregion TotalAmount

        #region Factura de gastos

        public abstract class isExpenseInvoice : IBqlField { }

        [PXDBBool]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual bool? IsExpenseInvoice { get; set; }

        #endregion Factura de gastos

        // -- Datos para poliza

        #region Document Type

        public abstract class documentType : IBqlField { }

        [PXDBString(1, IsFixed = false, IsUnicode = true)]
        [PXDefault(Common.DocumentType.Cfdi, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXStringList(
            new string[]
            {
                Common.DocumentType.Cfdi,
                Common.DocumentType.CfdCbb,
                Common.DocumentType.Foreign,
            },
            new string[]
            {
                Common.DocumentType.CfdiLabel,
                Common.DocumentType.CfdCbbLabel,
                Common.DocumentType.ForeignLabel,
            }
            )]
        [PXUIField(DisplayName = "Tipo de documento")]
        public virtual string DocumentType { get; set; }
        #endregion Document Type

        #region Bank

        public abstract class bankCD : IBqlField
        {
        }
        [PXDBString(3, IsUnicode = true)]
        [PXUIField(DisplayName = "Banco Destino")]
        public virtual string BankCD { get; set; }

        #endregion Bank
    }
}