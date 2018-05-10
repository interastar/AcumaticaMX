using PX.Data;
using PX.Objects.SO;

namespace AcumaticaMX
{
    public class MXSOAddressExtension : PXCacheExtension<PX.Objects.SO.SOBillingAddress>, IMXAddressExtension
    {
        #region AddressLine1

        [PXMergeAttributes(Method = MergeMethod.Merge)]
        [PXDBString(250, IsUnicode = true)]
        public string AddressLine1 { get; set; }

        #endregion AddressLine1

        #region AddressLine2

        [PXMergeAttributes(Method = MergeMethod.Merge)]
        [PXDBString(250, IsUnicode = true)]
        public string AddressLine2 { get; set; }

        #endregion AddressLine2

        #region AddressLine3

        [PXMergeAttributes(Method = MergeMethod.Merge)]
        [PXDBString(250, IsUnicode = true)]
        public string AddressLine3 { get; set; }

        #endregion AddressLine3

        #region Mandatory fields

        //[PXCustomizeBaseAttribute(typeof(PXUIFieldAttribute), "Required", true)]
        //[PXMergeAttributes(Method = MergeMethod.Merge)]
        //[PXDefault()]
        //public string City { get; set; }

        //[PXCustomizeBaseAttribute(typeof(PXUIFieldAttribute), "Required", true)]
        //[PXMergeAttributes(Method = MergeMethod.Merge)]
        //[PXDefault()]
        //public string CountryID { get; set; }

        //[PXCustomizeBaseAttribute(typeof(PXUIFieldAttribute), "Required", true)]
        //[PXMergeAttributes(Method = MergeMethod.Merge)]
        //[PXDefault()]
        //public string State { get; set; }

        //[PXCustomizeBaseAttribute(typeof(PXUIFieldAttribute), "Required", true)]
        //[PXMergeAttributes(Method = MergeMethod.Merge)]
        //[PXDefault()]
        //public string PostalCode { get; set; }

        #endregion Mandatory fields

        #region Street

        public abstract class street : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(SOAddress.addressLine1), 1, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Calle", Required = false)]
        public virtual string Street { get; set; }

        #endregion Street

        #region ExtNumber

        public abstract class extNumber : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(SOAddress.addressLine1), 2, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Número Exterior", Required = false)]
        public virtual string ExtNumber { get; set; }

        #endregion ExtNumber

        #region IntNumber

        public abstract class intNumber : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(SOAddress.addressLine1), 3, typeof(street), typeof(extNumber), typeof(intNumber))]
        [PXUIField(DisplayName = "Número Interior")]
        public virtual string IntNumber { get; set; }

        #endregion IntNumber

        #region Neighborhood

        public abstract class neighborhood : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(SOAddress.addressLine2), 1, typeof(neighborhood), typeof(municipality), Separator = ",")]
        [PXUIField(DisplayName = "Colonia", Required = false)]
        public virtual string Neighborhood { get; set; }

        #endregion Neighborhood

        #region Municipality

        public abstract class municipality : IBqlField
        {
        }

        [PXString(50, IsUnicode = true)]
        [MultipartField(typeof(SOAddress.addressLine2), 2, typeof(neighborhood), typeof(municipality), Separator = ",")]
        [PXUIField(DisplayName = "Municipio/Delegación", Required = false)]
        public virtual string Municipality { get; set; }

        #endregion Municipality

        #region Reference

        public abstract class reference : IBqlField
        {
        }

        [PXString(100, IsUnicode = true)]
        [MultipartField(typeof(SOAddress.addressLine3), 1, typeof(reference))]
        [PXUIField(DisplayName = "Referencia")]
        public virtual string Reference { get; set; }

        #endregion Reference
    }
}