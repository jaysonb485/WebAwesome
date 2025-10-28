using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAwesomeBlazor.Components;

namespace WebAwesomeBlazor.Extended
{
    public partial class DataSelect<TValue> : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public TValue? Value { get; set; }


        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; } = default!;


        [Parameter]
        public IEnumerable<TValue>? SelectOptions { get; set; } = [];

        [Parameter]
        public Func<TValue, object?>? OptionKey { get; set; }

        [Parameter]
        public virtual Func<TValue, string?> OptionText { get; set; } = default!;

        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// A custom label for assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// The select's size.
        /// </summary>
        [Parameter]
        public SelectSize Size { get; set; } = SelectSize.Inherit;

        /// <summary>
        /// The input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }
        /// <summary>
        /// Placeholder text to show as a hint when the select is empty.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// Adds a clear button (with-clear) when the select is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;

        /// <summary>
        /// Ensures a child radio is checked before allowing the containing form to submit.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;
        /// <summary>
        /// The select's visual appearance.
        /// </summary>
        [Parameter]
        public SelectAppearance Appearance { get; set; } = SelectAppearance.Outlined;
        /// <summary>
        /// Disables the select control.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Draws a pill-style input with rounded edges.
        /// </summary>
        [Parameter]
        public bool Pill { get; set; } = false;

        /// <summary>
        /// The name of the icon to draw in the start slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? StartIconName { get; set; }

        /// <summary>
        /// The icon to draw in the start slot.
        /// </summary>
        [Parameter]
        public Icon? StartIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw in the end slot. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? EndIconName { get; set; }
        /// <summary>
        /// The icon to draw in the end slot.
        /// </summary>
        [Parameter]
        public Icon? EndIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw for the clear icon. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ClearIconName { get; set; }
        /// <summary>
        /// The icon to draw in the clear slot.
        /// </summary>
        [Parameter]
        public Icon? ClearIcon { get; set; }

        /// <summary>
        /// The name of the icon to draw in the when the control is expanded and collapsed. Rotates on open and close. Available names depend on the icon library being used.
        /// </summary>
        [Parameter]
        public string? ExpandIconName { get; set; }
        /// <summary>
        /// The icon to draw in the expand slot.
        /// </summary>
        [Parameter]
        public Icon? ExpandIcon { get; set; }

        /// <summary>
        /// The duration of the show animation.
        /// </summary>
        [Parameter]
        public string? ShowDuration { get; set; }

        /// <summary>
        /// The duration of the hide animation.
        /// </summary>
        [Parameter]
        public string? HideDuration { get; set; }
        #endregion

        #region Computed  Properties
        protected override string? StyleNames => BuildStyleNames(Style,
    ($"--show-duration: {ShowDuration}", !String.IsNullOrEmpty(ShowDuration)),
    ($"--hide-duration: {HideDuration}", !String.IsNullOrEmpty(HideDuration))
);

        string SizeString
        {
            get
            {
                return Size switch
                {
                    SelectSize.Small => "small",
                    SelectSize.Medium => "medium",
                    SelectSize.Large => "large",
                    SelectSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    SelectAppearance.Filled => "filled",
                    SelectAppearance.Outlined => "outlined",
                    _ => "outlined"
                    //Only filled and outlined are valid for inputs
                };
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);
            AdditionalAttributes ??= new Dictionary<string, object>();


            if (ValueExpression != null)
            {
                try
                {
                    fieldIdentifier = FieldIdentifier.Create(ValueExpression);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine($"Invalid ValueExpression: {ex.Message}");
                }

            }
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
                await JSRuntime.InvokeVoidAsync("window.vengage.select.initialize", Id, objRef, GetOptionKeyString(Value ?? default!));
        }

        
        protected override async Task OnParametersSetAsync()
        {
            if (previousValue is null || !previousValue!.Equals(Value ?? default!))
            {
                previousValue = Value ?? default!;

                // Run your JS update logic here
                await JSRuntime.InvokeVoidAsync("window.vengage.select.setValue", Id, GetOptionKeyString(Value ?? default!));
            }
        }
        #endregion

        #region Private Methods
        private string? GetOptionText(TValue? option)
        {
            if (option != null) return OptionText.Invoke(option) ?? option.ToString();

            return null;
        }

        private string? GetOptionKeyString(TValue option)
        {
            var key = OptionKey?.Invoke(option);
            return key?.ToString() ?? string.Empty;
        }


        private async void ChangeSelectedOption(ChangeEventArgs e)
        {
            var selectedKey = e.Value?.ToString();

            await SetValueFromString(selectedKey!);


        }

        private async Task SetValueFromString(string? newValue)
        {
            var selectedOption = SelectOptions!.FirstOrDefault(opt =>
                OptionKey?.Invoke(opt)?.ToString() == newValue);

            Value = selectedOption ?? default!;

            await ValueChanged.InvokeAsync(Value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
            StateHasChanged();
        }
        #endregion

        #region Event Handlers
        [JSInvokable]
        public async Task HandleInputClear()
        {
            await SetValueFromString(default!);
        }


        #endregion

        #region State
        private DotNetObjectReference<DataSelect<TValue>> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
        private TValue previousValue = default!;
        #endregion


    }


}
