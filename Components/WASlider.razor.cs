using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome.Components
{
    public partial class WASlider : WAComponentBase
    {
        #region Parameters
        [Parameter]
        public int? Value { get; set; }
        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }
        [Parameter] public Expression<Func<int>> ValueExpression { get; set; } = default!;
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;
        /// <summary>
        /// The slider's label. If you need to provide HTML in the label, use the label slot instead.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The slider hint. If you need to display HTML, use the hint slot instead.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// The minimum acceptable value of the slider.
        /// </summary>
        [Parameter]
        public int? MinimumValue { get; set; } = 0;

        /// <summary>
        /// The maximum acceptable value of the slider.
        /// </summary>
        [Parameter]
        public int? MaximumValue { get; set; } = 100;

        /// <summary>
        /// Converts the slider to a range slider with two thumbs.
        /// </summary>
        [Parameter]
        public bool IsRange { get; set; } = false;

        /// <summary>
        /// The default value of the form control. Primarily used for resetting the form control.
        /// </summary>
        [Parameter]
        public int? DefaultValue { get; set; }

        /// <summary>
        /// The interval at which the slider will increase and decrease.
        /// </summary>
        [Parameter]
        public int? Step { get; set; } = 1;


        /// <summary>
        /// Disables the slider.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Makes the slider a read-only field.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// The starting value from which to draw the slider's fill, which is based on its current value.
        /// </summary>
        [Parameter]
        public int? IndicatorOffset { get; set; }

        [Parameter]
        public SliderSize Size { get; set; } = SliderSize.Medium;
        /// <summary>
        /// Shows the tooltip. Defaults to true.
        /// </summary>
        [Parameter]
        public bool ShowTooltip { get; set; } = true;

        /// <summary>
        /// The preferred placement of the slider tooltip. Acceptable values are Placement.Top and Placement.Bottom
        /// </summary>
        [Parameter]
        public SliderTooltipPlacement TooltipPlacement { get; set; } = SliderTooltipPlacement.Top;
        /// <summary>
        /// The orientation of the slider. Defaults to horizontal.
        /// </summary>
        [Parameter]
        public SliderOrientation Orientation { get; set; } = SliderOrientation.Horizontal;


        //// <summary>
        /// Draws markers at each step along the slider.
        /// </summary>
        [Parameter]
        public bool ShowMarkers { get; set; } = false;

        #endregion

        #region Computed  Properties

        string SizeString
        {
            get
            {
                return Size switch
                {
                    SliderSize.Small => "small",
                    SliderSize.Medium => "medium",
                    SliderSize.Large => "large",
                    SliderSize.Inherit => "inherit",
                    _ => "medium"
                };
            }
        }
        string TooltipPlacementString
        {
            get
            {
                return TooltipPlacement switch
                {
                    SliderTooltipPlacement.Top => "top",
                    SliderTooltipPlacement.Bottom => "bottom",
                    _ => "top"
                };
            }
        }
        string OrientationString
        {
            get
            {
                return Orientation switch
                {
                    SliderOrientation.Horizontal => "horizontal",
                    SliderOrientation.Vertical => "vertical",
                    _ => "horizontal"
                };
            }
        }

        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.slider.initialize", Id, objRef);
            }
        }

        protected override async ValueTask DisposeAsyncCore(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // if (IsRenderComplete)
                    // await JSRuntime.InvokeVoidAsync("window.blazorBootstrap.modal.dispose", Id);
                }
                catch (JSDisconnectedException)
                {
                    // do nothing
                }

                objRef?.Dispose();


            }

            await base.DisposeAsyncCore(disposing);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);


            AdditionalAttributes ??= new Dictionary<string, object>();

            fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            await base.OnInitializedAsync();
        }
        #endregion

        #region Event Handlers
        [JSInvokable("OnValueChanged")]
        public void OnSelectionChanged(int value)
        {
            Console.WriteLine($"onchange {value}");
            ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        #endregion

        #region State
        private DotNetObjectReference<WASlider> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
        #endregion




        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

    }


}
