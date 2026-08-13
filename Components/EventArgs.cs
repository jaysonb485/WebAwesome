using System.Text.Json.Serialization;

namespace WebAwesomeBlazor.Components
{
    public class TagRemovingEventArgs : EventArgs
    {
        public bool Cancel { get; set; } = false;
    }

    public class PaginationPageChangedEventArgs : EventArgs
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class DataGridDataRequestArgs : EventArgs
    {
        public IEnumerable<DataGridColumnSort>? Sort { get; set; }
        public string[]? Filters { get; set; }
        public string? Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        //public CancellationToken Signal { get; set; }
    }

    public class DataGridColumnSort
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;
        [JsonPropertyName("desc")]
        public bool Descending { get; set; }
    }
}
