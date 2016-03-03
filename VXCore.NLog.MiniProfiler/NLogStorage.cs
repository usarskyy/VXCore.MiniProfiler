using System;
using System.Collections.Generic;

using NLog;

using StackExchange.Profiling;
using StackExchange.Profiling.Storage;


namespace VXCore.NLog.MiniProfiler
{
  /// <summary>
  /// Enables <see cref="T:StackExchange.Profiling.MiniProfiler"/> to write its logs into NLog event log
  /// </summary>
  public class NLogStorage : IStorage
  {
    private readonly Logger _logger;
    private readonly LogLevel _logAsLevel;

    public NLogStorage()
      : this(LogManager.GetCurrentClassLogger(), LogLevel.Debug)
    {
    }

    public NLogStorage(Logger logger)
      : this(logger, LogLevel.Debug)
    {
    }

    public NLogStorage(Logger logger, LogLevel logAsLevel)
    {
      if (logger == null)
      {
        throw new ArgumentNullException("logger");
      }

      if (logAsLevel == null)
      {
        throw new ArgumentNullException("logAsLevel");
      }

      _logger = logger;
      _logAsLevel = logAsLevel;
    }


    public static void SetAsStorage(Logger logger = null, LogLevel logAsLevel = null)
    {
      StackExchange.Profiling.MiniProfiler.Settings.Storage =
        new NLogStorage(logger ?? LogManager.GetCurrentClassLogger(),
          logAsLevel ?? LogLevel.Debug);
    }

    public IEnumerable<Guid> List(int maxResults, DateTime? start = null, DateTime? finish = null, ListResultsOrder orderBy = ListResultsOrder.Descending)
    {
      throw new NotSupportedException();
    }

    public void Save(StackExchange.Profiling.MiniProfiler profiler)
    {
      if (_logAsLevel == LogLevel.Debug)
      {
        _logger.Debug(profiler.RenderPlainText());
      }
      else if (_logAsLevel == LogLevel.Trace)
      {
        _logger.Trace(profiler.RenderPlainText());
      }
      else if (_logAsLevel == LogLevel.Info)
      {
        _logger.Info(profiler.RenderPlainText());
      }
      else if (_logAsLevel == LogLevel.Warn)
      {
        _logger.Warn(profiler.RenderPlainText());
      }
      else if (_logAsLevel == LogLevel.Error)
      {
        _logger.Error(profiler.RenderPlainText());
      }
      else if (_logAsLevel == LogLevel.Fatal)
      {
        _logger.Fatal(profiler.RenderPlainText());
      }
    }

    public StackExchange.Profiling.MiniProfiler Load(Guid id)
    {
      throw new NotSupportedException();
    }

    public void SetUnviewed(string user, Guid id)
    {
    }

    public void SetViewed(string user, Guid id)
    {
    }

    public List<Guid> GetUnviewedIds(string user)
    {
      throw new NotSupportedException();
    }
  }
}
