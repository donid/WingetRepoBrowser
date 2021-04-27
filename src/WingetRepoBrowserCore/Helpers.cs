using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using YamlDotNet.Serialization;


namespace WingetRepoBrowserCore
{
	public class Helpers
	{
		public static void SaveWingetIdSettings(string idFilePath, WingetIdSettings wingetidSettings)
		{
			string json = JsonSerializer.Serialize(wingetidSettings, new JsonSerializerOptions() { WriteIndented = true });
			File.WriteAllText(idFilePath, json);
		}

		public static WingetIdSettings LoadWingetIdSettings(string idFilePath)
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
				WingetIdSettings settings = LoadWingetIdSettings(idFilePath);
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

		public static ManifestPackage_1_0_0 ReadYamlFile(string yamlFile)
		{
			// TODO: Firetrust.MailWasherPro -> copyright sign works with Encoding.Default, but other packages have wrong signs then 
			using (StreamReader streamReader = new StreamReader(yamlFile, true))
			{
				var deserializer = new DeserializerBuilder()
					.IgnoreUnmatchedProperties() // comment this out, to check if there are new properties used in yaml, which are not yet in the data-model
					.Build();

				ManifestPackage_1_0_0 package = deserializer.Deserialize<ManifestPackage_1_0_0>(streamReader);
				return package;
			}
		}

		public static void WriteYamlFile(string yamlFile, ManifestPackage_1_0_0 package)
		{
			using (StreamWriter streamWriter = File.CreateText(yamlFile))
			{
				var serializer = new SerializerBuilder().Build();

				serializer.Serialize(streamWriter, package);
			}
		}


		public static string CalculateSha256HashFromFile(string downloadFilePath)
		{
			using (SHA256 mySHA256 = SHA256.Create())
			{
				try
				{
					FileStream fileStream = File.Open(downloadFilePath, FileMode.Open);
					byte[] hashValue = mySHA256.ComputeHash(fileStream);
					fileStream.Close();//todo dispose
					return ToHex(hashValue);
				}
				catch (IOException e)
				{
					Console.WriteLine($"I/O Exception: {e.Message}");
				}
				catch (UnauthorizedAccessException e)
				{
					Console.WriteLine($"Access Exception: {e.Message}");
				}
			}
			return null;//todo
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

		public static string GetInstallerPackageFilePath(string filePath)
		{
			return Path.ChangeExtension(filePath, ".installer.yaml"); ;
		}
	}
}
