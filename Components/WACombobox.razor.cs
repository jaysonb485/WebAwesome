using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace WebAwesomeBlazor.Components
{
    public partial class WACombobox : WAComponentBase
    {

        #region Parameters
        [Parameter]
        public string Value { get; set; } = default!;

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public Expression<Func<string>> ValueExpression { get; set; } = default!;

        [Parameter]
        public string[] Values { get; set; } = default!;

        [Parameter]
        public EventCallback<string[]> ValuesChanged { get; set; }
        [Parameter] public Expression<Func<string[]>> ValuesExpression { get; set; } = default!;


        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// The combobox's label. 
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// The combobox's size.
        /// </summary>
        [Parameter]
        public ComboboxSize Size { get; set; } = ComboboxSize.Medium;

        /// <summary>
        /// The combobox's hint.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }
        /// <summary>
        /// Placeholder text to show as a hint when the combobox is empty.
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }

        /// <summary>
        /// Adds a clear button (with-clear) when the combobox is not empty.
        /// </summary>
        [Parameter]
        public bool Clearable { get; set; } = false;

        /// <summary>
        /// The combobox's required attribute.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;
        /// <summary>
        /// The combobox's visual appearance.
        /// </summary>
        [Parameter]
        public ComboboxAppearance Appearance { get; set; } = ComboboxAppearance.Outlined;
        /// <summary>
        /// Disables the combobox control.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Draws a pill-style combobox with rounded edges.
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

        /// <summary>
        /// The preferred placement of the combobox's menu. Note that the actual placement may vary as needed to keep the listbox inside of the viewport.
        /// </summary>
        [Parameter]
        public ComboboxPlacement Placement { get; set; } = ComboboxPlacement.Bottom;

        /// <summary>
        /// The autocomplete behavior of the combobox.
        /// List: When the popup is triggered, it presents suggested values that complete or logically correspond to the characters typed in the combobox. The character string the user has typed will become the value of the combobox unless the user selects a value in the popup.
        /// None: The combobox is editable, and when the popup is triggered, the suggested values it contains are the same regardless of the characters typed in the combobox.
        /// </summary>
        [Parameter]
        public ComboboxAutocomplete Autocomplete { get; set; } = ComboboxAutocomplete.List;

        /// <summary>
        /// When true, allows the user to enter a value that doesn't match any of the options. Only applies to single-select comboboxes. When false, the combobox will only accept values that match an option.
        /// </summary>
        [Parameter]
        public bool AllowCustomValue { get; set; } = false;

        /// <summary>
        /// Allows more than one option to be selected.
        /// </summary>
        [Parameter]
        public bool Multiselect { get; set; } = false;

        /// <summary>
        /// The maximum number of selected options to show when Multiselect is true. After the maximum, "+n" will be shown to indicate the number of additional items that are selected. Set to 0 to remove the limit.
        /// </summary>
        [Parameter]
        public int MaxOptionsVisible { get; set; } = 3;
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
                    ComboboxSize.Small => "small",
                    ComboboxSize.Medium => "medium",
                    ComboboxSize.Large => "large",
                    ComboboxSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }

        string PlacementString
        {
            get
            {
                return Placement switch
                {
                    ComboboxPlacement.Top => "top",
                    ComboboxPlacement.Bottom => "bottom",
                    _ => "bottom"
                };
            }
        }

        string AppearanceString
        {
            get
            {
                return Appearance switch
                {
                    ComboboxAppearance.Filled => "filled",
                    ComboboxAppearance.Outlined => "outlined",
                    ComboboxAppearance.FilledOutlined => "filled-outlined",
                    _ => "outlined"
                    //Only filled and outlined are valid for inputs
                };
            }
        }

        string AutocompleteString
        {
            get
            {
                return Autocomplete switch
                {
                    ComboboxAutocomplete.List => "list",
                    ComboboxAutocomplete.None => "none",
                    _ => "list"
                };
            }
        }
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            objRef ??= DotNetObjectReference.Create(this);

            AdditionalAttributes ??= new Dictionary<string, object>();

            if (!Multiselect && ValueExpression != null)
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

            if (Multiselect && ValuesExpression != null)
            {
                try
                {
                    fieldIdentifier = FieldIdentifier.Create(ValuesExpression);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine($"Invalid ValuesExpression: {ex.Message}");
                }

            }

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;

            object? initValue;

            if (Multiselect)
                initValue = Values;
            else
                initValue = Value;

            if (initValue is not null)
            {
                await JSRuntime.InvokeVoidAsync(
                    "window.vengage.combobox.initialize",
                    Id,
                    objRef,
                    initValue
                );
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            object? newValue = Multiselect ? Values : Value;
            object? previous = Multiselect ? previousValues : previousValue;

            // For arrays, use SequenceEqual instead of Equals
            bool hasChanged = false;

            if (Multiselect)
            {
                if (newValue is string[] arrNew && previous is string[] arrPrev)
                    hasChanged = !arrNew.SequenceEqual(arrPrev);
                else
                    hasChanged = !Equals(previous, newValue);

                previousValues = (string[])newValue;
            }
            else
            {
                hasChanged = !Equals(previous, newValue);
                previousValue = (string)newValue;
            }

            if (hasChanged && newValue is not null)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.combobox.setValue", Id, newValue);
            }
        }
        #endregion

        #region Event Handlers

        private async Task OnValueChanged(ChangeEventArgs e)
        {

            if (Multiselect)
            {
                var value = e.Value != null ? e.Value!.ConvertTo<string[]>() : [];
                await ValuesChanged.InvokeAsync(value);
            }
            else
            {
                var value = e.Value != null ? e.Value!.ConvertTo<string>() : string.Empty;
                await ValueChanged.InvokeAsync(value);
            }


            try
            {
                EditContext?.NotifyFieldChanged(fieldIdentifier);
            }
            catch (ArgumentException ex)
            {
                Console.Error.WriteLine($"Notify field error: {ex.Message}");
            }

        }

        [JSInvokable]
        public async Task HandleInputClear()
        {
            if (Multiselect)
            {
                await ValuesChanged.InvokeAsync(default!);
            }
            else
            {
                await ValueChanged.InvokeAsync(string.Empty);
            }
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }



        #endregion

        #region State
        private FieldIdentifier fieldIdentifier = default!;
        private DotNetObjectReference<WACombobox> objRef = default!;
        private string previousValue = default!;
        private string[] previousValues = default!;
        #endregion

        #region Public Methods
        /// <summary>
        /// Get the value of the input field.
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> GetInputValueAsync()
        {
            var value = await JSRuntime.InvokeAsync<string>("window.vengage.combobox.getInputValue", Id);
            return value;
        }


        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public void Show() => _ = ShowAsync();

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public async Task ShowAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.combobox.show", Id);
        }


        /// <summary>
        /// Hides the dialog.
        /// </summary>
        public void Hide() => _ = HideAsync();

        /// <summary>
        /// Hides the dialog.
        /// </summary>
        public async Task HideAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.combobox.hide", Id);
        }
        #endregion

    }
}
