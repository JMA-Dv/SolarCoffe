using System;

namespace SolarCoffe.Data.Responses
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public T Data { get; set; }
    }
}
