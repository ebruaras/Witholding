using System;
using System.Collections.Generic;
using System.Text;
using Stopaj_Business.Enum;

namespace Stopaj_Business.Interface
{
    public interface ILoggingService
    {
        void Log(string logDesc, LogType logTypeId, int userId);
    }
}
