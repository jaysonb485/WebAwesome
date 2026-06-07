using Microsoft.AspNetCore.Components;
using WebAwesomeBlazor.Components;

namespace WebAwesomeBlazor.Extended
{
    public partial class InlineEditor : WAComponentBase
    {
        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public RenderFragment? EditorContent { get; set; }

        [Parameter]
        public string? HoverCssClass { get; set; } = "inline-label-hover";

        [Parameter]
        public InlineEditorType EditorType { get; set; } = InlineEditorType.Text;

        [Parameter]
        public List<string>? SelectOptions { get; set; }

        [Parameter]
        public string? Label { get; set; }


        private bool _isHovering = false;
        private bool _isFocused = false;
        private bool _isFocussing = false;
        private WAInput WAInput { get; set; } = default!;
        private WATextArea WATextArea { get; set; } = default!;
        private WASelect WASelect { get; set; } = default!;

        private string? LabelClassNames => BuildClassNames(Class, ("inline-label", true), (HoverCssClass, _isHovering), ("inline-hidden", _isFocused));
        private string? EditorClassNames => BuildClassNames(Class, ("inline-hidden", !_isFocused));

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (_isFocussing)
            {
                _isFocussing = false;
                switch (EditorType)
                {
                    case InlineEditorType.Text:
                        await WAInput.SetFocusAsync();
                        break;
                    case InlineEditorType.TextArea:
                        await WATextArea.SetFocusAsync();
                        break;
                    case InlineEditorType.Select:
                        await WASelect.SetFocusAsync();
                        break;
                }
            }
        }

        private async Task OnLabelHover()
        {
            _isHovering = true;
            StateHasChanged();
        }

        private async Task OnLabelHoverExit()
        {
            _isHovering = false;
            StateHasChanged();
        }

        private async Task OnLabelClick()
        {
            _isFocused = true;
            _isFocussing = true;
            StateHasChanged();

        }

        private async Task OnInputBlur()
        {
            _isFocused = false;
            StateHasChanged();
        }

        private async Task OnSaveInput()
        {

        }
    }

    public enum InlineEditorType
    {
        Text,
        TextArea,
        Select,
        Custom
    }
}
