using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using WingetRepoBrowserCore;
using YamlDotNet.Serialization;


namespace WingetRepoBrowserCore
{
	public class Helpers
	{

		public static ManifestPackage ReadYamlFile(string yamlFile)
		{
			// TODO: Firetrust.MailWasherPro -> copyright sign works with Encoding.Default, but other packages have wrong signs then 
			using (StreamReader streamReader = new StreamReader(yamlFile, true))
			{
				var deserializer = new DeserializerBuilder()
					.IgnoreUnmatchedProperties() // comment this out, to check if there are new properties used in yaml, which are not yet in the data-model
					.Build();

				ManifestPackage package = deserializer.Deserialize<ManifestPackage>(streamReader);
				return package;
			}
		}

		public static void WriteYamlFile(string yamlFile, ManifestPackage package)
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

	}
}
