using Microsoft.AspNetCore.Components;

namespace WebAwesomeBlazor.Components
{
    public partial class WAMarkdown : WAComponentBase
    {
        #region Parameters
        /// <summary>
        /// The markdown text to display.
        /// </summary>
        [Parameter]
        public string? Markdown { get; set; }

        [Parameter]
        public int? TabSize { get; set; } = 4;

        #endregion


        #region Public Methods
        /// <summary>
        /// Updates the markdown content of the component. This method can be used to dynamically change the displayed markdown after the component has been rendered.
        /// </summary>
        /// <param name="Markdown">
        /// The markdown content to set.
        /// </param>
        public async Task SetMarkdownAsync(string Markdown)
        {
            this.Markdown = Markdown;
            await InvokeVoidAsync("updateContent", Id!, Markdown);
        }
        #endregion
    }


}
