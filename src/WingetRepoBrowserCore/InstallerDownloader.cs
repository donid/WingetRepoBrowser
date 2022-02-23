using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;

namespace WingetRepoBrowserCore
{
	public class InstallerDownloader : IDisposable
	{
		// newer, but very specific: "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0";
		// or "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"
		//const string cUserAgent = "Mozilla/4.0 (Windows NT 10.0; Win64; x64)";
		//public const string cUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0";
		public const string cUserAgent = "winget/1.0";

		WebClient _webClient;
		public InstallerDownloader()
		{
			_webClient = new MyWebClient();
			//without this: "https://fossies.org/windows/misc/audacity-win-2.4.1.exe" throws WebException 403 forbidden
			_webClient.Headers.Add("user-agent", cUserAgent);
		}

		public string GetFileNameFromUrl(string url, out Uri responseUri)
		{
			responseUri = null;
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "HEAD";    //without this: "https://fossies.org/windows/misc/audacity-win-2.4.1.exe" -> WebException 403 forbidden
			req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;  // avoid 404 for "https://dl.pstmn.io/download/version/8.9.0/win32"

			// https://github.com/HandBrake/HandBrake/releases/download/1.3.2/HandBrake-1.3.2-x86_64-Win_GUI.exe
			// this and other github release URIs throws 403 even with useragent, but webclient.downloadfile works

			if (!string.Equals(req.Host, "sourceforge.net", StringComparison.OrdinalIgnoreCase))//HACK!! sourceforge does not remove 'download' at the end of ResponseUri when we provide UserAgent
			{
				req.UserAgent = cUserAgent;
			}

			WebResponse response;
			try
			{
				response = req.GetResponse();
			}
			catch (WebException /*ex*/)
			{
				string fileNameFromUrl = Path.GetFileName(url);
				if (fileNameFromUrl.Contains('?') || fileNameFromUrl.Contains('='))
				{
					return "unknown.bin";//TODO
				}
				return fileNameFromUrl;
			}

			using (response)
			{
				responseUri = response.ResponseUri;
				// Try to extract the filename from the Content-Disposition header
				string contDisp = response.Headers["Content-Disposition"];
				string filenameFromCd = GetFilenameFromContentDisposition(contDisp);
				if (filenameFromCd != null)
				{
					return filenameFromCd;
				}

				string location = response.Headers["Location"];
				if (location != null)
				{
					return Path.GetFileName(location);
				}

				string potentialFilename = Path.GetFileName(response.ResponseUri.ToString());
				int foundIndex = potentialFilename.IndexOfAny(new[] { '?' });
				if (foundIndex == -1)
				{
					return potentialFilename;
				}
				return potentialFilename.Substring(0, foundIndex);
			}

		}

		static string GetFilenameFromContentDisposition(string contDisp)
		{
			if (string.IsNullOrEmpty(contDisp))
			{
				return null;
			}

			// this url: "https://download.sqlitebrowser.org/DB.Browser.for.SQLite-3.11.2-win64.msi"
			// returns this contDisp: "attachment; filename=\"DB.Browser.for.SQLite-3.11.2-win64.msi\"; modification-date=\"2019-04-03T18:13:35Z\";"
			// for which ContentDisposition ctor throws this exception: System.FormatException: 'An invalid character was found in the mail header: '{0}'.'
			// this does not work either: ContentDispositionHeaderValue.Parse(cd)
			ContentDisposition parsedContDisp = null;
			try
			{
				parsedContDisp = new ContentDisposition(contDisp);
			}
			catch (FormatException)
			{
				return GetFilenameFromContentDispositionWorkaround(contDisp);
			}

			//null: https://dl.google.com/edgedl/chrome/install/GoogleChromeStandaloneEnterprise64.msi
			if (parsedContDisp.FileName == null)
			{
				return null;
			}
			return parsedContDisp.FileName;
		}

		static string GetFilenameFromContentDispositionWorkaround(string contDisp)
		{
			string[] parts = contDisp.Split(';');
			string filenamePart = parts.Select(i => i.Trim()).FirstOrDefault(i => i.StartsWith("filename=", StringComparison.InvariantCultureIgnoreCase));
			if (filenamePart == null)
			{
				return null;
			}
			string filename = filenamePart.Substring("filename=".Length);
			return RemoveQuotes(filename);
		}

		static string RemoveQuotes(/*this*/ string text)
		{
			if (text == null)
			{
				return null;
			}
			string result = text;
			if (result.StartsWith("\""))
			{
				result = result.Substring(1);
			}
			if (result.EndsWith("\""))
			{
				result = result.Substring(0, result.Length - 1);
			}
			return result;
		}

		public void DownloadFile(string downloadUrl, string downloadFilePath)
		{
			_webClient.DownloadFile(downloadUrl, downloadFilePath);
		}
		public void Dispose()
		{
			((IDisposable)_webClient).Dispose();
		}
	}

	class MyWebClient : WebClient
	{
		protected override WebRequest GetWebRequest(Uri address)
		{
			HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
			request.UserAgent = InstallerDownloader.cUserAgent; // avoid 403 for some URLs - see InstallerDownloader
			request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip; // avoid 404 for "https://dl.pstmn.io/download/version/8.9.0/win32"
			return request;
		}
	}

}
