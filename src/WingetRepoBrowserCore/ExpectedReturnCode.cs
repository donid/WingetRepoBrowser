using System;
using System.Diagnostics;

namespace WingetRepoBrowserCore
{
	[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
	public class ExpectedReturnCode
	{
		public long InstallerReturnCode { get; set; }
		public string ReturnResponse { get; set; }

		public override string ToString()
		{
			return $"{InstallerReturnCode} {ReturnResponse}";
		}

		private string GetDebuggerDisplay()
		{
			return $"{InstallerReturnCode} {ReturnResponse}";
		}
	}
}
