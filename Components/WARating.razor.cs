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
    public partial class WARating : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The current rating.
        /// </summary>
        [Parameter]
        public decimal Value { get; set; } = 0;

        [Parameter]
        public EventCallback<decimal> ValueChanged { get; set; }
        [Parameter] public Expression<Func<decimal>> ValueExpression { get; set; } = default!;
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        /// <summary>
        /// A label that describes the rating to assistive devices.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The highest rating to show.
        /// </summary>
        [Parameter]
        public int MaximumRating { get; set; } = 5;
        /// <summary>
        /// The precision at which the rating will increase and decrease. For example, to allow half-star ratings, set this attribute to 0.5.
        /// </summary>
        [Parameter]
        public decimal RatingPrecision { get; set; } = 1;

        /// <summary>
        /// Makes the rating readonly.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Disables the rating.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;
        /// <summary>
        /// The component's size.
        /// </summary>
        [Parameter]
        public RatingSize Size { get; set; } = RatingSize.Inherit;
        #endregion

        #region Computed  Properties
        string SizeString
        {
            get
            {
                return Size switch
                {
                    RatingSize.Small => "small",
                    RatingSize.Medium => "medium",
                    RatingSize.Large => "large",
                    RatingSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion

        #region Lifecycle
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("window.vengage.rating.initialize", Id, objRef);
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

                // if (ModalService is not null && IsServiceModal)
                //     ModalService.OnShow -= OnShowAsync;
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
        public void OnSelectionChanged(decimal value)
        {
            Console.WriteLine($"onchange {value}");
            ValueChanged.InvokeAsync(value);
            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        #endregion

        #region State
        private DotNetObjectReference<WARating> objRef = default!;
        private FieldIdentifier fieldIdentifier = default!;
        #endregion


    }


}
