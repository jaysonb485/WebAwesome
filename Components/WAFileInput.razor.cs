using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Text.Json;

namespace WebAwesomeBlazor.Components
{
    public partial class WAFileInput : WAComponentBase
    {
        #region Parameters
        [CascadingParameter] private EditContext EditContext { get; set; } = default!;

        /// <summary>
        /// Called when the file input's value changes.
        /// </summary>
        [Parameter]
        public EventCallback FilesChanged { get; set; }

        /// <summary>
        /// The file input's size.
        /// </summary>
        [Parameter]
        public FileInputSize Size { get; set; } = FileInputSize.Inherit;

        /// <summary>
        /// The file input's label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// The file input's hint text.
        /// </summary>
        [Parameter]
        public string? Hint { get; set; }

        /// <summary>
        /// Makes the file input disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Makes the file input a required field.
        /// </summary>
        [Parameter]
        public bool Required { get; set; } = false;

        /// <summary>
        /// A comma-separated list of acceptable file types. Must be a list of unique file type specifiers.
        /// <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/input/file#unique_file_type_specifiers"/>
        /// </summary>
        [Parameter]
        public string? Accept { get; set; }

        /// <summary>
        /// Allows more than one file to be selected.
        /// </summary>
        [Parameter]
        public bool AllowMultiple { get; set; } = false;

        /// <summary>
        /// Custom content to show in the dropzone.
        /// </summary>
        [Parameter]
        public RenderFragment? Dropzone { get; set; }

        #endregion

        #region Computed  Properties


        string SizeString
        {
            get
            {
                return Size switch
                {
                    FileInputSize.Small => "small",
                    FileInputSize.Medium => "medium",
                    FileInputSize.Large => "large",
                    FileInputSize.Inherit => "inherit",
                    _ => "inherit"
                };
            }
        }
        #endregion

        #region Private Methods

        private async Task OnFilesChanged()
        {
            if (FilesChanged.HasDelegate)
            {
                await FilesChanged.InvokeAsync();
            }
        }
        #endregion
        #region Public Methods

        public async Task SetFocusAsync()
        {
            await JSRuntime.InvokeVoidAsync("window.vengage.input.setFocus", Id);
        }

        public void SetFocus() => _ = SetFocusAsync();

        /// <summary>
        /// Get a list of files selected in the file input. Each file is represented as a JsFileInfo object, which contains metadata about the file and a method to open a read stream for the file's contents.
        /// </summary>
        /// <returns>Array of JsFileInfo</returns>
        public async Task<JsFileInfo[]> GetFilesAsync()
        {
            var files = await JSRuntime.InvokeAsync<List<Dictionary<string, JsonElement>>>("window.vengage.fileInput.getFiles", Id);
            return [.. files.Select((f, index) => new JsFileInfo(JSRuntime, Id!)
            {
                Index = index,
                Name = f["name"].ToString() ?? string.Empty,
                Type = f["type"].ToString() ?? string.Empty,
                Size = Convert.ToInt64(f["size"].ToString()),
                LastModified = Convert.ToInt64(f["lastModified"].ToString()),
            })];
        }
        #endregion

    }

    #region FileProcessing

    public class JsFileInfo(IJSRuntime jSRuntime, string ElementId)
    {
        public int Index { get; set; } = default!;
        public string Name { get; set; } = default!;
        public long Size { get; set; } = default!;
        public string Type { get; set; } = default!;
        public long LastModified { get; set; } = default!;

        private IJSRuntime _JSRuntime = jSRuntime;

        private string _elementId = ElementId;

        public async Task<Stream> OpenReadStreamAsync(int chunkSize = 64 * 1024)
        {
            var streamRef = await _JSRuntime.InvokeAsync<IJSObjectReference>(
                "window.vengage.fileInput.openReadStream",
                _elementId,
                Index,
                chunkSize
            );

            return new JsFileStream(_JSRuntime, streamRef, chunkSize);
        }
    }



    public class JsFileStream : Stream
    {
        private readonly IJSRuntime _js;
        private readonly IJSObjectReference _streamRef;
        private readonly int _chunkSize;
        private byte[] _buffer;
        private int _bufferPos;
        private bool _completed;

        public JsFileStream(IJSRuntime js, IJSObjectReference streamRef, int chunkSize)
        {
            _js = js;
            _streamRef = streamRef;
            _chunkSize = chunkSize;
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (_completed) return 0;

            if (_buffer == null || _bufferPos >= _buffer.Length)
            {
                var chunk = await _streamRef.InvokeAsync<byte[]>("read");

                if (chunk == null)
                {
                    _completed = true;
                    return 0;
                }

                _buffer = chunk;
                _bufferPos = 0;
            }

            int bytesToCopy = Math.Min(count, _buffer.Length - _bufferPos);
            Array.Copy(_buffer, _bufferPos, buffer, offset, bytesToCopy);
            _bufferPos += bytesToCopy;

            return bytesToCopy;
        }

        public override void Flush() { }
        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    }

    #endregion

}
