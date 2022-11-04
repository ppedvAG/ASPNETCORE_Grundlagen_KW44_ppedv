using System.Globalization;
using System.Security.Cryptography;

namespace SignalRChartRazorPageSample.Services
{

    public record Point(string Label, int Value);

    public class Buffer<T> : Queue<T>
    {
        public int? MaxCapacity { get; }

        public Buffer(int? maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }


        public int TotalItemsAddedCount { get; private set; }

        public void Add(T newElement)
        {
            if (Count == (MaxCapacity ?? -1))
                Dequeue();
            Enqueue(newElement);

            TotalItemsAddedCount++;
        }
    }

    public static class BufferExtensions
    {
        public static Point AddNewRandomPoint(this Buffer<Point> buffer)
        {
            DateTime now = DateTime.Now.AddMonths(buffer.TotalItemsAddedCount);
            int year = now.Year;
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(now.Month);
            Point point = new Point($"{monthName} ({year})", RandomNumberGenerator.GetInt32(1, 11));
            buffer.Add(point);
            return point;
        }
    }
}
