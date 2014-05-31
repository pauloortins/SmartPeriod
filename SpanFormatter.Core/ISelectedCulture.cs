namespace SpanFormatter.Core
{
    public interface ISelectedCulture
    {
        DatePiece Year { get; set; }
        DatePiece Month { get; set; }
        DatePiece Day { get; set; }
        DatePiece Hour { get; set; }
        DatePiece Minute { get; set; }
        DatePiece Second { get; set; }
    }
}