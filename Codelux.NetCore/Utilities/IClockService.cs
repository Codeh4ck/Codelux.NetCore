using System;

namespace Codelux.NetCore.Utilities
{
    public interface IClockService
    {
        DateTime Now(bool useLocal = false);
    }
}
