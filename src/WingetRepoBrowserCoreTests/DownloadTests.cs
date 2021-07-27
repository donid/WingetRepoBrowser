using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WingetRepoBrowserCoreTests
{
	[TestClass]

	public class DownloadTests
	{
		[TestMethod]

		public void TestWebRequest()
		{
			// https://stackoverflow.com/questions/68529103/why-does-webrequest-fail-with-404/68529810?noredirect=1#comment121112114_68529810

			//string url = "https://dl.pstmn.io/download/version/8.9.0/win64"; // works
			//string url = "https://dl.pstmn.io/download/version/8.9.0/win32"; //404 here, but works in FF or Chrome
			string url = "https://download.filezilla-project.org/client/FileZilla_3.55.0_win32-setup.exe"; // 403
																										   //string url = "https://sourceforge.net/projects/smplayer/files/SMPlayer/21.1.0/smplayer-21.1.0-win32.exe/download";// do not use UserAgent when trying to get filename
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "HEAD";
			req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;// for postman!! avoid 404
			req.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0";
			WebResponse response = req.GetResponse();
		}
	}
}
