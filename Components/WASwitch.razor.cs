﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor.Components
{
    public partial class WASwitch : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The label for the switch.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The value of the switch.
        /// </summary>
        [Parameter]
        public bool Value { get; set; } = false;

        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; } = default!;

        /// <summary>
        /// The switch's size.
        /// </summary>
        [Parameter]
        public SwitchSize Size { get; set; } = SwitchSize.Inherit;
        [Parameter] public Expression<Func<bool>> ValueExpression { get; set; } = default!;
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// Disables the switch.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The switch's hint. If you need to display HTML, use the hint slot instead.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }
        #endregion

        #region Computed  Properties
        string SizeString
        {
            get
            {
                return Size switch
                {
                    SwitchSize.Small => "small",
                    SwitchSize.Medium => "medium",
                    SwitchSize.Large => "large",
                    SwitchSize.Inherit => "inherit",
                    _ => "inherit"
                };
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
        private async Task OnValueChanged(ChangeEventArgs e)
        {
            await ValueChanged.InvokeAsync(((string?)e.Value == "on"));
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
        #endregion

        #region State
        private FieldIdentifier fieldIdentifier = default!;
        #endregion




        #region Private Methods

        #endregion

        #region Public Methods

        #endregion


    }


}
