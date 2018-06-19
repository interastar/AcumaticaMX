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
        [PXMergeAttributes(Method = MergeMethod.Merge)]
        [PXDefault(Common.PayForm.Partial)]
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
        protected void Customer_PaymentForm_CacheAttached(PXCache sender) { }

        #region Event Handlers

        protected virtual void Customer_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            Customer customer = e.Row as Customer;
            if (customer == null) return;

            UpdateContactFields(customer);
        }

        protected virtual void Customer_RowPersisting(PXCache sender, PXRowPersistingEventArgs e, PXRowPersisting InvokeBaseHandler)
        {
            if (InvokeBaseHandler != null)
                InvokeBaseHandler(sender, e);

            if (e.Operation == PXDBOperation.Update || e.Operation == PXDBOperation.Insert)
            {
                Customer customer = e.Row as Customer;
                if (customer == null) return;

                MXBAccountExtension customerExt = customer.GetExtension<MXBAccountExtension>();

                if (string.IsNullOrEmpty(customer?.TaxRegistrationID))
                {
                    e.Cancel = true;

                    sender.RaiseExceptionHandling<Customer.taxRegistrationID>(
                        customer, customer.TaxRegistrationID, new PXSetPropertyException(Messages.TaxRegistrationIDRequired, PXErrorLevel.RowError));
                }

                bool sameAddress = (customer?.IsBillSameAsMain == true);
                bool sameContact = (customer?.IsBillContSameAsMain == true);
                bool natural = (customerExt?.IsNaturalPerson == true);
                PXCache cache;

                // Validación de contactos
                Contact contact;

                if (sameContact)
                {
                    contact = this.Base.DefContact.Current ?? this.Base.DefContact.Select();
                    cache = this.Base.DefContact.Cache;
                }
                else
                {
                    contact = this.Base.BillContact.Current ?? this.Base.BillContact.Select();
                    cache = this.Base.BillContact.Cache;
                }

                if (natural)
                {
                    // Para personas físicas, los nombres son obligatorios

                    var contactExt = contact?.GetExtension<MXContactExtension>();

                    if (string.IsNullOrEmpty(contact?.FirstName))
                    {
                        e.Cancel = true;

                        cache.RaiseExceptionHandling<Contact.firstName>(
                            contact, contact?.FirstName, new PXSetPropertyException(Messages.NaturalContactInfoRequired, PXErrorLevel.RowError));
                    }

                    if (string.IsNullOrEmpty(contactExt?.FirstLastName))
                    {
                        e.Cancel = true;

                        cache.RaiseExceptionHandling<MXContactExtension.firstLastName>(
                            contact, contactExt?.FirstLastName, new PXSetPropertyException(Messages.NaturalContactInfoRequired, PXErrorLevel.RowError));
                    }

                    if (string.IsNullOrEmpty(contactExt?.SecondLastName))
                    {
                        e.Cancel = true;

                        cache.RaiseExceptionHandling<MXContactExtension.secondLastName>(
                            contact, contactExt?.SecondLastName, new PXSetPropertyException(Messages.NaturalContactInfoRequired, PXErrorLevel.RowError));
                    }
                }
                else
                {
                    // Para personas morales, el nombre es obligatorio

                    if (string.IsNullOrEmpty(contact?.FullName))
                    {
                        e.Cancel = true;

                        cache.RaiseExceptionHandling<Contact.fullName>(
                            contact, contact?.FullName, new PXSetPropertyException(Messages.LegalContactInfoRequired, PXErrorLevel.RowError));
                    }
                }

                // Validación de dirección
                Address address;

                if (sameAddress)
                {
                    address = this.Base.DefAddress.Current ?? this.Base.DefAddress.Select();
                    cache = this.Base.DefAddress.Cache;
                }
                else
                {
                    address = this.Base.BillAddress.Current ?? this.Base.BillAddress.Select();
                    cache = this.Base.BillContact.Cache;
                }

                #region address
                //if (string.IsNullOrEmpty(address?.City))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<Address.city>(
                //        address, address?.City, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}

                //if (string.IsNullOrEmpty(address?.State))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<Address.state>(
                //        address, address?.State, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}

                //if (string.IsNullOrEmpty(address?.CountryID))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<Address.countryID>(
                //        address, address?.CountryID, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}

                //if (string.IsNullOrEmpty(address?.PostalCode))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<Address.postalCode>(
                //        address, address?.PostalCode, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}

                //var addressExt = address?.GetExtension<MXAddressExtension>();

                //if (string.IsNullOrEmpty(addressExt?.Street))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<MXAddressExtension.street>(
                //        address, addressExt?.Street, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}

                //if (string.IsNullOrEmpty(addressExt?.ExtNumber))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<MXAddressExtension.extNumber>(
                //        address, addressExt?.ExtNumber, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}

                //if (string.IsNullOrEmpty(addressExt?.Neighborhood))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<MXAddressExtension.neighborhood>(
                //        address, addressExt?.Neighborhood, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}

                //if (string.IsNullOrEmpty(addressExt?.Municipality))
                //{
                //    e.Cancel = true;

                //    cache.RaiseExceptionHandling<MXAddressExtension.municipality>(
                //        address, addressExt?.Municipality, new PXSetPropertyException(Messages.AddressInfoRequired, PXErrorLevel.RowError));
                //}
                #endregion address
            }
        }

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
            bool natural = (customerExt?.IsNaturalPerson == true);

            // Campos obligatorios: En caso de persona física: primer nombre, apellido paterno y apellido materno.
            PXUIFieldAttribute.SetRequired<Contact.fullName>(Base.DefContact.Cache, !natural);
            PXUIFieldAttribute.SetRequired<Contact.firstName>(Base.DefContact.Cache, natural);
            PXUIFieldAttribute.SetRequired<Contact.lastName>(Base.DefContact.Cache, natural);

            PXUIFieldAttribute.SetVisible<Contact.fullName>(Base.DefContact.Cache, null, !natural);
            PXUIFieldAttribute.SetVisible<Contact.lastName>(Base.DefContact.Cache, null, !natural);
            PXUIFieldAttribute.SetVisible<MXContactExtension.firstLastName>(Base.DefContact.Cache, null, natural);
            PXUIFieldAttribute.SetVisible<MXContactExtension.secondLastName>(Base.DefContact.Cache, null, natural);
            PXUIFieldAttribute.SetVisible<MXContactExtension.personalID>(Base.DefContact.Cache, null, natural);

            // Campos obligatorios: En caso de persona física: primer nombre, apellido paterno y apellido materno.
            PXUIFieldAttribute.SetRequired<Contact.fullName>(Base.BillContact.Cache, !natural);
            PXUIFieldAttribute.SetRequired<Contact.firstName>(Base.BillContact.Cache, natural);
            PXUIFieldAttribute.SetRequired<Contact.lastName>(Base.BillContact.Cache, natural);

            PXUIFieldAttribute.SetVisible<Contact.fullName>(Base.BillContact.Cache, null, !natural);
            PXUIFieldAttribute.SetVisible<Contact.lastName>(Base.BillContact.Cache, null, !natural);
            PXUIFieldAttribute.SetVisible<MXContactExtension.firstLastName>(Base.BillContact.Cache, null, natural);
            PXUIFieldAttribute.SetVisible<MXContactExtension.secondLastName>(Base.BillContact.Cache, null, natural);
            PXUIFieldAttribute.SetVisible<MXContactExtension.personalID>(Base.BillContact.Cache, null, natural);
        }

        #endregion Event Handlers
    }
}