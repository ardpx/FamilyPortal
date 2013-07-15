using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPortal.Utilites
{
    public class Logger
    {
        public static void Initialize(string app, string loglevel)
        {
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);

            t.AutoReset = true;
            t.Enabled = true;
            LogApplicationName = app;
            if (loglevel != null)
                m_LogLevel = int.Parse(loglevel);
            m_initialized = true;
        }

        public static System.Timers.Timer t = new System.Timers.Timer(300000);
        public static List<string> MessageList = new List<string>();
        private static EventLog m_eventlog;
        private static object m_lock = new object();
        public static string LogApplicationName;
        private static int m_LogLevel = 10;
        private static bool m_initialized = false;

        public static bool Initialized() { return m_initialized; }

        public static LogLevel TraceLogLevel
        {
            get
            {
#if DEBUG
                return LogLevel.Informational;
#else
                return LogLevel.None;
#endif
            }
        }

        public static Boolean VerboseTrace
        {
            get
            {
                return false;
            }
        }

        public static LogLevel EventLogLevel
        {
            get
            {
                string value = m_LogLevel.ToString();
                return (LogLevel)(Int32.Parse(value));
            }
        }

        public static void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            MessageList.Clear();
        }

       
        public static void LogMessage(LogLevel messageLogLevel, String message, String functionName = "", EventLogEntryType EntryType = EventLogEntryType.Error)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(functionName))
            {
                StackTrace stackTrace = new StackTrace();
                functionName = stackTrace.GetFrame(1).GetMethod().Name;
            }
            if (functionName != null && functionName.Length > 0)
                sb.AppendLine(String.Format("Function: {0}", functionName));
            sb.AppendLine(String.Format("Message: {0}", message));
            // Log event
            WriteLogEntry(messageLogLevel, sb.ToString(), functionName, EntryType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageLogLevel"></param>
        /// <returns></returns>
        public static Boolean CheckLogLevel(LogLevel messageLogLevel)
        {
            LogLevel traceLevel = TraceLogLevel;
            LogLevel eventLevel = EventLogLevel;
            if ((traceLevel == LogLevel.None || messageLogLevel > traceLevel) && (eventLevel == LogLevel.None || messageLogLevel > eventLevel))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void TraceMessage(LogLevel messageLogLevel, string tracer, String message)
        {
            if (!CheckLogLevel(messageLogLevel))
                return;

            if (tracer == string.Empty)
                tracer = "Default";

            if (messageLogLevel == LogLevel.Critical)
                Trace.TraceError(message);
            else
                Trace.WriteLine(message);
        }

        public static void WriteLogEntry(LogLevel messageLogLevel, String finalMessage, String function, EventLogEntryType LogType)
        {
            if (messageLogLevel <= EventLogLevel)
            {
                try
                {
                    int i = finalMessage.IndexOf('|');
                    string s = finalMessage.Substring(i + 2);
                    lock (m_lock)
                    {
                        foreach (string message in MessageList)
                        {
                            if (s.Equals(message))
                            {
                                return;
                            }
                        }

                        EventLog el = GetEventLog();
                        el.WriteEntry(finalMessage, LogType);
                        MessageList.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    String msg = ex.Message;
                    // TODO: Alternative tracing method
                }
            }

            if (messageLogLevel <= TraceLogLevel)
            {

                if (VerboseTrace)
                    TraceMessage(messageLogLevel, "TestTractor", finalMessage);
                else
                    TraceMessage(messageLogLevel, "TestTractor", function);
            }
        }

        protected static EventLog GetEventLog()
        {
            if (!EventLog.SourceExists(LogApplicationName))
            {
                EventLog.CreateEventSource(LogApplicationName, "Application");
            }
            lock (m_lock)
            {
                if (m_eventlog == null)
                {
                    m_eventlog = new EventLog();
                    m_eventlog.Source = LogApplicationName;
                }
            }
            return m_eventlog;
        }

        public static void LogException(Exception ex, EventLogEntryType EntryType = EventLogEntryType.Error, string AdditionalHeaderMessage = null)
        {
            if (!CheckLogLevel(LogLevel.Critical))
                return;

            StringBuilder sb = new StringBuilder(); // just log timestamp as head
            DateTime timeStamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);

            sb.AppendLine(String.Format("{0}", timeStamp));

            string errorMessage = string.Empty;
            StringBuilder err = new StringBuilder();
            if (AdditionalHeaderMessage != null)
                err.AppendLine(AdditionalHeaderMessage);

            for (Exception exCurrent = ex; exCurrent != null; exCurrent = exCurrent.InnerException)
            {
                err.AppendLine(String.Format("Message: {0}", exCurrent.Message));
                err.AppendLine(String.Format("Stack trace: {0}", exCurrent.StackTrace));
            }
            errorMessage = err.ToString();

            WriteLogEntry(LogLevel.Critical, sb.ToString() + errorMessage, errorMessage, EntryType);
        }
    }

    [Serializable]
    public enum LogLevel
    {
        None = 0,
        Critical = 1,
        Important = 5,
        Informational = 10,
        Debug = 100
    }
}
