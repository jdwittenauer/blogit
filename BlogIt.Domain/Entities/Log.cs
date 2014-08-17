namespace BlogIt.Domain.Entities
{
    /// <summary>
    /// Entity class that represents a log entry.
    /// </summary>
    public class Log : Entity
    {
        public string User { get; set; }
        public string EventType { get; set; }
        public string EventDetail { get; set; }
        public string Description { get; set; }
        public double? Metric { get; set; }
        public string MetricDescription { get; set; }
        public string MetricUnit { get; set; }

        public Log() { }
    }
}
