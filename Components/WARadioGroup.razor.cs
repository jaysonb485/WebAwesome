using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WARadioGroup<TValue> : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The current value of the radio group, submitted as a name/value pair with form data.
        /// </summary>
        [Parameter]
        public TValue Value { get; set; } = default!;

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; } = default!;
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// A custom label for assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The radio group's size. This size will be applied to all child radios and radio buttons, except when explicitly overridden.
        /// </summary>
        [Parameter]
        public RadioGroupSize Size { get; set; } = RadioGroupSize.Inherit;
        /// <summary>
        /// The radio groups's hint.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// The orientation in which to show radio items.
        /// </summary>
        [Parameter]
        public RadioGroupOrientation Orientation { get; set; } = RadioGroupOrientation.Vertical;
        /// <summary>
        /// Ensures a child radio is checked before allowing the containing form to submit.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// Disables the radio group and all child radios.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;
        #endregion

        #region Computed  Properties
        string SizeString
        {
            get
            {
                return Size switch
                {
                    RadioGroupSize.Small => "small",
                    RadioGroupSize.Medium => "medium",
                    RadioGroupSize.Large => "large",
                    RadioGroupSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        string OrientationString
        {
            get
            {
                return (Orientation == RadioGroupOrientation.Vertical) ? "vertical" : "horizontal";
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            AdditionalAttributes ??= new Dictionary<string, object>();

            fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            base.OnInitialized();
        }
        #endregion

        #region Event Handlers
        async Task OnValueChanged(ChangeEventArgs e)
        {
            var value = e.Value!.ConvertTo<TValue>();
            await ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

        #region State
        private FieldIdentifier fieldIdentifier = default!;
        #endregion

     }


}
