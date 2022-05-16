
namespace OnlineRocketShop.Modules
{
    public class PagePerformanceData
    {
        public string PageUrl { get; set; }
        public string PageTitle { get; set; }
        public double ReadyMeasure { get; set; }
        public double JSHeapMemoryUsed { get; set; }
        public double PageLoadTime => PagePerformanceTiming.Duration;
        public double DOMInteractive => PagePerformanceTiming.DomInteractive;
        public double SSLNegotiationTime => PagePerformanceTiming.ResponseStart - PagePerformanceTiming.SecureConnectionStart;
        public double ContentDownloadTime => PagePerformanceTiming.ResponseEnd - PagePerformanceTiming.ResponseStart;
        public double TimeToFirstByte => PagePerformanceTiming.ResponseStart - PagePerformanceTiming.ConnectStart;
        public double DOMComplete => PagePerformanceTiming.DomComplete;
        public double DOMContentLoadedTime => PagePerformanceTiming.DomContentLoadedEventEnd - PagePerformanceTiming.ConnectStart;
        public PagePerformanceTiming PagePerformanceTiming { get; set; }
    }
}
