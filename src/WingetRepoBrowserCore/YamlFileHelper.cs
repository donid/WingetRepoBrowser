using System.IO;

using YamlDotNet.Serialization;

namespace WingetRepoBrowserCore
{
	public class ReadYamlFileResult
	{
		public ManifestPackage_1_0_0 Manifest { get; set; }
		public string FilePath { get; set; }
		public string ErrorMessage { get; set; }
	}

	public class YamlFileHelper
	{

		IDeserializer _deserializer;
		ISerializer _serializer;

		public YamlFileHelper()
		{
			_deserializer = new DeserializerBuilder()
											.IgnoreUnmatchedProperties() // comment this out, to check if there are new properties used in yaml, which are not yet in the data-model
											.Build();
			_serializer = new SerializerBuilder().Build();
		}


		public ReadYamlFileResult ReadYamlFile(string yamlFile)
		{
			// TODO: Firetrust.MailWasherPro -> copyright sign works with Encoding.Default, but other packages have wrong signs then 
			using (StreamReader streamReader = new StreamReader(yamlFile, true))
			{
				try
				{
					ManifestPackage_1_0_0 package = _deserializer.Deserialize<ManifestPackage_1_0_0>(streamReader);
					return new ReadYamlFileResult() { Manifest=package, FilePath=yamlFile};
				}
				catch (YamlDotNet.Core.YamlException ex)
				{
					return new ReadYamlFileResult() {ErrorMessage=GetMessage(ex), FilePath=yamlFile};
				}
			}
		}

		public void WriteYamlFile(string yamlFile, ManifestPackage_1_0_0 package)
		{
			using (StreamWriter streamWriter = File.CreateText(yamlFile))
			{
				_serializer.Serialize(streamWriter, package);
			}
		}


		private /*static*/ string GetMessage(YamlDotNet.Core.YamlException ex)
		{
			string inner = null;
			if (ex.InnerException != null)
			{
				inner = " (" + ex.InnerException.Message + ")";
			}
			return ex.Message + inner;
		}



	}
}
