﻿using System;

namespace Codelux.NetCore.Utilities
{
    public class ClockService : IClockService
    {
        public DateTime Now(bool useLocal = false)
        {
            if (useLocal) return DateTime.Now;
            return DateTime.UtcNow;
        }
    }
}
