using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;

namespace cm
{
    public enum MessageType
    {
        Error,
        Warning,
        Info
    }
    [SuppressMessage("ReSharper", "LocalizableElement")]
    public sealed class Log
    {
        private static Log _instance;

        private int _extraIndex;

        private readonly Dictionary<int, Action<string>> _extra = new Dictionary<int, Action<string>>();

        private static readonly object Lock = new object();

        private static Log Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                            _instance = new Log();
                    }
                }
                return _instance;
            }
        }

        private Log()
        {
            _path = Path.ChangeExtension(Application.ExecutablePath, $".{DateTime.Now:yyyyMMddHHmmss}.log");
        }

        private readonly string _path;

        public static string Filename => Instance._path;

        private readonly Dictionary<MessageType, string> _typeMap = new Dictionary<MessageType, string>
        {
            {MessageType.Error, "[E]" },
            {MessageType.Warning, "[W]" },
            {MessageType.Info, "[I]" }
        };

        [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
        public static void Write(MessageType msgType, string message)
        {
            Instance.ExtraLog(message);
            InnerWrite(msgType, message);
        }

        private static void InnerWrite(MessageType msgType, string message)
        {
            try
            {
                File.AppendAllText(Instance._path, $"{DateTime.Now:yyyyMMdd HH:mm:ss.fff} {Instance._typeMap[msgType]} {message}\n");
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void ExtraLog(string message)
        {
            List<int> errorKeys = null;
            foreach (var action in _extra)
            {
                try
                {
                    action.Value.Invoke(message);
                }
                catch (Exception e)
                {
                    if (errorKeys == null)
                        errorKeys = new List<int> {action.Key};
                    else
                        errorKeys.Add(action.Key);

                    InnerWrite(MessageType.Error, string.Concat(
                        "Ошибка внешнего логирования в ",
                        action.Value?.Method.Name ?? "пустой делегат",
                        ": ",
                        e.Message));
                }
            }

            errorKeys?.ForEach(k => _extra.Remove(k));
        }

        public static void Info(string message)
        {
            Write(MessageType.Info, message);
        }

        public static void Warning(string message, Exception e = null)
        {
            Write(MessageType.Warning, $"{message}\n{e}");
        }

        public static void Error(string message, Exception e = null)
        {
            Write(MessageType.Error, $"{message}\n{e}");
        }

        public static int AddExtraLogger(Action<string> logger)
        {
            Instance._extra[++Instance._extraIndex] = logger;
            return Instance._extraIndex;
        }

        public static void RemoveExtraLogger(int key)
        {
            Instance._extra.Remove(key);
        }
    }
}
