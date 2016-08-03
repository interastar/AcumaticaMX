using System;
using PX.Data;
using PX.Objects;
using PX.Objects.AR;

namespace AcumaticaMX
{
    [PXTable(typeof(ARRegister.docType), typeof(ARRegister.refNbr), IsOptional = true)]
	public class MXARRegisterExtension : PXCacheExtension<PX.Objects.AR.ARRegister>
	{		
		// Campos persistentes (en BD)
	
		#region Series
		public abstract class series : IBqlField { }

		[PXDBString(25, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Serie")]
		public virtual string Series { get; set; }
		#endregion Series


		#region Certificate
		public abstract class certificate : IBqlField { }

		[PXDBString(2500, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Certificado", Enabled = false)]
		public virtual string Certificate { get; set; }
		#endregion Certificate

		#region PaymentForm
		public abstract class paymentForm : IBqlField { }

		[PXDBString(50, IsFixed = false, IsUnicode = true)]
		[PXDefault(AcumaticaMX.Common.PayForm.One)]
		[PXStringList(AcumaticaMX.Common.PayForm.Values)]
		[PXUIField(DisplayName = "Forma de Pago")]
		public virtual string PaymentForm { get; set; }
		#endregion PaymentForm

		#region PaymentMethod
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
		#endregion PaymentMethod

		#region PaymentConditions
		public abstract class paymentConditions : IBqlField { }

		[PXDBString(100, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Condiciones de Pago")]
		public virtual string PaymentConditions { get; set; }
		#endregion PaymentConditions

		#region OriginAccount
		public abstract class originAccount : IBqlField { }

		[PXDBString(4, IsFixed = true, IsUnicode = true)]
		[PXUIField(DisplayName = "Cuenta de Pago", Enabled = false)]
		public virtual string OriginAccount { get; set; }
		#endregion OriginAccount
		
		
		#region StampDate
		public abstract class stampDate : IBqlField { }

		[PXDBDate()]
		[PXUIField(DisplayName = "Fecha de Timbrado", Enabled = false)]
		public virtual DateTime? StampDate { get; set; }
		#endregion StampDate

		#region Uuid
		public abstract class uuid : IBqlField { }

		[PXDBGuid()]
		[PXUIField(DisplayName = "UUID", Enabled = false)]
		public virtual Guid? Uuid { get; set; }
		#endregion Uuid

		#region SatCertificateNum
		public abstract class satCertificateNum : IBqlField { }

		[PXDBString(20, IsFixed = true, IsUnicode = false)]
		[PXUIField(DisplayName = "No. Certificado SAT", Enabled = false)]
		public virtual string SatCertificateNum { get; set; }
		#endregion SatCertificateNum

		#region CfdStamp
		public abstract class cfdStamp : IBqlField { }

		[PXDBString(500, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Sello CFD", Enabled = false)]
		public virtual string CfdStamp { get; set; }
		#endregion CfdStamp

		#region SatStamp
		public abstract class satStamp : IBqlField { }

		[PXDBString(500, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Sello SAT", Enabled = false)]
		public virtual string SatStamp { get; set; }
		#endregion SatStamp

		#region QrCode
		public abstract class qrCode : IBqlField { }

		[PXDBString(100, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Codigo QR", Enabled = false)]
		public virtual string QrCode { get; set; }
		#endregion QrCode

		#region TfdOriginalString
		public abstract class tfdOriginalString : IBqlField { }

		[PXDBString(1000, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Cadena Original TFD", Enabled = false)]
		public virtual string TfdOriginalString { get; set; }
		#endregion TfdOriginalString

		// Campos no persistentes
		#region OriginalString
		public abstract class originalString : IBqlField { }

		[PXString(4000, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Cadena Original", Enabled = false)]
		public virtual string OriginalString { get; set; }
		#endregion OriginalString

		#region AmountInWords
		public abstract class amountInWords : IBqlField { }

		[PXString(500, IsFixed = false, IsUnicode = true)]
		[PXUIField(DisplayName = "Monto en Letra", Enabled = false)]
		public virtual string AmountInWords { get; set; }
		#endregion AmountInWords	
	}
}

