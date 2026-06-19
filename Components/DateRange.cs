namespace WebAwesomeBlazor.Components
{
    public class DateRange<TValue>(TValue start, TValue end)
    {
        public TValue Start { get; set; } = start;
        public TValue End { get; set; } = end;
    }
}
