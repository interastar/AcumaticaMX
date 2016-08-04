using System;
using PX.Data;
using PX.Objects;

namespace AcumaticaMX
{

    using PX.Objects.CR;
    using PX.Objects.AR;

    public class MXCustomerMaintExtension : PXGraphExtension<CustomerMaint>
    {
        #region Event Handlers
        protected virtual void Customer_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Customer customer = e.Row as Customer;
            if (customer == null) return;

            UpdateContactFields(customer);
        }

        protected virtual void Customer_IsBillContSameAsMain_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Customer customer = e.Row as Customer;
            if (customer == null) return;

            UpdateContactFields(customer);
        }

        protected virtual void Customer_IsNaturalPerson_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Customer customer = e.Row as Customer;
            if (customer == null) return;

            UpdateContactFields(customer);
        }

        protected virtual void UpdateContactFields(Customer customer)
        {
            bool same = (customer.IsBillContSameAsMain ?? true);

            MXBAccountExtension customerExt = customer.GetExtension<MXBAccountExtension>();
            bool enabled = ((customerExt != null) ? customerExt.IsNaturalPerson ?? false : false);

            PXTrace.WriteInformation(String.Format("enabled:{0} same:{1} enabled&&same:{2} enabled&&!same:{3}", enabled, same, (enabled && same), (enabled && !same)));
            
            PXUIFieldAttribute.SetVisible<Contact.firstName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.midName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.lastName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.secondLastName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.personalID>(Base.DefContact.Cache, null, enabled);

            PXUIFieldAttribute.SetVisible<Contact.firstName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.midName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.lastName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.secondLastName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.personalID>(Base.BillContact.Cache, null, enabled);
        }

        protected virtual void Address_Street_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Address address = e.Row as Address;

            if (address == null) return;

            MXAddressExtension addressExt = address.GetExtension<MXAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<Address.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void Address_ExtNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Address address = e.Row as Address;

            if (address == null) return;

            MXAddressExtension addressExt = address.GetExtension<MXAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<Address.addressLine1>(address, (addressExt.Street + " " + addressExt.ExtNumber).Trim());
        }

        protected virtual void Address_IntNumber_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Address address = e.Row as Address;

            if (address == null) return;

            MXAddressExtension addressExt = address.GetExtension<MXAddressExtension>();

            if (addressExt == null) return;

            sender.SetValueExt<Address.addressLine2>(address, addressExt.IntNumber);
        }
        #endregion
    }
}