﻿using System;
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
		const string cUserAgent = "Mozilla/4.0 (Windows NT 10.0; Win64; x64)";

		WebClient _webClient;
		public InstallerDownloader()
		{
			_webClient = new WebClient();
			//without this: "https://fossies.org/windows/misc/audacity-win-2.4.1.exe" throws WebException 403 forbidden
			_webClient.Headers.Add("user-agent", cUserAgent);

		}

		public string GetFileNameFromUrl(string url, out Uri responseUri)
		{
			responseUri = null;
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "HEAD";
			//without this: "https://fossies.org/windows/misc/audacity-win-2.4.1.exe" -> WebException 403 forbidden
			//req.Headers.Add("user-agent" -> System.ArgumentException: 'The 'user-agent' header must be modified using the appropriate property or method. Parameter name: name'

			// https://github.com/HandBrake/HandBrake/releases/download/1.3.2/HandBrake-1.3.2-x86_64-Win_GUI.exe
			// this and other github release URIs throws 403 even with useragent, but webclient.downloadfileworks

			if (req.Host.ToLower() != "sourceforge.net")//HACK!! sourceforge does not remove 'download' at the end of ResponseUri when we provide UserAgent
			{
				req.UserAgent = cUserAgent;
			}

			WebResponse resp = null;
			try
			{
				resp = req.GetResponse();
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
			using (resp)
			{
				responseUri = resp.ResponseUri;
				// Try to extract the filename from the Content-Disposition header
				string contDisp = resp.Headers["Content-Disposition"];
				if (!string.IsNullOrEmpty(contDisp))
				{
					ContentDisposition parsedContDisp = new ContentDisposition(contDisp);
					if (parsedContDisp.FileName != null)//null: https://dl.google.com/edgedl/chrome/install/GoogleChromeStandaloneEnterprise64.msi
					{
						return parsedContDisp.FileName;
					}
				}

				string location = resp.Headers["Location"];
				if (location != null)
				{
					return Path.GetFileName(location);
				}

				//string fileNameFromUrl = Path.GetFileName(url);
				//if (fileNameFromUrl.Contains('?') || fileNameFromUrl.Contains('=') )
				//{
				//	return Path.GetFileName(resp.ResponseUri.ToString());
				//}

				string potentialFilename = Path.GetFileName(resp.ResponseUri.ToString());
				int foundIndex = potentialFilename.IndexOfAny(new[] { '?' });
				if (foundIndex == -1)
				{
					return potentialFilename;
				}
				return potentialFilename.Substring(0, foundIndex);
			}

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
}
