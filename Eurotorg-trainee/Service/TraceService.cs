using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Eurotorg_trainee.Service
{
    internal static class TraceService
    {
        public static void Message(string msg, [CallerMemberName] string member = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        {
            var message = $"eurotorg: {msg} [{member}] {Path.GetFileName(path)}({line})";
            Trace.WriteLine(message);
        }
    }
}