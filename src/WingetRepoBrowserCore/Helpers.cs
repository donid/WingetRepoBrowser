using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


namespace WingetRepoBrowserCore;

public class Helpers
{
	public static void SaveWingetIdSettings(string idFilePath, WingetIdSettings wingetidSettings)
	{
		string json = JsonSerializer.Serialize(wingetidSettings, new JsonSerializerOptions() { WriteIndented = true });
		File.WriteAllText(idFilePath, json);
	}

	public static WingetIdSettings? LoadWingetIdSettings(string idFilePath)
	{
		string json = File.ReadAllText(idFilePath);
		if (string.IsNullOrWhiteSpace(json))
		{
			return null;
		}
		return JsonSerializer.Deserialize<WingetIdSettings>(json);
	}

	public static string[] GetVersionsToIgnoreDownload(string idFilePath)
	{
		string[] result = new string[] { };
		try
		{
			WingetIdSettings? settings = LoadWingetIdSettings(idFilePath);
			if (settings?.VersionsToIgnoreDownload != null)
			{
				result = settings.VersionsToIgnoreDownload;
			}
		}
		catch (JsonException ex)
		{
			Trace.WriteLine("Error during deserialization of '" + idFilePath + "': " + ex.Message);
		}
		return result;
	}

	//TODO: Retry if this occurs:
	// happens regularly on a network share (due to malware scanner?)
	// Error: Calculating Sha256-Hash: I/O Exception: The process cannot access the file '...\Firefox\89.0.1\x86_en-US\Firefox Setup 89.0.1.msi' because it is being used by another process.
	public static CalculateFileHashResult CalculateSha256HashFromFile(string downloadFilePath)
	{
		using (SHA256 mySHA256 = SHA256.Create())
		{
			try
			{
				using (FileStream fileStream = File.Open(downloadFilePath, FileMode.Open))
				{
					byte[] hashValue = mySHA256.ComputeHash(fileStream);
					string hash = ToHex(hashValue);
					return new CalculateFileHashResult() { Hash = hash };
				}
			}
			catch (IOException e)
			{
				return new CalculateFileHashResult() { ErrorMessage = $"I/O Exception: {e.Message}" };
			}
			catch (UnauthorizedAccessException e)
			{
				return new CalculateFileHashResult() { ErrorMessage = $"Access Exception: {e.Message}" };
			}
		}
	}

	public class CalculateFileHashResult
	{
		public string Hash { get; set; }    // TODO: use 'init' instead of 'set' when switching to c#9
		public string ErrorMessage { get; set; }
	}

	public static string ToHex(Byte[] bytes)
	{
		if (bytes == null)
		{
			throw new ArgumentException("bytes is null.", "bytes");
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Byte item in bytes)
		{
			stringBuilder.Append(item.ToString("x2"));
		}
		return stringBuilder.ToString();
	}


}
