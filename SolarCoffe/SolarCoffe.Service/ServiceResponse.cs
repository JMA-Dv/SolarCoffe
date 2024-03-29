﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Service
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public T Data { get; set; }
    }
}
