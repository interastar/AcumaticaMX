using System;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.GL;

namespace AcumaticaMX
{
    [Serializable]
    [PXTable(typeof(Batch.module),typeof(Batch.batchNbr), IsOptional = true)]
    public class MXGLBatchExtension : PXCacheExtension<Batch>
    {
        #region Cfdi Relacionado

        public abstract class relCfdi : IBqlField { }

        [PXDBBool]
        [PXUIField(DisplayName = "Rel. c/CFDI")]
        public virtual bool? RelCfdi { get; set; }

        #endregion Cfdi Relacionado

        #region RFC

        public abstract class taxRegistrationID : PX.Data.IBqlField { }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "RFC", Visibility = PXUIVisibility.SelectorVisible)]
        public string TaxRegistrationID { get; set; }

        #endregion RFC

        #region Nombre

        public abstract class name : PX.Data.IBqlField { }

        [PXDBString(100, IsUnicode = true)]
        [PXUIField(DisplayName = "Nombre", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Name { get; set; }

        #endregion

        #region Folio

        public abstract class folio : IBqlField { }

        [PXDBString(25, IsFixed = false, IsUnicode = true)]
        [PXUIField(DisplayName = "Folio", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual string Folio { get; set; }
        #endregion Folio

        #region Uuid

        public abstract class uuid : IBqlField { }

        [PXDBGuid()]
        [PXUIField(DisplayName = "UUID", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual Guid? Uuid { get; set; }

        #endregion Uuid

        #region Fecha Documento

        public abstract class docDate : IBqlField { }

        [PXDBDate()]
        [PXUIField(DisplayName = "Fecha Doc.")]
        public virtual DateTime? DocDate { get; set; }

        #endregion Fecha Documento

        #region Total Impuesto

        public abstract class totalTaxes : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Total de Impuestos")]
        public virtual decimal? TotalTaxes { get; set; }

        #endregion Total Impuesto

        #region Total Monto

        public abstract class totalAmount : IBqlField { }

        [PXDBDecimal]
        [PXUIField(DisplayName = "Monto total")]
        public virtual decimal? TotalAmount { get; set; }

        #endregion Total Monto

        #region Tipo Documento

        public abstract class documentType : IBqlField { }

        [PXDBString(1, IsFixed = false, IsUnicode = true)]
        //Desconozco los tipos de documento
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

        #endregion Tipo Documento
    }
}
