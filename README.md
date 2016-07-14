MiniProfiler extensions allows to save MiniProfiler results using NLog.

There are a few different ways to initialize NLogStorage.

Most simple one:

    NLogStorage.SetAsStorage();

This will use default NLog logger (VXCore.NLog.MiniProfiler.NLogStorage) and "Debug" level to save MiniProfiler results.

Then you can specify your own NLog logger:

    NLogStorage.SetAsStorage(logger: myLogger);

or logging level:

    NLogStorage.SetAsStorage(logAsLevel: LogLevel.Debug);

or both:

    NLogStorage.SetAsStorage(myLogger, LogLevel.Debug);

