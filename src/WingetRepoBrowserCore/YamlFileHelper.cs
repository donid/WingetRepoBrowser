using System.Collections.Generic;
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


		public IEnumerable<MultiFileYaml> LoadAllManifests(IEnumerable<string> yamlFiles, out List<string> messages)
		{
			Dictionary<string, MultiFileYaml> multiFileYamlDict = new Dictionary<string, MultiFileYaml>();
			messages = new List<string>();
			foreach (string yamlFilePath in yamlFiles)
			{
				ReadYamlFileResult ryfr = ReadYamlFile(yamlFilePath);
				if (ryfr.ErrorMessage != null)
				{
					messages.Add(yamlFilePath + ": " + ryfr.ErrorMessage);
					continue;
				}
				ManifestPackage_1_0_0 package = ryfr.Manifest;

				string yamlFolder = Path.GetDirectoryName(yamlFilePath);
				MultiFileYaml multiFileYaml = null;
				if (multiFileYamlDict.TryGetValue(yamlFolder, out multiFileYaml) == false)
				{
					multiFileYaml = new MultiFileYaml();
					multiFileYamlDict.Add(yamlFolder, multiFileYaml);
				}
				multiFileYaml.AddPackage(package, yamlFilePath);
			}
			return multiFileYamlDict.Values;
		}


	}
}
