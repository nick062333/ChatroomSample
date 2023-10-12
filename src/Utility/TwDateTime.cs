namespace Utility
{
    public readonly struct TwDateTime
    {
        public static DateTime Now { get { return DateTime.UtcNow.AddHours(8); } }
    }
}