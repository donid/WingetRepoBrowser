using System;
using System.IO;
using System.Linq;
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
			//todo: dispose?
			var input = new StreamReader(yamlFile, true);// TODO: Firetrust.MailWasherPro -> copyright sign works with Encoding.Default, but other packages have wrong signs then then 

			var deserializer = new DeserializerBuilder()
				// .WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();

			ManifestPackage package = deserializer.Deserialize<ManifestPackage>(input);
			return package;
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
