using PX.Data;
using PX.Objects;
using System;

namespace AcumaticaMX
{
    using PX.Objects.AR;
    using PX.Objects.CR;
    using System.Text.RegularExpressions;

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

        //Todo: Agregar Customer_RowPersisting para validar campos obligatorios

        protected virtual void Customer_TaxRegistrationID_FieldVerifying(PXCache sender, PXFieldVerifyingEventArgs e, PXFieldVerifying InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Customer customer = e.Row as Customer;
            if (customer == null) return;

            var value = e.NewValue as string;

            if (this.Base.BillAddress.Current?.CountryID == "MX")
            {
                Regex regex = new Regex(@"[A-Z,Ñ,&amp;]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9]?[A-Z,0-9]?[0-9,A-Z]?");
                Match match = regex.Match(value);
                if (match.Length < 12 || match.Length > 13 || !match.Success)
                {
                    e.Cancel = true;
                    sender.RaiseExceptionHandling<Customer.taxRegistrationID>(
                        e.Row, e.NewValue, new PXSetPropertyException(Messages.TaxRegistrationIDInvalid, PXErrorLevel.RowError));
                }

                if (!string.IsNullOrEmpty(value) && value != value.ToUpper())
                    e.NewValue = value.ToUpper();
            }
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

        protected virtual void Contact_FirstName_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            UpdateContactFields(sender, e.Row as Contact);
        }

        protected virtual void Contact_MidName_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            UpdateContactFields(sender, e.Row as Contact);
        }

        protected virtual void Contact_LastName_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e, PXFieldUpdated InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            UpdateContactFields(sender, e.Row as Contact);
        }

        protected virtual void UpdateContactFields(PXCache contactCache, Contact contact)
        {
            if (contact == null) return;

            var customer = Base.CurrentCustomer.Current;
            if (customer == null) return;
            MXBAccountExtension customerExt = customer.GetExtension<MXBAccountExtension>();

            if (customerExt?.IsNaturalPerson == true)
            {
                var fullName = contact.FirstName + " " + contact.MidName + " " + contact.LastName;
                contactCache.SetValueExt<Contact.fullName>(contact, fullName);
            }
        }

        protected virtual void UpdateContactFields(Customer customer)
        {
            MXBAccountExtension customerExt = customer.GetExtension<MXBAccountExtension>();

            bool same = (customer?.IsBillContSameAsMain == true);
            bool enabled = (customerExt?.IsNaturalPerson == true);

            // Campos obligatorios: En caso de persona física: primer nombre, apellido paterno y apellido materno.
            PXUIFieldAttribute.SetRequired<Contact.fullName>(Base.DefContact.Cache, !enabled);
            PXUIFieldAttribute.SetRequired<Contact.firstName>(Base.DefContact.Cache, enabled);
            PXUIFieldAttribute.SetRequired<Contact.lastName>(Base.DefContact.Cache, enabled);

            PXUIFieldAttribute.SetVisible<Contact.fullName>(Base.DefContact.Cache, null, !enabled);
            PXUIFieldAttribute.SetVisible<Contact.salutation>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.firstName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.midName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.lastName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.firstLastName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.secondLastName>(Base.DefContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.personalID>(Base.DefContact.Cache, null, enabled);

            // Campos obligatorios: En caso de persona física: primer nombre, apellido paterno y apellido materno.
            PXUIFieldAttribute.SetRequired<Contact.fullName>(Base.BillContact.Cache, !enabled);
            PXUIFieldAttribute.SetRequired<Contact.firstName>(Base.BillContact.Cache, enabled);
            PXUIFieldAttribute.SetRequired<Contact.lastName>(Base.BillContact.Cache, enabled);

            PXUIFieldAttribute.SetVisible<Contact.fullName>(Base.BillContact.Cache, null, !enabled);
            PXUIFieldAttribute.SetVisible<Contact.salutation>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.firstName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.midName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<Contact.lastName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.firstLastName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.secondLastName>(Base.BillContact.Cache, null, enabled);
            PXUIFieldAttribute.SetVisible<MXContactExtension.personalID>(Base.BillContact.Cache, null, enabled);
        }

        #endregion Event Handlers
    }
}