using PX.Common;
using PX.Data;
using PX.Objects.AR;
using PX.Objects.IN;
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
    public class SetCfdiStatusAttribute : PXEventSubscriberAttribute, IPXFieldVerifyingSubscriber, IPXRowSelectingSubscriber, IPXRowUpdatingSubscriber, IPXRowInsertingSubscriber//, IPXRowSelectedSubscriber
    {
        public static void StatusSet(PXCache sender, ARRegister doc)
        {
            var docExt = doc.GetExtension<MXARRegisterExtension>();
            if (docExt == null) return;

            var status = CfdiStatus.Clean;

            if (docExt.CancelDate.HasValue)
            {
                status = CfdiStatus.Canceled;
            }
            else if (docExt.StampDate.HasValue)
            {
                status = CfdiStatus.Stamped;
            }
            else if (docExt.Uuid.HasValue)
            {
                status = CfdiStatus.Blocked;
            }
            else
            {
                status = CfdiStatus.Clean;
            }

            sender.SetValue<MXARRegisterExtension.stampStatus>(doc, status);
        }

        public virtual void RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            var item = e.Row as ARRegister;
            if (item != null)
            {
                StatusSet(sender, item);
            }
        }

        public virtual void RowInserting(PXCache sender, PXRowInsertingEventArgs e)
        {
            var item = e.Row as ARRegister;
            if (item != null)
            {
                StatusSet(sender, item);
            }
        }

        public virtual void RowUpdating(PXCache sender, PXRowUpdatingEventArgs e)
        {
            var item = e.Row as ARRegister;
            if (item != null)
            {
                StatusSet(sender, item);
            }
        }

        public void FieldVerifying(PXCache sender, PXFieldVerifyingEventArgs e)
        {
            e.NewValue = sender.GetValue<MXARRegisterExtension.stampStatus>(e.Row);
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

    /// <summary>
    /// Este atributo permite marcar campos "virtuales" en PXCache que son parte de otro campo principal.
    /// Efectivamente separa el campo padre en cada padre hijo y concatena los hijos para actualizar el padre en la BD.
    /// </summary>
    public class MultipartFieldAttribute : PXEventSubscriberAttribute, IPXFieldSelectingSubscriber, IPXFieldUpdatedSubscriber, IPXRowSelectingSubscriber
    {
        // Separador de campos es un "espacio sin corte" en Unicode
        // Básicamente un espacio
        private static string DefaultSeparator = "\u00A0";

        private string _TargetField;
        private List<string> _SourceFields;

        private int _Position;

        private string _Separator = DefaultSeparator;

        public string Separator { get { return _Separator; } set { _Separator = value + DefaultSeparator; } }

        public MultipartFieldAttribute(Type TargetFieldType, int FieldPosition, params Type[] SourceFieldTypes)
            : base()
        {
            _TargetField = TargetFieldType.Name;
            _Position = FieldPosition;

            if (FieldPosition > 0)
            {
                _Position = FieldPosition;
            }
            else
            {
                throw new PXArgumentException();
            }

            if (SourceFieldTypes.Length > 0)
            {
                _SourceFields = new List<string>(SourceFieldTypes.Select(t => t.Name));
            }
            else
            {
                throw new PXArgumentException();
            }
        }

        public void FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
        {
            if (e.Row != null)
            {
                var newValue = UpdateFieldInPosition((string)sender.GetValue(e.Row, _TargetField), (string)sender.GetValue(e.Row, _FieldName), _Position);

                sender.SetValueExt(e.Row, _TargetField, newValue);
            }
        }

        public void FieldSelecting(PXCache sender, PXFieldSelectingEventArgs e)
        {
            if (e.Row == null) return;

            var value = ReadFieldValue((string)sender.GetValue(e.Row, _TargetField), _Position);

            e.ReturnValue = value;
        }

        public void RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            if (e.Row == null) return;

            var value = ReadFieldValue((string)sender.GetValue(e.Row, _TargetField), _Position);

            sender.SetValue(e.Row, _FieldName, value);
        }

        protected virtual string ReadFieldValue(string parentValue, int position)
        {
            string value = null;

            if (!string.IsNullOrEmpty(parentValue))
            {
                // Buscamos que exista la parte en el bloque dividido por el separador (1 es inicio de cadena)
                var start = FindNPosition(parentValue, Separator, _Position);

                // Si es positivo encontramos un valor
                if (start > -1)
                {
                    // asignamos el valor de donde se encontró el primer bloque hasta el segundo separador
                    value = CutToSeparator(parentValue.Substring(start), Separator);
                }
            }

            return value;
        }

        protected virtual string UpdateFieldInPosition(string target, string newValue, int position)
        {
            string value = null;

            target = target ?? string.Empty;

            if (position >= 0)
            {
                var parts = target.Split(new string[1] { Separator }, StringSplitOptions.None);

                // Agregamos las partes que hagan falta (si no hacen falta no se agrega ni una
                if (position > parts.Length)
                {
                    string[] biggerParts = new string[position];
                    parts.CopyTo(biggerParts, 0);
                    parts = biggerParts;
                }

                // Actualizamos el valor en la posición que corresponde
                parts[position - 1] = newValue;

                // Volvemos a concatenar las partes para formar la cadena completa
                value = string.Join(Separator, parts);

                // Si termina con separador, lo quitamos (puede ser varias veces)
                while ((value.EndsWith(Separator) || value == Separator))
                {
                    value = value.Substring(0, value.LastIndexOf(Separator));
                }
            }

            // Regresamos el valor
            return value;
        }

        private static string CutToSeparator(string searched, string separator)
        {
            int startIndex = -1;

            startIndex = searched.IndexOf(separator);

            if (startIndex < 0)
                return searched;

            var value = searched.Substring(0, startIndex).Trim();

            // Si es blanco reresamos null para disparar validaciones
            return string.IsNullOrEmpty(value) ? null : value;
        }

        private static int FindNPosition(string searched, string separator, int position)
        {
            int startIndex = 0;
            int hitCount = 1;

            if (position < 1) return 0;

            // Search for n occurrences of the target.
            while (hitCount < position)
            {
                startIndex = searched.IndexOf(
                    separator, startIndex);

                // Exit the loop if the target is not found.
                if (startIndex < 0)
                {
                    return position == 1 ? 0 : -1;
                }

                startIndex += separator.Length;

                if (startIndex >= searched.Length)
                    return -1;

                hitCount++;
            }

            return startIndex;
        }
    }

    public class StampableStatusAttribute : PXEventSubscriberAttribute, IPXFieldUpdatedSubscriber, IPXRowSelectingSubscriber
    {
        public override void CacheAttached(PXCache sender)
        {
            base.CacheAttached(sender);

            sender.Graph.FieldUpdated.AddHandler<MXARRegisterExtension.uuid>((localSender, e) =>
            {
                var doc = e.Row as ARRegister;
                if (doc != null)
                {
                    StatusSet(localSender, doc);
                }
            });
        }

        protected virtual void StatusSet(PXCache sender, ARRegister doc)
        {
            // Solo seguimos si tenemos el registro
            var cfdi = doc.GetExtension<MXARRegisterExtension>();

            if (cfdi == null) return;
            var check = false;

            // Si el documento está timbrado o cancelado limpiamos la bandera
            if (cfdi.StampStatus == CfdiStatus.Stamped || cfdi.StampStatus == CfdiStatus.Canceled)
            {
                check = false;
            }
            // Si tiene valor en ceros
            else if (cfdi.Uuid.HasValue && cfdi.Uuid == Guid.Empty)
            {
                check = true;
            }

            sender.SetValue<MXARRegisterExtension.notStampable>(doc, check);
        }

        public virtual void RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            var doc = e.Row as ARRegister;
            if (doc != null)
            {
                StatusSet(sender, doc);
            }
        }

        public void FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
        {
            var item = (ARRegister)e.Row;

            if (item != null)
            {
                var ext = item.GetExtension<MXARRegisterExtension>();
                if (ext == null) return;

                if (((bool?)e.OldValue != true) && ext.NotStampable == true && ext.Uuid == null)
                {
                    //ext.Uuid = Guid.Empty;
                    sender.SetValueExt<MXARRegisterExtension.uuid>(item, Guid.Empty);
                    return;
                }

                if (((bool?)e.OldValue == true) && ext.NotStampable != true && ext.Uuid == Guid.Empty)
                {
                    //ext.Uuid = null;
                    sender.SetValueExt<MXARRegisterExtension.uuid>(item, null);
                    return;
                }
            }
        }
    }

    public class ValidateFieldsAttribute : PXEventSubscriberAttribute, IPXRowPersistingSubscriber
    {
        private List<string> _SourceFields;
        private string _ErrorMsg;

        public ValidateFieldsAttribute(string ErrorMsg, params Type[] SourceFieldTypes)
            : base()
        {
            _ErrorMsg = ErrorMsg;

            if (SourceFieldTypes.Length > 0)
            {
                _SourceFields = new List<string>(SourceFieldTypes.Select(t => t.Name));
            }
            else
            {
                throw new PXArgumentException();
            }
        }

        public virtual void RowPersisting(PXCache sender, PXRowPersistingEventArgs e)
        {
            if (e.Row == null) return;

            var value = sender.GetValue(e.Row, this._FieldName);

            if (value != null ||
                ((value?.GetType() == typeof(string)) && (!string.IsNullOrEmpty((string)value))))
            {
                foreach (var field in _SourceFields)
                {
                    var fieldValue = sender.GetValue(e.Row, field);

                    // Si es nulo o
                    //  es una cadena vacía...
                    if (fieldValue == null)
                    {
                        // Lanza la excepción
                        sender.RaiseExceptionHandling(field,
                                e.Row, null, new PXSetPropertyException(_ErrorMsg, PXErrorLevel.RowError));
                    }
                    else if ((fieldValue.GetType() == typeof(string)))
                    {
                        if (string.IsNullOrEmpty((string)fieldValue))
                        {
                            sender.RaiseExceptionHandling(field,
                               e.Row, null, new PXSetPropertyException(_ErrorMsg, PXErrorLevel.RowError));
                        }
                    }
                }
            }
        }
    }

    public class RequestNumberAttribute : PXEventSubscriberAttribute, IPXRowPersistingSubscriber, IPXRowSelectingSubscriber, IPXRowPersistedSubscriber
    {
        private List<string> _SourceFields;
        private string _ErrorMsg;

        public RequestNumberAttribute(string ErrorMsg, params Type[] SourceFieldTypes)
            : base()
        {
            _ErrorMsg = ErrorMsg;

            if (SourceFieldTypes.Length > 0)
            {
                _SourceFields = new List<string>(SourceFieldTypes.Select(t => t.Name));
            }
            else
            {
                throw new PXArgumentException();
            }
        }

        public virtual void RowPersisting(PXCache sender, PXRowPersistingEventArgs e)
        {
            if (e.Row == null) return;

            var value = sender.GetValue(e.Row, this._FieldName);

            if (value != null ||
                ((value?.GetType() == typeof(string)) && (!string.IsNullOrEmpty((string)value))))
            {
                foreach (var field in _SourceFields)
                {
                    var fieldValue = sender.GetValue(e.Row, field);

                    // Si es nulo o
                    //  es una cadena vacía...
                    if (fieldValue == null || string.IsNullOrEmpty((string)fieldValue))
                    {
                        sender.RaiseExceptionHandling(field,
                                e.Row, null, new PXSetPropertyException(_ErrorMsg, PXErrorLevel.RowError));
                    }
                    else
                    {
                        var rowValue = fieldValue.ToString();
                        var parsedValue = rowValue.Substring(0, 2) + "  " + rowValue.Substring(2, 2) + "  " + 
                            rowValue.Substring(4, 4).Trim().PadLeft(4,'0') + "  " + rowValue.Substring(8, 7);
                        sender.SetValue(e.Row, this._FieldName, parsedValue);
                    }
                }
            }
        }

        public virtual void RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            if (e.Row == null) return;

            var value = sender.GetValue(e.Row, this._FieldName);

            if (value != null ||
                ((value?.GetType() == typeof(string)) && (!string.IsNullOrEmpty((string)value))))
            {
                foreach (var field in _SourceFields)
                {
                    var fieldValue = sender.GetValue(e.Row, field);

                    if (fieldValue != null || !string.IsNullOrEmpty(fieldValue.ToString()))
                    {
                        var joinValue = String.Join("", fieldValue.ToString().Split(' '));
                        sender.SetValue(e.Row, this._FieldName, joinValue);
                    }
                }
            }
        }

        public virtual void RowPersisted(PXCache sender, PXRowPersistedEventArgs e)
        {
            if (e.Row == null) return;

            var value = sender.GetValue(e.Row, this._FieldName);

            if (value != null ||
                ((value?.GetType() == typeof(string)) && (!string.IsNullOrEmpty((string)value))))
            {
                foreach (var field in _SourceFields)
                {
                    var fieldValue = sender.GetValue(e.Row, field);

                    if (fieldValue != null || !string.IsNullOrEmpty(fieldValue.ToString()))
                    {
                        var joinValue = String.Join("", fieldValue.ToString().Split(' '));
                        sender.SetValue(e.Row, this._FieldName, joinValue);
                    }
                }
            }
        }
    }

    public class CfdiStatusAttribute : PXEventSubscriberAttribute, IPXFieldUpdatedSubscriber, IPXRowSelectingSubscriber
    {
        private string _TargetField;
        private string _SourceField;
        private string _CancelField;

        public CfdiStatusAttribute(Type TargetFieldType, Type SourceField, Type CancelField) : base()
        {
            _TargetField = TargetFieldType.Name;
            _SourceField = SourceField.Name;
            _CancelField = CancelField.Name;
        }

        public virtual void RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            if (e.Row == null) return;
            var value = sender.GetValue(e.Row, this._SourceField);
            if(value != null)
            {
                value = sender.GetValue(e.Row, this._CancelField);
                if (value != null)
                {
                    sender.SetValue(e.Row, this._TargetField, CfdiStatus.Canceled);
                }
                else
                {
                    sender.SetValue(e.Row, this._TargetField, CfdiStatus.Stamped);
                }
            }
            else
            {
                sender.SetValue(e.Row, this._TargetField, CfdiStatus.Clean);
            }
        }

        public virtual void FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
        {
            if (e.Row == null) return;
            var value = sender.GetValue(e.Row, this._SourceField);
            if (value != null)
            {
                value = sender.GetValue(e.Row, this._CancelField);
                if (value != null)
                {
                    sender.SetValue(e.Row, this._TargetField, CfdiStatus.Canceled);
                }
                else
                {
                    sender.SetValue(e.Row, this._TargetField, CfdiStatus.Stamped);
                }
            }
            else
            {
                sender.SetValue(e.Row, this._TargetField, CfdiStatus.Clean);
            }
        }
    }

}