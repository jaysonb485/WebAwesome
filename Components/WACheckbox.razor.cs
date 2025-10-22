using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WACheckbox : WAComponentBase
    {
        #region Parameters
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; } = default!;

        [Parameter] public Expression<Func<bool>> ValueExpression { get; set; } = default!;

        /// <summary>
        /// The checkbox's label.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The value of the checkbox, submitted as a name/value pair with form data.
        /// </summary>
        [Parameter]
        public bool Value { get; set; } = false;

        /// <summary>
        /// Disables the checkbox.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The checkbox's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// The color of the checked and indeterminate icons.
        /// </summary>
        [Parameter]
        public string? CheckIconColor { get; set; }

        /// <summary>
        /// The size of the checked and indeterminate icons relative to the checkbox represented by a decimal. 1 is full size, 0.5 is half size etc.
        /// </summary>
        [Parameter]
        public decimal? CheckIconScale { get; set; }


        /// <summary>
        /// The checkbox's size.
        /// </summary>
        [Parameter]
        public CheckboxSize Size { get; set; } = CheckboxSize.Inherit;
        #endregion

        #region Computed  Properties
        protected override string? StyleNames => BuildStyleNames(Style,
                ($"--checked-icon-color:{CheckIconColor}", !String.IsNullOrEmpty(CheckIconColor)),
                ($"--checked-icon-scale:{CheckIconScale?.ToString()}", CheckIconScale.HasValue)
        );
        string SizeString
        {
            get
            {
                return Size switch
                {
                    CheckboxSize.Small => "small",
                    CheckboxSize.Medium => "medium",
                    CheckboxSize.Large => "large",
                    CheckboxSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            AdditionalAttributes ??= new Dictionary<string, object>();
            if (ValueExpression != null)
                fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            base.OnInitialized();
        }
        #endregion


        #region State
        private FieldIdentifier fieldIdentifier = default!;
        #endregion

        #region Private Methods
        private async Task OnChange(ChangeEventArgs e)
        {
            await ValueChanged.InvokeAsync(((string?)e.Value == "on"));
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }


        #endregion

    }
}
