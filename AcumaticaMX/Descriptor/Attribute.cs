using PX.Data;
using PX.Objects.AR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcumaticaMX
{
    public class CfdiStatus
    {
        public static readonly string[] Values = { Clean, Stamped, Canceled, Blocked };
        public static readonly string[] Labels = { Messages.CleanCfdi, Messages.StampedCfdi, Messages.CanceledCfdi, Messages.BlockedCfdi };

        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute()
                : base(Values, Labels)
            {
            }
        }

        public const string Clean = "N";
        public const string Stamped = "S";
        public const string Canceled = "C";
        public const string Blocked = "B";

        public class clean : Constant<string>
        {
            public clean() : base(Clean)
            {
                ;
            }
        }

        public class stamped : Constant<string>
        {
            public stamped() : base(Stamped)
            {
                ;
            }
        }

        public class canceled : Constant<string>
        {
            public canceled() : base(Canceled)
            {
                ;
            }
        }

        public class blocked : Constant<string>
        {
            public blocked() : base(Blocked)
            {
                ;
            }
        }
    }

    /// <summary>
    /// This attribute is intended for the status syncronization in the MXARRegisterExtension<br/>
    /// Namely, it sets a corresponeded string to the Status field, depending <br/>
    /// upon it has been signed, canceled or blocked<br/>
    /// [SetStatus()]
    /// </summary>
    public class SetCfdiStatusAttribute : PXEventSubscriberAttribute, IPXRowUpdatingSubscriber, IPXRowInsertingSubscriber
    {
        public override void CacheAttached(PXCache sender)
        {
            base.CacheAttached(sender);

            sender.Graph.FieldUpdating.AddHandler<MXARRegisterExtension.cancelDate>((cache, e) =>
            {
                var item = e.Row as MXARRegisterExtension;
                if (item != null)
                {
                    StatusSet(cache, item);
                }
            });

            sender.Graph.FieldUpdating.AddHandler<MXARRegisterExtension.uuid>((cache, e) =>
            {
                var item = e.Row as MXARRegisterExtension;
                if (item != null)
                {
                    StatusSet(cache, item);
                }
            });

            sender.Graph.FieldUpdating.AddHandler<MXARRegisterExtension.stampDate>((cache, e) =>
            {
                var item = e.Row as MXARRegisterExtension;
                if (item != null)
                {
                    StatusSet(cache, item);
                }
            });

            //sender.Graph.FieldVerifying.AddHandler<MXARRegisterExtension.stampStatus>((cache, e) => { e.NewValue = cache.GetValue<MXARRegisterExtension.stampStatus>(e.Row); });
            //sender.Graph.RowSelecting.AddHandler<ARRegister>(RowSelecting);
            //sender.Graph.RowInserting.AddHandler<ARRegister>(RowInserting);
            //sender.Graph.RowUpdating.AddHandler<ARRegister>(RowUpdating);

            sender.Graph.FieldVerifying.AddHandler<MXARRegisterExtension.stampStatus>((cache, e) => { e.NewValue = cache.GetValue<MXARRegisterExtension.stampStatus>(e.Row); });
            //sender.Graph.RowSelecting.AddHandler<ARInvoice>(RowSelecting);
            sender.Graph.RowInserting.AddHandler<ARInvoice>(RowInserting);
            sender.Graph.RowUpdating.AddHandler<ARInvoice>(RowUpdating);
            sender.Graph.RowSelected.AddHandler<ARInvoice>(RowSelected);
        }

        protected virtual void StatusSet(PXCache cache, MXARRegisterExtension cfdi)
        {
            if (cfdi.CancelDate.HasValue)
            {
                cfdi.StampStatus = CfdiStatus.Canceled;
            }
            else if (cfdi.StampDate.HasValue)
            {
                cfdi.StampStatus = CfdiStatus.Stamped;
            }
            else if (cfdi.Uuid.HasValue)
            {
                cfdi.StampStatus = CfdiStatus.Blocked;
            }
            else
            {
                cfdi.StampStatus = CfdiStatus.Clean;
            }
        }

        public virtual void RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            var item = (ARRegister)e.Row;
            if (item != null)
            {
                var ext = item.GetExtension<MXARRegisterExtension>();
                StatusSet(sender, ext);
            }
        }

        public virtual void RowInserting(PXCache sender, PXRowInsertingEventArgs e)
        {
            var item = (ARRegister)e.Row;
            if (item != null)
            {
                var ext = item.GetExtension<MXARRegisterExtension>();
                StatusSet(sender, ext);
            }
        }

        public virtual void RowUpdating(PXCache sender, PXRowUpdatingEventArgs e)
        {
            var item = (ARRegister)e.NewRow;
            if (item != null)
            {
                var ext = item.GetExtension<MXARRegisterExtension>();
                StatusSet(sender, ext);
            }
        }

        public virtual void RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {
            var item = (ARRegister)e.Row;
            if (item != null)
            {
                var ext = item.GetExtension<MXARRegisterExtension>();
                StatusSet(sender, ext);
            }
        }
    }

    public interface IMXAddressExtension
    {
        string Street { get; set; }
        string ExtNumber { get; set; }
        string IntNumber { get; set; }
        string Municipality { get; set; }
        string Neighborhood { get; set; }
        string Reference { get; set; }
    }

    public class MXAddressExtensionTools
    {
        private static bool Copy(IMXAddressExtension target, IMXAddressExtension source)
        {
            target.Street = source.Street;
            target.ExtNumber = source.ExtNumber;
            target.IntNumber = source.IntNumber;
            target.Municipality = source.Municipality;
            target.Neighborhood = source.Neighborhood;
            target.Reference = source.Reference;

            return (target.Street != null ||
                target.ExtNumber != null ||
                target.IntNumber != null ||
                target.Municipality != null ||
                target.Neighborhood != null ||
                target.Reference != null
                );
        }

        private static bool Copy(PXCache cache, object target, IMXAddressExtension source)
        {
            cache.SetValueExt(target, "Street", source.Street);
            cache.SetValueExt(target, "ExtNumber", source.ExtNumber);
            cache.SetValueExt(target, "IntNumber", source.IntNumber);
            cache.SetValueExt(target, "Municipality", source.Municipality);
            cache.SetValueExt(target, "Neighborhood", source.Neighborhood);
            cache.SetValueExt(target, "Reference", source.Reference);

            return (source.Street != null ||
                source.ExtNumber != null ||
                source.IntNumber != null ||
                source.Municipality != null ||
                source.Neighborhood != null ||
                source.Reference != null
                );
        }

        public static object CopyExtendedFields<TTargetAddress, TSourceAddress, TSourceAddressField, TTargetAddressExtension, TSourceAddressExtension>(PXCache sender, TTargetAddress address, int? baseAddressID)
                where TTargetAddress : class, IBqlTable, new()
                where TSourceAddress : class, IBqlTable, new()
                where TSourceAddressField : IBqlField
                where TTargetAddressExtension : PXCacheExtension, IMXAddressExtension, new()
                where TSourceAddressExtension : PXCacheExtension, IMXAddressExtension, new()
        {
            var addressCache = sender.Graph.Caches[address.GetType()];

            if (baseAddressID == null) return address;

            var targetAddressExt = address.GetExtension<TTargetAddressExtension>();
            if (targetAddressExt == null) return address;

            TSourceAddress sourceAddress = PXSelect<TSourceAddress,
                Where<TSourceAddressField, Equal<Required<TSourceAddressField>>>>.Select(sender.Graph, baseAddressID);

            if (sourceAddress == null) return address;
            var sourceAddressExt = sourceAddress.GetExtension<TSourceAddressExtension>();
            if (sourceAddressExt == null) return address;

            if (Copy(targetAddressExt, sourceAddressExt))
            {
                if (addressCache.GetStatus(address) == PXEntryStatus.Notchanged)
                {
                    addressCache.SetStatus(address, PXEntryStatus.Updated);
                }
            }

            return address;
        }
    }

    /// <summary>
    /// This attribute is intended to update selected fields with concatenation of other fields<br/>
    /// </summary>
    public class CompositeFieldAttribute : PXEventSubscriberAttribute, IPXFieldUpdatedSubscriber, IPXRowUpdatingSubscriber, IPXRowInsertingSubscriber
    {
        private string _TargetField;
        private List<string> _SourceFields;

        public CompositeFieldAttribute(Type TargetFieldType, params Type[] SourceFieldTypes)
            : base()
        {
            _TargetField = TargetFieldType.Name;

            if (SourceFieldTypes.Length > 0)
            {
                _SourceFields = new List<string>(SourceFieldTypes.Select(t => t.Name));
            }
            else
            {
                throw new PXArgumentException();
            }
        }

        protected virtual void UpdateTargetField(PXCache sender, object row)
        {
            var value = string.Join(" ", _SourceFields.Select(
                fieldName =>
                sender.GetValue(row, fieldName)?.ToString())).Trim();

            sender.SetValue(row, _TargetField, value);
        }

        public virtual void RowInserting(PXCache sender, PXRowInsertingEventArgs e)
        {
            if (e.Row != null)
            {
                UpdateTargetField(sender, e.Row);
            }
        }

        public virtual void RowUpdating(PXCache sender, PXRowUpdatingEventArgs e)
        {
            if (e.Row != null)
            {
                UpdateTargetField(sender, e.Row);
            }
        }

        public void FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
        {
            if (e.Row != null)
            {
                UpdateTargetField(sender, e.Row);
            }
        }
    }
}