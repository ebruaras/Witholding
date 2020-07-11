using Stopaj_Business.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Stopaj_Business.Enum;
using Stopaj_Data.Entity;
using Stopaj_Data.Context;

namespace Stopaj_Business
{
  public class LoggingService:ILoggingService
    {
        public LoggingService(IConfiguration config)
        {
            _config = config;
        }
        public IConfiguration _config { get; set; }
        public void Log(string logDesc, Stopaj_Business.Enum.LogType logTypeId, int userId)
        {
            Log log = new Log()
            {
                UserId = userId,
                CreatedDate = DateTime.Now,
                Description = logDesc,
                CreatedBy = userId,
                LogTypeId = Convert.ToInt32(logTypeId)

            };
            using (EntityContext entityContext = new EntityContext(_config))
            {
                entityContext.Logs.Add(log);
                entityContext.SaveChanges();
            }
        }
    }
}
