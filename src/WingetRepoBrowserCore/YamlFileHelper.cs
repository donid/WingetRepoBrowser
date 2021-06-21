using System.Collections.Generic;
using System.IO;

using YamlDotNet.Core;
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
					return new ReadYamlFileResult() { Manifest = package, FilePath = yamlFile };
				}
				catch (YamlException ex)
				{
					return new ReadYamlFileResult() { ErrorMessage = GetMessage(ex), FilePath = yamlFile };
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


		private /*static*/ string GetMessage(YamlException ex)
		{
			string inner = null;
			if (ex.InnerException != null)
			{
				inner = " (" + ex.InnerException.Message + ")";
			}
			return ex.Message + inner;
		}


		public MultiFileYaml LoadMultiFileYaml(string mainYamlFilePath)
		{
			var ryr = ReadYamlFile(mainYamlFilePath);
			if (ryr.ErrorMessage != null)
			{
				return null;//todo
			}
			MultiFileYaml result = new MultiFileYaml();
			result.AddPackage(ryr.Manifest, mainYamlFilePath);
			if (result.MainPackage.ManifestType == "version")
			{
				string packageIdentifier = result.MainPackage.PackageIdentifier;
				string folder = Path.GetDirectoryName(mainYamlFilePath);
				string installerFilePath = $"{packageIdentifier}.installer.yaml";
				var ryri = ReadYamlFile(Path.Combine(folder, installerFilePath));
				if (ryri.ErrorMessage != null)
				{
					return null;//todo
				}
				result.AddPackage(ryri.Manifest, installerFilePath);
				string[] yamlFilePaths = Directory.GetFiles(folder, $"{packageIdentifier}.locale.*.yaml", SearchOption.TopDirectoryOnly);
				foreach (string yamlFilePath in yamlFilePaths)
				{
					ReadYamlFileResult localeManifestResult = ReadYamlFile(Path.Combine(folder, yamlFilePath));
					if (localeManifestResult.ErrorMessage != null)
					{
						return null;//todo
					}

					result.AddPackage(localeManifestResult.Manifest, yamlFilePath);
				}
			}
			return result;
		}

		public LoadManifestsResult LoadAllManifests(IEnumerable<string> yamlFiles)
		{
			LoadManifestsResult result = new LoadManifestsResult();
			Dictionary<string, MultiFileYaml> multiFileYamlDict = new Dictionary<string, MultiFileYaml>();
			foreach (string yamlFilePath in yamlFiles)
			{
				ReadYamlFileResult ryfr = ReadYamlFile(yamlFilePath);
				if (ryfr.ErrorMessage != null)
				{
					result.Messages.Add(yamlFilePath + ": " + ryfr.ErrorMessage);
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
			result.Manifests = multiFileYamlDict.Values;
			return result;
		}

		public static string GetLocaleYamlFilePath(string yamlFilePath, string locale)
		{
			return Path.ChangeExtension(yamlFilePath, ".locale." + locale + ".yaml");
		}
		public static string GetInstallerPackageFilePath(string filePath)
		{
			return Path.ChangeExtension(filePath, ".installer.yaml");
		}

		public void SaveMultiFileYaml(MultiFileYaml mfy, string versionFolder)
		{
			string yamlTargetFilename = Path.GetFileName(mfy.MainYamlFilePath);
			string yamlTargetFilePath = Path.Combine(versionFolder, yamlTargetFilename);

			string packageIdentifier = mfy.MainPackage.PackageIdentifier;
			WriteYamlFile(Path.Combine(versionFolder, $"{packageIdentifier}.yaml"), mfy.MainPackage);
			if (mfy.MainPackage.ManifestType == "singleton")
			{
				return;
			}
			WriteYamlFile(Path.Combine(versionFolder, $"{packageIdentifier}.installer.yaml"), mfy.InstallerPackage);
			WriteYamlFile(Path.Combine(versionFolder, $"{packageIdentifier}.locale.{mfy.DefaultLocalePackage.PackageLocale}.yaml"), mfy.DefaultLocalePackage);
			foreach (ManifestPackage_1_0_0 localePackage in mfy.LocalePackages)
			{
				WriteYamlFile(Path.Combine(versionFolder, $"{packageIdentifier}.locale.{localePackage.PackageLocale}.yaml"), localePackage);				
			}
		}
	}

	public class LoadManifestsResult
	{
		public IEnumerable<MultiFileYaml> Manifests { get; set; }
		public List<string> Messages { get; } = new List<string>();

	}
}
