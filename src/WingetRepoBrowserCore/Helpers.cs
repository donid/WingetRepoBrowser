using System;
using System.IO;
using System.Linq;
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
	}
}
