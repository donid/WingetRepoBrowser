using System;

namespace WingetRepoBrowser
{
    public class CommitInfo
    {
        public string Sha { get; set; } = "";
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; } = "";
    }
}
