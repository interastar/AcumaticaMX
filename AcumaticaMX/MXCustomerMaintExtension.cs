using PX.Data;
using PX.Objects;
using System;

namespace AcumaticaMX
{
    using PX.Objects.AR;
    using PX.Objects.CR;

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
            MXBAccountExtension customerExt = customer.GetExtension<MXBAccountExtension>();

            bool same = (customer?.IsBillContSameAsMain ?? true);
            bool enabled = ((customerExt != null) ? customerExt?.IsNaturalPerson ?? false : false);

            //PXTrace.WriteInformation(String.Format("enabled:{0} same:{1} enabled&&same:{2} enabled&&!same:{3}", enabled, same, (enabled && same), (enabled && !same)));

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

        #endregion Event Handlers
    }
}